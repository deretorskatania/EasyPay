using OpenQA.Selenium;

namespace EasyPayLibrary
{
    public class HistoryPage : BasePageObject
    {
        #region Elements
        WebElement btnCurrentMonth;
        WebElement btnPreviousMonth;

        public override void Init(WebDriver driver)
        {
            base.Init(driver);
            btnCurrentMonth = driver.GetByXpath("//*[@data-locale-item='currentMonth']");
            btnPreviousMonth = driver.GetByXpath("//*[@data-locale-item='previousMonth']");
        }
        #endregion

        #region Methods
        public HistoryPage ClickOnCurrentMonthButton()
        {
            btnCurrentMonth.Click();
            return GetPOM<HistoryPage>(driver);
        }

        public bool CurrentMonthContainsAddress(string address, string date)
        {
            WebElement element;
            try
            {
                element = driver.GetByXpath($"//table[@id='scheduleHistoryCurrent']//td[contains(text(),'{address}')]/following-sibling::td[contains(text(),'{date}')]");
                return true;
            }
            catch (WebDriverTimeoutException)
            {
                return false;
            }
        }

        public HistoryPage ClickOnPreviousMonthButton()
        {
            btnPreviousMonth.Click();
            return GetPOM<HistoryPage>(driver);
        }

        public bool PreviousMonthContainsAddress(string date)
        {
            try
            {
                var element = driver.GetByXpath($"//*[contains(text(),'{date}')]", 1);
                return true;
            }
            catch (WebDriverTimeoutException)
            {
                return false;
            }
        }
        #endregion
    }
}