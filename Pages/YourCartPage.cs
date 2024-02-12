using Microsoft.Playwright;

namespace PlaywrightTests.Pages;

public class YourCartPage(IPage page)
{
    public ILocator YourCartRootPage() => page.Locator("#cart_contents_container");
    
    public ILocator ButtonChechout() => page.Locator("#checkout");
    
    public ILocator ButtonRemove() => page.GetByText("Remove");
    
    public ILocator ButtonContinueShopping() => page.Locator("#continue-shopping");
    
}