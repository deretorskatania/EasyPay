namespace EasyPayLibrary
{
    public class AdminSidebarPage : BaseSidebar
    {
        #region Elements
        WebElement mnuUtilities;
        WebElement mnuUsers;
        WebElement mnuRegisterUser;

        public override void Init(WebDriver driver)
        {
            base.Init(driver);
            mnuUtilities = driver.GetByXpath("//a[@href='/admin/utilitiesPage']");
            mnuUsers = driver.GetByXpath("//a[@href='/admin/management-users']");
            mnuRegisterUser = driver.GetByXpath("//a[@href='/admin/register-user']");
        }
        #endregion

        #region Methods
        public void ClickUtilitiesTab() 
            => mnuUtilities.Click();

        public void ClickUsersTab() 
            => mnuUsers.Click();

        public void ClickRegisterUserTab() 
            => mnuRegisterUser.Click();
        #endregion
    }
}