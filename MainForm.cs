using System.Drawing.Imaging;
using System.Runtime.InteropServices;

namespace OneMonShot;

public partial class MainForm : Form
{
    private List<MonitorInfo> monitors = new();
    private Button btnRefresh;
    private ListView listViewMonitors;
    private Button btnCapture;
    private Button btnCaptureAll;
    private Button btnChangeSaveLocation;
    private Button btnChangeFileFormat;
    private Label lblSaveLocation;
    private Label lblFileFormat;
    private CheckBox chkAutoOpenExplorer;
    private PictureBox previewBox;
    private Label statusLabel;
    private ProgressBar progressBar;
    private string saveLocation;
    private string fileNameFormat;
    private bool autoOpenExplorer;

    public MainForm()
    {
        InitializeComponent();
        RefreshMonitors();
    }

    private void InitializeComponent()
    {
        Text = "OneMonShot - Multi-Monitor Screenshot Tool";
        Size = new Size(800, 600);
        StartPosition = FormStartPosition.CenterScreen;
        MinimumSize = new Size(600, 400);

        // Create controls
        var mainPanel = new TableLayoutPanel
        {
            Dock = DockStyle.Fill,
            RowCount = 8,
            ColumnCount = 2,
            Padding = new Padding(10)
        };
        
        // Row and column styles
        mainPanel.RowStyles.Add(new RowStyle(SizeType.AutoSize)); // Title
        mainPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 25F)); // Monitor list
        mainPanel.RowStyles.Add(new RowStyle(SizeType.AutoSize)); // Buttons
        mainPanel.RowStyles.Add(new RowStyle(SizeType.AutoSize)); // Save location
        mainPanel.RowStyles.Add(new RowStyle(SizeType.AutoSize)); // File format
        mainPanel.RowStyles.Add(new RowStyle(SizeType.AutoSize)); // Options
        mainPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 75F)); // Preview
        mainPanel.RowStyles.Add(new RowStyle(SizeType.AutoSize)); // Status
        
        mainPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        mainPanel.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));

        // Title
        var titleLabel = new Label
        {
            Text = "Select Monitor for Screenshot",
            Font = new Font("Segoe UI", 12, FontStyle.Bold),
            Anchor = AnchorStyles.Left | AnchorStyles.Right,
            TextAlign = ContentAlignment.MiddleCenter
        };
        mainPanel.Controls.Add(titleLabel, 0, 0);
        mainPanel.SetColumnSpan(titleLabel, 2);

        // Monitor list
        listViewMonitors = new ListView
        {
            View = View.Details,
            FullRowSelect = true,
            GridLines = true,
            Dock = DockStyle.Fill
        };
        listViewMonitors.Columns.Add("Monitor", 80);
        listViewMonitors.Columns.Add("Name", 200);
        listViewMonitors.Columns.Add("Resolution", 120);
        listViewMonitors.Columns.Add("Position", 120);
        listViewMonitors.Columns.Add("Primary", 60);
        
        mainPanel.Controls.Add(listViewMonitors, 0, 1);
        mainPanel.SetColumnSpan(listViewMonitors, 2);

        // Buttons panel
        var buttonPanel = new FlowLayoutPanel
        {
            FlowDirection = FlowDirection.LeftToRight,
            Dock = DockStyle.Fill,
            Padding = new Padding(5)
        };

        btnRefresh = new Button
        {
            Text = "Refresh Monitors",
            Size = new Size(120, 30),
            Margin = new Padding(5)
        };
        btnRefresh.Click += BtnRefresh_Click;

        btnCapture = new Button
        {
            Text = "Capture Selected",
            Size = new Size(120, 30),
            Margin = new Padding(5),
            Enabled = false
        };
        btnCapture.Click += BtnCapture_Click;

        btnCaptureAll = new Button
        {
            Text = "Capture All",
            Size = new Size(100, 30),
            Margin = new Padding(5)
        };
        btnCaptureAll.Click += BtnCaptureAll_Click;

        btnChangeSaveLocation = new Button
        {
            Text = "Change Save Location",
            Size = new Size(140, 30),
            Margin = new Padding(5)
        };
        btnChangeSaveLocation.Click += BtnChangeSaveLocation_Click;

        btnChangeFileFormat = new Button
        {
            Text = "Change File Format",
            Size = new Size(130, 30),
            Margin = new Padding(5)
        };
        btnChangeFileFormat.Click += BtnChangeFileFormat_Click;

        buttonPanel.Controls.AddRange(new Control[] { btnRefresh, btnCapture, btnCaptureAll, btnChangeSaveLocation, btnChangeFileFormat });
        mainPanel.Controls.Add(buttonPanel, 0, 2);
        mainPanel.SetColumnSpan(buttonPanel, 2);

        // Save location panel
        var saveLocationPanel = new Panel
        {
            Height = 25,
            Dock = DockStyle.Fill
        };

        var lblSaveLocationTitle = new Label
        {
            Text = "Save Location:",
            Dock = DockStyle.Left,
            Width = 90,
            TextAlign = ContentAlignment.MiddleLeft,
            Font = new Font("Segoe UI", 9, FontStyle.Bold)
        };

        lblSaveLocation = new Label
        {
            Dock = DockStyle.Fill,
            TextAlign = ContentAlignment.MiddleLeft,
            ForeColor = Color.DarkBlue,
            Text = Environment.GetFolderPath(Environment.SpecialFolder.Desktop)
        };

        saveLocationPanel.Controls.AddRange(new Control[] { lblSaveLocationTitle, lblSaveLocation });
        mainPanel.Controls.Add(saveLocationPanel, 0, 3);
        mainPanel.SetColumnSpan(saveLocationPanel, 2);

        // File format panel
        var fileFormatPanel = new Panel
        {
            Height = 25,
            Dock = DockStyle.Fill
        };

        var lblFileFormatTitle = new Label
        {
            Text = "File Format:",
            Dock = DockStyle.Left,
            Width = 90,
            TextAlign = ContentAlignment.MiddleLeft,
            Font = new Font("Segoe UI", 9, FontStyle.Bold)
        };

        lblFileFormat = new Label
        {
            Dock = DockStyle.Fill,
            TextAlign = ContentAlignment.MiddleLeft,
            ForeColor = Color.DarkGreen,
            Text = "Screenshot_Monitor{M}_{TIMESTAMP}.png"
        };

        fileFormatPanel.Controls.AddRange(new Control[] { lblFileFormatTitle, lblFileFormat });
        mainPanel.Controls.Add(fileFormatPanel, 0, 4);
        mainPanel.SetColumnSpan(fileFormatPanel, 2);

        // Options panel
        var optionsPanel = new Panel
        {
            Height = 25,
            Dock = DockStyle.Fill
        };

        chkAutoOpenExplorer = new CheckBox
        {
            Text = "Auto-open File Explorer after capture",
            Dock = DockStyle.Left,
            AutoSize = true,
            Checked = true,
            ForeColor = Color.DarkSlateBlue
        };
        chkAutoOpenExplorer.CheckedChanged += (s, e) => 
        {
            autoOpenExplorer = chkAutoOpenExplorer.Checked;
            SaveSettings();
            statusLabel.Text = autoOpenExplorer ? "File Explorer will open after capture" : "File Explorer will not open after capture";
        };

        optionsPanel.Controls.Add(chkAutoOpenExplorer);
        mainPanel.Controls.Add(optionsPanel, 0, 5);
        mainPanel.SetColumnSpan(optionsPanel, 2);

        // Preview
        previewBox = new PictureBox
        {
            Dock = DockStyle.Fill,
            SizeMode = PictureBoxSizeMode.Zoom,
            BorderStyle = BorderStyle.FixedSingle
        };
        mainPanel.Controls.Add(previewBox, 0, 6);
        mainPanel.SetColumnSpan(previewBox, 2);

        // Status bar
        var statusPanel = new Panel
        {
            Height = 25,
            Dock = DockStyle.Fill
        };
        
        statusLabel = new Label
        {
            Text = "Ready",
            Dock = DockStyle.Left,
            TextAlign = ContentAlignment.MiddleLeft,
            Width = 200
        };

        progressBar = new ProgressBar
        {
            Dock = DockStyle.Right,
            Width = 200,
            Visible = false
        };

        statusPanel.Controls.AddRange(new Control[] { statusLabel, progressBar });
        mainPanel.Controls.Add(statusPanel, 0, 7);
        mainPanel.SetColumnSpan(statusPanel, 2);

        Controls.Add(mainPanel);

        // Event handlers
        listViewMonitors.SelectedIndexChanged += ListViewMonitors_SelectedIndexChanged;

        // Load settings after UI is created
        LoadSettings();
    }

    private void LoadSettings()
    {
        try
        {
            var settingsDirectory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "OneMonShot");
            var settingsFile = Path.Combine(settingsDirectory, "settings.txt");
            
            // Default values
            saveLocation = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            fileNameFormat = "Screenshot_Monitor{M}_{TIMESTAMP}.png";
            autoOpenExplorer = true;
            autoOpenExplorer = true;
            
            if (File.Exists(settingsFile))
            {
                var lines = File.ReadAllLines(settingsFile);
                
                if (lines.Length > 0 && Directory.Exists(lines[0].Trim()))
                {
                    saveLocation = lines[0].Trim();
                }
                
                if (lines.Length > 1 && !string.IsNullOrWhiteSpace(lines[1]))
                {
                    fileNameFormat = lines[1].Trim();
                }
                
                if (lines.Length > 2 && bool.TryParse(lines[2], out bool openExplorer))
                {
                    autoOpenExplorer = openExplorer;
                }
            }
        }
        catch
        {
            saveLocation = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            fileNameFormat = "Screenshot_Monitor{M}_{YYYYMMDD}_{HHMMSS}.png";
        }

        // Update UI if controls exist
        if (lblSaveLocation != null)
        {
            lblSaveLocation.Text = saveLocation;
        }
        
        if (lblFileFormat != null)
        {
            lblFileFormat.Text = fileNameFormat;
        }
        
        if (chkAutoOpenExplorer != null)
        {
            chkAutoOpenExplorer.Checked = autoOpenExplorer;
        }
    }

    private void SaveSettings()
    {
        try
        {
            var settingsDirectory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "OneMonShot");
            Directory.CreateDirectory(settingsDirectory);
            
            var settingsFile = Path.Combine(settingsDirectory, "settings.txt");
            var settingsContent = new[] { saveLocation, fileNameFormat, autoOpenExplorer.ToString() };
            File.WriteAllLines(settingsFile, settingsContent);
        }
        catch (Exception ex)
        {
            statusLabel.Text = $"Could not save settings: {ex.Message}";
        }
    }

    private void RefreshMonitors()
    {
        monitors.Clear();
        listViewMonitors.Items.Clear();

        var screens = Screen.AllScreens;
        for (int i = 0; i < screens.Length; i++)
        {
            var screen = screens[i];
            var monitor = new MonitorInfo
            {
                Index = i,
                Screen = screen,
                DeviceName = screen.DeviceName,
                Bounds = screen.Bounds,
                WorkingArea = screen.WorkingArea,
                IsPrimary = screen.Primary
            };

            monitors.Add(monitor);

            var item = new ListViewItem($"Monitor {i + 1}");
            item.SubItems.Add(monitor.DeviceName);
            item.SubItems.Add($"{monitor.Bounds.Width} x {monitor.Bounds.Height}");
            item.SubItems.Add($"({monitor.Bounds.X}, {monitor.Bounds.Y})");
            item.SubItems.Add(monitor.IsPrimary ? "Yes" : "No");
            item.Tag = monitor;

            listViewMonitors.Items.Add(item);
        }

        statusLabel.Text = $"Found {monitors.Count} monitor(s)";
    }

    private void ListViewMonitors_SelectedIndexChanged(object? sender, EventArgs e)
    {
        btnCapture.Enabled = listViewMonitors.SelectedItems.Count > 0;
    }

    private void BtnRefresh_Click(object? sender, EventArgs e)
    {
        RefreshMonitors();
    }

    private void BtnChangeSaveLocation_Click(object? sender, EventArgs e)
    {
        using var folderDialog = new FolderBrowserDialog
        {
            Description = "Select folder to save screenshots",
            SelectedPath = saveLocation,
            ShowNewFolderButton = true
        };

        if (folderDialog.ShowDialog() == DialogResult.OK)
        {
            saveLocation = folderDialog.SelectedPath;
            lblSaveLocation.Text = saveLocation;
            SaveSettings();
            statusLabel.Text = $"Save location changed to: {Path.GetFileName(saveLocation)}";
        }
    }

    private void BtnChangeFileFormat_Click(object? sender, EventArgs e)
    {
        var formatDialog = new FileFormatDialog(fileNameFormat);
        
        if (formatDialog.ShowDialog() == DialogResult.OK)
        {
            fileNameFormat = formatDialog.FileFormat;
            lblFileFormat.Text = fileNameFormat;
            SaveSettings();
            statusLabel.Text = "File format updated successfully";
        }
        
        formatDialog.Dispose();
    }

    private async void BtnCapture_Click(object? sender, EventArgs e)
    {
        if (listViewMonitors.SelectedItems.Count == 0) return;

        var monitor = (MonitorInfo)listViewMonitors.SelectedItems[0].Tag!;
        await CaptureScreenshotAsync(monitor);
    }

    private async void BtnCaptureAll_Click(object? sender, EventArgs e)
    {
        await CaptureAllScreenshotsAsync();
    }

    private async Task CaptureScreenshotAsync(MonitorInfo monitor)
    {
        try
        {
            ShowProgress(true);
            statusLabel.Text = $"Capturing Monitor {monitor.Index + 1}...";

            var bitmap = await Task.Run(() => CaptureScreen(monitor.Bounds));
            
            // Show preview
            previewBox.Image?.Dispose();
            previewBox.Image = new Bitmap(bitmap);

            // Save file
            var fileName = GenerateFileName(monitor.Index + 1);
            var filePath = Path.Combine(saveLocation, fileName);
            
            await Task.Run(() => bitmap.Save(filePath, ImageFormat.Png));

            statusLabel.Text = $"Screenshot saved: {fileName}";
            
            // Auto-open file location if enabled
            if (autoOpenExplorer)
            {
                System.Diagnostics.Process.Start("explorer.exe", $"/select,\"{filePath}\"");
            }
        }
        catch (Exception ex)
        {
            statusLabel.Text = $"Error: {ex.Message}";
            MessageBox.Show($"Failed to capture screenshot: {ex.Message}", "Error", 
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        finally
        {
            ShowProgress(false);
        }
    }

    private async Task CaptureAllScreenshotsAsync()
    {
        try
        {
            ShowProgress(true);
            progressBar.Maximum = monitors.Count;
            progressBar.Value = 0;

            var timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");
            var savedFiles = new List<string>();

            for (int i = 0; i < monitors.Count; i++)
            {
                var monitor = monitors[i];
                statusLabel.Text = $"Capturing Monitor {monitor.Index + 1} of {monitors.Count}...";
                
                var bitmap = await Task.Run(() => CaptureScreen(monitor.Bounds));
                
                var fileName = GenerateFileName(monitor.Index + 1);
                var filePath = Path.Combine(saveLocation, fileName);
                
                await Task.Run(() => bitmap.Save(filePath, ImageFormat.Png));
                savedFiles.Add(fileName);
                
                progressBar.Value = i + 1;
                bitmap.Dispose();
            }

            statusLabel.Text = $"All screenshots saved ({savedFiles.Count} files)";
            
            // Open save folder if enabled
            if (autoOpenExplorer)
            {
                System.Diagnostics.Process.Start("explorer.exe", saveLocation);
            }
            
            // Show summary
            var message = $"Captured {savedFiles.Count} screenshots:\n\n" + string.Join("\n", savedFiles);
            MessageBox.Show(message, "Screenshots Captured", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        catch (Exception ex)
        {
            statusLabel.Text = $"Error: {ex.Message}";
            MessageBox.Show($"Failed to capture screenshots: {ex.Message}", "Error", 
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        finally
        {
            ShowProgress(false);
        }
    }

    private void ShowProgress(bool show)
    {
        progressBar.Visible = show;
        if (!show)
        {
            progressBar.Value = 0;
        }
    }

    private static Bitmap CaptureScreen(Rectangle bounds)
    {
        var bitmap = new Bitmap(bounds.Width, bounds.Height, PixelFormat.Format32bppArgb);
        
        using (var graphics = Graphics.FromImage(bitmap))
        {
            graphics.CopyFromScreen(bounds.X, bounds.Y, 0, 0, bounds.Size, CopyPixelOperation.SourceCopy);
        }
        
        return bitmap;
    }

    private string GenerateFileName(int monitorNumber)
    {
        var now = DateTime.Now;
        var fileName = fileNameFormat;

        // Replace placeholders
        fileName = fileName.Replace("{M}", monitorNumber.ToString());
        fileName = fileName.Replace("{MONITOR}", monitorNumber.ToString("D2"));
        fileName = fileName.Replace("{YYYY}", now.Year.ToString());
        fileName = fileName.Replace("{YY}", now.ToString("yy"));
        fileName = fileName.Replace("{MONTH}", now.Month.ToString("D2"));
        fileName = fileName.Replace("{DD}", now.Day.ToString("D2"));
        fileName = fileName.Replace("{HH}", now.Hour.ToString("D2"));
        fileName = fileName.Replace("{mm}", now.Minute.ToString("D2"));
        fileName = fileName.Replace("{SS}", now.Second.ToString("D2"));
        fileName = fileName.Replace("{YYYYMMDD}", now.ToString("yyyyMMdd"));
        fileName = fileName.Replace("{HHMMSS}", now.ToString("HHmmss"));
        fileName = fileName.Replace("{TIMESTAMP}", now.ToString("yyyyMMdd_HHmmss"));

        // Ensure .png extension if not present
        if (!fileName.ToLower().EndsWith(".png"))
        {
            fileName += ".png";
        }

        return fileName;
    }

    protected override void OnFormClosing(FormClosingEventArgs e)
    {
        SaveSettings();
        previewBox.Image?.Dispose();
        base.OnFormClosing(e);
    }
}

public class MonitorInfo
{
    public int Index { get; set; }
    public Screen Screen { get; set; } = null!;
    public string DeviceName { get; set; } = string.Empty;
    public Rectangle Bounds { get; set; }
    public Rectangle WorkingArea { get; set; }
    public bool IsPrimary { get; set; }
}

public class FileFormatDialog : Form
{
    private TextBox txtFileFormat;
    private Label lblPreview;
    private Button btnOK;
    private Button btnCancel;
    
    public string FileFormat { get; private set; } = string.Empty;

    public FileFormatDialog(string currentFormat)
    {
        InitializeDialog();
        txtFileFormat.Text = currentFormat;
        FileFormat = currentFormat;
        UpdatePreview();
    }

    private void InitializeDialog()
    {
        Text = "Customize File Format";
        Size = new Size(500, 320);
        StartPosition = FormStartPosition.CenterParent;
        FormBorderStyle = FormBorderStyle.FixedDialog;
        MaximizeBox = false;
        MinimizeBox = false;

        var mainPanel = new TableLayoutPanel
        {
            Dock = DockStyle.Fill,
            RowCount = 5,
            ColumnCount = 1,
            Padding = new Padding(15)
        };

        mainPanel.RowStyles.Add(new RowStyle(SizeType.AutoSize));
        mainPanel.RowStyles.Add(new RowStyle(SizeType.AutoSize));
        mainPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        mainPanel.RowStyles.Add(new RowStyle(SizeType.AutoSize));
        mainPanel.RowStyles.Add(new RowStyle(SizeType.AutoSize));

        // Title
        var lblTitle = new Label
        {
            Text = "File Format Pattern:",
            Font = new Font("Segoe UI", 10, FontStyle.Bold),
            Dock = DockStyle.Fill,
            AutoSize = true
        };

        // Format input
        txtFileFormat = new TextBox
        {
            Dock = DockStyle.Fill,
            Font = new Font("Consolas", 10),
            Height = 25
        };
        txtFileFormat.TextChanged += (s, e) => UpdatePreview();

        // Help text
        var helpText = new RichTextBox
        {
            Dock = DockStyle.Fill,
            ReadOnly = true,
            BorderStyle = BorderStyle.None,
            BackColor = SystemColors.Control,
            Font = new Font("Segoe UI", 9),
            Text = "Available placeholders:\\n\\n" +
                   "{M} - Monitor number (1, 2, 3...)\\n" +
                   "{MONITOR} - Monitor number padded (01, 02, 03...)\n" +
                   "{YYYY} - Full year (2026)\n" +
                   "{YY} - Short year (26)\n" +
                   "{MONTH} - Month (01-12)\n" +
                   "{DD} - Day (01-31)\n" +
                   "{HH} - Hour (00-23)\n" +
                   "{mm} - Minute (00-59)\n" +
                   "{SS} - Second (00-59)\n" +
                   "{YYYYMMDD} - Date (20260226)\n" +
                   "{HHMMSS} - Time (143022)\n" +
                   "{TIMESTAMP} - Full timestamp (20260226_143022)\n\n" +
                   "Examples:\n" +
                   "• Screenshot_Monitor{M}_{TIMESTAMP}.png\n" +
                   "• Screen{MONITOR}_{YYYY}-{MONTH}-{DD}_{HH}-{mm}-{SS}.png\n" +
                   "• Monitor{M}_{YYYYMMDD}.png"
        };

        // Preview
        var lblPreviewTitle = new Label
        {
            Text = "Preview:",
            Font = new Font("Segoe UI", 9, FontStyle.Bold),
            AutoSize = true
        };

        lblPreview = new Label
        {
            Dock = DockStyle.Fill,
            Font = new Font("Consolas", 9),
            ForeColor = Color.DarkBlue,
            BorderStyle = BorderStyle.FixedSingle,
            TextAlign = ContentAlignment.MiddleLeft,
            Height = 25
        };

        // Buttons
        var buttonPanel = new FlowLayoutPanel
        {
            FlowDirection = FlowDirection.RightToLeft,
            Dock = DockStyle.Fill,
            Height = 35
        };

        btnCancel = new Button
        {
            Text = "Cancel",
            Size = new Size(75, 30),
            DialogResult = DialogResult.Cancel
        };

        btnOK = new Button
        {
            Text = "OK",
            Size = new Size(75, 30),
            DialogResult = DialogResult.OK
        };
        btnOK.Click += (s, e) => FileFormat = txtFileFormat.Text;

        buttonPanel.Controls.AddRange(new Control[] { btnCancel, btnOK });

        // Add to main panel
        mainPanel.Controls.Add(lblTitle, 0, 0);
        mainPanel.Controls.Add(txtFileFormat, 0, 1);
        mainPanel.Controls.Add(helpText, 0, 2);
        mainPanel.Controls.Add(lblPreviewTitle, 0, 3);
        mainPanel.Controls.Add(lblPreview, 0, 4);

        var outerPanel = new Panel { Dock = DockStyle.Fill };
        outerPanel.Controls.Add(mainPanel);
        outerPanel.Controls.Add(buttonPanel);
        buttonPanel.Dock = DockStyle.Bottom;

        Controls.Add(outerPanel);

        AcceptButton = btnOK;
        CancelButton = btnCancel;
    }

    private void UpdatePreview()
    {
        try
        {
            var format = txtFileFormat.Text;
            var now = DateTime.Now;
            
            var preview = format;
            preview = preview.Replace("{M}", "1");
            preview = preview.Replace("{MONITOR}", "01");
            preview = preview.Replace("{YYYY}", now.Year.ToString());
            preview = preview.Replace("{YY}", now.ToString("yy"));
            preview = preview.Replace("{MONTH}", now.Month.ToString("D2"));
            preview = preview.Replace("{DD}", now.Day.ToString("D2"));
            preview = preview.Replace("{HH}", now.Hour.ToString("D2"));
            preview = preview.Replace("{mm}", now.Minute.ToString("D2"));
            preview = preview.Replace("{SS}", now.Second.ToString("D2"));
            preview = preview.Replace("{YYYYMMDD}", now.ToString("yyyyMMdd"));
            preview = preview.Replace("{HHMMSS}", now.ToString("HHmmss"));
            preview = preview.Replace("{TIMESTAMP}", now.ToString("yyyyMMdd_HHmmss"));

            if (!preview.ToLower().EndsWith(".png"))
            {
                preview += ".png";
            }

            lblPreview.Text = preview;
            lblPreview.ForeColor = Color.DarkBlue;
        }
        catch
        {
            lblPreview.Text = "Invalid format";
            lblPreview.ForeColor = Color.Red;
        }
    }
}