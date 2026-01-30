using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;
using SauceDemo.Automation.Tests.Drivers;
using SauceDemo.Automation.Tests.Pages;



namespace SauceDemo.Automation.Tests.StepDefinitions
{
    [Binding]
    public class LoginSteps
    {
        private readonly IWebDriver _driver;

        private readonly LoginPage _loginPage;

        public LoginSteps(ScenarioContext scenarioContext)
        {
            _driver = DriverContext.Get(scenarioContext);
            _loginPage = new LoginPage(_driver);
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


    //  [Then(@"the inventory page should be displayed")]
    //  public void ThenInventoryPageShouldBeDisplayed(string expectedMessage)
    //  {
    //      var actual = _loginPage.GetErrorMessage();
    //      Assert.That(actual, Does.Contain(expectedMessage));
    //      _driver.Quit();
    //  }
    [Then(@"the error message is displayed")]
    public void ThenTheErrorMessageIsDisplayed()
    {
        var actual = _loginPage.GetErrorMessage();
        Assert.That(actual, Is.Not.Empty);
        Assert.That(actual, Does.Contain("Epic sadface"));
    }

    }

}
