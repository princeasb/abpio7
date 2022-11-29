45021
https://localhost:45021
core
CoreService
COPY "services/core/src/SchoolAut0mater.CoreService.HttpApi.Host/SchoolAut0mater.CoreService.HttpApi.Host.csproj" "services/core/src/SchoolAut0mater.CoreService.HttpApi.Host/SchoolAut0mater.CoreService.HttpApi.Host.csproj"

cd services\core\src\SchoolAut0mater.CoreService.HttpApi.Client

abp generate-proxy -t csharp -u https://localhost:45021/ -m CoreService







https://localhost:44361