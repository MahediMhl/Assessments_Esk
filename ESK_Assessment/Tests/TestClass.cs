using ESK_Assessment.Configurations;
using ESK_Assessment.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESK_Assessment.Tests
{
    public class TestClass
    {
        IWebDriver _Driver;
        PageGoogle _PageGoogle;
        PageEskimiLogin _PageEskimiLogin;
        public static string _BaseUrl = ConfigurationManager.AppSettings["baseUrl"];        
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
        public void Verify()
        {
            string searchString = "dsp.eskimi.com";
            string username = ConfigurationManager.AppSettings["username"];
            string password = ConfigurationManager.AppSettings["password"];
            string strUrl = _PageGoogle.Search(searchString, _Driver);
            _Driver = _PageGoogle.OpenSearchResultInNewWindow(strUrl);
            _PageEskimiLogin = new PageEskimiLogin(_Driver);
            _PageEskimiLogin.DoLogin(username, password); //credentials do not work
        }
        [TearDown]
        public void TearDown()
        {
            PostTestActions PostTestAction = new PostTestActions();
            PostTestAction.TakeAction(TestContext.CurrentContext.Result.Outcome.Status, _Driver);
        }
    }
}
