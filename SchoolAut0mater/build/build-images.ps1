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
$productServiceFolder = Join-Path $slnFolder "services/product/src/SchoolAut0mater.ProductService.HttpApi.Host"

### Gateway Folders
$webGatewayFolder = Join-Path $slnFolder "gateways/web/src/SchoolAut0mater.WebGateway"
$webPublicGatewayFolder = Join-Path $slnFolder "gateways/web-public/src/SchoolAut0mater.PublicWebGateway"

### DB Migrator Folder
$dbmigratorFolder = Join-Path $slnFolder "shared/SchoolAut0mater.DbMigrator"

Write-Host "*** BUILDING DB MIGRATOR ***" -ForegroundColor Green
Set-Location $slnFolder
docker build -f "$dbmigratorFolder/Dockerfile" -t mycompanyname/schoolaut0mater-db-migrator:$version .

Write-Host "===== BUILDING MICROSERVICES =====" -ForegroundColor Yellow 
### IDENTITY-SERVICE
Write-Host "*** BUILDING IDENTITY-SERVICE ***" -ForegroundColor Green
Set-Location $slnFolder
docker build -f "$identityServiceFolder/Dockerfile" -t mycompanyname/schoolaut0mater-service-identity:$version .

### ADMINISTRATION-SERVICE
Write-Host "*** BUILDING ADMINISTRATION-SERVICE ***" -ForegroundColor Green
Set-Location $slnFolder
docker build -f "$administrationServiceFolder/Dockerfile" -t mycompanyname/schoolaut0mater-service-administration:$version .

### SAAS-SERVICE
Write-Host "*** BUILDING SAAS-SERVICE ***" -ForegroundColor Green
Set-Location $slnFolder
docker build -f "$saasServiceFolder/Dockerfile" -t mycompanyname/schoolaut0mater-service-saas:$version .

### PRODUCT-SERVICE
Write-Host "*** BUILDING PRODUCT-SERVICE ***" -ForegroundColor Green
Set-Location $slnFolder
docker build -f "$productServiceFolder/Dockerfile" -t mycompanyname/schoolaut0mater-service-product:$version .
Write-Host "===== COMPLETED BUILDING MICROSERVICES =====" -ForegroundColor Yellow 

Write-Host "===== BUILDING GATEWAYS =====" -ForegroundColor Yellow 
### WEB-GATEWAY
Write-Host "*** BUILDING WEB-GATEWAY ***" -ForegroundColor Green
Set-Location $slnFolder
docker build -f "$webGatewayFolder/Dockerfile" -t mycompanyname/schoolaut0mater-gateway-web:$version .

### PUBLICWEB-GATEWAY
Write-Host "*** BUILDING WEB-PUBLIC-GATEWAY ***" -ForegroundColor Green
Set-Location $slnFolder
docker build -f "$webPublicGatewayFolder/Dockerfile" -t mycompanyname/schoolaut0mater-gateway-web-public:$version .
Write-Host "===== COMPLETED BUILDING GATEWAYS =====" -ForegroundColor Yellow 

Write-Host "===== BUILDING APPLICATIONS =====" -ForegroundColor Yellow 
### AUTH-SERVER
Write-Host "*** BUILDING AUTH-SERVER ***" -ForegroundColor Green
Set-Location $slnFolder
docker build -f "$authserverFolder/Dockerfile" -t mycompanyname/schoolaut0mater-app-authserver:$version .

### PUBLIC-WEB
Write-Host "*** BUILDING WEB-PUBLIC ***" -ForegroundColor Green
Set-Location $slnFolder
docker build -f "$publicWebFolder/Dockerfile" -t mycompanyname/schoolaut0mater-app-public-web:$version .
### Angular WEB App
if (Test-Path -Path $angularAppFolder) {
    Write-Host "*** BUILDING ANGULAR WEB APPLICATION ***" -ForegroundColor Green
    Set-Location $angularAppFolder
    docker build -f "$angularAppFolder/Dockerfile" -t mycompanyname/schoolaut0mater-app-angular:$version .
}
Write-Host "===== COMPLETED BUILDING APPLICATIONS =====" -ForegroundColor Yellow

### ALL COMPLETED
Write-Host "ALL COMPLETED" -ForegroundColor Green
Set-Location $currentFolder