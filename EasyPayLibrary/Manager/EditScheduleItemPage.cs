namespace EasyPayLibrary
{
    public class EditScheduleItemPage : BasePageObject
    {
        #region Elements
        WebElement fieldChooseDateAndTime;
        WebElement fieldDeleteAddress;
        WebElement fieldChooseAddress;
        WebElement btnApply;

        public override void Init(WebDriver driver)
        {
            fieldChooseDateAndTime = driver.GetByXpath("//input[@id='datetimepicker-edit']");
            fieldDeleteAddress = driver.GetByXpath("//*[@id='edit-schedule-item-form']/div/div/span");
            fieldChooseAddress = driver.GetByXpath("//form[@id='edit-schedule-item-form']//input[@placeholder='Select a Address']");
            btnApply = driver.GetByXpath("//button[@class='btn btn-primary js-edit-apply']");
            base.Init(driver);
        }
        #endregion

        #region Helper Methods
        private void ChooseDateAndTime(string date)
        {
            fieldChooseDateAndTime.Click();
            DatePicker.DatePickerFunc(fieldChooseDateAndTime);
            fieldChooseDateAndTime.SendText(date);
        }

        private void ChooseAddressToEdit(string address)
        {
            fieldDeleteAddress.Click();
            fieldChooseAddress.Click();
            fieldChooseAddress.SendText(address);
            fieldChooseAddress.SendEnter();
        }

        private void ClickApplyButton()
            => btnApply.Click();
        #endregion

        #region Helper Methods
        public SchedulePage ApplyToEdit(string date, string address)
        {
            ChooseDateAndTime(date);
            ChooseAddressToEdit(address);
            ClickApplyButton();
            return GetPOM<SchedulePage>(driver);
        }
        #endregion
    }
}