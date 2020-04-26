namespace EasyPayLibrary
{
    public class StatisticsPage: BasePageObject
    {
        #region Methods
        public bool IsCurrentAppointmentVisible() 
            => driver.GetByXpath("//span[contains(text(),'Current appointments')]").IsDisplayed();

        public bool IsPreviousAppointmentsVisible() 
            => driver.GetByXpath("//span[contains(text(),'Previous appointments')]").IsDisplayed();
        #endregion
    }
}