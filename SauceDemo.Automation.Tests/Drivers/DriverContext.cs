using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SauceDemo.Automation.Tests.Drivers
{
public static class DriverContext
{
    private const string DriverKey = "WebDriver";

    public static void Set(ScenarioContext context, IWebDriver driver)
        => context.Set(driver, DriverKey);

    public static IWebDriver Get(ScenarioContext context)
        => context.Get<IWebDriver>(DriverKey);

    public static bool TryGet(ScenarioContext context, out IWebDriver driver)
        => context.TryGetValue(DriverKey, out driver);
    }
}