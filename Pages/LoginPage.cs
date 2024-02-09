using Microsoft.Playwright;

namespace PlaywrightTests.Pages;

public class LoginPage
{
    private IPage _page;
    private readonly ILocator _lnkLogin;
    private readonly ILocator _inputUserName;
    private readonly ILocator _inputPasssword;
    private readonly ILocator _buttonLogin;
    
    //Yuryeee
    //Huligan123!
    
    public LoginPage(IPage page)
    {
        _page = page;
        _inputUserName = _page.Locator("#UserName");
        _inputPasssword = _page.Locator("#Password");
        _buttonLogin = _page.Locator("input[type=\"submit\"]");
    }
    
    public async Task SubmitCredentials()
    {
        await _buttonLogin.ClickAsync();
    }
    
    public async Task EnterCredentials(string userName, string password)
    {
        await _inputUserName.FillAsync(userName);
        await _inputPasssword.FillAsync(password);
    }
    
    
}