namespace EasyPayLibrary
{
    public class SchedulePage : BasePageObject
    {
        #region Elements
        WebElement btnAddScheduleItem;
        WebElement btnEditScheduleItem;
        WebElement btnDeleteScheduleItem;
        WebElement tabHistory;
        WebElement tabStatistics;

        public override void Init(WebDriver driver)
        {
            base.Init(driver);
            btnAddScheduleItem = driver.GetByXpath("//button[@class='fc-addScheduleItem-button fc-button fc-state-default fc-corner-left fc-corner-right']", 5);
            tabHistory = driver.GetByXpath("//a[@id='profile-tab2']");
            tabStatistics = driver.GetByXpath("//span[contains(text(),'Statistics')]");
        }
        #endregion

        #region Helper Methods
        public void ClickOnAddScheduleButton() 
            => btnAddScheduleItem.Click();

        public void ClickOnEditScheduleButton()
        {
            btnEditScheduleItem = driver.GetByXpath("//span[@class='fc-title']");
            btnEditScheduleItem.Click();
        }

        public void ClickOnDeleteScheduleButton()
        {
            btnDeleteScheduleItem = driver.GetByXpath("//i[@class='fa fa-trash-o']");
            btnDeleteScheduleItem.Click();
        }
        #endregion

        #region Methods
        public WebElement GetAddScheduleItem() 
            => btnAddScheduleItem;

        public WebElement GetTask()
        {
            btnEditScheduleItem = driver.GetByXpath("//span[@class='fc-title']");
            return btnEditScheduleItem;
        }

        public AddScheduleItemPage AddItem()
        {
            ClickOnAddScheduleButton();
            return GetPOM<AddScheduleItemPage>(driver);
        }

        public EditScheduleItemPage EditItem()
        {
            ClickOnEditScheduleButton();
            return GetPOM<EditScheduleItemPage>(driver);
        }

        public DeleteScheduleItemPage DeleteItem()
        {
            ClickOnDeleteScheduleButton();
            return GetPOM<DeleteScheduleItemPage>(driver);
        }

        public HistoryPage ClickOnTabHistory()
        {
            tabHistory.Click();
            return GetPOM<HistoryPage>(driver);
        }

        public StatisticsPage ClickOnTabStatistics()
        {
            tabStatistics.Click();
            return GetPOM<StatisticsPage>(driver);
        }

        public string GetStatusOfOperation()
        {
            var status = driver.GetByXpath("//h4[@class='ui-pnotify-title']").GetText();
            return status;
        }
        #endregion
    }
}