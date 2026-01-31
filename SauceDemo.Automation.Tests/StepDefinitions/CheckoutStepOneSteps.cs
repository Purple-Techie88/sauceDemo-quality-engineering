using SauceDemo.Automation.Tests.Pages;
using TechTalk.SpecFlow;

namespace SauceDemo.Automation.Tests.StepDefinitions
{
  [Binding]
  public class CheckoutStepOneSteps
  {
    private readonly CheckoutStepOnePage _checkoutStepOnePage;

    public CheckoutStepOneSteps(CheckoutStepOnePage checkoutStepOnePage)
    {
      _checkoutStepOnePage = checkoutStepOnePage;
    }

    [Given(@"I type ""(.*)"" for ""(.*)""")]
    public void GivenITypeFor(string value, string fieldName)
    {
      _checkoutStepOnePage.FillField(fieldName, value);
    }

    [When(@"I click on the CONTINUE button")]
    public void WhenIClickOnTheCONTINUEButton()
    {
      _checkoutStepOnePage.ClickContinueButton();
    }
  }
}
