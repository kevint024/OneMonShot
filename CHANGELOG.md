# Changelog

All notable changes to OneMonShot will be documented in this file.

The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.0.0/),
and this project adheres to [Semantic Versioning](https://semver.org/spec/v2.0.0.html).

## [1.0.0] - 2026-02-26

### Added
- Initial release of OneMonShot
- Multi-monitor detection and selection
- Full-screen screenshot capture for individual monitors
- Batch capture for all monitors simultaneously
- Live preview of captured screenshots
- Custom save location with persistent memory
- Custom file naming patterns with variable substitution
- Auto-open File Explorer toggle option
- High-DPI display support
- Modern Windows Forms UI with clean design
- Comprehensive settings persistence
- Portable distribution package
- Smart launcher with .NET runtime detection
- Progress tracking for batch operations
- Monitor information display (resolution, position, primary status)

### File Naming Variables
- `{M}` - Monitor number
- `{MONITOR}` - Padded monitor number  
- `{YYYY}`, `{YY}` - Year formats
- `{MONTH}`, `{DD}` - Month and day
- `{HH}`, `{mm}`, `{SS}` - Time components
- `{YYYYMMDD}`, `{HHMMSS}`, `{TIMESTAMP}` - Combined formats

### Technical Features
- .NET 8 Windows Forms application
- Native Windows screen capture APIs
- XML-based settings persistence in AppData
- Single-file portable deployment option
- Automatic dependency detection and guidance

### Distribution
- Portable ZIP package for easy sharing
- Smart launcher with runtime checking
- No installation required
- Runs from any folder location
- User-friendly setup guidance

---

*For older versions and detailed commit history, see the [commit log](../../commits/main).*