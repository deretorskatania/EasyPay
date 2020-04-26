using OpenQA.Selenium;
using System.Collections.Generic;
using System.Linq;

namespace EasyPayLibrary
{
    public class UtilityTablePage : BasePageObject
    {
        #region Elements
        private List<UtilityRowsPage> table;

        public override void Init(WebDriver driver)
        {
            List<WebElement> tableOnPage;
            base.Init(driver);

            try
            {
                tableOnPage = driver.GetElementsByXpath("//table[@class='table table-hover schedule text-center']//tbody//tr");
            }
            catch (WebDriverTimeoutException)
            {
                return;
            }
            table = new List<UtilityRowsPage>();

            foreach (var element in tableOnPage)
            {
                table.Add(new UtilityRowsPage(element, driver));
            }
        }
        #endregion

        #region Methods
        public UtilityRowsPage GetFirstRow()
            => table.First();

        public UtilityRowsPage GetLastRow()
            => table.Last();

        public List<UtilityRowsPage> GetAllRows()
            => table;
        #endregion
    }
}