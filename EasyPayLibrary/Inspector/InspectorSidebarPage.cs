namespace EasyPayLibrary
{
    public class InspectorSidebarPage : BaseSidebar
    {
        #region Elements
        public WebElement mnuSchedule;
        public WebElement mnuCheckCounters;
        public WebElement mnuRateClients;

        public override void Init(WebDriver driver)
        {
            base.Init(driver);
            mnuSchedule = driver.GetByXpath("//a[@href='/inspector/schedule/']");
            mnuCheckCounters = driver.GetByXpath("//a[@href='/inspector/addresses/counters/']");
            mnuRateClients = driver.GetByXpath("//a[@href='/inspector/rate/']");
        }
        #endregion

        #region Methods
        public void ClickCheckCounters()
            => mnuCheckCounters.Click();

        public void ClickRateClient()
            => mnuRateClients.Click();

        public void ClickSchedule()
            => mnuSchedule.Click();
        #endregion
    }
}