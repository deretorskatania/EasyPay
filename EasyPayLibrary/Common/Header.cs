namespace EasyPayLibrary
{
    public class Header : BasePageObject
    {
        #region Elements
        private WebElement btnProfile;
        private WebElement btnLogOut;
        private WebElement cboProfile;
        private WebElement cboLanguage;

        public override void Init(WebDriver driver)
        {
            cboProfile = driver.GetByXpath("//li[@id='user-menu-header']/a");
            cboLanguage = driver.GetByXpath("//a[@class='dropdown-toggle user-profile']");
            base.Init(driver);
        }
        #endregion

        #region Helper Methods
        private void ClickOnProfileDropdown()
            => cboProfile.Click();

        private void ClickOnLanguageDropdown()
            => cboLanguage.Click();
        #endregion

        #region Methods
        public void GoToProfile()
        {
            ClickOnProfileDropdown();
            btnProfile = driver.GetByXpath("//a[@href='/profile']");
            btnProfile.Click();
        }

        public void LogOut()
        {
            ClickOnProfileDropdown();
            btnLogOut = driver.GetByXpath("//a[@href='/logout']");
            btnLogOut.Click();
        }

        public void ChangeToUa()
            => ClickOnLanguageDropdown();
        #endregion
    }
}