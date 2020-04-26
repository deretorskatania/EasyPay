namespace EasyPayLibrary
{
    public class RegisterPage : BasePageObject
    {
        #region Elements
        public string lblHeaderText => lblHeader.GetText();
        public string lblFooterText => lblFooter.GetByXpath("./span").GetText();
        public string fieldNameText => fieldName.GetAttribute("placeholder");
        public string fieldSurnameText => fieldSurname.GetAttribute("placeholder");
        public string fieldEmailText => fieldEmail.GetAttribute("placeholder");
        public string fieldPasswordText => fieldPassword.GetAttribute("placeholder");
        public string fieldConfirmPasswordText => fieldConfirmPassword.GetAttribute("placeholder");
        public string btnSubmitText => btnSubmit.GetAttribute("value");
        public string btnSignInText => btnSignIn.GetByXpath("./span").GetText();

        private WebElement lblHeader;
        private WebElement lblFooter;
        private WebElement fieldName;
        private WebElement fieldSurname;
        private WebElement fieldPhoneNumber;
        private WebElement fieldEmail;
        private WebElement fieldPassword;
        private WebElement fieldConfirmPassword;
        private WebElement btnSubmit;
        private WebElement btnSignIn;

        public override void Init(WebDriver driver)
        {
            base.Init(driver);

            lblHeader = driver.GetByXpath("//h1[@id='registrationName']");
            lblFooter = driver.GetByXpath("//span[@data-locale-item='haveAnAccount']");
            fieldName = driver.GetByXpath("//input[@id='name']");
            fieldSurname = driver.GetByXpath("//input[@id='surname']");
            fieldPhoneNumber = driver.GetByXpath("//input[@id='phone']");
            fieldEmail = driver.GetByXpath("//input[@id='email']");
            fieldPassword = driver.GetByXpath("//input[@id='password']");
            fieldConfirmPassword = driver.GetByXpath("//input[@id='confirm']");
            btnSubmit = driver.GetByXpath("//input[@id='submit-btn']");
            btnSignIn = driver.GetByXpath("//a[@data-locale-item='signIn']");
        }
        #endregion

        #region Helper Methods
        private void SetName(string name)
            => fieldName.SendText(name);

        private void SetSurname(string surName)
            => fieldSurname.SendText(surName);

        private void SetPhoneNumber(string phoneNumber)
            => fieldPhoneNumber.SendText(phoneNumber);

        private void SetEmail(string email)
            => fieldEmail.SendText(email);

        private void SetPassword(string password)
            => fieldPassword.SendText(password);

        private void SetConfirmPassword(string password)
            => fieldConfirmPassword.SendText(password);

        private void ClickSubmitButton()
            => btnSubmit.Click();
        #endregion

        #region Methods
        public GmailEmailPage Register(string name, string surName, string phoneNumber, string email, string password)
        {
            SetName(name);
            SetSurname(surName);
            SetPhoneNumber(phoneNumber);
            SetEmail(email);
            SetPassword(password);
            SetConfirmPassword(password);
            ClickSubmitButton();
            RedirectModalWindow.ClickOnRedirectButton(driver, 30);
            return GetPOM<GmailEmailPage>(driver);
        }

        public RegisterPage TranslatePageToUA()
            => TranslatePageToUA<RegisterPage>(driver);

        public RegisterPage TranslatePageToEN()
            => TranslatePageToEN<RegisterPage>(driver);
        #endregion
    }

    public class RedirectModalWindow : BasePageObject
    {
        public static void ClickOnRedirectButton(WebDriver driver, int timeoutInSec)
        {
            WebElement btnRedirect = driver.GetByXpath("//a[@id='redirect-btn']", timeoutInSec);
            btnRedirect.Click();
        }
    }
}