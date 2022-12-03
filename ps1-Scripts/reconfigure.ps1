Clear-Host
Set-Location $PSScriptRoot;
$src = $PSScriptRoot | Join-Path -ChildPath ".." | Join-Path -ChildPath "SchoolAut0mater" | Resolve-Path;

$src | Join-Path -ChildPath "etc" | Join-Path -ChildPath "docker" | Set-Location;
.\down.ps1
Start-Sleep -Seconds 2

$src | Set-Location;
abp clean
Start-Sleep -Seconds 1

$src | Set-Location;
Get-ChildItem -Filter "Logs" -Recurse | Remove-Item -Recurse -Force -ErrorAction SilentlyContinue;
Start-Sleep -Seconds 1

# Remove all volumes not used by at least one container.
docker volume prune --force
Start-Sleep -Seconds 1

$src | Join-Path -ChildPath "etc" | Join-Path -ChildPath "docker" | Set-Location;
.\up.ps1
Start-Sleep -Seconds 2

$src | Set-Location;
dotnet build /graphBuild
Start-Sleep -Seconds 2

$src | Join-Path -ChildPath "shared" | Join-Path -ChildPath "SchoolAut0mater.DbMigrator" | Set-Location;
dotnet run
Start-Sleep -Seconds 2

$src | Set-Location;