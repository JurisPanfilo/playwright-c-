using System.Text;
using Allure.Net.Commons;
using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using NUnit.Framework.Interfaces;
using PlaywrightTests.Helpers;
using PlaywrightTests.Pages;

namespace PlaywrightTests;

[Parallelizable(ParallelScope.Self)]
[TestFixture]
[AllureNUnit]
public class PurchaseTest : PageTest
{
    readonly string baseUrl = "https://www.saucedemo.com/";

    private LoginPage loginPage;
    private ProductsPage productsPage;
    private CommonHeader commonHeader;
    private YourCartPage yourCartPage;


    [SetUp]
    public async Task Setup()
    {
        loginPage = new LoginPage(Page);
        productsPage = new ProductsPage(Page);
        commonHeader = new CommonHeader(Page);
        yourCartPage = new YourCartPage(Page);

        await TeardownSetupHelper.StartTracingAsync(Page);
        await Page.GotoAsync(baseUrl);
    }


    [TearDown]
    public async Task TearDown()
    {
        await TeardownSetupHelper.StopTracingAsync(Page);
    }


    [Test]
    public async Task NavigationTest()
    {
        
        await loginPage.SignIn("standard_user", "secret_sauce");
        await Expect(commonHeader.ShoppingCart()).ToBeVisibleAsync();
        await productsPage.AddProduct("Sauce Labs Bolt T-Shirt");
        await commonHeader.ShoppingCart().ClickAsync();
        await yourCartPage.ButtonRemove().ClickAsync();
        await yourCartPage.ButtonChechout().ClickAsync();
        await commonHeader.HamburgerMenu().ClickAsync();
        await commonHeader.HamburgerMenuAllProducts().ClickAsync();
        await commonHeader.HamburgerMenu().ClickAsync();
        await commonHeader.HamburgerMenuLogOut().ClickAsync();
        await loginPage.SignIn("standard_user", "secret_sauce");
    }
    
    [Test]
    [AllureSeverity(SeverityLevel.minor)]
    public async Task NavigationTestShouldFail()
    {
        
        await loginPage.SignIn("standard_user", "secret_sauce");
        await Expect(commonHeader.ShoppingCart()).ToBeVisibleAsync();
        await productsPage.AddProduct("Sauce Labs Bolt T-Shirt");
        await commonHeader.ShoppingCart().ClickAsync();
        await yourCartPage.ButtonRemove().ClickAsync();
        await yourCartPage.ButtonChechout().ClickAsync();
        await commonHeader.HamburgerMenu().ClickAsync();
        await commonHeader.HamburgerMenuAllProducts().ClickAsync();
        // await commonHeader.HamburgerMenu().ClickAsync();
        await commonHeader.HamburgerMenuLogOut().ClickAsync();
        await loginPage.SignIn("standard_user", "secret_sauce");
    }
}