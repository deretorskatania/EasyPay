namespace EasyPayLibrary
{
    public class SetFuturePriceFormPage : BasePageObject
    {
        #region Elements
        WebElement btnApplyFuturePrice;
        WebElement inputFormForFuturePrice;
        WebElement inputFormForDate;

        public override void Init(WebDriver driver)
        {
            base.Init(driver);
            inputFormForFuturePrice = driver.GetByXpath("//input[@id='future_price_value']");
            inputFormForDate = driver.GetByXpath("//input[@id='future_price_date']");
            btnApplyFuturePrice = driver.GetByXpath("//*[@id='future_price_form']/button");
        }
        #endregion

        #region Helper Methods
        public void SetValueIntoFuturePriceForm(string value)
        {
            inputFormForFuturePrice.SendText(value);
        }

        public void SetDate(string date)
        {
            inputFormForDate.SendText(date);
        }

        public void ClickOnApplyFuturePriceButton()
        {
            btnApplyFuturePrice.Click();
        }
        #endregion

        #region Methods
        public void SetFuturePrice(string value, string date)
        {
            SetValueIntoFuturePriceForm(value);
            SetDate(date);
            ClickOnApplyFuturePriceButton();
        }
        #endregion
    }
}