using Microsoft.Playwright;

namespace PlaywrightTests
{
    public class TeardownSetupHelper
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
                    "test-results",
                    $"{TestContext.CurrentContext.Test.ClassName}.{TestContext.CurrentContext.Test.Name}.zip"
                )
            });
        }
        
        public static string? GetBaseUrl()
        {
            var environment = TestContext.Parameters["Environment"];
            return environment == "dev" ? TestContext.Parameters["BaseUrlDev"] : TestContext.Parameters["BaseUrlTest"];
        }
    }
}