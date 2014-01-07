using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NBehave.Narrator.Framework;
using OpenQA.Selenium;

namespace BrowserTests
{
    [ActionSteps]
    public class SeleniumSteps
    {
        public IWebDriver driver;
        [Given("a browser")]
        public void GetBrowser()
        {
            driver = NBehaveUtils.GetDriver();
            Assert.IsTrue(driver != null);
        }

        [When("I visit \"$website\"")]
        public void VisitUrl(string website)
        {
            driver.Navigate().GoToUrl(website);
        }

        [When("I fill in \"$fieldname\" with \"$value\"")]
        [When("I fill in the form field $fieldname with \"$value\"")]
        public void FillElementWithValue(string fieldname, string value)
        {
            var field = driver.SearchForElement(fieldname);
            field.SendKeys(value);
        }

        [When("I press \"$elementName\"")]
        public void PressElement(string elementName)
        {
            var element = driver.SearchForElement(elementName);
            element.Click();
        }

        [When("I press the button \"$buttontext\"")]
        public void PressButton(string buttonText)
        {
            var field = driver.SearchForButtonWithText(buttonText);
        }

        [When("I click the link with text that contains \"$linktext\"")]
        public void ClickLinkWithText(string linktext)
        {
            var link = driver.FindElement(By.PartialLinkText(linktext));
            link.Click();
        }

        [When("And I press the element with xpath \"$xpath\"")]
        public void ClickXpath(string xpath)
        {
            var link = driver.FindElement(By.XPath(xpath));
            link.Click();
        }

        [When("I wait for $num seconds")]
        [When("I wait for $num second")]
        public void WaitTime(int num)
        {
            Thread.Sleep(num*1000);
        }

        [Then("I should see \"$text\"")]
        public void CheckForText(string text)
        {
            Assert.IsTrue(driver.CanFindText(text));
        }
    }
}
