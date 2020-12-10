using ESK_Assessment.Configurations;
using ESK_Assessment.Shared;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESK_Assessment.Pages
{    
    public class PageGoogle : Shared.Shared
    {
        public IWebDriver _Driver;
        public IWebElement Searchbox { get { return FindElementByCssSelector("input[type='text']", _Driver); } }
        public IWebElement SearchResult(string linkText) { return FindElementByLinkText(linkText, _Driver); }

        public PageGoogle(IWebDriver driver)
        {
            _Driver = driver;
        }

        public string Search(string searchString, IWebDriver driver)
        {
            Searchbox.SendKeys(searchString);
            Searchbox.SendKeys(Keys.Enter);
            string strURL = FindElementByLinkText(searchString, driver).Text;
            return strURL;
        }        

    }
}
