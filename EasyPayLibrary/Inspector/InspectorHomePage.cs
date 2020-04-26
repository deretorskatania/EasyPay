namespace EasyPayLibrary
{
    public class InspectorHomePage : GeneralPage
    {
        #region Elements
        private InspectorSidebarPage sidebar;

        public override void Init(WebDriver driver)
        {
            sidebar = GetPOM<InspectorSidebarPage>(driver);
            base.Init(driver);
        }
        #endregion

        #region Methods
        public CheckCountersPage NavigateToCheckCounters()
        {
            sidebar.ClickCheckCounters();
            return GetPOM<CheckCountersPage>(driver);
        }

        public RateClientsPage NavigateToRateClients()
        {
            sidebar.ClickRateClient();
            return GetPOM<RateClientsPage>(driver);
        }

        public InspectorSchedulePage NavigateToSchedule()
        {
            sidebar.ClickSchedule();
            return GetPOM<InspectorSchedulePage>(driver);
        }
        #endregion
    }
}