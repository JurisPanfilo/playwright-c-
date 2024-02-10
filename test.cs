using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;
using NUnit.Framework.Constraints;
using PlaywrightTests.Pages;

namespace PlaywrightTests;

[Parallelizable(ParallelScope.Self)]
[TestFixture]
public class MyTest : PageTest
{
    
    [SetUp]
    public async Task Setup()
    {
        await Context.Tracing.StartAsync(new()
        {
            Title = "playwright-traces",
            Screenshots = true,
            Snapshots = true,
            Sources = true
        });
    }
    
    [TearDown]
    public async Task TearDown()
    {
        // This will produce e.g.:
        // bin/Debug/net8.0/playwright-traces/PlaywrightTests.Tests.Test1.zip
        await Context.Tracing.StopAsync(new()
        {
            Path = Path.Combine(
                TestContext.CurrentContext.WorkDirectory,
                "test-results",
                $"{TestContext.CurrentContext.Test.ClassName}.{TestContext.CurrentContext.Test.Name}.zip"
            )
        });
    }
    
    [Test]
    public async Task ShouldHaveTheCorrectSlogan()
    {
        LoginPage loginPage = new LoginPage(Page);
        PageHeader pageHeader = new PageHeader(Page);
        
        await Page.GotoAsync("http://eaapp.somee.com/");
        var title = await Page.TitleAsync();
        Console.WriteLine("Title is: " + title);

        await pageHeader.ClickLogin();
        await loginPage.EnterCredentials("Yuryeee", "Hu");
        await loginPage.SubmitCredentials();
        await Expect(pageHeader.LinkEmployeeList()).ToBeVisibleAsync();
        await Expect(pageHeader.LinkEmployeeList2()).ToBeVisibleAsync();
    }
    
}