namespace EasyPayLibrary
{
    public class UsersPage : AdminHomePage
    {
        #region Elements
        WebElement tblUsers;

        public override void Init(WebDriver driver)
        {
            base.Init(driver);
            tblUsers = driver.GetByXpath("//table[@id='user-list']//tbody");
        }
        #endregion

        #region Methods
        public bool UsersTableIsVisible() 
            => tblUsers.IsDisplayed();

        public UsersTable ReturnUsersTable()
        {
            return GetPOM<UsersTable>(driver);
        }
        #endregion
    }
}