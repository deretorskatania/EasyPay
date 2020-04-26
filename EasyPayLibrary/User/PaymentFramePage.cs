using System;

namespace EasyPayLibrary
{
    public class PaymentFramePage : BasePageObject
    {
        #region Elements
        private WebElement txtEmail;
        private WebElement txtCardNumber;
        private WebElement txtDateOfCard;
        private WebElement txtCvc;
        private WebElement txtZipCode;
        private WebElement btnSubmit;
        private string frameName = "stripe_checkout_app";

        public override void Init(WebDriver driver)
        {
            driver.ChangeFrame(frameName);
            txtEmail = driver.GetByXpath("//input[@placeholder='Email']");
            txtCardNumber = driver.GetByXpath("//input[@placeholder='Card number']");
            txtDateOfCard = driver.GetByXpath("//input[@placeholder='MM / YY']");
            txtCvc = driver.GetByXpath("//input[@placeholder='CVC']");
            btnSubmit = driver.GetByXpath("//button");
            base.Init(driver);
        }
        #endregion

        #region Helper Methods
        private void SetEmail(string email) 
            => this.txtEmail.SendText(email);

        private void SetZipCode(string zipCode)
        {
            this.txtZipCode = driver.GetByXpath("//input[@placeholder='ZIP Code']");
            this.txtZipCode.SendText(zipCode);
        }

        private void SetCardNumber(string cardNumber) 
            => this.txtCardNumber.SendText(cardNumber);

        private void SetDateOfCard(string dateOfCard) 
            => this.txtDateOfCard.SendText(dateOfCard);

        private void SetCVC(string cvc) 
            => this.txtCvc.SendText(cvc);

        private void ClickSubmitButton() 
            => btnSubmit.Click();
        #endregion

        #region Methods
        public Tuple<UserHomePage, string> Pay(string email, string cardNumber, string dateOfCard, string cvc, string zipCode)
        {
            SetEmail(email);
            SetCardNumber(cardNumber);
            SetDateOfCard(dateOfCard);
            SetCVC(cvc);
            SetZipCode(zipCode);
            ClickSubmitButton();
            var receiptUrl = driver.GetUrl();
            driver.GoToURL("http://localhost:8080/home");
            return new Tuple<UserHomePage, string>(GetPOM<UserHomePage>(driver), receiptUrl);
        }
        #endregion
    }
}