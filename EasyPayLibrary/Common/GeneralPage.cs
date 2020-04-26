namespace EasyPayLibrary
{
    public abstract class GeneralPage : BasePageObject
    {
        protected Header header;

        public override void Init(WebDriver driver)
        {
            header = GetPOM<Header>(driver);
            base.Init(driver);
        }

        public ProfilePage GoToProfile()
        {
            header.GoToProfile();
            return GetPOM<ProfilePage>(driver);
        }

        public LoginPage LogOut()
        {
            header.LogOut();
            return GetPOM<LoginPage>(driver);
        }

        public static string GetRole(WebDriver driver)
            => BaseSidebar.GetRole(driver);
    }
}
