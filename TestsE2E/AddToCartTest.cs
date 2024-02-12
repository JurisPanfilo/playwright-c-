using Allure.Net.Commons;
using Microsoft.Playwright.NUnit;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using PlaywrightTests.Helpers;
using PlaywrightTests.Pages;

namespace PlaywrightTests;

[Parallelizable(ParallelScope.Self)]
[TestFixture]
[AllureNUnit]
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
        await Page.GotoAsync(baseUrl);
    }


    [TearDown]
    public async Task TearDown()
    {
        await TeardownSetupHelper.StopTracingAsync(Page);
    }

    [Test]
    [AllureSeverity(SeverityLevel.critical)]
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