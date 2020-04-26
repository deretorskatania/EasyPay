namespace EasyPayLibrary
{
    public class ChangeManagerPage : BasePageObject
    {
        #region Elements
        WebElement txtUpdate;
        WebElement manager;
        WebElement btnClose;
        WebElement btnConfim;

        public override void Init(WebDriver driver)
        {
            base.Init(driver);
            txtUpdate = driver.GetByXpath("//input[@id='change_manager']");
            manager = driver.GetByXpath("//select[@id='update_managers']");
            btnClose = driver.GetByXpath("//div[@id='update_utility_modal']//a[contains(@class,'btn btn-secondary')]");
            btnConfim = driver.GetByXpath("//button[@id='update_button']");
        }
        #endregion

        #region Helper Methods
        private void inputKeyWord()
        {
            txtUpdate.Click();
            txtUpdate.SendText("UPDATE");
        }

        private void chooseManager(string name)
        {
            manager.Click();
            var chooseManger = driver.GetByXpath($"//select[@id='update_managers']//option[contains(text(),'{name}')]");
            chooseManger.Click();
        }
        #endregion

        #region Methods
        public UtilitiesPage SelectManager(string myManager)
        {
            inputKeyWord();
            chooseManager(myManager);
            return ClickConfirm();
        }

        public UtilitiesPage ClickConfirm()
        {
            btnConfim.Click();
            return GetPOM<UtilitiesPage>(driver);
        }
        #endregion
    }
}