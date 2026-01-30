using OpenQA.Selenium;

namespace SauceDemo.Automation.Tests.Pages
{
  public class LoginPage
  {
    private readonly IWebDriver _driver;

    public LoginPage(IWebDriver driver)
    {
      _driver = driver;
    }

    public const string Url = "https://www.saucedemo.com/";

    private By UserNameInput => By.Id("user-name");
    private By UsernameInput => By.Id("user-name");
    private By PasswordInput => By.Id("password");
    private By LoginButton => By.Id("login-button");
    private By ErrorMessage => By.CssSelector("[data-test='error']");

    public void GoTo()
    {
      _driver.Navigate().GoToUrl(Url);
    }

    public void LoginAs(string username, string password)
    {
      _driver.FindElement(UsernameInput).Clear();
      _driver.FindElement(UsernameInput).SendKeys(username);

      _driver.FindElement(PasswordInput).Clear();
      _driver.FindElement(PasswordInput).SendKeys(password);

      _driver.FindElement(LoginButton).Click();
    }

    public string GetErrorMessage()
    {
      return _driver.FindElement(ErrorMessage).Text;
    }
  }

}