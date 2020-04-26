namespace EasyPayLibrary
{
    public class AdminHomePage : GeneralPage
    {
        #region Elements
        private AdminSidebarPage sidebar;

        public override void Init(WebDriver driver)
        {
            base.Init(driver);
            sidebar = GetPOM<AdminSidebarPage>(driver);
        }
        #endregion

        #region Methods
        public UtilitiesPage NavigateToUtilities()
        {
            sidebar.ClickUtilitiesTab();
            return GetPOM<UtilitiesPage>(driver);
        }

        public UsersPage NavigateToUsers()
        {
            sidebar.ClickUsersTab();
            return GetPOM<UsersPage>(driver);
        }
        #endregion
    }
}