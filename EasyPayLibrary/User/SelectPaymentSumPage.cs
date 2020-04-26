namespace EasyPayLibrary
{
    public class SelectPaymentSumPage : BasePageObject
    {
        #region Elements
        private WebElement txtSumToPay;
        private WebElement btnDownloadReceipt;
        private WebElement btnProcceed;

        public override void Init(WebDriver driver)
        {
            base.Init(driver);
            txtSumToPay = driver.GetByXpath("//input[@id='payment-sum-input']");
            btnDownloadReceipt = driver.GetByXpath("//span[@id='download-check-text']");
            btnProcceed = driver.GetByXpath("//button[@id='payment-proceed']");
        }
        #endregion

        #region Helper Methods
        private void SetSumToPay(float sum) 
            => txtSumToPay.SendText(sum.ToString());

        private void ClickOnPayButton() 
            => btnProcceed.Click();
        #endregion

        #region Methods
        public void ChooseDownloadCheck() 
            => btnDownloadReceipt.Click();

        public PaymentFramePage PayForSum(float sum)
        {
            SetSumToPay(sum);
            ClickOnPayButton();
            return GetPOM<PaymentFramePage>(driver);
        }
        #endregion
    }
}