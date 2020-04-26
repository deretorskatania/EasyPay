using OpenQA.Selenium;
using System.Collections.Generic;
using System.Linq;

namespace EasyPayLibrary
{
    public class PaymentHistoryTablePage : BaseTable<PaymentHistoryTableRowPage>
    {
        public override void Init(WebDriver driver)
        {
            List<WebElement> tbPayments;
            base.Init(driver);
            try
            {
                tbPayments = driver.GetElementsByXpath("//table[@id='historyTable']//tbody/tr", 1);
            }
            catch (WebDriverTimeoutException)
            {
                Rows = new List<PaymentHistoryTableRowPage>();
                return;
            }

            Rows = tbPayments.Select(element => new PaymentHistoryTableRowPage(driver, element)).ToList();
        }
    }
}