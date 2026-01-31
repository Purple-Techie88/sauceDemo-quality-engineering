using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace SauceDemo.Automation.Tests.Pages
{
  public class YourCartPage
  {
    private readonly IWebDriver _driver;

    public YourCartPage(IWebDriver driver)
    {
      _driver = driver;
    }

    public const string Url = "https://www.saucedemo.com/cart.html";

    private By CheckoutButton => By.Id("checkout");
    private By ContinueShoppingButton => By.Id("continue-shopping");
    private By ErrorMessage => By.CssSelector("[data-test='error']");
    private By NumberOfItemsInCart => By.CssSelector(".shopping_cart_badge");
    private By CartItem => By.CssSelector(".cart_item");
    private By ItemQuantity => By.CssSelector("[data-test='item-quantity']");
    private By InventoryItemName => By.CssSelector("[data-test='inventory-item-name']");

    public void GoTo()
    {
      _driver.Navigate().GoToUrl(Url);
    }

    public void RemoveItemFromCart(string itemName)
    {
      var buttonId = "remove-" + itemName.ToLower().Replace(" ", "-");
      var removeSelector = By.Id(buttonId);
      var removeButton = _driver.FindElement(removeSelector);
      removeButton.Click();

      // Wait for the item to be removed from the DOM before continuing
      var wait = new OpenQA.Selenium.Support.UI.WebDriverWait(_driver, TimeSpan.FromSeconds(5));
      wait.Until(d => d.FindElements(removeSelector).Count == 0);
    }

    public string GetErrorMessage()
    {
      return _driver.FindElement(ErrorMessage).Text;
    }

    public void ClickContinueShoppingButton()
    {
      _driver.FindElement(ContinueShoppingButton).Click();
    }

    public void ClickCheckoutButton()
    {
      _driver.FindElement(CheckoutButton).Click();
    }
    public int GetNumberOfItemsInCart()
    {
      return int.Parse(_driver.FindElement(NumberOfItemsInCart).Text);
    }

    /// <summary>
    /// Gets each cart item's name and displayed quantity using [data-test='item-quantity'] and [data-test='inventory-item-name'].
    /// </summary>
    public IReadOnlyList<(string ItemName, int Quantity)> GetCartItemQuantities()
    {
      var cartItems = _driver.FindElements(CartItem);
      var result = new List<(string, int)>();
      foreach (var item in cartItems)
      {
        var nameEl = item.FindElement(InventoryItemName);
        var qtyEl = item.FindElement(ItemQuantity);
        result.Add((nameEl.Text.Trim(), int.Parse(qtyEl.Text.Trim())));
      }
      return result;
    }
  }
}