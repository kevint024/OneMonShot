# OneMonShot 📸

**Multi-Monitor Screenshot Tool for Windows**

[![.NET](https://img.shields.io/badge/.NET-8.0-blue)](https://dotnet.microsoft.com/download/dotnet/8.0)
[![Windows](https://img.shields.io/badge/Windows-10%2B-blue)](https://www.microsoft.com/windows/)
[![License](https://img.shields.io/badge/License-MIT-green.svg)](LICENSE)

> A powerful, user-friendly Windows application for capturing full-screen screenshots across multiple monitors with advanced customization options.

![OneMonShot Screenshot](docs/screenshot-main.png)

## ✨ Features

- 🖥️ **Multi-Monitor Support** - Detect and capture from any connected monitor
- 📸 **Selective Capture** - Choose specific monitors or capture all at once  
- 🎯 **Custom Save Location** - Set your preferred save folder with persistent memory
- 🏷️ **Custom File Naming** - Fully customizable filename patterns with variables
- 👁️ **Live Preview** - See captured screenshots before saving
- 🔧 **Auto-Open Toggle** - Control whether File Explorer opens after capture
- ⚡ **High Performance** - Native Windows API for optimal speed and quality
- 💾 **Persistent Settings** - All preferences remembered between sessions
- 🎨 **Modern UI** - Clean, intuitive Windows Forms interface

## 🚀 Quick Start

### For Users (No Technical Knowledge Required)

1. **Download** the latest release from [Releases](../../releases)
2. **Extract** the ZIP file to any folder
3. **Run** `OneMonShot.bat` - that's it!

The launcher automatically checks for .NET 8 and provides installation guidance if needed.

### For Developers

```bash
git clone https://github.com/yourusername/OneMonShot.git
cd OneMonShot

# Quick start
.\build.ps1          # Build the application
.\run.ps1            # Run the application

# Distribution
.\package.ps1        # Create portable package
.\create-zip.ps1     # Create release ZIP
```

## 📦 Installation

### Option 1: Portable Release (Recommended)
- Download `OneMonShot-Portable.zip` from [Releases](../../releases)
- Extract anywhere and run `OneMonShot.bat`
- No installation required, runs from any folder

### Option 2: Build from Source
- Install [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- Clone this repository
- Run `.\build.ps1` or use the build commands above

## 🎮 Usage

### Taking Screenshots

1. **Launch OneMonShot** - All connected monitors are automatically detected
2. **Select Monitor** - Choose from the list showing resolution, position, and status
3. **Capture Options**:
   - **Single Monitor**: Select and click "Capture Selected"
   - **All Monitors**: Click "Capture All" for batch capture
4. **Preview & Save** - Screenshots appear in preview and save automatically

### Customization

#### Save Location
- Click **"Change Save Location"** to browse and select your preferred folder
- Setting is automatically remembered for future sessions

#### File Naming
- Click **"Change File Format"** to customize filename patterns
- Use variables like `{M}` (monitor), `{TIMESTAMP}`, `{YYYY}`, etc.
- Live preview shows exactly how files will be named
- Examples:
  - `Screenshot_Monitor{M}_{TIMESTAMP}.png` → `Screenshot_Monitor1_20260226_143022.png`
  - `Screen{MONITOR}_{YYYY}-{MM}-{DD}.png` → `Screen01_2026-02-26.png`

#### File Explorer Control  
- Toggle **"Auto-open File Explorer after capture"** checkbox
- Enable for immediate file access, disable for clean batch workflows

## 🛠️ Development

### Prerequisites
- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- Windows 10 or later
- Any IDE (Visual Studio, VS Code, JetBrains Rider)

### Build Scripts
```powershell
# Development build
.\build.ps1

# Create portable distribution
.\create-package.ps1

# Create release ZIP
.\create-zip.ps1
```

### Project Structure
```
OneMonShot/
├── OneMonShot.csproj      # Project file
├── Program.cs             # Application entry point
├── MainForm.cs            # Main UI and logic
├── README.md              # This file
├── build.ps1              # Development build script
├── create-package.ps1     # Distribution package creator
├── create-zip.ps1         # Release ZIP creator
└── docs/                  # Documentation and screenshots
```

## 🔧 Technical Details

### File Naming Variables
| Variable | Description | Example |
|----------|-------------|---------|
| `{M}` | Monitor number | `1`, `2`, `3` |
| `{MONITOR}` | Padded monitor number | `01`, `02`, `03` |
| `{YYYY}` | Full year | `2026` |
| `{YY}` | Short year | `26` |
| `{MONTH}` | Month | `01`-`12` |
| `{DD}` | Day | `01`-`31` |
| `{HH}` | Hour (24h) | `00`-`23` |
| `{mm}` | Minute | `00`-`59` |
| `{SS}` | Second | `00`-`59` |
| `{YYYYMMDD}` | Date stamp | `20260226` |
| `{HHMMSS}` | Time stamp | `143022` |
| `{TIMESTAMP}` | Full timestamp | `20260226_143022` |

### System Requirements
- **OS**: Windows 10 (1803) or later
- **Runtime**: .NET 8 Desktop Runtime
- **Memory**: 50MB RAM
- **Storage**: 200KB (portable version)
- **Permissions**: User-level (no admin required)

## 🤝 Contributing

Contributions are welcome! Please feel free to submit a Pull Request. For major changes, please open an issue first to discuss what you would like to change.

1. Fork the Project
2. Create your Feature Branch (`git checkout -b feature/AmazingFeature`)
3. Commit your Changes (`git commit -m 'Add some AmazingFeature'`)
4. Push to the Branch (`git push origin feature/AmazingFeature`)
5. Open a Pull Request

## 📄 License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

## 🙋‍♂️ Support

- 📖 **Documentation**: Check the [Wiki](../../wiki) for detailed guides
- 🐛 **Bug Reports**: Use [Issues](../../issues) to report bugs
- 💡 **Feature Requests**: Use [Issues](../../issues) with the enhancement label
- 💬 **Discussions**: Use [Discussions](../../discussions) for questions and ideas

## 🎯 Roadmap

- [ ] Additional image formats (JPEG, BMP, TIFF)
- [ ] Hotkey support for quick captures
- [ ] Screenshot annotations and markup
- [ ] Cloud storage integration
- [ ] Multi-language support
- [ ] System tray functionality
- [ ] Scheduled screenshots

## 🏆 Acknowledgments

- Built with [.NET 8](https://dotnet.microsoft.com/download/dotnet/8.0) and Windows Forms
- Icon design inspiration from modern screenshot tools
- Thanks to all contributors and users for feedback and suggestions

---

**OneMonShot** - Making multi-monitor screenshots simple and efficient! 📸🖥️

*If you find this tool useful, please consider giving it a ⭐ on GitHub!*