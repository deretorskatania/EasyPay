using OpenQA.Selenium.Interactions;

namespace EasyPayLibrary
{
    public class RateInspectorsPage : GeneralPage
    {
        #region Elements
        private RateInspectorsFormPage rate;

        public override void Init(WebDriver driver)
        {
            base.Init(driver);
            rate = GetPOM<RateInspectorsFormPage>(driver);
        }
        #endregion

        #region Helper Methods
        public RateInspectorsPage ReturnRateInspectors() 
            => GetPOM<RateInspectorsPage>(driver);

        public WebElement Rate(string name, float star)
        {
            var element = driver.GetByXpath($"//td[contains(text(),'{name}')]/..//td[4]/span");
            var clickOnStar = new Actions(driver.GetDriver);
            clickOnStar.MoveToElement(element.GetElement(), (int)(6 * star), 5).Click().Build().Perform();
            var errorOrSuccess = driver.GetByXpath("//h4[@class='ui-pnotify-title']");
            return errorOrSuccess;
        }
        #endregion
    }
}