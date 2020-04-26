namespace EasyPayLibrary
{
    public class UtilityPricePage : BasePageObject
    {
        #region Elements
        WebElement btnSetNewPrice;
        WebElement btnSetFuturePrice;

        public override void Init(WebDriver driver)
        {
            base.Init(driver);
            btnSetNewPrice = driver.GetByXpath("//button[@id='price_form_btn']");
            btnSetFuturePrice = driver.GetByXpath("//button[@id='future_price_form_btn']");
        }
        #endregion

        #region Methods
        public SetNewPriceFormPage ClickSetNewPriceButton()
        {
            btnSetNewPrice.Click();
            return GetPOM<SetNewPriceFormPage>(driver);
        }

        public SetFuturePriceFormPage ClickSetFuturePriceButton()
        {
            btnSetFuturePrice.Click();
            return GetPOM<SetFuturePriceFormPage>(driver);
        }

        public string GetCurrentPrice()
        {
            driver.Refresh();
            var currentPrice = driver.GetByXpath("//p[@id='service_price']").GetText();
            return currentPrice;
        }

        public string GetFuturePrice()
        {
            driver.Refresh();
            var futurePrice = driver.GetByXpath("//p[@id='future_price']").GetText();
            return futurePrice;
        }

        public string GetActivationDate()
        {
            var activationDate = driver.GetByXpath("//p[@id='activation_date']").GetText();
            return activationDate;
        }
        #endregion
    }
}