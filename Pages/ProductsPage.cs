using Microsoft.Playwright;

namespace PlaywrightTests.Pages;

public class ProductsPage
{
    private readonly IPage _page;

    public ProductsPage(IPage page)
    {
        _page = page;
    }

    public ILocator ProductsPageTitle() => _page.GetByText("Products");

    public ILocator ProductByTitle(string productTitle) => _page.GetByText(productTitle);
    
    private ILocator ButtonAddToChartByTitle(string productName) => _page.Locator($"xpath=//div[text()='{productName}']/../../..//button");
    
        
    public Task AddProduct(string productName)
    {
        return ButtonAddToChartByTitle(productName).ClickAsync();
    }
}