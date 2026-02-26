# OneMonShot - Create Distribution ZIP
# Creates a ready-to-share ZIP file

Write-Host "OneMonShot - Creating Distribution ZIP" -ForegroundColor Cyan
Write-Host "====================================" -ForegroundColor Cyan

# Check if package exists
if (-not (Test-Path "..\OneMonShot-Portable")) {
    Write-Host "`nError: OneMonShot-Portable folder not found!" -ForegroundColor Red
    Write-Host "Please run '.\create-package.ps1' first" -ForegroundColor Yellow
    exit 1
}

# Create ZIP file
$zipName = "..\OneMonShot-Portable.zip"
if (Test-Path $zipName) { Remove-Item $zipName -Force }

Write-Host "`nCreating ZIP file..." -ForegroundColor Yellow
Compress-Archive -Path "..\OneMonShot-Portable\*" -DestinationPath $zipName -CompressionLevel Optimal

$zipSize = (Get-Item $zipName).Length / 1KB

Write-Host "`nDistribution ZIP created!" -ForegroundColor Green
Write-Host "========================" -ForegroundColor Green
Write-Host "`nFile: $zipName" -ForegroundColor Cyan
Write-Host "Size: $([math]::Round($zipSize, 1)) KB" -ForegroundColor White
Write-Host "`nReady to share!" -ForegroundColor Yellow
Write-Host "• Send this ZIP file to anyone" -ForegroundColor Green
Write-Host "• They extract and run 'OneMonShot.bat'" -ForegroundColor Green
Write-Host "• Automatic .NET setup guidance included" -ForegroundColor Green

Write-Host "`nDistribution ZIP ready! 🎉" -ForegroundColor Cyan