# [How to add new Microservices to the Solution](https://docs.abp.io/en/commercial/latest/startup-templates/microservice/add-microservice)

```bash
pwsh
```

```ps1
cd "$(echo (git rev-parse --show-toplevel))"
.\create-new-microservice.ps1
```

Each project type has different port. Start your web application from one the following addresses:

- **Blazor Server**: [https://localhost:44214](https://localhost:44214/)
- **Blazor Web Assembly**: [https://localhost:44207](https://localhost:44207/)
- **MVC**: [https://localhost:44221](https://localhost:44221/)
- **Angular**: [http://localhost:4200](http://localhost:4200/)
- **Ad**: [http://localhost:4200](http://localhost:4200/)
- **Angular**: [http://localhost:4200](http://localhost:4200/)
- **AuthServer**: [http://localhost:44322](http://localhost:44322/)
- **AdministrationService**: [http://localhost:44367](http://localhost:44367/)
- **IdentityService**: [http://localhost:44388](http://localhost:44388/)
- **SaasService**: [http://localhost:44381](http://localhost:44381/)
- **ProductService**: [http://localhost:44361](http://localhost:44361/)

there for change the port numbers

- for PublicWebGateway , `44353` to `44300`
- for PublicWeb , `44335` to `44301`
- for WebGateway , `44325` to `44310`
- for AuthServer , `44322` to `44311`
- for AdministrationService , `44367` to `44312`
- for IdentityService , `44388` to `44313`
- for SaasService , `44381` to `44314`
- also change newily created microservice port number to `443xx`

This script `create-new-microservice.ps1` will create run `abp new <<ServiceName>> -t microservice-service-pro` and assign the following refrencing

- add `<<ServiceName>>.Application.Contracts.csproj` reference to `.....DbMigrator.csproj`
- add `<<ServiceName>>.EntityFrameworkCore.csproj` reference to `.....DbMigrator.csproj`

Since we have the docker configuration of sql server, we need to manually change the connection string

- replace `,1434;Database=SchoolAut0mater_(.*);User Id=sa;password=myPassw0rd` to `,5434;User Id=sa;password=P@ssw0rd00;Database=SchoolAut0mater_$1` on all items in solutions using 'Regex Expression' (`.*`)
- replace `SchoolAut0mater_CoreService` to `SchoolAut0mater_Core` in all appsettings.json
- add `"CoreService": "Server=localhost,5434;User Id=sa;password=P@ssw0rd00;Database=SchoolAut0mater_Core;MultipleActiveResultSets=true;TrustServerCertificate=True"` to `\shared\SchoolAut0mater.DbMigrator\appsettings.json`

### In `shared\SchoolAut0mater.Shared.Hosting\SchoolAut0materSharedHostingModule.cs`

```cs
            options.Databases.Configure("CoreService", database =>
            {
                database.MappedConnections.Add("CoreService");
            });
   
            options.Databases.Configure("ProductService", database =>
            {
                database.MappedConnections.Add("ProductService");
            });
```

### In `\services\identity\src\SchoolAut0mater.IdentityService.HttpApi.Host\DbMigrations\OpenIddictDataSeeder.cs` and in `\shared\SchoolAut0mater.DbMigrator\OpenIddictDataSeeder.cs`

- `await CreateScopesAsync("<<ServiceName>>");`

- ```csharp
  private async Task CreateWebGatewaySwaggerClientsAsync()
  {
      await CreateSwaggerClientAsync("WebGateway", new[] { 
        "AccountService", 
        "IdentityService", 
        "AdministrationService", 
        "SaasService", 
        "<<ServiceName>>", 
        "ProductService" 
      });
  }
  ```

- Add to CreateSwaggerClientAsync

```csharp
var <<ServiceName>>RootUrl = \_configuration[$"IdentityServer:Resources:<<ServiceName>>:RootUrl"].TrimEnd('/');
// ...
$"{<<ServiceName>>RootUrl}/swagger/oauth2-redirect.html", // <<ServiceName>> redirect uri

```

- under all snipped of `//Web`, `//Blazor Client`, `//Blazor Client`, `//Public Web Client`, `//Angular Client` modify as below

```cs
            scopes: commonScopes.Union(new[] {
                "AccountService", 
                # ...
                # ...
                "CoreService", <-- Add 
                "ProductService" 
            }).ToList(),
```

### In `\gateways\web\src\SchoolAut0mater.WebGateway\SchoolAut0materWebGatewayModule.cs`

```cs
  SwaggerConfigurationHelper.ConfigureWithAuth(
            context: context,
            authority: configuration["AuthServer:Authority"],
            scopes: new
                Dictionary<string, string> /* Requested scopes for authorization code request and descriptions for swagger UI only */ {
                    { "AccountService", "Account Service API" },
                    { "IdentityService", "Identity Service API" },
                    { "AdministrationService", "Administration Service API" },
                    { "SaasService", "Saas Service API" },
                    { "CoreService", "Core Service API" }, // <---
                    { "ProductService", "Product Service API" }
                },
            apiTitle: "Web Gateway API"
        );
```

### In `\apps\angular\src\environments\environment.ts`

```json
 "CoreService": { url: 'https://localhost:45015', rootNamespace: 'SchoolAut0mater', },
```  
  
### In `\shared\SchoolAut0mater.DbMigrator\appsettings.json` and `\services\identity\src\SchoolAut0mater.IdentityService.HttpApi.Host\appsettings.json` add OpenIddict\Resources url

```json
  "CoreService": { "RootUrl": "https://localhost:45015" },
```  

### in `\tye.yaml`

```yaml
- name: core-service
  project: services/core/src/SchoolAut0mater.CoreService.HttpApi.Host/SchoolAut0mater.CoreService.HttpApi.Host.csproj
  bindings:
    - protocol: https
      port: 45015
  env:
    - Kestrel__Certificates__Default__Path=../../../../etc/dev-cert/localhost.pfx
    - Kestrel__Certificates__Default__Password=e8202f07-66e5-4619-be07-72ba76fde97f
```

- add `,https://localhost:45015` to `\apps\auth-server\src\SchoolAut0mater.AuthServer\appsettings.json` 'App\CorsOrigins'

- add to `\etc\prometheus\prometheus.yml`

```yml
  - job_name: 'core-service'
    scheme: https
    tls_config:
      insecure_skip_verify: true
    static_configs:
    - targets: ['host.docker.internal:45015']
```

### In `\gateways\web\src\SchoolAut0mater.WebGateway\ocelot.json`

```json
    {
      "ServiceKey": "Core Service",
      "DownstreamPathTemplate": "/api/core-service/{everything}",
      "DownstreamScheme": "https",
      "DownstreamHostAndPorts": [
        {
          "Host": "localhost",
          "Port": 44873
        }
      ],
      "UpstreamPathTemplate": "/api/core-service/{everything}",
      "UpstreamHttpMethod": [ "Put", "Delete", "Get", "Post" ]
    },
```

***************************************
***************************************

- change the operating port `44324` info in the newly created launchSettings.json `./services/core/src/SchoolAut0mater.<<ServiceName>>.HttpApi.Host/Properties/launchSettings.json`

```json
{
  "iisSettings": {
    "windowsAuthentication": false,
    "anonymousAuthentication": true,
    "iisExpress": {
      "applicationUrl": "https://localhost:44324",
      "sslPort": 44324
    }
  },
  "profiles": {
    "IIS Express": {
      "commandName": "IISExpress",
      "launchBrowser": true,
      "environmentVariables": {
        "ASPNETCORE_ENVIRONMENT": "Development"
      }
    },
    "SchoolAut0mater.<<ServiceName>>.HttpApi.Host": {
      "commandName": "Project",
      "launchBrowser": true,
      "applicationUrl": "https://localhost:44324",
      "environmentVariables": {
        "ASPNETCORE_ENVIRONMENT": "Development"
      }
    }
  }
}
```

- Add `<<ServiceName>>` to all clients in CreateClientsAsync

- Add rootUrl to CorsOrigins in AuthServer appsettings
  `./SchoolAut0mater/apps/auth-server/src/SchoolAut0mater.AuthServer/appsettings.json` append `https://localhost:44324` to `App.CorsOrigins` in `appsettings.json`

- `./SchoolAut0mater/services/core/src/SchoolAut0mater.<<ServiceName>>.HttpApi.Host/appsettings.json` change

```json
"AuthServer": {
  "Authority": "https://localhost:44311",
  "RequireHttpsMetadata": "true",
  "SwaggerClientId": "WebGateway_Swagger",
  "SwaggerClientSecret": "1q2w3e*"
},
```

- replace `UseSwaggerUI` in `SchoolAut0mater/services/core/src/SchoolAut0mater.<<ServiceName>>.HttpApi.Host/<<ServiceName>>HttpApiHostModule.cs`

```csharp
//...
app.UseSwaggerUI(options =>
{
  options.SwaggerEndpoint("/swagger/v1/swagger.json", "Core Service API");
});
```

`to`

```csharp
app.UseSwaggerUI(options =>
{
  options.SwaggerEndpoint("/swagger/v1/swagger.json", "Core Service API");
  var configuration = context.ServiceProvider.GetRequiredService<Microsoft.Extensions.Configuration.IConfiguration>();
  options.OAuthClientId(configuration["AuthServer:SwaggerClientId"]);
  options.OAuthClientSecret(configuration["AuthServer:SwaggerClientSecret"]);
});
```

### In `\gateways\web\src\SchoolAut0mater.WebGateway\SchoolAut0mater.WebGateway.csproj`

- add `typeof(SchoolAut0mater.<<ServiceName>>.<<ServiceName>>HttpApiModule)` to `DependsOn`
- Add scope definition to SchoolAut0materWebGatewayModule `{ "<<ServiceName>>", "Core Service API" }`
- Add to `./gateways/web/src/SchoolAut0mater.WebGateway/ocelot.json`

  ```json
  {
    "ServiceKey": "Core Service",
    "DownstreamPathTemplate": "/api/<<ServiceName>>/{everything}",
    "DownstreamScheme": "https",
    "DownstreamHostAndPorts": [
      {
        "Host": "localhost",
        "Port": 44324
      }
    ],
    "UpstreamPathTemplate": "/api/<<ServiceName>>/{everything}",
    "UpstreamHttpMethod": [ "Put", "Delete", "Get", "Post" ]
  },
  ```

### Add to shared\SchoolAut0mater.DbMigrator\SchoolAut0materDbMigratorModule.cs

- add `typeof(SchoolAut0mater.<<ServiceName>>.<<ServiceName>>ApplicationContractsModule)`
- add `typeof(SchoolAut0mater.<<ServiceName>>.EntityFrameworkCore.<<ServiceName>>EntityFrameworkCoreModule)`

### update MigrateAllDatabasesAsync method in shared\SchoolAut0mater.DbMigrator\SchoolAut0materDbMigrationService.cs

`await MigrateDatabaseAsync<SchoolAut0mater.<<ServiceName>>.EntityFrameworkCore.<<ServiceName>>DbContext>(cancellationToken);`

### add <<ServiceName>> scope to oAuthConfig in apps/angular/src/environments/environment.ts

```json
<<ServiceName>>: {
    url: 'https://localhost:45015',
    rootNamespace: 'SchoolAut0mater',
},
```

### update tye.yaml

```yml
- name: core-service
  project: services/core/src/SchoolAut0mater.CoreService.HttpApi.Host/SchoolAut0mater.CoreService.HttpApi.Host.csproj
  bindings:
    - protocol: https
      port: 44324
  env:
    - Kestrel**Certificates**Default\_\_Path=../../../../etc/dev-cert/localhost.pfx
    - Kestrel**Certificates**Default\_\_Password=e8202f07-66e5-4619-be07-72ba76fde97f
```

```ps1
cd "$(echo (git rev-parse --show-toplevel))\SchoolAut0mater" && dotnet build /graphBuild
cd "$(echo (git rev-parse --show-toplevel))\SchoolAut0mater/shared/SchoolAut0mater.DbMigrator" && dotnet run && cd ../..
```

### Adding PermissionsProvider via `\services\core\src\SchoolAut0mater.<<ServiceName>>.Application.Contracts\Permissions\<<ServiceName>>Permissions.cs`

```csharp
public class Staffs
{
    public const string Default = GroupName + ".Products";
    public const string Edit = Default + ".Edit";
    public const string Create = Default + ".Create";
    public const string Delete = Default + ".Delete";
}
```

### Adding PermissionsProvider via `\services\core\src\SchoolAut0mater.<<ServiceName>>.Application.Contracts\Permissions\<<ServiceName>>PermissionDefinitionProvider.cs`

```csharp
var myGroup = context.AddGroup(StaffServicePermissions.GroupName, L("Permission:StaffService"));

//Define your own permissions here. Example:
//myGroup.AddPermission(BookStorePermissions.MyPermission1, L("Permission:MyPermission1"));
```

to

```csharp
var myGroup = context.AddGroup(StaffServicePermissions.GroupName, L("Permission:StaffService"));

var permissions = myGroup.AddPermission(StaffServicePermissions.Staffs.Default, L("Permission:StaffManagement"));
permissions.AddChild(StaffServicePermissions.Staffs.Create, L("Permission:Create"));
permissions.AddChild(StaffServicePermissions.Staffs.Edit, L("Permission:Edit"));
permissions.AddChild(StaffServicePermissions.Staffs.Delete, L("Permission:Delete"));
```

By doint this we can decorate our service class with `[Authorize]`, like below where `Staffs` is the entities.

- `[Authorize(StaffServicePermissions.Staffs.Default)]`
- `[Authorize(StaffServicePermissions.Staffs.Create)]`
- `[Authorize(StaffServicePermissions.Staffs.Edit)]`
- `[Authorize(StaffServicePermissions.Staffs.Delete)]`

#### Changed Files

- `tye.yaml`
- `apps/angular/src/environments/environment.prod.ts`
- `apps/angular/src/environments/environment.ts`
- `apps/public-web/src/SchoolAut0mater.PublicWeb/SchoolAut0mater.PublicWeb.csproj`
- `apps/public-web/src/SchoolAut0mater.PublicWeb/SchoolAut0materPublicWebModule.cs`
- `build/build-images-locally.ps1`
- `build/build-images.ps1`
- `gateways/web/src/SchoolAut0mater.WebGateway/SchoolAut0materWebGatewayModule.cs`
- `gateways/web-public/src/SchoolAut0mater.PublicWebGateway/SchoolAut0materPublicWebGatewayModule.cs`
- `services/administration/src/SchoolAut0mater.AdministrationService.HttpApi.Host/AdministrationServiceHttpApiHostModule.cs`
- `services/administration/src/SchoolAut0mater.AdministrationService.HttpApi.Host/SchoolAut0mater.AdministrationService.HttpApi.Host.csproj`
- `services/core/src/SchoolAut0mater.CoreService.HttpApi.Host/appsettings.json`
- `services/core/src/SchoolAut0mater.CoreService.HttpApi.Host/Properties/launchSettings.json`
- `services/identity/src/SchoolAut0mater.IdentityService.HttpApi.Host/appsettings.json`
- `services/identity/src/SchoolAut0mater.IdentityService.HttpApi.Host/DbMigrations/IdentityServerDataSeeder.cs`
- `shared/SchoolAut0mater.DbMigrator/appsettings.json`
- `shared/SchoolAut0mater.DbMigrator/IdentityServerDataSeeder.cs`
- `shared/SchoolAut0mater.DbMigrator/SchoolAut0materDbMigrationService.cs`
- `shared/SchoolAut0mater.DbMigrator/SchoolAut0materDbMigratorModule.cs`
- `shared/SchoolAut0mater.Shared.Hosting/SchoolAut0materSharedHostingModule.cs`
