namespace EasyPayLibrary
{
    internal class UserSidebarPage : BaseSidebar
    {
        #region Elements
        WebElement mnuAddresses;
        WebElement mnuConnectedUtilities;
        WebElement mnuPayments;
        WebElement mnuPaymentsHistory;
        WebElement mnuRateInspectors;

        public override void Init(WebDriver driver)
        {
            base.Init(driver);
            mnuAddresses = driver.GetByXpath("//a[@href='/user/addresses']");
            mnuConnectedUtilities = driver.GetByXpath("//a[@href='/user/connected-utilities/']");
            mnuPayments = driver.GetByXpath("//a[@href='/user/paymentsPage']");
            mnuPaymentsHistory = driver.GetByXpath("//a[@href='/user/paymentsHistoryPage']");
            mnuRateInspectors = driver.GetByXpath("//a[@href='/user/rate/']");
        }
        #endregion

        #region Methods
        public string GetAddressesText() 
            => mnuAddresses.GetText();

        public string GetConnectedUtilitiesText() 
            => mnuConnectedUtilities.GetText();

        public string GetPaymentsText() 
            => mnuPayments.GetText();

        public string GetPaymentsHistoryText() 
            => mnuPaymentsHistory.GetText();

        public string GetRateInspectorsText() 
            => mnuRateInspectors.GetText();

        public void ClickOnAddresses() 
            => mnuAddresses.Click();

        public void ClickOnConnectedUtilities() 
            => mnuConnectedUtilities.Click();

        public void ClickOnPayment() 
            => mnuPayments.Click();

        public void ClickOnPaymentHistory() 
            => mnuPaymentsHistory.Click();

        public void ClickOnRateInspectorsPage() 
            => mnuRateInspectors.Click();
        #endregion
    }
}