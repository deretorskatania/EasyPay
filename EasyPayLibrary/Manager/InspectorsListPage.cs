namespace EasyPayLibrary
{
    public class InspectorsListPage : BasePageObject
    {
        #region Elements
        WebElement optInspector;
        WebElement btnAddInspector;
        WebElement btnRemoveInspector;

        public override void Init(WebDriver driver)
        {
            base.Init(driver);
        }
        #endregion

        #region Helper Methods
        public void ClickOnInspector(string name)
        {
            optInspector = GetInspector(name);
            optInspector.Click();
        }

        public void ClickToRemoveInspector(string name)
        {
            btnRemoveInspector = driver.GetByXpath($"//a[contains(text(),'{name}')]/../..//td[2]/button");
            btnRemoveInspector.Click();
        }

        public void ClickOnAddInspectorsButton()
        {
            btnAddInspector = driver.GetByXpath("//button[@onclick='getFreeInspectors()']");
            btnAddInspector.Click();
        }
        #endregion

        #region Methods
        public string GetStatusOfOperation()
            => driver.GetByXpath("//h4[@class='ui-pnotify-title']").GetText();

        public WebElement GetInspector(string name)
            => driver.GetByXpath($"//a[contains(text(),'{name}')]");

        public SchedulePage NavigateToInspectorsSchedule(string name)
        {
            ClickOnInspector(name);
            return GetPOM<SchedulePage>(driver);
        }

        public RemoveInspectorPage RemoveInspector(string name)
        {
            driver.Refresh();
            ClickToRemoveInspector(name);
            return GetPOM<RemoveInspectorPage>(driver);
        }

        public AddInspectorsPage ClickToAddInspector()
        {
            driver.Refresh();
            ClickOnAddInspectorsButton();
            return GetPOM<AddInspectorsPage>(driver);
        }

        public string VerifyListOfInspectorsIsNotEmpty()
            => driver.GetByXpath("//div[@id='tab-inspectors']//td[1]").ToString();
        #endregion
    }
}