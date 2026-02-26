@echo off
title OneMonShot - Multi-Monitor Screenshot Tool

if not exist "..\Release\OneMonShot.exe" (
    echo Error: OneMonShot.exe not found!
    echo.
    echo Please build the standalone executable first:
    echo   • Run: scripts\build-exe.bat
    echo   • Or: scripts\build-exe.ps1
    echo.
    pause
    exit /b 1
)

echo Starting OneMonShot...
start "..\Release\OneMonShot.exe"