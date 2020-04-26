using OpenQA.Selenium;
using System.Collections.Generic;

namespace EasyPayLibrary
{
    public class UsersTable : BasePageObject
    {
        #region Elements
        List<RowUsersTable> table;

        public override void Init(WebDriver driver)
        {
            List<WebElement> tableOnPage;
            table = new List<RowUsersTable>();
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
                table.Add(new RowUsersTable(element, driver));
            }
        }
        #endregion

        #region Methods
        public RowUsersTable GetRowByEmail(string myEmail)
        {
            foreach (var element in table)
            {
                if (element.GetEmail() == myEmail)
                {
                    return element;
                }
            }
            return null;
        }

        public RowUsersTable GetSpecialRow()
            => GetPOM<RowUsersTable>(driver);

        public List<RowUsersTable> GetAllRows()
            => table;
        #endregion
    }

    public class RowUsersTable : BasePageObject
    {
        #region Elements
        WebElement surname;
        WebElement name;
        WebElement role;
        WebElement email;
        WebElement phoneNumber;
        WebElement btnChangeRole;
        WebElement btnSaveChange;
        WebElement btnBan;

        public RowUsersTable(WebElement element, WebDriver driver)
        {
            base.Init(driver);
            surname = element.GetByXpath(".//td[1]");
            name = element.GetByXpath(".//td[2]");
            role = element.GetByXpath(".//td[3]");
            email = element.GetByXpath(".//td[4]");
            phoneNumber = element.GetByXpath(".//td[5]");
            btnChangeRole = element.GetByXpath(".//td[6]//button");
            btnSaveChange = element.GetByXpath(".//td[7]//a");
            btnBan = element.GetByXpath(".//td[7]//a");
        }
        #endregion

        #region Methods
        public RowUsersTable() { }

        public string GetRole() 
            => role.GetText();

        public string GetSurname() 
            => surname.GetText();

        public string GetName() 
            => name.GetText();

        public string GetEmail() 
            => email.GetText();

        public string GetPhoneNumber() 
            => phoneNumber.GetText();

        public ChangeRolePage GetChangeRolePopUp()
        {
            btnChangeRole.Click();
            return GetPOM<ChangeRolePage>(driver);
        }
        public BanUserPage ClickBan()
        {
            btnBan.Click();
            return GetPOM<BanUserPage>(driver);
        }
        #endregion
    }
}