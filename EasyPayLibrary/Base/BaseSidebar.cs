using OpenQA.Selenium;
using System.Collections.Generic;

namespace EasyPayLibrary
{
    public abstract class BaseSidebar : BasePageObject
    {
        internal static string GetRole(WebDriver driver)
        {
            try
            {
                return driver.GetByXpath("//div[@class='menu_section']//h3", 2).GetText();
            }
            catch (WebDriverTimeoutException)
            {
                return null;
            }
        }

        internal IEnumerable<WebElement> ListOfSideBarComponents => driver.GetElementsByXpath("//ul[@class='nav side-menu']/li/a//span");
    }
}
