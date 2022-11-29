Clear-Host
Set-Location $PSScriptRoot
Write-Host "PSScriptRoot: $PSScriptRoot";
Set-Location "$(Write-Output (git rev-parse --show-toplevel))"
Write-Host "Current Location: $((Get-Location).Path)";

$projectName = 'SchoolAut0mater'
if (!(Test-Path -PathType Container $projectName)) { Write-Error 'Project not found' -ErrorAction Stop; }

$projectFolder = $PSScriptRoot | Join-Path -ChildPath $projectName 
$projectFolder = (Get-Location).Path | Join-Path -ChildPath $projectName 
Write-Host "Project Folder: $projectFolder"; # return 'D:\Projects\abpio\abp7\SchoolAut0mater'

Set-Location $projectFolder

if ($null -eq $solutionFile) { $solutionFile = (Get-ChildItem -Recurse -Filter "$projectName.sln").Name }
Write-Host "Solution file: $solutionFile"; # return 'SchoolAut0mater.sln'

if ($null -eq $solutionLocation) { $solutionLocation = (Get-ChildItem -Recurse -Filter "$projectName.sln").FullName }
Write-Host "Solution location: $solutionLocation"; # return 'D:\Projects\abpio\abp7\SchoolAut0mater\SchoolAut0mater.sln'

$newServiceName = Read-Host -Prompt 'Enter New MicroService name ';
$newServiceNames = ($newServiceName.Replace(' ', '').Replace('Service', '') + 'Service') -csplit "([A-Z][a-z]+)" | Where-Object { $_ }
$newServiceName, $newServiceNames = $newServiceNames;
if ($newServiceNames.Length -eq 0) { $newServiceNames += 'Service' }

$newServiceLocation = "services" | Join-Path -ChildPath ($newServiceName.ToLowerInvariant() + ($newServiceNames -join "").Replace(' ', '').Replace('Service', ''));
Write-Host "New MicroService location: $newServiceLocation"; # return 'services\core'

$newServiceName = (Get-Culture).TextInfo.ToTitleCase($newServiceName) + ($newServiceNames -join "");
Write-Host "New MicroService name: $newServiceName"; # return 'CoreService'

$title = "Going to create a new MicroService '$newServiceName' at '$newServiceLocation'";
$question = 'Are you sure you want to proceed?'
$choices = '&Yes', '&No'

$decision = $Host.UI.PromptForChoice($title, $question, $choices, 1)
if ($decision -eq 0) { Write-Host 'confirmed'; }
else { Write-Host 'cancelled'; return; }


$connectionString = "Server=localhost,5434;User Id=sa;password=P@ssw0rd00;Database=SchoolAut0mater_Core;MultipleActiveResultSets=true;TrustServerCertificate=True"
if (Test-Path -PathType Container "$newServiceLocation") { Write-Error 'MicroService already exist!!!' -ErrorAction Stop; }
else { abp new $newServiceName -t microservice-service-pro --connection-string $connectionString --preview }

$projectFolder | Join-Path -ChildPath $newServiceLocation | Set-Location
Write-Host "Initial Building of $newServiceName service"; Start-Sleep -Seconds 3;
dotnet build

# . "$($PSScriptRoot | Join-Path -ChildPath "modify-solution-for-new-proj.ps1")" $newServiceLocation
Set-Location $projectFolder
dotnet sln add "$($projectFolder | Join-Path -ChildPath $newServiceLocation)\src\SchoolAut0mater.$newServiceName.HttpApi.Host\SchoolAut0mater.$newServiceName.HttpApi.Host.csproj" --solution-folder services 

# $administrationServiceHost = "$((Get-ChildItem -LP "$($projectFolder | Join-Path -ChildPath "services" | Join-Path -ChildPath "administration" | Join-Path -ChildPath "src")" -Filter *.AdministrationService.HttpApi.Host.csproj -Recurse).FullName)"
# $contract = "$((Get-ChildItem -LP $newServiceLocation -Filter *.Application.Contracts.csproj -Recurse).FullName)"
# if ($administrationServiceHost -ne $null -and $contract -ne $null) { dotnet add $administrationServiceHost reference $contract }
# $administrationServiceHost = $null; $contract = $null;

# $gateway = "$((Get-ChildItem -Filter *.WebGateway.csproj -Recurse).FullName)"
# $httpApi = "$((Get-ChildItem -LP "$newServiceLocation" -Filter "*$newServiceName.HttpApi.csproj" -Recurse).FullName)"
# if ($gateway -ne $null -and $httpApi -ne $null) { dotnet add $gateway reference $httpApi }
# $gateway = $null; $httpApi = $null;

$DbMigrator = "$((Get-ChildItem -Filter *.DbMigrator.csproj -Recurse).FullName)"
$Contracts = "$((Get-ChildItem -Path "$newServiceLocation" -Filter "*$newServiceName.Application.Contracts.csproj" -Recurse).FullName)"
$EntityFrameworkCore = "$((Get-ChildItem -Path "$newServiceLocation" -Filter "*$newServiceName.EntityFrameworkCore.csproj" -Recurse).FullName)"
if ($DbMigrator -ne $null -and $Contracts -ne $null) { dotnet add $DbMigrator reference $Contracts }
if ($DbMigrator -ne $null -and $EntityFrameworkCore -ne $null) { dotnet add $DbMigrator reference $EntityFrameworkCore }
$DbMigrator = $null; $Contracts = $null; $EntityFrameworkCore = $null;

Set-Location $projectFolder; return;