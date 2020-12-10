using ESK_Assessment.Configurations;
using ESK_Assessment.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ESK_Assessment.Tests
{
    public class TestClass
    {
        IWebDriver _Driver;
        IWebDriver _Driver2;
        PageGoogle _PageGoogle;
        PageEskimiLogin _PageEskimiLogin;
        PageCampaigns _PageCampaigns;
        public static string _BaseUrl = ConfigurationManager.AppSettings["baseUrl"];        
        public static int _Timeout = int.Parse(ConfigurationManager.AppSettings["timeout"]);        
        [SetUp]
        public void Setup()
        {
            Initialization initialization = new Initialization();
            _Driver = initialization.Initialize();
            _PageGoogle = new PageGoogle(_Driver);
            _PageEskimiLogin = new PageEskimiLogin(_Driver);            
            _Driver.Navigate().GoToUrl(_BaseUrl);
        }
        [Test]
        public void VerifyCampaign()
        {
            string searchString = "dsp.eskimi.com";
            string username = ConfigurationManager.AppSettings["username"];
            string password = ConfigurationManager.AppSettings["password"];            
            string strUrl = _PageGoogle.Search(searchString, _Driver);
            PostTestActions pta = new PostTestActions();
            pta.TakeScreenshot(_Driver);
            string window1 = _Driver.CurrentWindowHandle;
            _Driver2 = new Initialization().Initialize();            
            _Driver2.Navigate().GoToUrl(strUrl);
            _PageEskimiLogin = new PageEskimiLogin(_Driver2);
            pta.TakeScreenshot(_Driver2);
            _PageEskimiLogin.DoLogin(username, password, _Driver2);
            pta.TakeScreenshot(_Driver2);
            _PageCampaigns = new PageCampaigns(_Driver2);
            _PageCampaigns.VisitFirstPreview();
            pta.TakeScreenshot(_Driver2);
            _Driver2.SwitchTo().Frame(0);
            string redirectionURL = _PageCampaigns.Preview.GetAttribute("href");
            _PageCampaigns.Preview.Click();
            _Driver2.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(_Timeout);
            _Driver2.SwitchTo().Window(_Driver2.WindowHandles.Last());
            Thread.Sleep(6000); //helpless :(, had to avoid weird error            
            string actualURL = _Driver2.Url;
            pta.TakeScreenshot(_Driver2);
            Assert.IsTrue(actualURL.Equals(redirectionURL)); 
            _Driver2.Quit();
        }
        [TearDown]
        public void TearDown()
        {
            PostTestActions PostTestAction = new PostTestActions();
            if(_Driver2!=null)
            {
                PostTestAction.TakeAction(TestContext.CurrentContext.Result.Outcome.Status, _Driver2);
            }
            PostTestAction.TakeAction(TestContext.CurrentContext.Result.Outcome.Status, _Driver);
        }
    }
}
