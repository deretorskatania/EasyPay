namespace EasyPayLibrary
{
    public class ConnectedUtilitiesPage : BasePageObject
    {
        #region Elements
        private ConnectedUtilitiesFormPage cboAddress;

        public override void Init(WebDriver driver)
        {
            base.Init(driver);
            cboAddress = GetPOM<ConnectedUtilitiesFormPage>(driver);
        }
        #endregion

        #region Methods
        public UserHomePage CallInspector(string address)
        {
            cboAddress.CallInspector(address);
            return cboAddress.SubmitCall();
        }

        public string SelectAddress(string address) 
            => cboAddress.SelectAddress(address);

        public ConnectedUtilitiesFormPage Disconect() 
            => cboAddress.Disconect();
        #endregion
    }
}