using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyPayLibrary
{
    public class WelcomePage : BasePageObject
    {
        #region Elements
        public string btnSignInText => btnSignIn.GetByXpath("./span").GetText();
        public string btnSignUpText => btnSignUp.GetByXpath("./span").GetText();
        public string lblLeadText => lblLead.GetText();
        public string FooterText => driver.GetByXpath("//*[@class='mastfoot']/div[@class='inner']//p[2]").GetText();

        private WebElement btnSignIn;
        private WebElement btnSignUp;
        private WebElement lblLead;

        public override void Init(WebDriver driver)
        {
            lblLead = driver.GetByXpath("//p[@class='lead']");
            btnSignIn = driver.GetByXpath("//a[@id='Sign_in']");
            btnSignUp = driver.GetByXpath("//a[@id='Sign_up']");

            base.Init(driver);
        }
        #endregion

        #region Helper Methods
        private void ClickOnSignInButton()
            => btnSignIn.Click();

        private void ClickOnSignUpButton()
            => btnSignUp.Click();
        #endregion

        #region Methods
        public LoginPage SignIn()
        {
            ClickOnSignInButton();
            return GetPOM<LoginPage>(driver);
        }

        public RegisterPage SignUp()
        {
            ClickOnSignUpButton();
            return GetPOM<RegisterPage>(driver);
        }

        public WelcomePage TranslatePageToUA()
            => TranslatePageToUA<WelcomePage>(driver);

        public WelcomePage TranslatePageToEN()
            => TranslatePageToEN<WelcomePage>(driver);
        #endregion
    }
}
