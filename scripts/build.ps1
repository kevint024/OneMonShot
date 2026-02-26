# OneMonShot Build Script
# This script builds the OneMonShot multi-monitor screenshot application

Write-Host "OneMonShot - Multi-Monitor Screenshot Tool" -ForegroundColor Cyan
Write-Host "=========================================" -ForegroundColor Cyan

# Check if .NET 8 is installed
Write-Host "`nChecking .NET installation..." -ForegroundColor Yellow
try {
    $dotnetVersion = dotnet --version
    Write-Host ".NET Version: $dotnetVersion" -ForegroundColor Green
} catch {
    Write-Host "Error: .NET is not installed or not found in PATH" -ForegroundColor Red
    Write-Host "Please install .NET 8 from: https://dotnet.microsoft.com/download" -ForegroundColor Red
    exit 1
}

# Clean previous builds
Write-Host "`nCleaning previous builds..." -ForegroundColor Yellow
if (Test-Path "bin") {
    Remove-Item -Path "bin" -Recurse -Force
    Write-Host "Removed bin directory" -ForegroundColor Green
}
if (Test-Path "obj") {
    Remove-Item -Path "obj" -Recurse -Force  
    Write-Host "Removed obj directory" -ForegroundColor Green
}

# Restore dependencies
Write-Host "`nRestoring NuGet packages..." -ForegroundColor Yellow
dotnet restore
if ($LASTEXITCODE -ne 0) {
    Write-Host "Failed to restore packages" -ForegroundColor Red
    exit 1
}

# Build the application
Write-Host "`nBuilding OneMonShot..." -ForegroundColor Yellow
dotnet build --configuration Release --no-restore
if ($LASTEXITCODE -ne 0) {
    Write-Host "Build failed!" -ForegroundColor Red
    exit 1
}

Write-Host "`nBuild completed successfully!" -ForegroundColor Green

Write-Host "`nBuild Options:" -ForegroundColor Cyan
Write-Host "• This build requires .NET 8 runtime to be installed" -ForegroundColor Yellow
Write-Host "• To create a standalone .exe (no runtime required):" -ForegroundColor Yellow
Write-Host "  Run: .\build-exe.ps1" -ForegroundColor White

# Check if we should run the application
$runApp = Read-Host "`nWould you like to run OneMonShot now? (y/n)"
if ($runApp -eq 'y' -or $runApp -eq 'Y') {
    Write-Host "`nStarting OneMonShot..." -ForegroundColor Yellow
    dotnet run --configuration Release --no-build
}

Write-Host "`nBuild script completed!" -ForegroundColor Cyan