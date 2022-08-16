using System.Reflection;
using System.Xml.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;

namespace SeleniumFramework.util
{
    internal class DriverManager
    {
        //code to manager driver instances
        public WebDriver driver { get; set; }
        public DriverManager()
        {

        }
        public WebDriver getDriver(BrowserConfig browserConfig)
        {
            string gridUrl = Environment.GetEnvironmentVariable("gridUrl");
            string browserName = Environment.GetEnvironmentVariable("browserName");
            if(gridUrl==null){
                TestContext.WriteLine("gridUrl command line parameter is not provided. Launching driver using local browser.");
            }
            if(browserName==null){
                TestContext.WriteLine("Browser Name is empty. Please provide one of the values for browserName [chrome, edge, firefox]");
                Assert.Fail();
            }
            switch (browserName)
            {
                case ("chrome"):
                    ChromeOptions chromeOptions = new ChromeOptions();
                    
                    if (browserConfig.Headless)
                    {
                        chromeOptions.AddArgument("--headless");
                    }
                    chromeOptions.AddArgument("--window-size=1920,1080");
                    chromeOptions.AddArgument("--ignore-certificate-errors");
                    if(gridUrl==null){
                        driver = new ChromeDriver(chromeOptions);
                    }else{
                        driver = new RemoteWebDriver(new Uri(gridUrl), chromeOptions);
                    }
                    break;
                case ("firefox"):
                    FirefoxOptions ffOptions = new FirefoxOptions();
                    if (browserConfig.Headless)
                    {
                        ffOptions.AddArgument("--headless");
                    }
                    ffOptions.AddArgument("--window-size=1920,1080");
                    ffOptions.AddArgument("--ignore-certificate-errors");
                    if(gridUrl==null){
                        driver = new FirefoxDriver(ffOptions);
                    }else{
                        driver = new RemoteWebDriver(new Uri(gridUrl), ffOptions);
                    }
                    break;
                case ("edge"):
                    EdgeOptions edgeOptions = new EdgeOptions();
                    if (browserConfig.Headless)
                    {
                        edgeOptions.AddArgument("--headless");
                    }
                    edgeOptions.AddArgument("--window-size=1920,1080");
                    edgeOptions.AddArgument("--ignore-certificate-errors");
                    if(gridUrl ==null){
                        driver = new EdgeDriver(edgeOptions);
                    }else{
                        driver = new RemoteWebDriver(new Uri(gridUrl), edgeOptions);
                    }
                    break;
                default:
                    break;
            }
            return driver;
        }
    }
}
