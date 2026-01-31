using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;
using WebDriverManager.Helpers;

namespace SauceDemo.Automation.Tests.Drivers
{
    public static class DriverFactory
    {
        public static IWebDriver CreateChromeDriver(bool headless = true)
        {
            new DriverManager().SetUpDriver(new ChromeConfig(), VersionResolveStrategy.MatchingBrowser);

            var options = new ChromeOptions();
            options.AddUserProfilePreference("profile.password_manager_leak_detection", false);
            if (headless)
            {
                options.AddArgument("--headless=new");
                options.AddArgument("--window-size=1280,800");
            }
            return new ChromeDriver(options);
        }
    }
}