namespace EasyPayLibrary
{
    public class UtilityRowsPage : BasePageObject
    {
        #region Elements
        private WebElement btnActivate;
        private WebElement btnDeactivate;
        private WebElement btnFixed;
        private WebElement btnUnfixed;
        private WebElement btnSetNewValue;
        private WebElement columnActivate;
        private WebElement columnFixed;

        public UtilityRowsPage(WebElement element, WebDriver driver)
        {
            btnActivate = element.GetByXpath("./td/button[1]");
            btnDeactivate = element.GetByXpath("./td/button[1]");
            btnFixed = element.GetByXpath("./td/button[2]");
            btnUnfixed = element.GetByXpath("./td/button[2]");
            btnSetNewValue = element.GetByXpath("./td/button[4]");
            columnActivate = element.GetByXpath("./td[@class ='is-active'][@data-value]");
            columnFixed = element.GetByXpath("./td[@class ='is-fixed'][@data-value]");
            base.Init(driver);
        }
        #endregion

        #region Helper Methods
        private bool IsSuccsess()
        {
            var messageBox = driver.GetByXpath("//h4[@class='ui-pnotify-title']");
            var textOfMessageBox = messageBox.GetText();
            if (textOfMessageBox == "Success")
                return true;
            else
                return false;
        }

        private void ActivateUtility()
            => btnActivate.Click();

        private void DeactivateUtility()
            => btnDeactivate.Click();

        private void FixedUtility()
            => btnFixed.Click();

        private void UnfixedUtility()
            => btnUnfixed.Click();

        private void SetNewValueUtility()
            => btnSetNewValue.Click();
        #endregion

        #region Methods
        public bool IsActivate()
        {
            ActivateUtility();
            var success = IsSuccsess();
            return success;
        }

        public bool IsDeactivate()
        {
            DeactivateUtility();
            var success = IsSuccsess();
            return success;
        }

        public bool IsFixed()
        {
            FixedUtility();
            var success = IsSuccsess();
            return success;
        }

        public bool IsUnfixed()
        {
            UnfixedUtility();
            var success = IsSuccsess();
            return success;
        }

        public SetCurrentValuePage SetNewValueUtility(string address)
        {
            btnSetNewValue.Click();
            return GetPOM<SetCurrentValuePage>(driver);
        }

        public void SelectNewAddress(string text)
        {
            var checkCounters = driver.GetByXpath("//span[@class='input-group-addon dropdown-toggle']");
            checkCounters.Click();
            var addresses = driver.GetElementsByXpath("//li[@data-value]");
            foreach (var element in addresses)
            {
                if (element.GetText() == text)
                {
                    element.Click();
                }
            }
        }
        #endregion
    }
}