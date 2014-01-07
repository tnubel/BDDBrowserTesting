using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading;
using OpenQA.Selenium;


namespace BrowserTests
{
    public static class DriverExtensions
    {
        public static IWebElement SearchForElement(this IWebDriver driver, string key)
        {
            IWebElement elem = null;
            //1: ID
            try
            {
                elem = driver.FindElement(By.Id(key));
            }
            catch (NoSuchElementException)
            {
                //2: Name (if only one)
                try
                {
                    elem = driver.FindElement(By.Name(key));

                }
                catch (Exception e)
                {   //3: CSS
                    try
                    {
                        elem = driver.FindElements((By.CssSelector(key))).Single();
                    }
                    catch (Exception e2)
                    {
                        throw new Exception("No element found with id, name or css selector: "+key);
                    }
                }
            }

            return elem;
        }

        public static IWebElement SearchForButtonWithText(this IWebDriver driver, string key)
        {
            var xpath = String.Format("//button[contains(text(),\"{0}\"]",key);
            return driver.FindElement(By.XPath(xpath));
        }

        public static void SetValueOfTextBoxByTitle(this IWebDriver driver, string title, string value)
        {
            var elem = driver.FindElement(By.CssSelector("[title='" + title + "']"));
            elem.Clear();
            elem.SendKeys(value);
        }

        public static void ClickSelector(this IWebDriver driver, string selector)
        {
            var elem = driver.FindElement(By.CssSelector(selector));
            driver.FocusOnElement(elem);
            elem.Click();
        }

        public static void SaveAndCloseModal(this IWebDriver driver, string closeCssSelector)
        {
            driver.FindElement(By.CssSelector(closeCssSelector)).Click();
            Thread.Sleep(2000);
            driver.SwitchTo().DefaultContent();
        }

        public static void FocusOnElement(this IWebDriver driver, IWebElement elem)
        {
            IJavaScriptExecutor js = driver as IJavaScriptExecutor;
            js.ExecuteScript("arguments[0].scrollIntoView();", elem);
        }

        public static void ResizeToFullScreen(this IWebDriver driver)
        {
            IJavaScriptExecutor js = driver as IJavaScriptExecutor;
            js.ExecuteScript("window.resizeTo(screen.width,screen.height);window.x=0;window.y=0");
        }

        public static bool CanFindText(this IWebDriver driver, string text)
        {
            string xpathToFind = String.Format("//*[contains(text(),\"{0}\")]",text);
            try
            {
                driver.FindElement(By.XPath(xpathToFind));
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        
        }
    }
}
