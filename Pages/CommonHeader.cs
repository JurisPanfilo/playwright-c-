using Microsoft.Playwright;

namespace PlaywrightTests.Pages;

public class CommonHeader(IPage page)
{
    public ILocator ShoppingCart() => page.Locator("#shopping_cart_container");

    public ILocator HamburgerMenu() => page.Locator("#react-burger-menu-btn");
    public ILocator HamburgerMenuAllProducts() => page.Locator("#inventory_sidebar_link");
    public ILocator HamburgerMenuLogOut() => page.Locator("#logout_sidebar_link");
}