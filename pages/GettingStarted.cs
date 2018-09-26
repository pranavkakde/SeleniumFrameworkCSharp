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
        private Util util = null;
        private By pageImageClass = By.ClassName("title-highlights");
        private By backToTop = By.CssSelector(".back-to-top-a");
        private By legalLink = By.LinkText("Legal");
        public GettingStarted(IWebDriver d)
        {
            driver = d;
            util = new Util(d);
        }
        public bool isFeaturePageLoaded()
        {
            return util.IsElementVisible(pageImageClass);
        }
        public bool clickLegalLink()
        {
            return util.ClickElement(legalLink);
        }
        public bool clickBackToTop()
        {
            return util.ClickElement(backToTop);
        }
    }
}
