namespace EasyPayLibrary
{
    public class SetValuePage : BasePageObject
    {
        #region Elements
        private WebElement txtNewCurrentValue;
        private WebElement btnApply;

        public override void Init(WebDriver driver)
        {
            txtNewCurrentValue = driver.GetByXpath("//input[@id='newCurrentValue']");
            btnApply = driver.GetByXpath("//button[@class='btn btn-primary js-apply']");
            base.Init(driver);
        }
        #endregion

        #region Helper Methods
        public void SetFieldNewCurrentValue(float Value) 
            => txtNewCurrentValue.SendText(Value.ToString());

        public void ClickApplyButton() => btnApply.Click();
        #endregion

        #region Methods
        public UtilityDetailsPage SetValue(float value)
        {
            SetFieldNewCurrentValue(value);
            ClickApplyButton();
            return GetPOM<UtilityDetailsPage>(driver);
        }
        #endregion
    }
}