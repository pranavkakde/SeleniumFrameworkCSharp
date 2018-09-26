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
namespace SeleniumFramework.tests
{
    [TestFixture]
    
    class testClass
    {
        IWebDriver driver = null;
        Util util = new Util();
        GettingStarted gettingStarted = null;
        Home home = null;
        public static void Main(string [] args)
        {

        }
        [OneTimeSetUp]
        public void initialize()
        {
            driver = new ChromeDriver();
            gettingStarted = new GettingStarted(driver);
            home = new Home(driver);
            home.openHome();
        }
        [Test]
        public void testHomePage() {            
            //Assert.AreEqual(driver.Title, "PrestaShop - Free ecommerce software");
            Assert.IsTrue(home.isHomePageLoaded());
            Console.WriteLine("App is launched successfully");
        }
        [Test]
        public void testGSPage()
        {
            //startApp();
            gettingStarted.clickMenuPlus();
            Assert.IsTrue(gettingStarted.isGSLinkVisible());
            gettingStarted.clickGSLink();
            Assert.IsTrue(gettingStarted.isGSValidationTextVisible());
        }
        [OneTimeTearDown]
        public void cleanUp()
        {
            driver.Quit();
        }
    }
}
