# SchoolAut0mater v4 on ABO.IO 7.0.0-rc.2

## Install the ABP CLI

```ps1
# List of globally installed tools
dotnet tool list -g

# dotnet tool uninstall -g volo.abp.cli
# dotnet tool install -g Volo.Abp.Cli
dotnet tool update -g Volo.Abp.Cli
# or
dotnet tool update -g Volo.Abp.Cli  --prerelease

# abp update  # if needed
# abp suite update # if required

# abp login <username>
abp login "$(cat ./abpio-username)" --organization "$(cat ./abpio-organization)"

# abp suite install
abp suite update
abp suite update --preview
```

### How to Kill the Process Currently Using a Port on localhost in Windows

```ps1
# Check the localhost Port Running Process
netstat -ano | findstr :8000

# Kill Process Using PID
taskkill /PID 14408 /F
```

### ABP Suite logs directory

* WINDOWS =>  %UserProfile%\.abp\suite\logs
* MAC => ~/.abp/suite/logs

## [Run the Solution](https://docs.abp.io/en/commercial/latest/startup-templates/microservice/get-started)

Before building the infrastructure using docker compose, we need to change couple of `docker-compose.infrastructure.override.yml` configurations inorder to avoid future issues

* bind local port '**5434**' to docker '1433'
* change the password to a min 8 char long complex password '**P@ssw0rd00**'
* sqlserver image `mcr.microsoft.com/mssql/server` will not work in Apple M1 Chip laptop, therefore change to `mcr.microsoft.com/azure-sql-edge`

```yml
  sql-server-db:
    image: mcr.microsoft.com/azure-sql-edge
    ports:
      - "5434:1433"
    environment:
      SA_PASSWORD: "P@ssw0rd00"
      ACCEPT_EULA: "Y"
```

Since we have the docker configuration of sql server, we need to manually change the connection string
      

* replace `myPassw@rd` to `myPassw0rd`
* replace `,1433;Database=SchoolAut0mater_(.*);User Id=sa;password=myPassw0rd` to `,5434;User Id=sa;password=P@ssw0rd00;Database=SchoolAut0mater_$1` on all items in solutions using 'Regex Expression' (`.*`)
* replace `Database=SchoolAut0mater_ProductService` to `Database=SchoolAut0mater_Product` on all items in solutions using 'Regex Expression' (`.*`)
* replace `localhost,1434` to `localhost,5434` in all appsettings.json
* replace `myPassw0rd` to `P@ssw0rd00` in all appsettings.json

### Rebuilding docker to accomodate core changes

shutdown the abp docker by runing

```ps1
cd "$(echo (git rev-parse --show-toplevel))\SchoolAut0mater\etc\docker" && .\down.ps1
```

Now delete all stopped docker `Note: Please make sure all the non abp dockers are in running state.`

```ps1
docker rm $(docker ps --filter status=exited -q)    # Remove all stoped containers 
# docker image prune -a                               # To remove all images which are not used by existing containers
docker volume prune                                 # Remove all volumes not used by at least one container.
```

```ps1
cd "$(echo (git rev-parse --show-toplevel))\SchoolAut0mater\etc\docker" && .\up.ps1
```

### Rebuilding the solution and running the applications

```ps1
cd "$(echo (git rev-parse --show-toplevel))\SchoolAut0mater\etc\docker" && .\down.ps1
cd "$(echo (git rev-parse --show-toplevel))\SchoolAut0mater\etc\dev-cert" && .\create-certificate.ps1
cd "$(echo (git rev-parse --show-toplevel))\SchoolAut0mater\etc\dev-cert" && abp clean
cd "$(echo (git rev-parse --show-toplevel))\SchoolAut0mater" && abp install-libs
cd "$(echo (git rev-parse --show-toplevel))\SchoolAut0mater" && dotnet build /graphBuild
cd "$(echo (git rev-parse --show-toplevel))\SchoolAut0mater/shared/SchoolAut0mater.DbMigrator" && dotnet run && cd ../..
cd "$(echo (git rev-parse --show-toplevel))\SchoolAut0mater\etc\docker" && .\up.ps1
cd "$(echo (git rev-parse --show-toplevel))\SchoolAut0mater" && .\run-tye.ps1
cd "$(echo (git rev-parse --show-toplevel))\SchoolAut0mater\apps\angular" && yarn && yarn start # Only First Time
```

`cd "$(echo (git rev-parse --show-toplevel))\SchoolAut0mater" && tye run --watch`
