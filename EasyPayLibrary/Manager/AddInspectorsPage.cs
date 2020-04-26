namespace EasyPayLibrary
{
    public class AddInspectorsPage : BasePageObject
    {
        #region Elements
        WebElement btnAdd;

        public override void Init(WebDriver driver)
        {
            base.Init(driver);
            btnAdd = driver.GetByXpath("//button[@data-locale-item='add']");
        }
        #endregion

        #region Helper Methods
        private void SelectInspectorByName(string name)
            => driver.GetByXpath($"//option[contains(text(),'{name}')]").Click();

        private void ClickAddButton()
            => btnAdd.Click();

        private void ClickCloseButton()
            => driver.GetByXpath("//div[@id='add-inspector-modal']//button[@class='btn btn-default']").Click();
        #endregion

        #region Methods
        public string GetCaption()
            => driver.GetByXpath("//h3[@id='busy']").GetText();

        public InspectorsListPage AddInspector(string name)
        {
            SelectInspectorByName(name);
            ClickAddButton();
            return GetPOM<InspectorsListPage>(driver);
        }

        public InspectorsListPage CloseWindow()
        {
            ClickCloseButton();
            return GetPOM<InspectorsListPage>(driver);
        }
        #endregion
    }
}