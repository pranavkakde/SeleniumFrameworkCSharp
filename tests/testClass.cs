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
        TestDataManager testData = null;
        DriverManager dm = new DriverManager();
        public static void Main(string[] args)
        {
            Console.WriteLine("Main");
        }
        [OneTimeSetUp]
        public void initialize()
        {
            testData = TestDataManager.GetInstance;
            driver = dm.getDriver(testData.browserConfig);
            gettingStarted = new GettingStarted(driver);
            home = new Home(driver);
        }
        [Test]
        public void testHomePage()
        {
            TestContext.WriteLine(String.Format("Launching App {0}",  testData.AppURL));
            home.openHome(testData.AppURL);
            home.isHomePageLoaded().Should().BeTrue();
            TestContext.WriteLine("App is launched successfully");
        }
        [Test]
        public void testGoToFeaturePage()
        {
            home.openHome(testData.AppURL);
            TestContext.WriteLine("App is launched successfully");
            home.clickResourceMenu().Should().BeTrue();
            TestContext.WriteLine("Clicked on Resource Menu");
            home.clickFeatureMenu().Should().BeTrue();
            TestContext.WriteLine("Clicked on Feature Menu");
        }
        [Test]
        public void testFeaturePage()
        {
            home.openHome(testData.AppURL);
            TestContext.WriteLine("App is launched successfully");
            home.clickResourceMenu().Should().BeTrue();
            TestContext.WriteLine("Clicked on Resource Menu");
            home.clickFeatureMenu().Should().BeTrue();
            TestContext.WriteLine("Clicked on Feature Menu");
            gettingStarted.isFeaturePageLoaded().Should().BeTrue();
            gettingStarted.clickLegalLink().Should().BeTrue();
            TestContext.WriteLine("Clicked on Legal Link");
            gettingStarted.clickBackToTop().Should().BeTrue();
            TestContext.WriteLine("Feature Page testing completed");
        }
        [OneTimeTearDown]
        public void cleanUp()
        {
            driver.Quit();
        }
    }
}
