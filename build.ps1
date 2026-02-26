# OneMonShot - Development Build
# Convenience script that calls the main build script

Write-Host "OneMonShot - Development Build" -ForegroundColor Cyan
Write-Host "==============================" -ForegroundColor Cyan

# Ensure we're in the project root
Set-Location $PSScriptRoot

# Call the main build script in scripts folder
try {
    & ".\scripts\build.ps1"
    if ($LASTEXITCODE -eq 0) {
        Write-Host "`n✅ Build completed successfully!" -ForegroundColor Green
        Write-Host "`nNext steps:" -ForegroundColor Cyan
        Write-Host "• Create package: .\package.ps1" -ForegroundColor Yellow
        Write-Host "• Run application: .\run.ps1" -ForegroundColor Yellow
    }
} catch {
    Write-Host "`n❌ Build failed: $_" -ForegroundColor Red
    exit 1
}