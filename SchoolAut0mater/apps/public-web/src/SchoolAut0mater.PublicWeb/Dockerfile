FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src

# It's important to keep lines from here down to "COPY . ." identical in all Dockerfiles
# to take advantage of Docker's build cache, to speed up local container builds
COPY "SchoolAut0mater.sln" "SchoolAut0mater.sln"

# Applications
COPY "apps/auth-server/src/SchoolAut0mater.AuthServer/SchoolAut0mater.AuthServer.csproj" "apps/auth-server/src/SchoolAut0mater.AuthServer/SchoolAut0mater.AuthServer.csproj"
COPY "apps/public-web/src/SchoolAut0mater.PublicWeb/SchoolAut0mater.PublicWeb.csproj" "apps/public-web/src/SchoolAut0mater.PublicWeb/SchoolAut0mater.PublicWeb.csproj"
COPY *"apps/blazor/src/SchoolAut0mater.Blazor/SchoolAut0mater.Blazor.csproj" "apps/blazor/src/SchoolAut0mater.Blazor/SchoolAut0mater.Blazor.csproj"
COPY *"apps/blazor/src/SchoolAut0mater.Blazor.Server/SchoolAut0mater.Blazor.Server.csproj" "apps/blazor/src/SchoolAut0mater.Blazor.Server/SchoolAut0mater.Blazor.Server.csproj"
COPY *"apps/web/src/SchoolAut0mater.Web/SchoolAut0mater.Web.csproj" "apps/web/src/SchoolAut0mater.Web/SchoolAut0mater.Web.csproj"

# Shared Projects
COPY "shared/SchoolAut0mater.DbMigrator/SchoolAut0mater.DbMigrator.csproj" "shared/SchoolAut0mater.DbMigrator/SchoolAut0mater.DbMigrator.csproj"
COPY "shared/SchoolAut0mater.Shared.Hosting/SchoolAut0mater.Shared.Hosting.csproj" "shared/SchoolAut0mater.Shared.Hosting/SchoolAut0mater.Shared.Hosting.csproj"
COPY "shared/SchoolAut0mater.Shared.Hosting.Gateways/SchoolAut0mater.Shared.Hosting.Gateways.csproj" "shared/SchoolAut0mater.Shared.Hosting.Gateways/SchoolAut0mater.Shared.Hosting.Gateways.csproj"
COPY "shared/SchoolAut0mater.Shared.Hosting.Microservices/SchoolAut0mater.Shared.Hosting.Microservices.csproj" "shared/SchoolAut0mater.Shared.Hosting.Microservices/SchoolAut0mater.Shared.Hosting.Microservices.csproj"
COPY "shared/SchoolAut0mater.Shared.Hosting.AspNetCore/SchoolAut0mater.Shared.Hosting.AspNetCore.csproj" "shared/SchoolAut0mater.Shared.Hosting.AspNetCore/SchoolAut0mater.Shared.Hosting.AspNetCore.csproj"
COPY "shared/SchoolAut0mater.Shared.Hosting/SchoolAut0mater.Shared.Hosting.csproj" "shared/SchoolAut0mater.Shared.Hosting/SchoolAut0mater.Shared.Hosting.csproj"
COPY "shared/SchoolAut0mater.Shared.Localization/SchoolAut0mater.Shared.Localization.csproj" "shared/SchoolAut0mater.Shared.Localization/SchoolAut0mater.Shared.Localization.csproj"

# Microservices
COPY "services/administration/src/SchoolAut0mater.AdministrationService.HttpApi.Host/SchoolAut0mater.AdministrationService.HttpApi.Host.csproj" "services/administration/src/SchoolAut0mater.AdministrationService.HttpApi.Host/SchoolAut0mater.AdministrationService.HttpApi.Host.csproj"
COPY "services/identity/src/SchoolAut0mater.IdentityService.HttpApi.Host/SchoolAut0mater.IdentityService.HttpApi.Host.csproj" "services/identity/src/SchoolAut0mater.IdentityService.HttpApi.Host/SchoolAut0mater.IdentityService.HttpApi.Host.csproj"
COPY "services/saas/src/SchoolAut0mater.SaasService.HttpApi.Host/SchoolAut0mater.SaasService.HttpApi.Host.csproj" "services/saas/src/SchoolAut0mater.SaasService.HttpApi.Host/SchoolAut0mater.SaasService.HttpApi.Host.csproj"
COPY "services/core/src/SchoolAut0mater.CoreService.HttpApi.Host/SchoolAut0mater.CoreService.HttpApi.Host.csproj" "services/core/src/SchoolAut0mater.CoreService.HttpApi.Host/SchoolAut0mater.CoreService.HttpApi.Host.csproj"
COPY "services/product/src/SchoolAut0mater.ProductService.HttpApi.Host/SchoolAut0mater.ProductService.HttpApi.Host.csproj" "services/product/src/SchoolAut0mater.ProductService.HttpApi.Host/SchoolAut0mater.ProductService.HttpApi.Host.csproj"

# Gateways
COPY "gateways/web/src/SchoolAut0mater.WebGateway/SchoolAut0mater.WebGateway.csproj" "gateways/web/src/SchoolAut0mater.WebGateway/SchoolAut0mater.WebGateway.csproj"
COPY "gateways/web-public/src/SchoolAut0mater.PublicWebGateway/SchoolAut0mater.PublicWebGateway.csproj" "gateways/web-public/src/SchoolAut0mater.PublicWebGateway/SchoolAut0mater.PublicWebGateway.csproj"

COPY "NuGet.Config" "NuGet.Config"

RUN dotnet restore "SchoolAut0mater.sln"

COPY . .
WORKDIR "/src/apps/public-web/src/SchoolAut0mater.PublicWeb"
RUN dotnet publish -c Release -o /app 
# Should be used after .net6 is out of preview for better performance
# RUN dotnet publish --no-restore -c Release -o /app 

FROM build AS publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "SchoolAut0mater.PublicWeb.dll"]