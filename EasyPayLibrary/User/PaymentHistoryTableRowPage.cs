using System;

namespace EasyPayLibrary
{
    public class PaymentHistoryTableRowPage : BaseRow
    {
        #region Elements
        private string lblDate;
        private string lblSum;
        private WebElement btnViewCheck;

        public PaymentHistoryTableRowPage(WebDriver driver, WebElement element)
        {
            lblDate = element.GetByXpath(".//td[@class='historyDate']").GetText();
            lblSum = element.GetByXpath(".//td[@class='historySum']").GetText();
            btnViewCheck = element.GetByXpath(".//td[@class='historyView']/a");
            base.Init(driver);
        }
        #endregion

        #region Helper Methods
        private void ClickViewReceiptButton()
            => btnViewCheck.Click();

        private void ViewReceipt()
        {
            ClickViewReceiptButton();
            driver.WaitUntillUrlContainString("drive.google.com", 20);
        }

        private int DaysInDateOfPay()
        {
            var firstDate = new DateTime(2000, 1, 1);
            var secondDate = Date;
            TimeSpan difference = firstDate - secondDate;
            return difference.Days;
        }
        #endregion

        #region Methods
        public DateTime Date 
            => Convert.ToDateTime(lblDate);

        public float Sum 
            => Convert.ToSingle(lblSum.Replace(".", ","));
        
        public ReceiptPDFPage GetReceipt()
        {
            ViewReceipt();
            return GetPOM<ReceiptPDFPage>(driver);
        }

        public override bool Equals(object obj)
        {
            if (!(obj is PaymentHistoryTableRowPage)) return false;

            var castedObj = ((PaymentHistoryTableRowPage)obj);
            return (castedObj.Date == Date && castedObj.Sum == Sum);
        }

        public override int GetHashCode()
        {
            return ((int)(Sum * 100)) ^ DaysInDateOfPay();
        }
        #endregion
    }
}