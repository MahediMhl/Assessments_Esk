using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESK_Assessment.Pages
{
    public class PageEskimiLogin : Shared.Shared
    {
        IWebDriver _Driver;
        public PageEskimiLogin(IWebDriver driver)
        {
            _Driver = driver;
        }
        public IWebElement UserName { get { return FindElementById("username", _Driver); } }
        public IWebElement Password { get { return FindElementById("password", _Driver); } }
        public IWebElement BtnLogin { get { return FindElementByXPath("//input[contains(@value,'Log in')]", _Driver); } }
        public IList<IWebElement> ErrorDivs { get { return _Driver.FindElements(By.XPath("//strong[contains(.,'Error')]")); } }

        public void DoLogin(string username, string pass)
        {
            UserName.SendKeys(username);
            Password.SendKeys(pass);
            BtnLogin.Click();
            Assert.IsTrue(ErrorDivs.Count == 0, "valid user could not login!!!");
        }
    }
}
