# 📸 OneMonShot

> **Simple, powerful multi-monitor screenshot tool for Windows**

[![Downloads](https://img.shields.io/github/downloads/kevint024/OneMonShot/total.svg)](https://github.com/kevint024/OneMonShot/releases)
[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](https://opensource.org/licenses/MIT)
[![.NET](https://img.shields.io/badge/.NET-8.0-blue.svg)](https://dotnet.microsoft.com/download/dotnet/8.0)

OneMonShot is a lightweight Windows application that makes taking screenshots of multiple monitors effortless. Whether you have a single display or a complex multi-monitor setup, OneMonShot provides precise control over which screen to capture with custom save locations and flexible file naming.

## ✨ Features

### 🖥️ **Multi-Monitor Support**
- **Auto-detect all monitors** with detailed information (name, resolution, position)
- **Individual capture** - Select and screenshot specific monitors
- **Batch capture** - Screenshot all monitors with one click
- **Primary monitor highlighting** - Easily identify your main display

### 💾 **Flexible Saving Options**  
- **Custom save locations** with folder browser
- **Smart file naming** with variables and live preview
- **Persistent settings** - Remembers your preferences
- **Auto-open File Explorer** option (toggleable)

### 🎯 **Professional Quality**
- **High-resolution capture** - Pixel-perfect screenshots  
- **PNG format** - Lossless compression for crisp images
- **Instant preview** - See your screenshot immediately
- **Error handling** - Graceful failure recovery

### ⚡ **User Experience**
- **Clean, intuitive interface** - No learning curve
- **Portable distribution** - No installation required
- **High-DPI awareness** - Looks great on all displays
- **Lightweight** - Minimal resource usage

## 🚀 Quick Start

### Option 1: Portable Package (Recommended)
1. **Download** the latest `OneMonShot-Portable.zip` from [Releases](../../releases)
2. **Extract** to any folder on your computer
3. **Run** `OneMonShot.bat` to launch the application
4. **Start taking screenshots!**

### Option 2: Build from Source
```powershell
# Prerequisites: .NET 8 SDK
git clone https://github.com/yourusername/OneMonShot.git
cd OneMonShot
.\build.ps1
.\run.ps1
```

## 📖 How to Use

### Basic Screenshot Workflow
1. **Launch OneMonShot** - All connected monitors are automatically detected
2. **Select a monitor** from the list (shows name, resolution, position)
3. **Click "Capture Selected"** or use "Capture All Monitors"
4. **Preview your screenshot** in the built-in viewer
5. **Save** - Your screenshot is saved with your custom settings

### Customizing Save Settings

#### **Custom Save Location**
1. Click **"Browse"** next to the save location
2. Select your preferred folder
3. Settings are saved automatically for future use

#### **Custom File Naming**
1. Click **"Rename Format"** to open the naming dialog
2. Use variables in your filename pattern:
   - `{M}` - Monitor number (1, 2, 3...)
   - `{TIMESTAMP}` - Full timestamp (20241201_143022)
   - `{YYYY}` - Year (2024)
   - `{MM}` - Month (12)
   - `{DD}` - Day (01)
   - `{HH}` - Hour (14)
   - `{mm}` - Minute (30)
   - `{ss}` - Second (22)
3. **Live preview** shows how your files will be named
4. Example: `Screenshot_Monitor{M}_{YYYY}-{MM}-{DD}_{HH}-{mm}-{ss}.png`

#### **File Explorer Auto-Open**
- **Toggle the checkbox** to enable/disable automatic folder opening
- When enabled, File Explorer opens to your screenshot after saving
- Perfect for quick sharing or editing workflows

## 🛠️ System Requirements

| Component | Requirement |
|-----------|-------------|
| **OS** | Windows 10 or later |
| **Framework** | .NET 8.0 Runtime (auto-installed if missing) |
| **RAM** | 50MB available memory |
| **Storage** | 10MB for application files |
| **Displays** | Any number of connected monitors |

## 📁 Project Structure

```
OneMonShot/
├── 📄 OneMonShot.csproj         # Project configuration
├── 📄 Program.cs                # Application entry point  
├── 📄 MainForm.cs               # Main UI and screenshot logic
├── 📁 scripts/                  # Build and deployment automation
│   ├── build.ps1                # Development build
│   ├── create-package.ps1       # Portable package creation
│   ├── create-zip.ps1          # Distribution packaging  
│   └── build-exe.ps1           # Framework-dependent build
├── 📁 docs/                    # Documentation and guides
├── 📁 .github/                 # GitHub workflows and templates
└── 📄 README.md                # This file
```

## 🔨 Building and Development

### Development Commands
```powershell
.\build.ps1              # Build for development
.\run.ps1                # Run the application  
.\package.ps1            # Create portable package
.\create-zip.ps1         # Create distribution ZIP
```

### Advanced Build Options
```powershell
# Framework-dependent build (smaller, requires .NET 8)
.\scripts\build-exe.ps1

# Self-contained package (larger, includes .NET 8)
.\scripts\create-package.ps1

# Debug build with symbols
dotnet build --configuration Debug
```

### Testing Checklist
- [ ] All monitors detected correctly
- [ ] Screenshots capture full resolution
- [ ] Custom save locations work
- [ ] File naming variables substitute properly  
- [ ] Settings persist between sessions
- [ ] Auto-open File Explorer toggles correctly

## 🤝 Contributing

We welcome contributions from the community! Whether it's bug fixes, new features, or documentation improvements, your help makes OneMonShot better for everyone.

### Quick Contribution Guide
1. **Fork** this repository
2. **Create** a feature branch (`git checkout -b feature/amazing-feature`)
3. **Make** your changes following our [coding guidelines](CONTRIBUTING.md)
4. **Test** thoroughly on Windows
5. **Submit** a pull request with detailed description

See our [Contributing Guide](CONTRIBUTING.md) for detailed information.

### Areas for Contribution
- 🔥 **High Priority**: Performance optimizations, additional image formats (JPEG, BMP), hotkey support
- 📈 **Medium Priority**: System tray functionality, screenshot annotation, cloud storage integration  
- 💡 **Ideas Welcome**: Dark theme, multi-language support, advanced editing features

## 📊 Version History

See [CHANGELOG.md](CHANGELOG.md) for detailed version history and release notes.

## 🐛 Known Issues & Troubleshooting

### Common Issues
- **Monitor not detected**: Restart OneMonShot after connecting new displays
- **Save permission errors**: Ensure write access to selected save folder
- **Blurry screenshots on high-DPI**: Application handles DPI scaling automatically

### Getting Help  
- 📋 **Bug Reports**: Use our [bug report template](../../issues/new?template=bug_report.md)
- 💡 **Feature Requests**: Use our [feature request template](../../issues/new?template=feature_request.md)  
- ❓ **Questions**: Check [GitHub Discussions](../../discussions) or create a [support issue](../../issues/new?template=question.md)

## 📄 License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

## 🙏 Acknowledgments

- Built with ❤️ using .NET 8 and Windows Forms
- Inspired by the need for simple, reliable multi-monitor screenshot tools
- Built with *help* from Claude Sonnet

## ⭐ Support the Project

If OneMonShot helps streamline your workflow:
- 🌟 **Star this repository** to show your support  
- 🐛 **Report bugs** to help us improve
- 💡 **Suggest features** for future development
- 🤝 **Contribute code** to make it even better
- 📢 **Share with others** who could benefit

---

<div align="center">

**[Download Latest Release](../../releases) • [View Documentation](docs/) • [Report Issue](../../issues) • [Contribute](CONTRIBUTING.md)**

Made with 💻 for the Windows community

</div>
