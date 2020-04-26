namespace EasyPayLibrary
{
    public class RemoveInspectorPage : BasePageObject
    {
        #region Elements
        WebElement btnRemove;

        public override void Init(WebDriver driver)
        {
            base.Init(driver);
            btnRemove = driver.GetByXpath("//button[@id='removeInspector']");
        }
        #endregion

        #region Helper Methods
        public void ClickRemoveButton() 
            => btnRemove.Click();
        #endregion

        #region Methods
        public InspectorsListPage ConfirmRemoving()
        {
            ClickRemoveButton();
            return GetPOM<InspectorsListPage>(driver);
        }
        #endregion
    }
}