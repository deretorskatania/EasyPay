using System.Collections.Generic;

namespace EasyPayLibrary
{
    public class CheckCountersPage : BasePageObject
    {
        #region Elements
        public WebElement dropdown;
        public UtilityRowsPage utility;

        public override void Init(WebDriver driver)
        {
            dropdown = driver.GetByXpath("//span[@class='input-group-addon dropdown-toggle']");
            base.Init(driver);
        }
        #endregion

        #region Helper Methods
        private void SelectFromDropDown(IEnumerable<WebElement> addresses, string text)
        {
            foreach (var element in addresses)
            {
                if (element.GetText() == text)
                {
                    element.Click();
                }
            }
        }
        #endregion

        #region Methods
        public void ClickOnDropDown() 
            => dropdown.Click();

        public IEnumerable<WebElement> ReturnListOfDropDown() 
            => driver.GetElementsByXpath("//li[@data-value]");

        public UtilityTablePage SelectAddress(string text)
        {
            ClickOnDropDown();
            var addresses = ReturnListOfDropDown();
            SelectFromDropDown(addresses, text);
            return GetPOM<UtilityTablePage>(driver);
        }
        #endregion
    }
}