namespace EasyPayLibrary
{
    public class BanUserPage : BasePageObject
    {
        #region Elements
        WebElement btnClose;
        WebElement btnSave;

        public override void Init(WebDriver driver)
        {
            base.Init(driver);
            btnClose = driver.GetByXpath("//button[@id='closeChangeStatus']");
            btnSave = driver.GetByXpath("//button[@id='updateUserStatus']");
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
        #endregion
    }
}