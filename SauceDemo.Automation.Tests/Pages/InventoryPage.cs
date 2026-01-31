using OpenQA.Selenium;

namespace SauceDemo.Automation.Tests.Pages
{
  public class InventoryPage
  {
    private readonly IWebDriver _driver;

    public InventoryPage(IWebDriver driver)
    {
      _driver = driver;
    }

    public const string Url = "https://www.saucedemo.com/inventory.html";

    private By InventoryContainer => By.Id("inventory_container");
    private By NumberOfItemsInCart => By.CssSelector("[class='shopping_cart_badge']");
    private By ShoppingCartButton => By.Id("shopping_cart_container");

    public bool IsDisplayed()
    {
        return _driver.FindElement(InventoryContainer).Displayed;
    }

    public void GoTo()
    {
      _driver.Navigate().GoToUrl(Url);
    }

    public void AddItemToCart(string itemName)
    {
      var buttonId = "add-to-cart-" + itemName.ToLower().Replace(" ", "-");
      _driver.FindElement(By.Id(buttonId)).Click();
    }

    public int GetNumberOfItemsInCart()
    {
      return int.Parse(_driver.FindElement(NumberOfItemsInCart).Text);
    }

    public void ClickShoppingCartButton()
    {
      _driver.FindElement(ShoppingCartButton).Click();
    }
  }
}
