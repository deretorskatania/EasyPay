namespace EasyPayLibrary
{
    public abstract class BasePageObject
    {
        protected WebDriver driver;

        public virtual void Init(WebDriver driver) => this.driver = driver;

        public static T GetPOM<T>(WebDriver driver) where T : BasePageObject, new()
        {
            var pom = new T();
            pom.Init(driver);
            return pom;
        }

        public static T TranslatePageToUA<T>(WebDriver driver) where T : BasePageObject, new()
        {
            LanguageChanger.ChangeToUA(driver);
            return GetPOM<T>(driver);
        }

        public static T TranslatePageToEN<T>(WebDriver driver) where T : BasePageObject, new()
        {
            LanguageChanger.ChangeToEN(driver);
            return GetPOM<T>(driver);
        }
    }
}