using SauceDemo.Automation.Tests.Pages;
using TechTalk.SpecFlow;

namespace SauceDemo.Automation.Tests.StepDefinitions
{
  [Binding]
  public class CheckoutStepTwoSteps
  {
    private readonly CheckoutStepTwoPage _checkoutStepTwoPage;

    public CheckoutStepTwoSteps(CheckoutStepTwoPage checkoutStepTwoPage)
    {
      _checkoutStepTwoPage = checkoutStepTwoPage;
    }

    [Then(@"Item total will be equal to the ""(.*)"" for item in the list")]
    public void ThenItemTotalWillBeEqualToTheForItemInTheList(string type)
    {
      double sumOfItems = _checkoutStepTwoPage.AddCartTotal();
      double displayedSubtotal = _checkoutStepTwoPage.GetCartSubtotal(type);
      Assert.That(sumOfItems, Is.EqualTo(displayedSubtotal).Within(0.01),
        $"Item total ({sumOfItems}) should equal displayed subtotal ({displayedSubtotal})");
    }

    [Then(@"a ""(.*)"" rate of (.*) % is applied to the total")]
    public void ThenARateOfIsAppliedToTheTotal(string type, int taxRate)
    {
        double expectedTax = _checkoutStepTwoPage.CalculateTaxRate("tax", taxRate);
        double displayedTax = _checkoutStepTwoPage.GetCartSubtotal("tax");
        Assert.That(expectedTax, Is.EqualTo(displayedTax).Within(0.01),
          $"Tax amount ({expectedTax}) should equal displayed tax amount ({displayedTax})");
    }

    [Then(@"the total will be equal to the ""(.*)"" for item in the list")]
    public void ThenTheTotalWillBeEqualToTheForItemInTheList(string total0)
    {
      double expectedTotal = double.Parse(total0.Replace("$", "").Trim());
      double actualTotal = _checkoutStepTwoPage.GetTotal();
      Assert.That(actualTotal, Is.EqualTo(expectedTotal).Within(0.01),
        $"Expected total {expectedTotal} but got {actualTotal}");
    }
  }
}
