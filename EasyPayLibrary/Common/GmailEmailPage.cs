namespace EasyPayLibrary
{
    public class GmailEmailPage : BasePageObject
    {
        #region Elements
        private WebElement txtEmail;
        private WebElement btnNext;

        public override void Init(WebDriver driver)
        {
            driver.GoToURL("https://accounts.google.com");
            txtEmail = driver.GetByXpath("//input[@id='identifierId']");
            btnNext = driver.GetByXpath("//div[@id='identifierNext']");
            base.Init(driver);
        }
        #endregion

        #region Helper Methods
        private void SetEmail(string email)
            => txtEmail.SendText(email);

        private void ClickNextButton()
            => btnNext.Click();
        #endregion

        #region Methods
        public GmailPasswordPage EnterEmail(string email)
        {
            SetEmail(email);
            ClickNextButton();
            return GetPOM<GmailPasswordPage>(driver);
        }
        #endregion
    }
}