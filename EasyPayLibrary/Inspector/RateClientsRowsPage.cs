using OpenQA.Selenium.Interactions;

namespace EasyPayLibrary
{
    public class RateClientsRowsPage : BasePageObject
    {
        #region Elements
        private string name;
        private WebElement rate;

        public RateClientsRowsPage(WebElement element, WebDriver driver)
        {
            name = element.GetByXpath(".//td[1]").GetText();
            rate = element.GetByXpath(".//td[3]");
            base.Init(driver);
        }
        #endregion

        #region Methods
        public void Rate(int starNumber, bool andHalf = false)
        {
            starNumber = starNumber * 12;
            starNumber += (andHalf) ? 6 : 0;
            var element = rate.GetByXpath("./span");
            var clickOnStar = new Actions(driver.GetDriver);
            clickOnStar.MoveToElement(element.GetElement(), (starNumber), 5).Click().Build().Perform();
        }

        public bool IsRated(int starNumber, bool andHalf = false)
        {
            Rate(starNumber, andHalf);
            var messageBox = driver.GetByXpath("//h4[@class='ui-pnotify-title']");
            var textOfMessageBox = messageBox.GetText();
            if (textOfMessageBox == "Success")
                return true;
            else
                return false;
        }
        #endregion
    }
}