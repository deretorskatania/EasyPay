namespace EasyPayLibrary
{
    public class PaymentsHistoryPage : UserHomePage
    {
        #region Elements
        private WebElement cboAddresses;
        private WebElement cboUtilities;

        public override void Init(WebDriver driver)
        {
            base.Init(driver);
            cboAddresses = driver.GetByXpath("//select[@id='select-address']");
            cboUtilities = driver.GetByXpath("//select[@id='select-utility']");
        }
        #endregion

        #region Methods
        public string SelectAddress(string address)
        {
            SelectOption listOfAddresses = cboAddresses.SelectElement();
            listOfAddresses.SelectByText(address);
            return listOfAddresses.GetSelectedOptionText();
        }

        public void SelectUtility(string utility)
        {
            SelectOption list = new SelectOption(cboUtilities);
            list.SelectByText(utility);
        }

        public PaymentHistoryTablePage ReturnPaymentHistoryTable()
        {
            return GetPOM<PaymentHistoryTablePage>(driver);
        }
        #endregion
    }
}