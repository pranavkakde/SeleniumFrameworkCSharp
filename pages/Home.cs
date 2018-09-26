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
        //########## Setup ############
        private IWebDriver driver = null;
        private Util util = null;
        public Home(IWebDriver d)
        {
            this.driver = d;
            util = new Util(d);
        }
        //########### Element Definition #############
        private By getprestaShop = By.CssSelector(".popup-link.prestashop-link.primary-link");
        private By productMenuXpath = By.XPath("//*[@id='header-menu']/ul/div[1]/div[1]/a");
        private By featureMenuXpath = By.XPath("//*[@id='more-submenus-column-4093']/ul/li[3]/a");
        //######### Function Definition #################
        public bool isHomePageLoaded()
        {
            return util.IsElementVisible(getprestaShop);
        }
        public bool clickProductMenu()
        {
            return util.ClickElement(productMenuXpath);
        }
        public bool clickFeatureMenu()
        {
            return util.ClickElement(featureMenuXpath);
        }
        public void openHome(string url)
        {
            driver.Navigate().GoToUrl(url);
            driver.Manage().Window.FullScreen();
            util.captureScreenshot();
        }
    }
}
