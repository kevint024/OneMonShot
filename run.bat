@echo off
title OneMonShot - Multi-Monitor Screenshot Tool

echo Starting OneMonShot...
echo.

REM Check if .NET is available
dotnet --version >nul 2>&1
if %errorlevel% neq 0 (
    echo Error: .NET is not installed or not found in PATH
    echo Please install .NET 8 from: https://dotnet.microsoft.com/download
    pause
    exit /b 1
)

REM Run the application
dotnet run --configuration Release

if %errorlevel% neq 0 (
    echo.
    echo Application exited with error code: %errorlevel%
    pause
)