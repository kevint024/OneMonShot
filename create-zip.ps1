# OneMonShot - Create Release ZIP
# Convenience script for creating distribution ZIP

Write-Host "OneMonShot - Create Release ZIP" -ForegroundColor Cyan  
Write-Host "===============================" -ForegroundColor Cyan

# Ensure we're in the project root
Set-Location $PSScriptRoot

# Check if package exists
if (-not (Test-Path "OneMonShot-Portable")) {
    Write-Host "`n⚠️  Distribution package not found!" -ForegroundColor Yellow
    Write-Host "Creating package first..." -ForegroundColor Gray
    
    try {
        & ".\package.ps1"
        if ($LASTEXITCODE -ne 0) {
            throw "Package creation failed"
        }
    } catch {
        Write-Host "`n❌ Package creation failed: $_" -ForegroundColor Red
        exit 1
    }
}

try {
    # Create the ZIP
    & ".\scripts\create-zip.ps1"
    
    if ($LASTEXITCODE -eq 0) {
        Write-Host "`n✅ Release ZIP created successfully!" -ForegroundColor Green
        Write-Host "`nFile: OneMonShot-Portable.zip" -ForegroundColor Cyan
        Write-Host "Ready for distribution! 🎉" -ForegroundColor Yellow
    }
} catch {
    Write-Host "`n❌ ZIP creation failed: $_" -ForegroundColor Red
    exit 1
}