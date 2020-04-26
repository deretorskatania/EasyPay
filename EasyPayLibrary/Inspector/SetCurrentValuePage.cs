namespace EasyPayLibrary
{
    public class SetCurrentValuePage : BasePageObject
    {
        #region Elements
        private WebElement fieldNewCurrentValue;
        private WebElement btnApply;

        public override void Init(WebDriver driver)
        {
            fieldNewCurrentValue = driver.GetByXpath("//input[@id='newCurrentValue']");
            btnApply = driver.GetByXpath("//div[@class='modal fade in']//button[2]");
            base.Init(driver);
        }
        #endregion

        #region Methods
        public void FillNewCurrentValue(string text)
            => fieldNewCurrentValue.SendText(text);

        public void ClickApplyButton()
            => btnApply.Click();

        public bool IsSuccsess()
        {
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