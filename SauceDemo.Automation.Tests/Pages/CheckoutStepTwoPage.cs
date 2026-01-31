using System.Text.RegularExpressions;
using OpenQA.Selenium;

namespace SauceDemo.Automation.Tests.Pages
{
  public class CheckoutStepTwoPage
  {
    private readonly IWebDriver _driver;

    public CheckoutStepTwoPage(IWebDriver driver)
    {
      _driver = driver;
    }


    public const string Url = "https://www.saucedemo.com/checkout-step-two.html";

    private By CheckoutContainer => By.Id("checkout_info_container");
    private By ContinueButton => By.Id("continue");
    private By FinishButton => By.Id("finish");
    private By CancelButton => By.Id("cancel");
    private By BackHomeButton => By.Id("back-to-products");
    private By ItemTotal => By.CssSelector("[class='summary_info_label summary_total_label']");
    private By Tax => By.CssSelector("[class='summary_info_label summary_tax_label']");
    private By Total => By.CssSelector("[class='summary_info_label summary_total_label']");
    private By ErrorMessage => By.CssSelector("[data-test='error']");
    private By InventoryItemPrice => By.CssSelector("[data-test='inventory-item-price']");
    public void GoTo()
    {
      _driver.Navigate().GoToUrl(Url);
    }

    public void ClickContinueButton()
    {
      _driver.FindElement(ContinueButton).Click();
    }

    public void ClickFinishButton()
    {
      _driver.FindElement(FinishButton).Click();
    }

    public void ClickCancelButton()
    {
      _driver.FindElement(CancelButton).Click();
    }

    public void ClickBackHomeButton()
    {
      _driver.FindElement(BackHomeButton).Click();
    }

    public double GetItemTotal()
    {
      return GetCartSubtotal("subtotal");
    }

    public double GetTax()
    {
      var text = _driver.FindElement(Tax).Text;
      var pricePart = text.Split('$')[^1].Trim();
      return double.Parse(pricePart);
    }

    public double GetTotal()
    {
      var text = _driver.FindElement(Total).Text;
      var pricePart = text.Split('$')[^1].Trim();
      return double.Parse(pricePart);
    }

    public string GetErrorMessage()
    {
      return _driver.FindElement(ErrorMessage).Text;
    }

    public double AddCartTotal()
    {
      double total = 0.0;
      var itemPrices = _driver.FindElements(InventoryItemPrice);
      foreach (var itemPrice in itemPrices)
      {
        var itemPriceText = itemPrice.Text.Replace("$", "").Trim();
        total += double.Parse(itemPriceText);
      }
      return total;
    }

    public double GetCartSubtotal(string type)
    {
      var labelElement = _driver.FindElement(By.CssSelector($"[data-test='{type}-label']"));
      var labelText = labelElement.Text;
      var amountText = Regex.Replace(labelText, @"[^\d.]", "");
      return double.Parse(amountText);
    }

    public double CalculateTaxRate(string type, int taxRate)
    {
      double subtotalAmount = GetCartSubtotal("subtotal");
      double expectedTax = subtotalAmount * (taxRate / 100.0);
      return Math.Round(expectedTax, 2, MidpointRounding.AwayFromZero);
    }
  }
}

  
