WebGateway_Swagger


abp clean
cd "$(echo (git rev-parse --show-toplevel))\SchoolAut0mater\etc\docker" && .\up.ps1
abp clean && cd "$(echo (git rev-parse --show-toplevel))\SchoolAut0mater" && dotnet build /graphBuild
cd "$(echo (git rev-parse --show-toplevel))\SchoolAut0mater/shared/SchoolAut0mater.DbMigrator" && dotnet run && cd ../..

cd "$(echo (git rev-parse --show-toplevel))\SchoolAut0mater" && .\run-tye.ps1
cd "$(echo (git rev-parse --show-toplevel))\SchoolAut0mater" && tye run --watch
cd "$(echo (git rev-parse --show-toplevel))\SchoolAut0mater\apps\angular" && yarn && yarn start

cd "$(echo (git rev-parse --show-toplevel))\SchoolAut0mater\services\core\src\SchoolAut0mater.CoreService.HttpApi.Client"
abp generate-proxy -t csharp -u https://localhost:45021/ -m CoreService

cd "$(echo (git rev-parse --show-toplevel))\SchoolAut0mater\apps\angular\"
yarn ng generate library core-service1 --prefix app --skip-install --project-root SchoolAut0mater
abp generate-proxy -t ng --module CoreService --url https://localhost:45021/ --target core-service



yarn ng generate @abp/ng.schematics:proxy-add --target=core-service --source=CoreService --module CoreService --url https://localhost:45021/ --project SchoolAut0mater
yarn ng generate @abp/ng.schematics:proxy-refresh --module CoreService --apiName CoreService --source CoreService --target "core-service\" --url "https://localhost:45021" --entryPoint "core-service\"

yarn ng generate @abp/ng.schematics:proxy-refresh --module "app\" --apiName CoreService --source CoreService --target "core-service\" --url "https://localhost:45021" --entryPoint "core-service\"
yarn ng generate @abp/ng.schematics:proxy-index

node run-schematics.mjs "D:/Projects/abpio/abp7/SchoolAut0mater/apps/angular/.suite/schematics/node_modules/.bin/ng" g ".suite/schematics/collection.json:entity" microservice-pro SchoolAut0mater.CoreService "D:/Projects/abpio/abp7/SchoolAut0mater/services/core/.suite/entities/MITCatalog.json" "D:/Projects/abpio/abp7/SchoolAut0mater/apps/angular" 
yarn ng g ".suite/schematics/collection.json:entity" microservice-pro SchoolAut0mater.CoreService "D:/Projects/abpio/abp7/SchoolAut0mater/services/core/.suite/entities/MITCatalog.json" "D:/Projects/abpio/abp7/SchoolAut0mater/apps/angular" 

node ./.suite/schematics/schematics/run-schematics.mjs "./.suite/schematics/node_modules/.bin/ng" g "./.suite/schematics/collection.json:entity" microservice-pro SchoolAut0mater.CoreService ".suite/entities/MITCatalog.json" "D:/Projects/abpio/abp7/SchoolAut0mater/apps/angular" 

yarn ng g ".suite/schematics/collection.json:entity" microservice-pro SchoolAut0mater.CoreService "D:/Projects/abpio/abp7/SchoolAut0mater/services/core/.suite/entities/MITCatalog.json" "D:/Projects/abpio/abp7/SchoolAut0mater/apps/angular" 

ng generate @abp/ng.schematics:proxy-add --target=ProjectName --source=ProjectName
