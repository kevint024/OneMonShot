# OneMonShot - Build Standalone Executable
# This script creates a self-contained executable that runs on any Windows machine

Write-Host "OneMonShot - Building Portable Executable" -ForegroundColor Cyan
Write-Host "========================================" -ForegroundColor Cyan

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
if (Test-Path "..\bin") {
    Remove-Item -Path "..\bin" -Recurse -Force
    Write-Host "Removed bin directory" -ForegroundColor Green
}
if (Test-Path "..\obj") {
    Remove-Item -Path "..\obj" -Recurse -Force  
    Write-Host "Removed obj directory" -ForegroundColor Green
}

# Create release directory
$releaseDir = "..\Release"
if (Test-Path $releaseDir) {
    Remove-Item -Path $releaseDir -Recurse -Force
}
New-Item -Path $releaseDir -ItemType Directory -Force | Out-Null
Write-Host "Created Release directory" -ForegroundColor Green

# Build framework-dependent executable (smaller size, requires .NET runtime)
Write-Host "`nBuilding framework-dependent executable..." -ForegroundColor Yellow
Write-Host "This creates a smaller executable that requires .NET 8 runtime to be installed" -ForegroundColor Gray

dotnet publish --configuration Release --runtime win-x64 --output $releaseDir --property:PublishSingleFile=true
if ($LASTEXITCODE -ne 0) {
    Write-Host "Build failed!" -ForegroundColor Red
    exit 1
}

# Get the executable info
$exePath = Join-Path $releaseDir "OneMonShot.exe"
$exeSize = (Get-Item $exePath).Length / 1MB

Write-Host "`nBuild completed successfully!" -ForegroundColor Green
Write-Host "=============================" -ForegroundColor Green
Write-Host "`nPortable executable created:" -ForegroundColor Cyan
Write-Host "  Location: $exePath" -ForegroundColor White
Write-Host "  Size: $([math]::Round($exeSize, 1)) MB" -ForegroundColor White
Write-Host "`nThis executable:" -ForegroundColor Yellow
Write-Host "  • Runs on Windows 10+ machines with .NET 8 runtime" -ForegroundColor Green  
Write-Host "  • Single file deployment (portable)" -ForegroundColor Green
Write-Host "  • Smaller size than self-contained" -ForegroundColor Green
Write-Host "  • Requires .NET 8 runtime on target machine" -ForegroundColor Yellow

# Check if we should run the executable
Write-Host ""
$runExe = Read-Host "Would you like to test the executable now? (y/n)"
if ($runExe -eq 'y' -or $runExe -eq 'Y') {
    Write-Host "`nStarting OneMonShot executable..." -ForegroundColor Yellow
    Start-Process -FilePath $exePath
}

Write-Host "`nExecutable build complete!" -ForegroundColor Cyan
Write-Host "You can distribute 'OneMonShot.exe' along with .NET 8 runtime requirement!" -ForegroundColor Green
Write-Host "For easier distribution, see README for installer creation options." -ForegroundColor Yellow