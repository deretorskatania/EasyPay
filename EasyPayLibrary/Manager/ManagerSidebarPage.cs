namespace EasyPayLibrary
{
    public  class ManagerSidebarPage : BaseSidebar
    {
        #region Elements
        WebElement mnuInspectors;
        WebElement mnuUtilityPrice;

        public override void Init(WebDriver driver)
        {
            base.Init(driver);
            mnuInspectors = driver.GetByXpath("//a[@href='/manager/schedule/']");
            mnuUtilityPrice = driver.GetByXpath("//a[@href='/manager/utility/price']");
        }
        #endregion

        #region Methods
        public void ClickInspectorsTab() 
            => mnuInspectors.Click();

        public void ClickUtilityPriceTab() 
            => mnuUtilityPrice.Click();
        #endregion
    }
}