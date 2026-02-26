# OneMonShot - Create Distribution Package
# Convenience script for creating portable distribution

Write-Host "OneMonShot - Create Distribution Package" -ForegroundColor Cyan
Write-Host "========================================" -ForegroundColor Cyan

# Ensure we're in the project root
Set-Location $PSScriptRoot

try {
    # Create the package
    & ".\scripts\create-package.ps1"
    
    if ($LASTEXITCODE -eq 0) {
        Write-Host "`n✅ Package created successfully!" -ForegroundColor Green
        Write-Host "`nNext steps:" -ForegroundColor Cyan
        Write-Host "• Create ZIP: .\create-zip.ps1" -ForegroundColor Yellow
        Write-Host "• Test package: .\OneMonShot-Portable\OneMonShot.bat" -ForegroundColor Yellow
    }
} catch {
    Write-Host "`n❌ Package creation failed: $_" -ForegroundColor Red
    exit 1
}