namespace EasyPayLibrary
{
    public class ChangeRolePage : BasePageObject
    {
        #region Elements
        WebElement role;
        WebElement btnClose;
        WebElement btnSave;

        public override void Init(WebDriver driver)
        {
            base.Init(driver);
            role = driver.GetByXpath("//select[@id='role']");
            btnClose = driver.GetByXpath("//button[@id='closeChangeRole']");
            btnSave = driver.GetByXpath("//button[@id='updateRole']");
        }
        #endregion

        #region Methods
        public UsersPage ClickOnClose()
        {
            btnClose.Click();
            return GetPOM<UsersPage>(driver);
        }

        public UsersPage ClickOnSave()
        {
            btnSave.Click();
            return GetPOM<UsersPage>(driver);
        }

        public UsersPage SelectRole(string myRole)
        {
            myRole = myRole.ToUpper();
            var role = driver.GetByXpath("//select[@id='role']").SelectElement();
            role.SelectByText(myRole);
            return ClickOnSave();
        }
        #endregion
    }
}