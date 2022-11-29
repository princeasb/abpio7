param ($version='latest')

$currentFolder = $PSScriptRoot
$slnFolder = Join-Path $currentFolder "../"
### Apps Folders
$angularAppFolder = Join-Path $slnFolder "apps/angular"
$authserverFolder = Join-Path $slnFolder "apps/auth-server/src/SchoolAut0mater.AuthServer"
$publicWebFolder = Join-Path $slnFolder "apps/public-web/src/SchoolAut0mater.PublicWeb"

### Microservice Folders
$identityServiceFolder = Join-Path $slnFolder "services/identity/src/SchoolAut0mater.IdentityService.HttpApi.Host"
$administrationServiceFolder = Join-Path $slnFolder "services/administration/src/SchoolAut0mater.AdministrationService.HttpApi.Host"
$saasServiceFolder = Join-Path $slnFolder "services/saas/src/SchoolAut0mater.SaasService.HttpApi.Host"
$coreServiceFolder = Join-Path $slnFolder "services/core/src/SchoolAut0mater.CoreService.HttpApi.Host"
$productServiceFolder = Join-Path $slnFolder "services/product/src/SchoolAut0mater.ProductService.HttpApi.Host"

### Gateway Folders
$webGatewayFolder = Join-Path $slnFolder "gateways/web/src/SchoolAut0mater.WebGateway"
$webPublicGatewayFolder = Join-Path $slnFolder "gateways/web-public/src/SchoolAut0mater.PublicWebGateway"

### DB Migrator Folder
$dbmigratorFolder = Join-Path $slnFolder "shared/SchoolAut0mater.DbMigrator"

Write-Host "*** BUILDING DB MIGRATOR ***" -ForegroundColor Green
Set-Location $dbmigratorFolder
dotnet publish -c Release
docker build -f Dockerfile.local -t mycompanyname/schoolaut0mater-db-migrator:$version .

Write-Host "===== BUILDING MICROSERVICES =====" -ForegroundColor Yellow 
### IDENTITY-SERVICE
Write-Host "*** BUILDING IDENTITY-SERVICE ***" -ForegroundColor Green
Set-Location $identityServiceFolder
dotnet publish -c Release
docker build -f Dockerfile.local -t mycompanyname/schoolaut0mater-service-identity:$version .

### ADMINISTRATION-SERVICE
Write-Host "*** BUILDING ADMINISTRATION-SERVICE ***" -ForegroundColor Green
Set-Location $administrationServiceFolder
dotnet publish -c Release
docker build -f Dockerfile.local -t mycompanyname/schoolaut0mater-service-administration:$version .

### SAAS-SERVICE
Write-Host "*** BUILDING SAAS-SERVICE ***" -ForegroundColor Green
Set-Location $saasServiceFolder
dotnet publish -c Release
docker build -f Dockerfile.local -t mycompanyname/schoolaut0mater-service-saas:$version .

### CORE-SERVICE
Write-Host "*** BUILDING CORE-SERVICE ***" -ForegroundColor Green
Set-Location $coreServiceFolder
dotnet publish -c Release
docker build -f Dockerfile.local -t mycompanyname/schoolaut0mater-service-core:$version .

### PRODUCT-SERVICE
Write-Host "*** BUILDING PRODUCT-SERVICE ***" -ForegroundColor Green
Set-Location $productServiceFolder
dotnet publish -c Release
docker build -f Dockerfile.local -t mycompanyname/schoolaut0mater-service-product:$version .
Write-Host "===== COMPLETED BUILDING MICROSERVICES =====" -ForegroundColor Yellow 

Write-Host "===== BUILDING GATEWAYS =====" -ForegroundColor Yellow 
### WEB-GATEWAY
Write-Host "*** BUILDING WEB-GATEWAY ***" -ForegroundColor Green
Set-Location $webGatewayFolder
dotnet publish -c Release
docker build -f Dockerfile.local -t mycompanyname/schoolaut0mater-gateway-web:$version .

### PUBLICWEB-GATEWAY
Write-Host "*** BUILDING WEB-PUBLIC-GATEWAY ***" -ForegroundColor Green
Set-Location $webPublicGatewayFolder
dotnet publish -c Release
docker build -f Dockerfile.local -t mycompanyname/schoolaut0mater-gateway-web-public:$version .
Write-Host "===== COMPLETED BUILDING GATEWAYS =====" -ForegroundColor Yellow 

Write-Host "===== BUILDING APPLICATIONS =====" -ForegroundColor Yellow 
### AUTH-SERVER
Write-Host "*** BUILDING AUTH-SERVER ***" -ForegroundColor Green
Set-Location $authserverFolder
dotnet publish -c Release
docker build -f Dockerfile.local -t mycompanyname/schoolaut0mater-app-authserver:$version .

### PUBLIC-WEB
Write-Host "*** BUILDING WEB-PUBLIC ***" -ForegroundColor Green
Set-Location $publicWebFolder
dotnet publish -c Release
docker build -f Dockerfile.local -t mycompanyname/schoolaut0mater-app-public-web:$version .
### Angular WEB App
if (Test-Path -Path $angularAppFolder) {
    Write-Host "*** BUILDING ANGULAR WEB APPLICATION ***" -ForegroundColor Green
    Set-Location $angularAppFolder
    yarn
    # ng build --prod
    npm run build:prod
    docker build -f Dockerfile.local -t mycompanyname/schoolaut0mater-app-angular:$version .
}
Write-Host "===== COMPLETED BUILDING APPLICATIONS =====" -ForegroundColor Yellow 
### ALL COMPLETED
Write-Host "ALL COMPLETED" -ForegroundColor Green
Set-Location $currentFolder