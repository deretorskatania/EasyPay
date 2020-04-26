namespace EasyPayLibrary
{
    public class ProfilePage : GeneralPage
    {
        #region Elements
        private WebElement title;
        private WebElement nameInput;
        private WebElement surnameInput;
        private WebElement phoneNumberInput;
        private WebElement password;
        private WebElement newPassword;
        private WebElement confirmPassword;
        private WebElement btnUpdateProfile;

        public override void Init(WebDriver driver)
        {
            base.Init(driver);
            nameInput = driver.GetByXpath("//input[@id = 'name']");
            surnameInput = driver.GetByXpath("//input[@id = 'surname']");
            phoneNumberInput = driver.GetByXpath("//input[@id='phone-number']");
            password = driver.GetByXpath("//input[@id='password']");
            newPassword = driver.GetByXpath("//input[@id='new-password']");
            confirmPassword = driver.GetByXpath("//input[@id='password-repeat']");
            btnUpdateProfile = driver.GetByXpath("//button[@id='submit-button']");
            title = driver.GetByXpath("//div[@class='title_left']//span");
        }
        #endregion

        #region Helper Methods
        public bool NameIsVisible()
            => nameInput.IsDisplayed();

        public bool SurnameIsVisible()
            => surnameInput.IsDisplayed();

        public bool PhoneNumberIsVisible()
            => phoneNumberInput.IsDisplayed();

        public string GetName()
            => nameInput.GetAttribute("value");

        public string GetSurname()
            => surnameInput.GetAttribute("value");

        public string GetPhoneNumber()
            => phoneNumberInput.GetAttribute("value");

        public string GetTitle()
            => title.GetText();

        public void SetName(string firstName)
            => nameInput.SendText(firstName);

        public void SetSurname(string secondName)
            => surnameInput.SendText(secondName);

        public void SetPhoneNumber(string phone)
            => phoneNumberInput.SendText(phone);

        public void SetPassword(string pass)
            => password.SendText(pass);

        public void SetNewPassword(string newpass)
            => newPassword.SendText(newpass);

        public void SetConfirmPassword(string newpass)
            => confirmPassword.SendText(newpass);

        public void ClickOnUpdateProfile()
        {
            btnUpdateProfile.Click();
            btnUpdateProfile.Click();
        }
        #endregion

        #region Methods
        public string GetSuccessText()
            => driver.GetByXpath("//h4[@class='ui-pnotify-title']").GetText();

        public bool IsErrorAlertDisplayed()
            => driver.GetByXpath("//*[@class='alert ui-pnotify-container alert-danger ui-pnotify-shadow']").IsDisplayed();

        public bool IsSuccessAlertDisplayed()
            => driver.GetByXpath("//*[@class='alert ui-pnotify-container alert-success ui-pnotify-shadow']").IsDisplayed();
        public void EditPassword(string pass, string newpass)
        {
            SetPassword(pass);
            SetNewPassword(newpass);
            SetConfirmPassword(newpass);
            ClickOnUpdateProfile();
        }

        public void EditData(string firstName, string secondName, string phone, string pass, string newpass)
        {
            SetName(firstName);
            SetSurname(secondName);
            SetPhoneNumber(phone);
            EditPassword(pass, newpass);
            ClickOnUpdateProfile();
        }

        public ProfilePage UpdateProfile()
        {
            ClickOnUpdateProfile();
            return GetPOM<ProfilePage>(driver);
        }

        public ProfilePage ChangeToUKR()
        {
            header.ChangeToUa();
            return GetPOM<ProfilePage>(driver);
        }
    }
    #endregion
}