using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESK_Assessment.Configurations
{
    public class Initialization
    {
        public IWebDriver _Driver;
        public IWebDriver Initialize()
        {
            string browser = ConfigurationManager.AppSettings["browser"];
            switch (browser.ToLower())
            {
                case "chrome":
                    var chromeOptions = new ChromeOptions();
                    _Driver = new ChromeDriver(chromeOptions);
                    break;
                case "firefox":
                    _Driver = new FirefoxDriver();
                    break;
            }
            _Driver.Manage().Window.Maximize();
            return _Driver;
        }
    }
}
