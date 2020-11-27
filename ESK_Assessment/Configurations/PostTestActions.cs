using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESK_Assessment.Configurations
{
    public class PostTestActions
    {
        public void TakeAction(TestStatus testResult, IWebDriver driver)
        {
            if (testResult == TestStatus.Failed)
            {
                TakeScreenshot(driver);
            }
            driver.Quit();
        }
        public void TakeScreenshot(IWebDriver driver)
        {
            Screenshot screenshot = ((ITakesScreenshot)driver).GetScreenshot();

            string shot = screenshot.AsBase64EncodedString;
            byte[] shotAsByteArray = screenshot.AsByteArray;

            string portalName = driver.Url;
            string folderPath = ConfigurationManager.AppSettings["SSPath"];

            bool exists = Directory.Exists(folderPath);

            if (!exists)
                Directory.CreateDirectory(folderPath);
            string dir = System.IO.Path.GetDirectoryName(folderPath);
            string fileName = TestContext.CurrentContext.Test.FullName + DateTime.Now.ToString("ddd d MMM  hh-mm-ss") + ".png";
            screenshot.SaveAsFile(@"..\..\TestFailures\" + fileName, ScreenshotImageFormat.Png);
            screenshot.ToString();
        }
    }
}
