param(
    [Parameter(Mandatory)]
    [string]$ServiceLocation
)
 
Clear-Host;
$location = "$ServiceLocation"

Push-Location "$PSScriptRoot\SchoolAut0mater"

if (!(Test-Path "$PSScriptRoot\SchoolAut0mater\$location")) {
    Write-Host "$PSScriptRoot\SchoolAut0mater\$location";
    $msg = "Service location $($location) does not exist";
    Write-Error $msg -ErrorAction Stop;
}

if (!(Test-Path "$PSScriptRoot\SchoolAut0mater\SchoolAut0mater.sln")) {
    $msg = "Service location $PSScriptRoot\SchoolAut0mater\SchoolAut0mater.sln does not exist";
    Write-Error $msg -ErrorAction Stop;
}

Write-Host "Location      : $((Get-Location).Path)"
Write-Host "Solution File : $((Get-Item 'SchoolAut0mater.sln').FullName)"
$sln = $((Get-Item 'SchoolAut0mater.sln').FullName);


# Write-Host "Attaching Test Projects";
# Get-ChildItem -r "$location\**\*.*.csproj" | 
# Where-Object { $_.FullName -match "[.]Tests|TestBase[.]" } | % {
#     $pro = "$($_.FullName)".replace("$PSScriptRoot\SchoolAut0mater", ".");
#     dotnet sln $sln add "$pro" --solution-folder "$location/test"
# }

# Write-Host "Attaching Host Projects";
# Get-ChildItem -r "$location\**\*.*.csproj" | 
# Where-Object { $_.FullName -match "[.]Host[.]" } | % {
#     $pro = "$($_.FullName)".replace("$PSScriptRoot\SchoolAut0mater", ".");
#     dotnet sln $sln add "$pro" --solution-folder "$location/host"
# }

# Write-Host "Attaching Other Projects";
# Get-ChildItem -r "$location\**\*.*.csproj" | 
# Where-Object { $_.FullName -notmatch "Tests|Host|TestBase|Web" } | % {
#     $pro = "$($_.FullName)".replace("$PSScriptRoot\SchoolAut0mater", ".");
#     dotnet sln $sln add "$pro" --solution-folder "$location/src"
# }

Pop-Location