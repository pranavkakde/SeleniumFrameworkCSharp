using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using SeleniumFramework.util;
namespace SeleniumFramework.pages
{
    class GettingStarted
    {
        private IWebDriver driver = null;
        private IWebElement menuPlus = null;
        private Util util = new Util();
        private String gsPageValidationText = "/html/body/div[1]/div/div[1]/div[1]/div/div";

        public GettingStarted(IWebDriver driver)
        {
            this.driver = driver;
        }
        public IWebElement getMenuPlus()
        {
            return driver.FindElement(By.Id("menuPlus"));
        }
        public void clickMenuPlus()
        {
            getMenuPlus().Click();
            util.captureScreenshot(driver);
        }
        public bool isGSLinkVisible()
        {
            return driver.FindElement(By.LinkText("Get Started")).Displayed;
        }
        public void clickGSLink()
        {
            driver.FindElement(By.LinkText("Get Started")).Click();
            util.captureScreenshot(driver);
        }
        public bool isGSValidationTextVisible()
        {
            return driver.FindElement(By.XPath(gsPageValidationText)).Displayed;
        }
    }
}
