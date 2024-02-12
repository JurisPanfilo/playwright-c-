using Microsoft.Playwright;
using NUnit.Allure.Attributes;

namespace PlaywrightTests.Pages;

public class LoginPage
{
    private IPage _page;
    private readonly ILocator _inputUserName;
    private readonly ILocator _inputPassword;
    private readonly ILocator _buttonLogin;
    
    public LoginPage(IPage page)
    {
        _page = page;
        _inputUserName = _page.Locator("#user-name");
        _inputPassword = _page.Locator("#password");
        _buttonLogin = _page.Locator("#login-button");
    }
    
    [AllureStep]
    public async Task SignIn(string userName, string password)
    {
        await _inputUserName.FillAsync(userName);
        await _inputPassword.FillAsync(password);
        await _buttonLogin.ClickAsync();
    }
    
    
}