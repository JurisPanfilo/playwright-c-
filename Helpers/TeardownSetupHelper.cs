using Allure.Net.Commons;
using Microsoft.Playwright;

namespace PlaywrightTests.Helpers
{
    public static class TeardownSetupHelper
    {
        public static async Task StartTracingAsync(IPage page)
        {
            await page.Context.Tracing.StartAsync(new()
            {
                Title = "playwright-traces",
                Screenshots = true,
                Snapshots = true,
                Sources = true
            });
        }

        public static async Task StopTracingAsync(IPage page)
        {
            await page.Context.Tracing.StopAsync(new()
            {
                Path = Path.Combine(
                    TestContext.CurrentContext.WorkDirectory,
                    "playwright-traces",
                    $"{TestContext.CurrentContext.Test.ClassName}.{TestContext.CurrentContext.Test.Name}.zip"
                )
            });
            await TakeScreenshotOnFailure(page);
        }

        public static async Task TakeScreenshotOnFailure(IPage page)
        {
            if (TestContext.CurrentContext.Result.Outcome.Status == NUnit.Framework.Interfaces.TestStatus.Failed)
            {
                var screenshotPath = Path.Combine(TestContext.CurrentContext.WorkDirectory,
                    $"failure-screenshots/{TestContext.CurrentContext.Test.MethodName}.png");
                await page.ScreenshotAsync(new PageScreenshotOptions { Path = screenshotPath });
                AllureApi.AddAttachment("Screenshot", "image/png", screenshotPath);
            }
        }

        public static string? GetBaseUrl()
        {
            var environment = TestContext.Parameters["Environment"];
            return environment == "dev" ? TestContext.Parameters["BaseUrlDev"] : TestContext.Parameters["BaseUrlTest"];
        }
    }
}