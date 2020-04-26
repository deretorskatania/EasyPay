namespace EasyPayLibrary
{
    public class UtilitiesPage : AdminHomePage
    {
        #region Elements
        WebElement tblUtilities;

        public override void Init(WebDriver driver)
        {
            base.Init(driver);
            tblUtilities = driver.GetByXpath("//table/tbody[@id='utility_table']");
        }
        #endregion

        #region Methods
        public bool UtilitiesTableIsVisible() 
            => tblUtilities.IsDisplayed();

        public UtilitiesTable ReturnUtilitiesTable() 
            => GetPOM<UtilitiesTable>(driver);
        #endregion
    }
}