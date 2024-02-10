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
    public async Task LoginValidCredentials()
    {
        LoginPage loginPage = new LoginPage(Page);
        PageHeader pageHeader = new PageHeader(Page);
        
        await Page.GotoAsync("http://eaapp.somee.com/");
        
        await pageHeader.ClickLogin();
        await loginPage.EnterCredentials("Yury123", "Qwe123!");
        await loginPage.SubmitCredentials();
        await Expect(pageHeader.LinkLogOff()).ToBeVisibleAsync();
        await Expect(pageHeader.LinkEmployeeList2()).ToBeVisibleAsync();
    }
    
    [Test]
    public async Task LoginValidCredentialsFailure()
    {
        LoginPage loginPage = new LoginPage(Page);
        PageHeader pageHeader = new PageHeader(Page);
        
        await Page.GotoAsync("http://eaapp.somee.com/");
        
        await pageHeader.ClickLogin();
        await loginPage.EnterCredentials("xxx", "xxx");
        await loginPage.SubmitCredentials();
        await Expect(pageHeader.LinkLogOff()).ToBeVisibleAsync();
        await Expect(pageHeader.LinkEmployeeList2()).ToBeVisibleAsync();
    }
    
}