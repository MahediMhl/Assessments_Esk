using ESK_Assessment.Configurations;
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
        public static string _BaseUrl = ConfigurationManager.AppSettings["baseUrl"];        
        [SetUp]
        public void Setup()
        {
            Initialization initialization = new Initialization();
            _Driver = initialization.Initialize();            
            _Driver.Navigate().GoToUrl(_BaseUrl);
        }
        [Test]
        public void Verify()
        {

        }
        [TearDown]
        public void TearDown()
        {
            PostTestActions PostTestAction = new PostTestActions();
            PostTestAction.TakeAction(TestContext.CurrentContext.Result.Outcome.Status, _Driver);
        }
    }
}
