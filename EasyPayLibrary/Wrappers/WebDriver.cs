using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using System.Reflection;
using System.IO;

namespace EasyPayLibrary
{
    public class WebDriver
    {
        private IWebDriver driver { get; set; }

        public WebDriver(IWebDriver Driver) => driver = Driver;

        public IWebDriver GetDriver => driver;
        public string GetUrl() => driver.Url;
        public void GoToURL(string url) => driver.Navigate().GoToUrl(url);
        public void SwitchToWindow() => driver.SwitchTo().Window(driver.WindowHandles.Last());
        public void Refresh() => driver.Navigate().Refresh();
        public void Maximaze() => driver.Manage().Window.Maximize();
        public void ChangeFrame(string name) => driver.SwitchTo().Frame(name);
        public Actions MoveToElement() => new Actions(driver);
        public List<WebElement> GetElementsByXpath(string xpath, int timeoutInSeconds = 5)
        {
            GetByXpath(xpath);
            var elements = driver.FindElements(By.XPath(xpath));
            var result = elements.Select(x => new WebElement(x));
            return result.ToList();
        }
        public WebElement GetByXpath(string xpath, int timeoutInSeconds = 5)
        {
            if (timeoutInSeconds > 0)
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
                var result = new WebElement(wait.Until(condition: ExpectedConditions.ElementIsVisible(By.XPath(xpath))));
                return result;
            }
            else
            {
                var result = new WebElement(driver.FindElement(By.XPath(xpath)));
                return result;
            }
        }
        public void GoToURL()
        {
            string url = ConfigurationManager.AppSettings["URL"];
            driver.Url = url;
        }

        public string GetScreenshot(string pathToSaveIn)
        {
            Screenshot ss = ((ITakesScreenshot)driver).GetScreenshot();
            string nameTest = TestContext.CurrentContext.Test.MethodName;
            string title = nameTest + DateTime.Now.ToString(" dd-MM-yyyy_(HH_mm_ss)");
            var x = Assembly.GetExecutingAssembly().Location;
            var info = new FileInfo(x);
            var path = pathToSaveIn;
            var adress = new FileInfo($"{path}\\");
            string screenshotFileName = adress + title + ".png";
            ss.SaveAsFile(screenshotFileName);
            return screenshotFileName;
        }
        public void Quit()
        {
            if (driver == null) return;
            driver.Quit();
            driver = null;
        }
        public void WaitUntillUrlContainString(string str, int timeInSec = 20)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeInSec));
            wait.Until(condition: ExpectedConditions.UrlContains(str));
        }       
    }

    public class Action
    {
        public Actions action;

        public Action(WebDriver driver, WebElement element, int x, int y)
        {
            action = driver.MoveToElement();
            element.MoveToElement(action, x, y).Build().Perform();
        }
    }

    public class DriverFactory
    {
        public WebDriver GetDriver(string browser)
        {
            return (browser == null) ? ChooseDriver(ConfigurationManager.AppSettings["browser"]) : ChooseDriver(browser);
        }

        private WebDriver ChooseDriver(string browser)
        {
            IWebDriver driver = null;
            switch (browser)
            {
                case "Chrome":
                    driver = new ChromeDriver();
                    break;
                case "Firefox":
                    driver = new FirefoxDriver();
                    break;
                case "Edge":
                    driver = new EdgeDriver();
                    break;

            }
            return new WebDriver(driver);
        }
    }
}
