using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using SeleniumFramework.util;
using System.Runtime;
using SeleniumFramework.pages;
using FluentAssertions;
namespace SeleniumFramework.tests
{
    [TestFixture]

    class testClass
    {
        IWebDriver driver = null;
        GettingStarted gettingStarted = null;
        Home home = null;
        public static void Main(string[] args)
        {

        }
        [OneTimeSetUp]
        public void initialize()
        {
            driver = new ChromeDriver();
            gettingStarted = new GettingStarted(driver);
            home = new Home(driver);
        }
        [Test]
        public void testHomePage()
        {
            home.openHome("https://www.prestashop.com/en");
            home.isHomePageLoaded().Should().BeTrue();
            Console.WriteLine("App is launched successfully");
        }
        [Test]
        public void testGoToFeaturePage()
        {
            home.openHome("https://www.prestashop.com/en");
            home.clickProductMenu();
            home.clickFeatureMenu();
            Console.WriteLine("Clicked on Feature Menu");
        }
        [Test]
        public void testFeaturePage()
        {
            home.openHome("https://www.prestashop.com/en");
            home.clickProductMenu();
            home.clickFeatureMenu();
            gettingStarted.isFeaturePageLoaded().Should().BeTrue();
            gettingStarted.clickLegalLink();
            gettingStarted.clickBackToTop().Should().BeTrue();
            Console.WriteLine("Feature Page testing completed");
        }
        [OneTimeTearDown]
        public void cleanUp()
        {
            driver.Quit();
        }
    }
}
