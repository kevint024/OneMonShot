# GitHub Integration Setup for OneMonShot

## Repository Setup Checklist

After creating your GitHub repository, complete these steps:

### 1. Repository Settings
- [ ] Enable Issues and Discussions
- [ ] Set default branch to `main`
- [ ] Enable branch protection rules for `main`
- [ ] Configure merge settings (squash and merge recommended)

### 2. Repository Secrets (for GitHub Actions)
If you plan to use the automated release workflow:
- [ ] Add `GITHUB_TOKEN` (automatically available)
- [ ] Consider adding code signing certificates for releases

### 3. Labels Setup
Create these labels for better issue management:
- `bug` (red) - Something isn't working  
- `enhancement` (blue) - New feature or request
- `documentation` (green) - Improvements to documentation
- `good first issue` (purple) - Good for newcomers
- `help wanted` (yellow) - Extra attention is needed
- `question` (pink) - Further information is requested
- `duplicate` (gray) - This issue or pull request already exists
- `wontfix` (white) - This will not be worked on

### 4. GitHub Pages (Optional)
- [ ] Enable GitHub Pages from `/docs` folder
- [ ] Set up custom domain if desired
- [ ] Configure documentation builds

### 5. Release Configuration
- [ ] Create initial release (v1.0.0)
- [ ] Upload OneMonShot-Portable.zip as release asset
- [ ] Configure release template in repository settings

## Repository Links to Update

After creating the repository, update these files to replace placeholder URLs:

1. **README.md** - Update all `yourusername` placeholders:
   - Badge URLs
   - Release links
   - Issue templates links

2. **CONTRIBUTING.md** - Update repository-specific links

3. **GitHub Actions workflow** - Verify repository context variables

### Find and Replace
Search for: `yourusername`  
Replace with: `your-actual-username`

## Marketing Setup

### Repository Description
```
Simple, powerful multi-monitor screenshot tool for Windows. No installation required - just download, extract, and run!
```

### Topics/Tags
Add these repository topics:
- `screenshot`
- `multi-monitor`  
- `windows`
- `dotnet`
- `csharp`
- `portable`
- `screenshot-tool`
- `windows-forms`
- `desktop-application`

### Social Preview
- Upload a screenshot of OneMonShot in action
- Include the repository description and key features

## Documentation Structure

Recommended documentation in `/docs`:
- Installation guide
- User manual with screenshots
- Developer setup guide
- API documentation (if applicable)
- FAQ and troubleshooting

## Community Guidelines

### Welcome Message (Repository Description)
"Welcome to OneMonShot! 🎉 We're excited to have you here. Whether you're reporting bugs, suggesting features, or contributing code, your involvement makes this project better for everyone."

### Contributing Recognition
- Set up All Contributors integration
- Acknowledge contributors in releases
- Consider contributor rewards/recognition

## Automation Opportunities

Future GitHub Actions you might add:
- Auto-label PRs based on changed files
- Automated testing on multiple Windows versions
- Code quality checks (linting, security scanning)
- Automated documentation generation
- Issue stale bot for old issues

---

🚀 **Ready to publish?** Double-check all placeholder URLs are updated, then push to GitHub!