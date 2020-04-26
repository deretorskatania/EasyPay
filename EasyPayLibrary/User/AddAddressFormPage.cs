namespace EasyPayLibrary
{
    public class AddAddressFormPage : BasePageObject
    {
        #region Elements
        private WebElement txtAddress;
        private WebElement txtHouse;
        private WebElement txtStreet;
        private WebElement txtCity;
        private WebElement txtRegion;
        private WebElement txtZipCode;
        private WebElement txtCountry;
        private WebElement btnAddAddress;
        private WebElement btnCheck;
        private WebElement txtFlat;

        public override void Init(WebDriver driver)
        {
            base.Init(driver);
            txtAddress = driver.GetByXpath("//input[@id='autocomplete']");
            txtHouse = driver.GetByXpath("//*[@id='street_number']");
            txtStreet = driver.GetByXpath("//*[@id='route']");
            txtCity = driver.GetByXpath("//*[@id='locality']");
            txtRegion = driver.GetByXpath("//*[@id='administrative_area_level_1']");
            txtZipCode = driver.GetByXpath("//*[@id='postal_code']");
            txtCountry = driver.GetByXpath("//*[@id='country']");
            txtFlat = driver.GetByXpath("//*[@id='flat_number']");
            btnCheck = driver.GetByXpath("//*[@id='flat_checkbox']");
            btnAddAddress = driver.GetByXpath("//*[@id='submit']");
        }
        #endregion

        #region Helper Methods
        public void ClickCheckButton() 
            => btnCheck.Click();

        public void ClickAddAddressButton() 
            => btnAddAddress.Click();
        #endregion

        #region Methods
        public void EnterAllFields(string address, string house, string street, string city, string region, string zipCode, string country, string flat)
        {
            txtAddress.SendText(address);
            txtAddress.SendEnter();
            txtHouse.SendText(house);
            txtStreet.SendText(street);
            txtCity.SendText(city);
            txtRegion.SendText(region);
            txtZipCode.SendText(zipCode);
            txtCountry.SendText(country);
            ClickCheckButton();
            txtFlat.SendText(flat);
            ClickAddAddressButton();
        }

        public string GetError() 
            => driver.GetByXpath("//div[contains(@class,'ui-pnotify-fade-normal ui-pnotify-move ui-pnotify-in ui-pnotify-fade-in')]").GetText();
        #endregion
    }
}