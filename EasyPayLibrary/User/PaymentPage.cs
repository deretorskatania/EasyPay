using System;

namespace EasyPayLibrary
{
    public class PaymentPage : BasePageObject
    {
        #region Elements
        private WebElement cboAddresses;
        private WebElement tblUtilities;
        private WebElement btnDetails;
        private WebElement btnSetNewValue;
        private WebElement txtNewValue;
        private WebElement btnApply;
        private WebElement tblCellBalance;

        public override void Init(WebDriver driver)
        {
            base.Init(driver);
            cboAddresses = driver.GetByXpath("//select[@id='selectAddress']");
            tblUtilities = driver.GetByXpath("//table[@id='historyTable']");
        }
        #endregion

        #region Methods
        public void SelectAddress(string address)
        {
            SelectOption list = new SelectOption(cboAddresses);
            list.SelectByText(address);
        }

        public UtilityDetailsPage NavigateToUtilityDetails(string utility)
        {
            WebElement btnDetails = driver.GetByXpath($"//tbody/tr/td[contains(text(),'{utility}')]/../td[3]/button");
            btnDetails.Click();
            return GetPOM<UtilityDetailsPage>(driver);
        }

        public double GetBalance()
        {
            tblCellBalance = driver.GetByXpath("//tbody/tr[1]/td[2]");
            return Convert.ToDouble(tblCellBalance.GetText().Replace('.', ','));
        }

        public void ChangeMetrics(string address, string value)
        {
            SelectAddress(address);

            btnDetails = driver.GetByXpath("//tbody/tr[1]/td/button");
            btnDetails.Click();
            btnSetNewValue = driver.GetByXpath("//table[@id = 'modal-table']/tbody/tr/td/button");
            btnSetNewValue.Click();
            txtNewValue = driver.GetByXpath("//input[@id='newCurrentValue']");
            txtNewValue.SendText(value);
            btnApply = driver.GetByXpath("//button[@class='btn btn-primary js-apply']");
            btnApply.Click();
        }
        #endregion
    }
}