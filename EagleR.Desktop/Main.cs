using System.Text.Json;
using System.Text.RegularExpressions;
using Azure.Storage.Queues;
using Microsoft.Extensions.Configuration;
using PuppeteerSharp;
using static Microsoft.Extensions.Logging.EventSource.LoggingEventSource;

namespace EagleR.Desktop;

public partial class Main : Form
{
    private readonly static HttpClient _httpClient = new()
    {
        BaseAddress = new Uri("http://localhost:41593"),
    };

    private readonly QueueClient _queueClient;

    private readonly string _screenshotPath;
    private IBrowser _browser;
    private IPage _page;

    public Main(IConfiguration configuration)
    {
        InitializeComponent();

        Directory.SetCurrentDirectory(new FileInfo(Application.ExecutablePath).DirectoryName);
        _screenshotPath = Path.Combine(Directory.GetCurrentDirectory(), "screenshot.png");

        _queueClient = new(configuration.GetConnectionString("StorageAccount"), "eagle-saver");
    }

    private void TrayIcon_DoubleClick(object sender, EventArgs e)
    {
        ShowForm();
    }

    private void Main_FormClosing(object sender, FormClosingEventArgs e)
    {
        Hide();
        ShowInTaskbar = false;
        e.Cancel = true;
    }

    private async void Main_FormClosed(object sender, FormClosedEventArgs e)
    {
        await _page.CloseAsync();
        await _page.DisposeAsync();
        await _browser.CloseAsync();
        await _browser.DisposeAsync();
    }

    private async void Main_Shown(object sender, EventArgs e)
    {
        // Download the Chromium browser if needed
        await new BrowserFetcher().DownloadAsync();

        // Launch the browser
        _browser = await Puppeteer.LaunchAsync(new LaunchOptions
        {
            Headless = true,
            Args = ["--enable-features=WebContentsForceDark"]
        });

        // Create a new page
        _page = await _browser.NewPageAsync();

        AddLog($"Screenshot path: {_screenshotPath}");
        AddLog();

        while (true)
        {
            lastFetchStatusLabel.Text = $"Last fetch: {DateTime.Now}";
            await FetchAndStoreBookmarks();
            await Task.Delay(60000);
        }
    }

    private async Task FetchAndStoreBookmarks()
    {
        try
        {
            var messagesResponse = await _queueClient.ReceiveMessagesAsync(10);

            foreach (var message in messagesResponse.Value)
            {
                var urlRequest = JsonSerializer.Deserialize<UrlRequest>(message.MessageText);

                // Navigate to the URL
                await _page.GoToAsync(urlRequest.Url);
                await _page.WaitForNetworkIdleAsync();

                // Set the viewport size if needed (optional)
                await _page.SetViewportAsync(new ViewPortOptions
                {
                    Width = 720,
                    Height = 400
                });

                // Take the screenshot
                await _page.ScreenshotAsync(_screenshotPath, new ScreenshotOptions()
                {
                    Type = ScreenshotType.Png,
                    OptimizeForSpeed = true
                });

                var pageTitle = ClearWeirdCharacters(await _page.GetTitleAsync());
                var title = pageTitle[..Math.Min(pageTitle.Length, 65)];
                var keywords = (await _page.EvaluateExpressionAsync(@"
                            Array.from(document.querySelectorAll('meta[name=""keywords""]'), (e) => { return e.content })")).FirstOrDefault()?.ToString() ?? "";
                var description = (await _page.EvaluateExpressionAsync(@"
                            Array.from(document.querySelectorAll('meta[name=""description""]'), (e) => { return e.content })")).FirstOrDefault()?.ToString() ?? "";

                byte[] bytes = File.ReadAllBytes(_screenshotPath);
                string file = "data:image/png;base64," + Convert.ToBase64String(bytes);

                var body = new List<KeyValuePair<string, string>>()
                    {
                        new("type", "save-url"),
                        new("version", "3.0.25"),
                        new("title", title),
                        new("behavior", "save-url"),
                        new("url", urlRequest.Url),
                        new("metaTags", keywords),
                        new("metaDescription", description),
                        //new("src", file),
                        new("width", "720"),
                        new("height", "400"),
                        new("base64", file),
                    };

                AddLog($"""
                            Saving {urlRequest.Url}...
                            - Title: {title}
                            - Keywords: {keywords}
                            - Description: {description}
                            """);

                using (var req = new HttpRequestMessage(HttpMethod.Post, "/") { Content = new FormUrlEncodedContent(body) })
                {
                    using var response = await _httpClient.SendAsync(req);
                    AddLog($"Response: {response.StatusCode}\r\n");
                }

                await _queueClient.DeleteMessageAsync(message.MessageId, message.PopReceipt);

                await Task.Delay(1000);
            }
        }
        catch (Exception exception)
        {
            AddLog($"""
                        {exception.Message}
                        {exception.StackTrace}
                        """);

            trayIcon.ShowBalloonTip(100000, "EagleR", "Error while processing bookmarks.", ToolTipIcon.Error);
        }
    }

    private void Main_Load(object sender, EventArgs e)
    {
        Hide();
    }

    private void OpenEaglerMenu_Click(object sender, EventArgs e)
    {
        ShowForm();
    }

    private void QuitEaglerMenu_Click(object sender, EventArgs e)
    {
        FormClosing -= Main_FormClosing;
        Close();
    }

    private void TrayIcon_BalloonTipClicked(object sender, EventArgs e)
    {
        ShowForm();
    }

    private static string ClearWeirdCharacters(string text)
    {
        if (string.IsNullOrEmpty(text))
        {
            return "";
        }

        string step1 = Step1Regex().Replace(text, "");
        string step2 = Step2Regex().Replace(step1, "");
        string step3 = Step3Regex().Replace(step2, "");
        string step4 = Step4Regex().Replace(step3, "");
        
        return step4.Replace("\ud83d", "");
    }

    private void ShowForm()
    {
        Show();
        WindowState = FormWindowState.Normal;
        ShowInTaskbar = true;
        Activate();
    }

    private void AddLog(string text = null)
    {
        logsText.AppendText($"{text}{Environment.NewLine}");
        logsText.ScrollToCaret();
    }

    [GeneratedRegex(@"(?![*#0-9]+)")]
    private static partial Regex Step1Regex();

    [GeneratedRegex(@"[#$%^&*()<>:'""/\\|?*]+")]
    private static partial Regex Step2Regex();

    [GeneratedRegex(@"([0-9]\uFE0F\u20E3)|([*#\u1F51F]\uFE0F\u20E3)")]
    private static partial Regex Step3Regex();

    [GeneratedRegex(@"[^\u1F600-\u1F6FF\s]")]
    private static partial Regex Step4Regex();
}
