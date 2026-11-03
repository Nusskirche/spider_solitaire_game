using System.Reflection;
using Microsoft.Web.WebView2.Core;
using Microsoft.Web.WebView2.WinForms;

namespace OmasSpiderSolitaire;

internal static class Program
{
    [STAThread]
    private static void Main()
    {
        ApplicationConfiguration.Initialize();
        Application.Run(new GameWindow());
    }
}

internal sealed class GameWindow : Form
{
    private const string VirtualHost = "spider-solitaire.example";
    private const string GameFile = "SpiderSolitaire.html";
    private readonly WebView2 _browser = new() { Dock = DockStyle.Fill };

    public GameWindow()
    {
        Text = "Oma's Spider Solitaire";
        MinimumSize = new Size(850, 600);
        ClientSize = new Size(1280, 850);
        StartPosition = FormStartPosition.CenterScreen;
        Controls.Add(_browser);
        Shown += async (_, _) => await InitializeGameAsync();
    }

    private async Task InitializeGameAsync()
    {
        try
        {
            // De locatie en virtuele oorsprong blijven identiek bij elke update.
            // Zo bewaart WebView2 de spelstand/statistieken tussen versies.
            var appData = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                "OmasSpiderSolitaire");
            var webFolder = Path.Combine(appData, "Game");
            var profileFolder = Path.Combine(appData, "WebView2Profile");
            Directory.CreateDirectory(webFolder);
            Directory.CreateDirectory(profileFolder);

            var htmlPath = Path.Combine(webFolder, GameFile);
            using (var source = Assembly.GetExecutingAssembly()
                .GetManifestResourceStream("OmasSpiderSolitaire.SpiderSolitaire.html")
                ?? throw new InvalidOperationException("Ingebouwde spelcode ontbreekt."))
            using (var target = File.Create(htmlPath))
            {
                await source.CopyToAsync(target);
            }

            var environment = await CoreWebView2Environment.CreateAsync(
                browserExecutableFolder: null,
                userDataFolder: profileFolder);
            await _browser.EnsureCoreWebView2Async(environment);

            var core = _browser.CoreWebView2;
            core.Settings.AreDevToolsEnabled = false;
            core.Settings.AreDefaultContextMenusEnabled = false;
            core.Settings.AreBrowserAcceleratorKeysEnabled = false;
            core.Settings.IsStatusBarEnabled = false;
            core.NewWindowRequested += (_, args) => args.Handled = true;
            core.NavigationStarting += (_, args) =>
            {
                if (!Uri.TryCreate(args.Uri, UriKind.Absolute, out var uri)
                    || uri.Scheme != Uri.UriSchemeHttps
                    || !uri.Host.Equals(VirtualHost, StringComparison.OrdinalIgnoreCase))
                {
                    args.Cancel = true;
                }
            };

            // De browser ziet een stabiele HTTPS-oorsprong, maar laadt
            // uitsluitend bestanden uit de lokale Game-map.
            core.SetVirtualHostNameToFolderMapping(
                VirtualHost,
                webFolder,
                CoreWebView2HostResourceAccessKind.DenyCors);
            core.Navigate($"https://{VirtualHost}/{GameFile}");
        }
        catch (Exception ex)
        {
            _browser.Visible = false;
            MessageBox.Show(
                "Het spel kon niet worden gestart.\n\n" +
                "Controleer of Microsoft Edge WebView2 Runtime is geïnstalleerd.\n\n" +
                $"Technische informatie: {ex.Message}",
                "Oma's Spider Solitaire",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }
    }
}
