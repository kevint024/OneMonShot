using System;
using System.Windows.Forms;

namespace OneMonShot;

internal static class Program
{
    /// &lt;summary&gt;
    /// The main entry point for the application.
    /// &lt;/summary&gt;
    [STAThread]
    static void Main()
    {
        Application.SetHighDpiMode(HighDpiMode.SystemAware);
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        
        try
        {
            Application.Run(new MainForm());
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Application error: {ex.Message}", "OneMonShot Error", 
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}