namespace EasyPayLibrary
{
    public class GmailPasswordPage : BasePageObject
    {
        #region Elements
        private WebElement txtPassword;
        private WebElement btnNext;

        public override void Init(WebDriver driver)
        {
            txtPassword = driver.GetByXpath("//input[@name='password']");
            btnNext = driver.GetByXpath("//div[@id='passwordNext']");
            base.Init(driver);
        }
        #endregion

        #region Helper Methods
        private void SetPassword(string password)
            => txtPassword.SendText(password);

        private void ClickNextButton()
            => btnNext.Click();
        #endregion

        #region Methods
        public GmailPage EnterPassword(string password)
        {
            SetPassword(password);
            ClickNextButton();
            driver.GetByXpath("//a[@aria-label='Приложения Google']");
            driver.GoToURL("https://mail.google.com/mail/u/0/h/1pq68r75kzvdr/?v%3Dlui");
            return GetPOM<GmailPage>(driver);
        }
        #endregion
    }
}