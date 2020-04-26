using System.Collections.Generic;

namespace EasyPayLibrary
{
    public class UserHomePage : GeneralPage
    {
        #region Elements
        private WebElement mainPageTitle;
        private WebElement xTitle;
        private UserSidebarPage sidebar;

        public override void Init(WebDriver driver)
        {
            sidebar = GetPOM<UserSidebarPage>(driver);
            base.Init(driver);
        }
        #endregion

        #region Methods
        public string GetAddressesText()
            => sidebar.GetAddressesText();

        public string GetConnectedUtilitiesText()
            => sidebar.GetConnectedUtilitiesText();

        public string GetPaymentsText()
            => sidebar.GetPaymentsText();

        public string GetPaymentsHistoryText()
            => sidebar.GetPaymentsHistoryText();

        public string GetRateInspectorsText()
            => sidebar.GetRateInspectorsText();

        public UserHomePage ChangeToUA()
        {
            header.ChangeToUa();
            return TranslatePageToUA<UserHomePage>(driver);
        }

        public string GetMainPageTitleText()
        {
            mainPageTitle = driver.GetByXpath("//*[@data-locale-item='mainPage']/span");
            return mainPageTitle.GetText();
        }

        public string GetXTitleText()
        {
            xTitle = driver.GetByXpath("//*[@class='x_title']/h2");
            return xTitle.GetText();
        }

        public PaymentPage NavigateToPaymentPage()
        {
            sidebar.ClickOnPayment();
            return GetPOM<PaymentPage>(driver);
        }

        public PaymentsHistoryPage NavigateToPaymentHistoryPage()
        {
            sidebar.ClickOnPaymentHistory();
            return GetPOM<PaymentsHistoryPage>(driver);
        }

        public IEnumerable<WebElement> GetListOfSidebarMenus()
            => sidebar.ListOfSideBarComponents;

        public AddAddressFormPage NavigateToAddressesPage()
        {
            sidebar.ClickOnAddresses();
            return GetPOM<AddAddressFormPage>(driver);
        }

        public ConnectedUtilitiesPage NavigateToConnectedUtilitiesPage()
        {
            sidebar.ClickOnConnectedUtilities();
            return GetPOM<ConnectedUtilitiesPage>(driver);
        }

        public RateInspectorsPage NavigateToRateInspectorsPage()
        {
            sidebar.ClickOnRateInspectorsPage();
            return GetPOM<RateInspectorsPage>(driver);
        }
        #endregion
    }
}