# OneMonShot - Simple Distribution Package Creator
# Creates a portable folder with all necessary files

Write-Host "OneMonShot - Creating Distribution Package" -ForegroundColor Cyan
Write-Host "==========================================" -ForegroundColor Cyan

# Clean and create directories
if (Test-Path "..\Release") { Remove-Item -Path "..\Release" -Recurse -Force }
if (Test-Path "..\OneMonShot-Portable") { Remove-Item -Path "..\OneMonShot-Portable" -Recurse -Force }

# Build regular release
Write-Host "`nBuilding OneMonShot..." -ForegroundColor Yellow
dotnet build --configuration Release
if ($LASTEXITCODE -ne 0) {
    Write-Host "Build failed!" -ForegroundColor Red
    exit 1
}

# Create portable package
Write-Host "`nCreating portable package..." -ForegroundColor Yellow
New-Item -Path "..\OneMonShot-Portable" -ItemType Directory -Force | Out-Null

# Copy executable and dependencies
$sourceDir = "..\bin\Release\net8.0-windows"
$targetDir = "..\OneMonShot-Portable"

Copy-Item -Path "$sourceDir\*" -Destination $targetDir -Recurse -Force

# Create launcher script
$launcherScript = @"
@echo off
title OneMonShot - Multi-Monitor Screenshot Tool

REM Check if .NET 8 is installed
dotnet --version >nul 2>&1
if %errorlevel% neq 0 (
    echo OneMonShot requires .NET 8 Runtime
    echo.
    echo Please install .NET 8 from:
    echo https://dotnet.microsoft.com/download/dotnet/8.0
    echo.
    echo Look for: ".NET Desktop Runtime 8.0.x (Windows x64)"
    pause
    exit /b 1
)

echo Starting OneMonShot...
dotnet OneMonShot.dll
"@

$launcherScript | Out-File -FilePath "$targetDir\OneMonShot.bat" -Encoding ASCII

# Create README for distribution
$distReadme = @"
# OneMonShot - Multi-Monitor Screenshot Tool

## Quick Start
1. Double-click 'OneMonShot.bat' to run the application

## Requirements  
- Windows 10 or later
- .NET 8 Desktop Runtime

## If .NET 8 is not installed:
1. Visit: https://dotnet.microsoft.com/download/dotnet/8.0
2. Download: ".NET Desktop Runtime 8.0.x (Windows x64)"
3. Install and run OneMonShot.bat again

## What's Included
- OneMonShot.dll - Main application
- OneMonShot.bat - Launcher (checks for .NET)
- All required libraries and dependencies

## Features
- Multi-monitor screenshot capture
- Custom save locations
- Custom file naming formats  
- File Explorer auto-open toggle
- Live preview of screenshots

Enjoy using OneMonShot!
"@

$distReadme | Out-File -FilePath "$targetDir\README.txt" -Encoding UTF8

# Get package info
$packageSize = (Get-ChildItem $targetDir -Recurse | Measure-Object -Property Length -Sum).Sum / 1MB

Write-Host "`nPackage created successfully!" -ForegroundColor Green
Write-Host "============================" -ForegroundColor Green
Write-Host "`nPortable package: OneMonShot-Portable\" -ForegroundColor Cyan
Write-Host "Size: $([math]::Round($packageSize, 1)) MB" -ForegroundColor White
Write-Host "`nTo distribute:" -ForegroundColor Yellow
Write-Host "  • Zip the 'OneMonShot-Portable' folder" -ForegroundColor Green
Write-Host "  • Users extract and run 'OneMonShot.bat'" -ForegroundColor Green
Write-Host "  • Automatic .NET runtime check included" -ForegroundColor Green

$testRun = Read-Host "`nTest the package now? (y/n)"
if ($testRun -eq 'y' -or $testRun -eq 'Y') {
    Write-Host "`nTesting package..." -ForegroundColor Yellow
    Start-Process -FilePath "$targetDir\OneMonShot.bat"
}

Write-Host "`nDistribution package ready!" -ForegroundColor Cyan