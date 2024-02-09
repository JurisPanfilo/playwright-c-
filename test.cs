using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;
using NUnit.Framework.Constraints;
using PlaywrightTests.Pages;

namespace PlaywrightTests;

[Parallelizable(ParallelScope.Self)]
[TestFixture]
public class MyTest : PageTest
{
    
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