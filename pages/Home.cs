using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using SeleniumFramework.util;
namespace SeleniumFramework.pages
{
    class Home
    {
        private IWebDriver driver = null;
        private Util util = new Util();
        
        public Home(IWebDriver driver)
        {
            this.driver = driver;
        }
        public IWebElement getprestaShop = null;
        public IWebElement getHomeDownloadLink()
        {
            getprestaShop = driver.FindElement(By.LinkText("Get PrestaShop"));
            return getprestaShop;
        }
        public bool isHomePageLoaded()
        {
            return getHomeDownloadLink().Displayed;
        }
        public void openHome()
        {
            driver.Navigate().GoToUrl("https://www.prestashop.com/en");
            util.captureScreenshot(driver);
        }

    }
}
