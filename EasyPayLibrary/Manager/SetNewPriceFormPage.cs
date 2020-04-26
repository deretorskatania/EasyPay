namespace EasyPayLibrary
{
    public class SetNewPriceFormPage : BasePageObject
    {
        #region Elements
        WebElement btnApplyNewPrice;
        WebElement txtFormForNewPrice;

        public override void Init(WebDriver driver)
        {
            base.Init(driver);
            txtFormForNewPrice = driver.GetByXpath("//input[@id='new_price_value']");
            btnApplyNewPrice = driver.GetByXpath("//*[@id='price_form']/button");
        }
        #endregion

        #region Helper Methods
        public void SetValueIntoNewPriceForm(string value)
        {
            txtFormForNewPrice.SendText(value);
        }

        public void ClickOnApplyNewPriceButton()
        {
            btnApplyNewPrice.Click();
        }
        #endregion

        #region Methods
        public void SetNewPrice(string value)
        {
            SetValueIntoNewPriceForm(value);
            ClickOnApplyNewPriceButton();
            driver.Refresh();
        }
        #endregion
    }
}