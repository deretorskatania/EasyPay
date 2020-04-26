using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyPayLibrary
{
    public class InspectorSchedulePage : BasePageObject
    {
        #region Elements
        public WebElement schedule;

        public override void Init(WebDriver driver)
        {
            schedule = driver.GetByXpath("//div[@class='fc-view-container']");
            base.Init(driver);
        }
        #endregion

        #region Methods
        public bool IsScheduleDisplayed()
            => schedule.IsDisplayed();

        public WebElement GetCallByAddress(string address)
        {
            try
            {
                return driver.GetByXpath($"//span[contains(text(),'{address}')]");
            }
            catch (WebDriverTimeoutException)
            {
                return null;
            }
        }
        #endregion
    }
}
