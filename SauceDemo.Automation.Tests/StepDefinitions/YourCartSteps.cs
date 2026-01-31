using SauceDemo.Automation.Tests.Pages;
using TechTalk.SpecFlow;

namespace SauceDemo.Automation.Tests.StepDefinitions
{
  [Binding]
  public class YourCartSteps
  {
    private readonly YourCartPage _yourCartPage;

    public YourCartSteps(YourCartPage yourCartPage)
    {
      _yourCartPage = yourCartPage;
    }

    [Given(@"I verify that the QTY count for each item should be (.*)")]
    public void GivenIVerifyThatTheQtyCountForEachItemShouldBe(int expectedQuantity)
    {
      var itemQuantities = _yourCartPage.GetCartItemQuantities();
      Assert.That(itemQuantities, Is.Not.Empty, "Cart should have at least one item");
      foreach (var (itemName, quantity) in itemQuantities)
      {
        Assert.That(quantity, Is.EqualTo(expectedQuantity),
          $"Item '{itemName}' should have quantity {expectedQuantity} but has {quantity}");
      }
    }

    [Given(@"I remove the following item:")]
    public void GivenIRemoveTheFollowingItem(Table table)
    {
      foreach (var row in table.Rows)
      {
        _yourCartPage.RemoveItemFromCart(row["itemName"]);
      }
    }

    [Given(@"I should see (.*) item(s)? added to the shopping cart")]
    public void GivenIShouldSeeItemsAddedToTheShoppingCart(int expectedCount, string? optionalS = null)
    {
      Assert.That(_yourCartPage.GetNumberOfItemsInCart(), Is.EqualTo(expectedCount));
    }

    [Given(@"I click on the CHECKOUT button")]
    public void GivenIClickOnTheCHECKOUTButton()
    {
      _yourCartPage.ClickCheckoutButton();
    }
  }
}
