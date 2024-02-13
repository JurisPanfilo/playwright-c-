// using Microsoft.Playwright;
//
// namespace PlaywrightTests.Pages;
//
// public class PageHeader
// {
//     private readonly IPage _page;
//     private readonly ILocator _linkLogin;
//     private readonly ILocator _linkEmployee;
//     private readonly ILocator _linkLogOff;
//     
//
//     public PageHeader(IPage page)
//     {
//         _page = page;
//         _linkLogin = _page.Locator("#loginLink");
//         _linkEmployee = _page.Locator("a[href=\"/Employee\"]");
//         _linkLogOff = _page.GetByRole(AriaRole.Link, new() { Name = "Log off" });
//     }
//
//     public async Task ClickLogin()
//     {
//         await _linkLogin.ClickAsync();
//     }
//     
//
//     public ILocator LinkEmployeeList()
//     {
//         return _linkEmployee;
//     }
//     
//     public ILocator LinkLogOff()
//     {
//         return _linkLogOff;
//     }
//     
//     ////Other Pattern
//     public ILocator LinkEmployeeList2() =>
//          _page.Locator("a[href=\"/Employee\"]");
//     
// }

