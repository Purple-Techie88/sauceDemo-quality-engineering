using OpenQA.Selenium;

namespace SauceDemo.Automation.Tests.Pages
{
  public class CheckoutStepOnePage
  {
    private readonly IWebDriver _driver;
    public CheckoutStepOnePage(IWebDriver driver)
    {
      _driver = driver;
    }

    public const string Url = "https://www.saucedemo.com/checkout-step-one.html";
    
    private By CheckoutContainer => By.Id("checkout_info_container");
    private By FirstNameInput => By.Id("first-name");
    private By LastNameInput => By.Id("last-name");
    private By ZipCodeInput => By.Id("postal-code");
    private By ContinueButton => By.Id("continue");
    private By FinishButton => By.Id("finish");
    private By CancelButton => By.Id("cancel");
    private By BackHomeButton => By.Id("back-to-products");
  
    public void GoTo()
    {
      _driver.Navigate().GoToUrl(Url);
    }

    public void ClickContinueButton()
    {
      _driver.FindElement(ContinueButton).Click();
    }

    public void FillField(string fieldName, string value)
    {
      var locator = fieldName switch
      {
        "First Name" => FirstNameInput,
        "Last Name" => LastNameInput,
        "ZIP/Postal Code" => ZipCodeInput,
        _ => throw new ArgumentException($"Unknown field: {fieldName}")
      };
      _driver.FindElement(locator).Clear();
      _driver.FindElement(locator).SendKeys(value);
    }
  }
}
