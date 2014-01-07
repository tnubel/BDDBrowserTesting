using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NBehave.Narrator.Framework;
using OpenQA.Selenium;

namespace BrowserTests
{
    class NBehaveUtils
    {
        public static IWebDriver GetDriver()
        {
            if (ScenarioContext.Current == null)
            {
                return null;
            }
            if (ScenarioContext.Current.ContainsKey(ContextKeys.Driver))
            {
                return (IWebDriver) ScenarioContext.Current[ContextKeys.Driver];
            }
            throw new Exception("Driver cannot be found");
        }
    }
}
