namespace EasyPayLibrary
{
    public class ManagerHomePage : GeneralPage
    {
        #region Elements
        private ManagerSidebarPage sidebar;

        public override void Init(WebDriver driver)
        {
            sidebar = GetPOM<ManagerSidebarPage>(driver);
            base.Init(driver);
        }
        #endregion

        #region Methods
        public InspectorsListPage NavigateToInspectorsList()
        {
            sidebar.ClickInspectorsTab();
            return GetPOM<InspectorsListPage>(driver);
        }

        public UtilityPricePage NavigateToUtilityPrice()
        {
            sidebar.ClickUtilityPriceTab();
            return GetPOM<UtilityPricePage>(driver);
        }
        #endregion
    }
}