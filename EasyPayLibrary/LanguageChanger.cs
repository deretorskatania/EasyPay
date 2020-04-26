namespace EasyPayLibrary
{
    internal class LanguageChanger
    {
        public static void ChangeToUA(WebDriver driver)
        {
            WebElement btnUA = driver.GetByXpath("//a[@href='?lang=ua']");
            btnUA.Click();
        }

        public static void ChangeToEN(WebDriver driver)
        {
            WebElement btnEN = driver.GetByXpath("//a[@href='?lang=en']");
            btnEN.Click();
        }
    }
}