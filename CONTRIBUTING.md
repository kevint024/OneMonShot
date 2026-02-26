# Contributing to OneMonShot

Thank you for considering contributing to OneMonShot! We welcome contributions from the community.

## 🚀 Quick Start

### Prerequisites
- .NET 8 SDK
- Windows 10 or later
- Git
- Code editor (Visual Studio, VS Code, etc.)

### Setup Development Environment
```bash
# Clone the repository
git clone https://github.com/yourusername/OneMonShot.git
cd OneMonShot

# Build and run
.\build.ps1
.\run.ps1
```

## 🐛 Reporting Bugs

Before creating bug reports, please check the existing issues. When creating a bug report, include:

- **Clear title** describing the problem
- **Detailed description** of what happened vs. what you expected
- **Steps to reproduce** the issue
- **Screenshots** if applicable
- **System information**: Windows version, .NET version, monitor setup
- **Log output** if available

## 💡 Suggesting Features

Feature suggestions are welcome! Please:
- Check if the feature has already been requested
- Clearly describe the use case and benefit
- Consider the scope and complexity
- Be open to discussion and feedback

## 🔧 Development Guidelines

### Code Style
- Follow C# coding conventions
- Use meaningful variable and method names
- Add comments for complex logic
- Keep methods focused and concise

### Project Structure
```
OneMonShot/
├── OneMonShot.csproj      # Project file
├── Program.cs             # Entry point
├── MainForm.cs            # Main UI and logic
├── scripts/               # Build and deployment scripts
├── docs/                  # Documentation
└── .github/               # GitHub workflows and templates
```

### Commit Guidelines
- Use clear, descriptive commit messages
- Follow the format: `type(scope): description`
- Types: `feat`, `fix`, `docs`, `style`, `refactor`, `test`, `chore`
- Examples:
  - `feat: add hotkey support for screenshot capture`
  - `fix: resolve multi-monitor detection issue`
  - `docs: update installation instructions`

## 📝 Pull Request Process

1. **Fork** the repository and create a feature branch
2. **Make changes** following the coding guidelines
3. **Test** your changes thoroughly
4. **Update documentation** if needed
5. **Create pull request** with:
   - Clear title and description
   - Reference to related issues
   - Screenshots/demo if UI changes
   - Testing details

### Pull Request Template
```markdown
## Description
Brief description of changes

## Type of Change
- [ ] Bug fix
- [ ] New feature
- [ ] Documentation update
- [ ] Performance improvement
- [ ] Code refactoring

## Testing
- [ ] Tested on Windows 10
- [ ] Tested on Windows 11
- [ ] Tested with multiple monitors
- [ ] Tested with single monitor
- [ ] Tested custom save locations
- [ ] Tested file naming patterns

## Screenshots/Demo
If applicable, add screenshots or GIFs

## Checklist
- [ ] Code follows project style guidelines
- [ ] Self-review completed
- [ ] Documentation updated
- [ ] No breaking changes (or clearly documented)
```

## 🏗️ Building and Testing

### Development Build
```powershell
.\build.ps1              # Build application
.\run.ps1                # Run application
```

### Distribution Testing
```powershell
.\package.ps1            # Create portable package
.\create-zip.ps1         # Create distribution ZIP

# Test the package
.\OneMonShot-Portable\OneMonShot.bat
```

### Manual Testing Checklist
- [ ] Application starts without errors
- [ ] All monitors detected correctly
- [ ] Screenshot capture works on each monitor
- [ ] Batch capture works for all monitors
- [ ] Save location changes persist
- [ ] File naming patterns work correctly
- [ ] Auto-open File Explorer toggle works
- [ ] Settings save and load properly
- [ ] UI scales correctly on high-DPI displays

## 📚 Documentation

### Types of Documentation
- **README.md**: Main project documentation
- **docs/**: Detailed guides and API documentation  
- **Code comments**: Inline documentation for complex logic
- **CHANGELOG.md**: Version history and changes

### Documentation Standards
- Use clear, beginner-friendly language
- Include code examples where helpful
- Add screenshots for UI features
- Keep formatting consistent
- Update version numbers and dates

## 🎯 Areas for Contribution

### High Priority
- Performance optimizations
- Additional image format support (JPEG, BMP, TIFF)
- Hotkey/keyboard shortcut support
- System tray functionality
- Accessibility improvements

### Medium Priority
- Screenshot annotation tools
- Cloud storage integration
- Scheduled screenshot functionality
- Multi-language support
- Dark theme support

### Low Priority
- Advanced editing features
- Plugin system
- Network sharing capabilities
- Screenshot comparison tools

## 🔄 Release Process

### Version Numbering
We use [Semantic Versioning](https://semver.org/):
- **MAJOR**: Breaking changes
- **MINOR**: New features (backward compatible)
- **PATCH**: Bug fixes (backward compatible)

### Release Checklist
1. Update version numbers in project files
2. Update CHANGELOG.md
3. Test all features thoroughly
4. Create release tag: `git tag v1.x.x`
5. Push tag to trigger GitHub Actions release
6. Verify release artifacts and documentation

## ❓ Getting Help

- **Questions**: Use [GitHub Discussions](../../discussions)
- **Issues**: Use [GitHub Issues](../../issues)
- **Documentation**: Check the [docs/](docs/) folder
- **Examples**: See existing code patterns

## 🏆 Recognition

Contributors will be acknowledged in:
- CHANGELOG.md for their contributions
- GitHub contributor statistics
- Special recognition for significant contributions

## 📄 Code of Conduct

Be respectful, inclusive, and constructive in all interactions. We want OneMonShot to be a welcoming project for contributors of all backgrounds and experience levels.

---

Thank you for contributing to OneMonShot! 🎉