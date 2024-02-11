using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;
using NUnit.Framework.Constraints;
using PlaywrightTests.Pages;

namespace PlaywrightTests;

[Parallelizable(ParallelScope.Self)]
[TestFixture]
public class MyTest : PageTest
{
    
    private LoginPage loginPage;
    private ProductsPage productsPage;
    private CommonHeader commonHeader;
    
    [SetUp]
    public async Task Setup()
    {
        
        loginPage = new LoginPage(Page);
        productsPage = new ProductsPage(Page);
        commonHeader = new CommonHeader(Page);
        
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
    public async Task AddProductToChart()
    {
        await Page.GotoAsync("https://www.saucedemo.com/");
        
        await loginPage.SignIn("standard_user", "secret_sauce");
        await Expect(productsPage.ProductsPageTitle()).ToBeVisibleAsync();

        await productsPage.AddProduct("Sauce Labs Bolt T-Shirt");
        await Expect(commonHeader.ShoppingCart()).ToContainTextAsync("1");
    }
    
    [Test]
    public async Task AddMultipleProducts()
    {
        await Page.GotoAsync("https://www.saucedemo.com/");
        
        await loginPage.SignIn("standard_user", "secret_sauce");
        await Expect(productsPage.ProductsPageTitle()).ToBeVisibleAsync();

        await productsPage.AddProduct("Sauce Labs Bolt T-Shirt");
        await productsPage.AddProduct("Sauce Labs Onesie");
        await Expect(commonHeader.ShoppingCart()).ToContainTextAsync("2");
    }
    


    
    
}