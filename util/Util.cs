using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Support.Extensions;
using System.Diagnostics;

namespace SeleniumFramework.util
{
    class Util
    {
        private IWebDriver driver = null;
        public Util(IWebDriver d)
        {
            driver = d;
        }
        public void captureScreenshot()
        {
            Screenshot ss = ((ITakesScreenshot)driver).GetScreenshot();
            string screenshot = ss.AsBase64EncodedString;
            byte[] screenshotAsByteArray = ss.AsByteArray;
            ss.SaveAsFile("E:\\code\\CSharpe\\" + "Step" + GetTimestamp(DateTime.Now) + ".jpeg", OpenQA.Selenium.ScreenshotImageFormat.Jpeg);
            //Console.WriteLine("Screenshot captured in file " + "E:\\code\\CSharpe\\" + "Step" + GetTimestamp(DateTime.Now) + ".jpeg");
        }
        public static String GetTimestamp(DateTime value)
        {
            return value.ToString("yyyyMMddHHmmssffff");
        }

        public IWebElement WaitForElementVisible(By locator)
        {
            WebDriverWait wait = new WebDriverWait(driver, System.TimeSpan.FromSeconds(10));
            IWebElement element = wait.Until(ExpectedConditions.ElementIsVisible(locator));
            return element;
        }
        public bool ClickElement(By locator)
        {
            bool returnValue = false;
            try
            {
                WaitForElementVisible(locator).Click();
                returnValue = true;
            }
            catch (NoSuchElementException e)
            {
                Console.WriteLine("Element " + locator + "not found on page " + driver.Title);
                returnValue = false;
            }
            catch (Exception e)
            {
                Console.WriteLine("Unknown error " + e.Message + " occurred on page " + driver.Title);
                returnValue = false;
            }
            return returnValue;
        }
        public bool IsElementVisible(By locator)
        {
            bool returnValue = false;
            try
            {
                returnValue=WaitForElementVisible(locator).Displayed;
            }
            catch (NoSuchElementException e)
            {
                Console.WriteLine("Element " + locator + "not found on page " + driver.Title);
                returnValue=false;
            }
            catch (Exception e)
            {
                Console.WriteLine("Unknown error " + e.Message + " occurred on page " + driver.Title);
                returnValue = false;
            }
            return returnValue;
        }
    }
}
