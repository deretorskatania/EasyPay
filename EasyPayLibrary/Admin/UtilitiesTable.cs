using OpenQA.Selenium;
using System.Collections.Generic;

namespace EasyPayLibrary
{
    public class UtilitiesTable : BasePageObject
    {
        #region Elements
        List<RowUtilitiesTable> table;

        public override void Init(WebDriver driver)
        {
            List<WebElement> tableOnPage;
            table = new List<RowUtilitiesTable>();
            try
            {
                tableOnPage = driver.GetElementsByXpath("//tbody[@id='users-table']//tr");
            }
            catch (WebDriverTimeoutException)
            {
                return;
            }

            foreach (var element in tableOnPage)
            {
                table.Add(new RowUtilitiesTable(element, driver));
            }
        }
        #endregion

        #region Methods
        public RowUtilitiesTable GetRowByUtilities(string myUtilities)
        {
            foreach (var element in table)
            {
                if (element.GetCompanyName() == myUtilities)
                {
                    return element;
                }
            }
            return null;
        }

        public List<RowUtilitiesTable> GetAllRows() 
            => table;
        #endregion
    }

    public class RowUtilitiesTable : BasePageObject
    {
        #region Elements
        WebElement companyName;
        WebElement address;
        WebElement idefCode;
        WebElement manager;
        WebElement btnChangeManager;

        public RowUtilitiesTable(WebElement element, WebDriver driver)
        {
            base.Init(driver);
            companyName = element.GetByXpath(".//td[2]");
            address = element.GetByXpath(".//td[3]");
            idefCode = element.GetByXpath(".//td[4]");
            manager = element.GetByXpath(".//td[5]");
            btnChangeManager = element.GetByXpath(".//td[7]//button[2]");
        }
        #endregion

        #region Methods
        public RowUtilitiesTable() { }

        public string GetCompanyName() 
            => companyName.GetText();

        public string GetAddress() 
            => address.GetText();

        public string GetIdefCode() 
            => idefCode.GetText();

        public string GetManagersName() 
            => manager.GetText();

        public ChangeManagerPage ChangeManager()
        {
            btnChangeManager.Click();
            return GetPOM<ChangeManagerPage>(driver);
        }
        #endregion
    }
}