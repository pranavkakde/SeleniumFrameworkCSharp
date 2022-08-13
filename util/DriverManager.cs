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
            
            switch (browserConfig.BrowserName)
            {
                case ("chrome"):
                    ChromeOptions options = new ChromeOptions();
                    
                    if (browserConfig.Headless)
                    {
                        options.AddArgument("--headless");
                    }
                    options.AddArgument("--window-size=1920,1080");
                    options.AddArgument("--ignore-certificate-errors");
                    driver = new ChromeDriver(options);
                    break;
                case ("firefox"):
                    FirefoxOptions ffOptions = new FirefoxOptions();
                    if (browserConfig.Headless)
                    {
                        ffOptions.AddArgument("--headless");
                    }
                    ffOptions.AddArgument("--window-size=1920,1080");
                    ffOptions.AddArgument("--ignore-certificate-errors");
                    driver = new FirefoxDriver(ffOptions);
                    break;
                case ("edge"):
                    EdgeOptions edgeOptions = new EdgeOptions();
                    if (browserConfig.Headless)
                    {
                        edgeOptions.AddArgument("--headless");
                    }
                    edgeOptions.AddArgument("--window-size=1920,1080");
                    edgeOptions.AddArgument("--ignore-certificate-errors");
                    driver = new EdgeDriver(edgeOptions);
                    break;
                default:
                    break;
            }
            return driver;
        }
    }
}
