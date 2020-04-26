using OpenQA.Selenium;
using System;

namespace EasyPayLibrary
{
    public class ConnectedUtilitiesFormPage : BasePageObject
    {
        #region Elements
        private WebElement btnDisconnect;
        private WebElement cboAddresses;
        private WebElement btnCallinspector;
        private WebElement txtDate;
        private WebElement btnCall;
        private WebElement text;

        public override void Init(WebDriver driver)
        {
            base.Init(driver);
            cboAddresses = driver.GetByXpath("//select[@id='selectAddress']");
        }
        #endregion

        #region Helper Methods
        private void ClickCallInspectorButton()
        {
            btnCallinspector = driver.GetByXpath("//button[@id='preCall']");
            btnCallinspector.Click();
        }

        private void SelectDate()
        {
            txtDate = driver.GetByXpath("//input[@id='picker']");
            txtDate.Click();
            DateTime currentDate = DateTime.Today.AddDays(1);
            string currentDateString = currentDate.ToString("yyyy-MM-dd");
            txtDate.SendText(currentDateString);
        }
        #endregion

        #region Methods
        public string SelectAddress(string address)
        {
            SelectOption list = cboAddresses.SelectElement();
            list.SelectByText(address);
            return list.GetSelectedOptionText();
        }

        public void CallInspector(string address)
        {
            SelectAddress(address);
            ClickCallInspectorButton();
            SelectDate();
        }

        public ConnectedUtilitiesFormPage Disconect()
        {
            btnDisconnect = driver.GetByXpath("//td[contains(text(),'ДнепрОблЭнерго')]/..//td[3]/a");
            btnDisconnect.Click();
            return GetPOM<ConnectedUtilitiesFormPage>(driver);
        }
                
        public UserHomePage SubmitCall()
        {
            btnCall = driver.GetByXpath("//button[@id='submit']");
            btnCall.Click();
            driver.Refresh();
            return GetPOM<UserHomePage>(driver);
        }

        public string VerifyThatUtilitiExist()
        {
            try
            {
                text = driver.GetByXpath("//td[contains(text(),'ДнепрОблЭнерго')]/..");
            }
            catch (WebDriverTimeoutException)
            {
                return null;
            }
            return text.GetText();
        }
        #endregion
    }
}