namespace EasyPayLibrary
{
    public class UtilityDetailsPage : BasePageObject
    {
        #region Elements
        private WebElement btnSetNewValue;
        private WebElement btnClose;
        private WebElement btnPay;

        public override void Init(WebDriver driver)
        {
            base.Init(driver);
            btnSetNewValue = driver.GetByXpath("//button[@class='btn btn-primary change-value']");
            btnClose = driver.GetByXpath("//div[@class='modal-dialog modal-lg']//button[@class='btn btn-default']");
            btnPay = driver.GetByXpath("//button[@id='pay']");
        }
        #endregion

        #region Helper Methods
        private void ClickCloseButton()
            => btnClose.Click();

        private void ClickPayButton()
            => btnPay.Click();

        private SetValuePage ClickSetNewValueButton()
        {
            btnSetNewValue.Click();
            return GetPOM<SetValuePage>(driver);
        }

        private UtilityDetailsPage SetNewValue(float Value)
        {
            var SetValuePage = ClickSetNewValueButton();
            SetValuePage.SetValue(Value);
            return GetPOM<UtilityDetailsPage>(driver);
        }

        private PaymentPage CloseUtilityDetailsPage()
        {
            ClickCloseButton();
            return GetPOM<PaymentPage>(driver);
        }
        #endregion

        #region Methods
        public SelectPaymentSumPage NavigateToSelectPaymentSumPage()
        {
            ClickPayButton();
            return GetPOM<SelectPaymentSumPage>(driver);
        }
        #endregion
    }
}