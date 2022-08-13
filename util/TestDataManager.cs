using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace SeleniumFramework.util
{
    public sealed class TestDataManager 
    {
        //manage test data from appsettings.json
        public string AppURL { get; set; }
        public BrowserConfig browserConfig { get; set; }

        private static TestDataManager instance = null;

        public static TestDataManager GetInstance{
            get
            {
                if (instance == null)
                    instance = new TestDataManager();
                return instance;
            }
        }
        private TestDataManager()
        {
            IConfiguration config = getTestData();
            AppURL = config.GetSection("TestData").GetValue<string>("AppUrl");
            browserConfig = config.GetSection("Config").Get<BrowserConfig>();
            Console.WriteLine($"AppURL = {AppURL}");
        }

        public IConfiguration getTestData()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false);

            return builder.Build();

        }
    }
    public class BrowserConfig
    {
        public string BrowserName { get; set; }
        public bool Headless { get; set; }

        public BrowserConfig()
        {

        }

    }
}
