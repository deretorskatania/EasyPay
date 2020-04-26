namespace EasyPayLibrary
{
    public class GmailPage : BasePageObject
    {
        #region Elements
        private WebElement emailFromEasyPay;

        public override void Init(WebDriver driver)
        {
            var ListOfEmails = driver.GetElementsByXpath("//*[contains(text(),'EASY PAY - Confirm Registration')]/../..");
            emailFromEasyPay = ListOfEmails[0];
            base.Init(driver);
        }
        #endregion

        #region Helper Methods
        private void ClickOnFirstMail()
            => emailFromEasyPay.Click();
        #endregion

        #region Methods
        public MailPage OpenMail()
        {
            ClickOnFirstMail();
            return GetPOM<MailPage>(driver);
        }
        #endregion
    }
}