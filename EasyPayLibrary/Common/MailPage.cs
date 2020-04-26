namespace EasyPayLibrary
{
    public class MailPage : BasePageObject
    {
        #region Elements
        private WebElement lnkConfirmation;

        public override void Init(WebDriver driver)
        {
            var listOfLinks = driver.GetElementsByXpath("//div[contains(text(),'To confirm your account registration, click on the link:')]//a");
            lnkConfirmation = listOfLinks[0];
            base.Init(driver);
        }
        #endregion

        #region Helper Methods
        private void ClickLastLink()
            => lnkConfirmation.Click();

        private void DeleteAllMails() 
            => driver.GetByXpath("//table//table//table[1]//tbody[1]//tr[1]//td[1]//input[6]").Click();
        #endregion

        #region Methods
        public LoginPage ConfirmEmail()
        {
            ClickLastLink();
            DeleteAllMails();
            driver.SwitchToWindow();
            return GetPOM<LoginPage>(driver);
        }
        #endregion
    }
}