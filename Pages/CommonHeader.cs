using Microsoft.Playwright;

namespace PlaywrightTests.Pages;

public class CommonHeader
{
    private readonly IPage _page;
    
    public CommonHeader(IPage page)
    {
        _page = page;
    }
    
    public ILocator ShoppingCart() => _page.Locator("#shopping_cart_container");
    
    
}