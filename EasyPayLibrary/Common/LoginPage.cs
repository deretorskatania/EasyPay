using System;

namespace EasyPayLibrary
{
    public class LoginPage : BasePageObject
    {
        #region Elements
        public string fieldEmailText => fieldEmail.GetAttribute("placeholder");
        public string fieldPasswordText => fieldPassword.GetAttribute("placeholder");
        public string btnLoginText => btnLogin.GetAttribute("value");
        public string btnCreateAccountText => btnCreateAccount.GetByXpath("./span").GetText();
        public string NewToSiteText => driver.GetByXpath("//*[@data-locale-item='newToSite']").GetText();
        public string LostYourPassword => driver.GetByXpath("//*[@data-locale-item='lostYourPassword']").GetText();
        public string HeaderText => driver.GetByXpath("//*[@data-locale-item='login']/span").GetText();
        public string lblOr => driver.GetByXpath("//*[@data-locale-item='or']/span").GetText();
        public string FooterText => driver.GetByXpath("//*[@data-locale-item='copyright']/span").GetText();
        
        WebElement fieldEmail;
        WebElement fieldPassword;
        WebElement btnLogin;
        WebElement btnCreateAccount;
        WebElement errorAlert;

        public override void Init(WebDriver driver)
        {
            fieldEmail = driver.GetByXpath("//input[@id='email']");
            fieldPassword = driver.GetByXpath("//input[@id='password']");
            btnLogin = driver.GetByXpath("//input[@id='Login_button']");
            btnCreateAccount = driver.GetByXpath("//a[@data-locale-item='createAccount']");
            base.Init(driver);
        }
        #endregion

        #region Helper Methods
        private void SetEmail(string email)
            => fieldEmail.SendText(email);

        private void SetPassword(string password)
            => fieldPassword.SendText(password);

        private void ClickOnLoginButton()
            => btnLogin.Click();

        private void ClickOnCreateAccountButton()
            => btnCreateAccount.Click();

        private void EnterEmailAndPasswordAndClickLogin(string email, string password)
        {
            SetEmail(email);
            SetPassword(password);
            ClickOnLoginButton();
        }
        #endregion

        #region Methods
        public AdminHomePage LoginAsAdmin(string email, string password)
        {
            EnterEmailAndPasswordAndClickLogin(email, password);
            return GetPOM<AdminHomePage>(driver);
        }

        public ManagerHomePage LoginAsManager(string email, string password)
        {
            EnterEmailAndPasswordAndClickLogin(email, password);
            return GetPOM<ManagerHomePage>(driver);
        }

        public InspectorHomePage LoginAsInspector(string email, string password)
        {
            EnterEmailAndPasswordAndClickLogin(email, password);
            return GetPOM<InspectorHomePage>(driver);
        }

        public UserHomePage LoginAsUser(string email, string password)
        {
            EnterEmailAndPasswordAndClickLogin(email, password);
            return GetPOM<UserHomePage>(driver);
        }

        public LoginPage TryLoginWithInvalidData(string email, string password)
        {
            EnterEmailAndPasswordAndClickLogin(email, password);
            return GetPOM<LoginPage>(driver);
        }

        public RegisterPage NavigateToCreateAccountPage()
        {
            ClickOnCreateAccountButton();
            return GetPOM<RegisterPage>(driver);
        }

        public bool IsErrorPresent()
        {
            try
            {
                errorAlert = driver.GetByXpath("//*[@class='alert ui-pnotify-container alert-danger ui-pnotify-shadow']");
                return true;
            }
            catch (TimeoutException)
            {
                return false;
            }
        }
        #endregion
    }
}