using TechTalk.SpecFlow;
using SauceDemo.Automation.Tests.Pages;

namespace SauceDemo.Automation.Tests.StepDefinitions
{
    [Binding]
    public class LoginSteps
    {
        private readonly LoginPage _loginPage;
        private readonly InventoryPage _inventoryPage;

        public LoginSteps(LoginPage loginPage, InventoryPage inventoryPage)
        {
            _loginPage = loginPage;
            _inventoryPage = inventoryPage;
        }

        [Given(@"the user is on the Sauce Demo login page")]
        public void GivenUserIsOnLoginPage()
        {
            _loginPage.GoTo();
        }

        [When(@"I login with username ""(.*)"" and password ""(.*)""")]
        public void WhenILoginWithUsernameAndPassword(string username, string password)
        {
            _loginPage.LoginAs(username, password);
        }

        [Given(@"I log in with valid credentials")]
        public void GivenILogInWithValidCredentials(Table table)
        {
            _loginPage.GoTo();
            _loginPage.LoginAs(table.Rows[0]["userName"], table.Rows[0]["password"]);
        }

        [Then(@"the inventory page should be displayed")]
        public void ThenInventoryPageShouldBeDisplayed()
        {
            Assert.That(_inventoryPage.IsDisplayed(), Is.True, "Inventory page should be visible after login");
        }

        [Then(@"the error message is displayed")]
        public void ThenTheErrorMessageIsDisplayed()
        {
            var actual = _loginPage.GetErrorMessage();
            Assert.That(actual, Is.Not.Empty);
            Assert.That(actual, Does.Contain("Epic sadface"));
        }
    }
}
