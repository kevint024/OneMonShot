@echo off
title OneMonShot - Build Standalone Executable

echo OneMonShot - Building Standalone Executable
echo =============================================
echo.

REM Check if .NET is available
dotnet --version >nul 2>&1
if %errorlevel% neq 0 (
    echo Error: .NET is not installed or not found in PATH
    echo Please install .NET 8 from: https://dotnet.microsoft.com/download
    pause
    exit /b 1
)

echo Checking .NET installation...
for /f "tokens=*" %%i in ('dotnet --version') do set DOTNET_VERSION=%%i
echo .NET Version: %DOTNET_VERSION%
echo.

REM Clean previous builds
echo Cleaning previous builds...
if exist "..\bin" rmdir /s /q "..\bin"
if exist "..\obj" rmdir /s /q "..\obj"
if exist "..\Release" rmdir /s /q "..\Release"
mkdir "..\Release"
echo Cleaned directories
echo.

REM Build self-contained executable
echo Building self-contained executable...
echo This may take a few minutes as it includes the .NET runtime...
echo.

dotnet publish --configuration Release --self-contained true --runtime win-x64 --output "..\Release" --property:PublishSingleFile=true --property:IncludeNativeLibrariesForSelfExtract=true

if %errorlevel% neq 0 (
    echo.
    echo Build failed!
    pause
    exit /b 1
)

echo.
echo =============================
echo Build completed successfully!
echo =============================
echo.
echo Standalone executable created: Release\OneMonShot.exe
echo.
echo This executable:
echo   • Runs on any Windows 10+ machine
echo   • No .NET runtime installation required  
echo   • Can be distributed as a single file
echo   • Includes all necessary dependencies
echo.

set /p RUN_EXE="Would you like to test the executable now? (y/n): "
if /i "%RUN_EXE%"=="y" (
    echo.
    echo Starting OneMonShot executable...
    start Release\OneMonShot.exe
)

echo.
echo Executable build complete!
echo You can now distribute 'OneMonShot.exe' to any Windows computer!
pause