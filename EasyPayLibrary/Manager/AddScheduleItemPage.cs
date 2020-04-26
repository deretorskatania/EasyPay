using OpenQA.Selenium;

namespace EasyPayLibrary
{
    public class AddScheduleItemPage : BasePageObject
    {
        #region Elements
        WebElement txtChooseDateAndTime;
        WebElement txtChooseAddress;
        WebElement btnApply;

        public override void Init(WebDriver driver)
        {
            base.Init(driver);
            txtChooseDateAndTime = driver.GetByXpath("//input[@id='datetimepicker']");
            txtChooseAddress = driver.GetByXpath("//form[@id='add-schedule-item-form']//input[@placeholder='Select a Address']");
            btnApply = driver.GetByXpath("//button[@class='btn btn-primary js-add-apply']");
        }
        #endregion

        #region Helper Methods
        private void ChooseDateAndTime(string date)
        {
            txtChooseDateAndTime.Click();
            DatePicker.DatePickerFunc(txtChooseDateAndTime);
            txtChooseDateAndTime.SendText(date);
        }

        private void ChooseAddress(string address)
        {
            txtChooseAddress.SendText(address);
            txtChooseAddress.SendEnter();
        }

        private void ClickOnApplyButton()
            => btnApply.Click();
        #endregion

        #region Methods
        public SchedulePage ApplyToAdd(string date, string address)
        {
            ChooseDateAndTime(date);
            ChooseAddress(address);
            ClickOnApplyButton();
            return GetPOM<SchedulePage>(driver);
        }

        public bool IsAddressFromScheduleDisplayed()
        {
            try
            {
                var element = driver.GetByXpath("//div[@class='fc-content']");
                return element.IsDisplayed();
            }
            catch (WebDriverTimeoutException)
            {
                return false;
            }
        }
        #endregion
    }
}