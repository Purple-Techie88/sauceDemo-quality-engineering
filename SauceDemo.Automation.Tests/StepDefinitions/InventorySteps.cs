using TechTalk.SpecFlow;
using SauceDemo.Automation.Tests.Pages;

namespace SauceDemo.Automation.Tests.StepDefinitions
{
    [Binding]
    public class InventorySteps
    {
        private readonly InventoryPage _inventoryPage;

        public InventorySteps(InventoryPage inventoryPage)
        {
            _inventoryPage = inventoryPage;
        }

        [Given(@"I add the following items to the basket")]
        public void GivenIAddTheFollowingItemsToTheBasket(Table table)
        {
            foreach (var row in table.Rows)
            {
                _inventoryPage.AddItemToCart(row["itemName"]);
            }
        }

        [Given(@"I click on the shopping cart")]
        public void GivenIClickOnTheShoppingCart()
        {
            _inventoryPage.ClickShoppingCartButton();
        }
    }
}
