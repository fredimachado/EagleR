using Microsoft.Win32;

namespace EagleR.Desktop;
public partial class Settings : Form
{
    private const string RegistryKeyPath = "SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run";
    private const string RegistryValueName = "EagleR";

    public Settings()
    {
        InitializeComponent();
    }

    private void Settings_Load(object sender, EventArgs e)
    {
        using RegistryKey key = Registry.CurrentUser.OpenSubKey(RegistryKeyPath);
        launchAutomaticallyCheck.Checked = key != null && key.GetValue(RegistryValueName) != null;
    }

    private void Cancel_Click(object sender, EventArgs e)
    {
        Close();
    }

    private void Save_Click(object sender, EventArgs e)
    {
        using RegistryKey key = Registry.CurrentUser.OpenSubKey(RegistryKeyPath, writable: true);

        if (launchAutomaticallyCheck.Checked)
        {
            key.SetValue(RegistryValueName, Application.ExecutablePath);
        }
        else
        {
            key.DeleteValue(RegistryValueName, throwOnMissingValue: false);
        }

        Close();
    }
}
