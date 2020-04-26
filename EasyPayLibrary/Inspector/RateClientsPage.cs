namespace EasyPayLibrary
{
    public class RateClientsPage : BasePageObject
    {
        #region Elements
        private WebElement tblRateClients;

        public override void Init(WebDriver driver)
        {
            tblRateClients = driver.GetByXpath("//table[@id='user-list-rating']//tbody");
            base.Init(driver);
        }
        #endregion

        #region Methods
        public bool IsRateClientsTableDisplayed()
            => tblRateClients.IsDisplayed();

        public RateClientsTablePage ReturnRateClientsTable()
            => GetPOM<RateClientsTablePage>(driver);
        #endregion
    }
}