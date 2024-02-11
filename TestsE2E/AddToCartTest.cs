using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;
using NUnit.Framework.Constraints;
using PlaywrightTests.Pages;

namespace PlaywrightTests;

[Parallelizable(ParallelScope.Self)]
[TestFixture]
public class AddToCart : PageTest
{
    readonly string baseUrl = "https://www.saucedemo.com/";
    
    private LoginPage loginPage;
    private ProductsPage productsPage;
    private CommonHeader commonHeader;
    
    
    [SetUp]
    public async Task Setup()
    {
        loginPage = new LoginPage(Page);
        productsPage = new ProductsPage(Page);
        commonHeader = new CommonHeader(Page);
        
        await TeardownSetupHelper.StartTracingAsync(Page);
        // baseUrl = TeardownSetupHelper.GetBaseUrl();
        await Page.GotoAsync(baseUrl);
    }
    
    
    [TearDown]
    public async Task TearDown()
    {
        await TeardownSetupHelper.StopTracingAsync(Page);
    }
    
    [Test]
    public async Task AddProductToChart()
    {
        await loginPage.SignIn("standard_user", "secret_sauce");
        await Expect(commonHeader.ShoppingCart()).ToBeVisibleAsync();

        await productsPage.AddProduct("Sauce Labs Bolt T-Shirt");
        await Expect(commonHeader.ShoppingCart()).ToContainTextAsync("1");
    }
    
    [Test]
    public async Task AddMultipleProducts()
    {
        await loginPage.SignIn("standard_user", "secret_sauce");
        await Expect(commonHeader.ShoppingCart()).ToBeVisibleAsync();

        await productsPage.AddProduct("Sauce Labs Bolt T-Shirt");
        await productsPage.AddProduct("Sauce Labs Onesie");
        await Expect(commonHeader.ShoppingCart()).ToContainTextAsync("2");
    }
}