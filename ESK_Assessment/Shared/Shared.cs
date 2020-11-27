using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESK_Assessment.Shared
{
    public class Shared
    {
        public IWebElement FindElementById(string elementID, IWebDriver driver)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(120));
            wait.Until((d) =>
            {
                try
                {
                    IWebElement element = driver.FindElement(By.Id(elementID));
                    if (element.Displayed && element.Enabled)
                    {
                        int x = element.Size.Height;
                        int y = element.Size.Width;
                        Assert.IsTrue((x + y) > 0);
                        return true;
                    }
                    else
                        return false;
                }
                catch
                {
                    return false;
                }
            });
            return driver.FindElement(By.Id(elementID));
        }

        internal IWebElement FindElementByName(string name, IWebDriver driver)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(120));
            wait.Until((d) =>
            {
                try
                {
                    IWebElement element = driver.FindElement(By.Name(name));
                    if (element.Displayed && element.Enabled)
                    {
                        int x = element.Size.Height;
                        int y = element.Size.Width;
                        Assert.IsTrue((x + y) > 0);
                        return true;
                    }
                    else
                        return false;
                }
                catch
                {
                    return false;
                }
            });
            return driver.FindElement(By.Name(name));
        }
        public IWebElement FindElementByXPath(string XPath, IWebDriver driver)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(120));
            wait.Until((d) =>
            {
                try
                {
                    IWebElement element = driver.FindElement(By.XPath(XPath));
                    if (element.Displayed && element.Enabled)
                    {
                        int x = element.Size.Height;
                        int y = element.Size.Width;
                        Assert.IsTrue((x + y) > 0);
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                catch
                {
                    return false;
                }
            });
            return driver.FindElement(By.XPath(XPath));
        }

        public IWebElement FindElementByCssSelector(string selector, IWebDriver driver)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(120));
            wait.Until((d) =>
            {
                try
                {
                    IWebElement element = driver.FindElement(By.CssSelector(selector));
                    if (element.Displayed && element.Enabled)
                    {
                        int x = element.Size.Height;
                        int y = element.Size.Width;
                        Assert.IsTrue((x + y) > 0);
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                catch
                {
                    return false;
                }
            });
            return driver.FindElement(By.CssSelector(selector));
        }
        public IWebElement FindElementByLinkText(string linkText, IWebDriver driver)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(120));
            wait.Until((d) =>
            {
                try
                {
                    IWebElement element = driver.FindElement(By.PartialLinkText(linkText));
                    if (element.Displayed && element.Enabled)
                    {
                        int x = element.Size.Height;
                        int y = element.Size.Width;
                        Assert.IsTrue((x + y) > 0);
                        return true;
                    }
                    else
                        return false;
                }
                catch
                {
                    return false;
                }
            });
            return driver.FindElement(By.PartialLinkText(linkText));
        }
    }
}
