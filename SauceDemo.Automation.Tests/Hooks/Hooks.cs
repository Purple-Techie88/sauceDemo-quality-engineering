using SauceDemo.Automation.Tests.Drivers;
using OpenQA.Selenium;
using TechTalk.SpecFlow;
using System;
using System.IO;

namespace SauceDemo.Automation.Tests.Hooks;

[Binding]
public class Hooks
{
    private readonly ScenarioContext _scenarioContext;

    public Hooks(ScenarioContext scenarioContext)
    {
        _scenarioContext = scenarioContext;
    }

    [BeforeScenario]
    public void BeforeScenario()
    {
        var headless = string.Equals(
            Environment.GetEnvironmentVariable("HEADLESS"),
            "true",
            StringComparison.OrdinalIgnoreCase
        );

        IWebDriver driver = DriverFactory.CreateChromeDriver(headless);
        DriverContext.Set(_scenarioContext, driver);
    }

    [AfterScenario]
    public void AfterScenario()
    {
        if (DriverContext.TryGet(_scenarioContext, out IWebDriver driver))
        {
            if (_scenarioContext.TestError != null)
            {
                SaveScreenshotOnFailure(driver, _scenarioContext.ScenarioInfo.Title);
            }

            driver.Quit();
            driver.Dispose();
        }
    }

    private void SaveScreenshotOnFailure(IWebDriver driver, string scenarioTitle)
    {
        try
        {
            if (driver is ITakesScreenshot takesScreenshot)
            {
                var screenshot = takesScreenshot.GetScreenshot();
                var safeTitle = MakeSafeFileName(scenarioTitle);
                var fileName = $"{safeTitle}_{DateTime.Now:yyyyMMdd_HHmmss}.png";
                var folder = Path.Combine(
                    AppDomain.CurrentDomain.BaseDirectory,
                    "TestArtifacts",
                    "Screenshots"
                );
                Directory.CreateDirectory(folder);
                var fullPath = Path.Combine(folder, fileName);
                screenshot.SaveAsFile(fullPath);

                Console.WriteLine($"Screenshot saved to: {fullPath}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Screenshot failed: {ex.Message}");
        }
    }

    private string MakeSafeFileName(string name)
    {
        foreach (var c in Path.GetInvalidFileNameChars())
        {
            name = name.Replace(c, '_');
        }
        return name.Replace(' ', '_');
    }
}
