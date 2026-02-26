# OneMonShot - Run Application
# Convenience script to run the built application

Write-Host "OneMonShot - Run Application" -ForegroundColor Cyan
Write-Host "===========================" -ForegroundColor Cyan

# Ensure we're in the project root
Set-Location $PSScriptRoot

# Check if built
if (-not (Test-Path "bin\Release\net8.0-windows\OneMonShot.exe")) {
    Write-Host "`n⚠️  Application not built yet!" -ForegroundColor Yellow
    Write-Host "Building now..." -ForegroundColor Gray
    
    try {
        & ".\build.ps1"
        if ($LASTEXITCODE -ne 0) {
            throw "Build failed"
        }
    } catch {
        Write-Host "`n❌ Build failed: $_" -ForegroundColor Red
        exit 1
    }
}

Write-Host "`n🚀 Starting OneMonShot..." -ForegroundColor Green
try {
    dotnet run --configuration Release --no-build
} catch {
    Write-Host "`n❌ Failed to start application: $_" -ForegroundColor Red
    exit 1
}