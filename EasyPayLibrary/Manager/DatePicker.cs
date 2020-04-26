namespace EasyPayLibrary
{
    public class DatePicker
    {
        public static void DatePickerFunc(WebElement element)
        {
            for (int i = 0; i <= 7; i++)
            {
                element.SendBackSpace();
            }
        }
    }
}