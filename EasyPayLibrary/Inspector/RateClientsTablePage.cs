using OpenQA.Selenium;
using System.Collections.Generic;
using System.Linq;

namespace EasyPayLibrary
{
    public class RateClientsTablePage : BasePageObject
    {
        #region Elements
        private List<RateClientsRowsPage> table;

        public override void Init(WebDriver driver)
        {
            List<WebElement> tableOnPage;
            base.Init(driver);

            try
            {
                tableOnPage = driver.GetElementsByXpath("//table[@class='table table-hover text-justify']//tbody//tr");
            }
            catch (WebDriverTimeoutException)
            {
                return;
            }
            table = new List<RateClientsRowsPage>();

            foreach (var element in tableOnPage)
            {
                table.Add(new RateClientsRowsPage(element, driver));
            }
            table = tableOnPage.Select(element => new RateClientsRowsPage(element, driver)).ToList();
        }
        #endregion

        #region Methods
        public RateClientsRowsPage GetFirstRow()
            => table.First();

        public RateClientsRowsPage GetLastRow()
            => table.Last();

        public List<RateClientsRowsPage> GetAllRows()
            => table;
        #endregion
    }
}