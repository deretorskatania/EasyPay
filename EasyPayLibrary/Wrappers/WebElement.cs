using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace EasyPayLibrary
{
    public class WebElement
    {
        IWebElement element;

        public WebElement(IWebElement el) 
            => element = el;

        public WebElement GetByXpath(string xpath) 
            => new WebElement(element.FindElement(By.XPath(xpath)));

        public string GetText() 
            => element.Text;

        public void Click() 
            => element.Click();

        public string GetCssValue(string name) 
            => element.GetCssValue(name);

        public string GetAttribute(string attribute) 
            => element.GetAttribute(attribute);

        public IWebElement GetElement()
            => element;

        public void SendBackSpace() 
            => element.SendKeys(Keys.Backspace);

        public void SendEnter() 
            => element.SendKeys(Keys.Enter);

        public Actions MoveToElement(Actions actions, int x, int y) 
            => actions.MoveToElement(element, x, y);

        public SelectOption SelectElement() 
            => new SelectOption(new WebElement(element));

        public void SendText(string text)
        {
            element.Clear();
            element.SendKeys(text);
        }
        public bool IsDisplayed()
        {
            bool result;
            try
            {
                result = element.Displayed;
            }
            catch
            {
                result = false;
            }
            return result;
        }
    }

    public class SelectOption
    {
        SelectElement selectElement;

        public SelectOption(WebElement element) => selectElement = new SelectElement(element.GetElement());

        public void SelectByText(string text) 
            => selectElement.SelectByText(text);

        public string GetSelectedOptionText() 
            => selectElement.SelectedOption.Text;
    }
}