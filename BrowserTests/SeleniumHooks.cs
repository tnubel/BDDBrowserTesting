using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NBehave.Narrator.Framework;
using NBehave.Narrator.Framework.Hooks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace BrowserTests
{
    [Hooks]
    public class SeleniumHooks
    {
        private IWebDriver driver;

        [BeforeFeature]
        public void SetupFeature()
        {

        }

        public void TearDownFeature()
        {

        }

        [NBehave.Narrator.Framework.Hooks.BeforeScenario]
        public void SetupScenario()
        {
            //todo: Extract driver  choice
            driver = new FirefoxDriver();
            ScenarioContext.Current.Add(ContextKeys.Driver,driver);
        }

        [NBehave.Narrator.Framework.Hooks.AfterScenario]
        public void TearDownScenario()
        {
            if (driver == null)
            {
                return;

            }
            driver.Close();

        }

    }

    public static class ContextKeys
    {
        public const string Driver = "DRIVER";
    }
}
