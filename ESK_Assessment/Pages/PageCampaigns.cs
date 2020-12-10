using ESK_Assessment.Configurations;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESK_Assessment.Pages
{
    public class PageCampaigns : Shared.Shared
    {
        IWebDriver _Driver;
        public PageCampaigns(IWebDriver driver)
        {
            _Driver = driver;
        }
        public IWebElement ActionsDropdown { get { return FindElementByCssSelector("tr td.dropdown a", _Driver); } }
        public IWebElement PreviewInBrowserLink { get { return FindElementByCssSelector("td.dropdown a[title='Preview in browser']", _Driver); } }
        public IWebElement Preview { get { return FindElementByXPath("//body/a", _Driver); } }

        public void VisitFirstPreview()
        {
            ActionsDropdown.Click();
            PostTestActions pta = new PostTestActions();
            pta.TakeScreenshot(_Driver);
            string prevUrl = PreviewInBrowserLink.GetAttribute("href");
            _Driver.Navigate().GoToUrl(prevUrl);
        }



    }
}
