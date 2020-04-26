namespace EasyPayLibrary
{
    public class DeleteScheduleItemPage : BasePageObject
    {
        #region Elements
        WebElement btnApply;

        public override void Init(WebDriver driver)
        {
            base.Init(driver);
            btnApply = driver.GetByXpath("//button[@class='btn btn-primary js-remove-apply']");
        }
        #endregion

        #region Helper Methods
        private void ClickOnApplyButton()
            => btnApply.Click();
        #endregion

        #region Methods
        public SchedulePage ApplyToDelete()
        {
            ClickOnApplyButton();
            return GetPOM<SchedulePage>(driver);
        }
        #endregion
    }
}