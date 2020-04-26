using EasyPayLibrary;
using NUnit.Framework;
using ExtentReport;

namespace EasyPayTests
{
    public class BaseTest
    {
        string browser;
        protected TranslationValues t;
        protected WebDriver driver;
        protected WelcomePage welcomePage;
        protected SeleniumExtentReport report;

        [OneTimeSetUp]
        public void BeforeClass()
        {
            report = new SeleniumExtentReport();
            report.BeforeClass();
        }

        [SetUp]
        public virtual void PreCondition()
        {
            report.BeforeTest();
            t = TranslationProvider.GetTranslation("ua");
            browser = TestContext.Parameters.Get("browser");
            driver = new DriverFactory().GetDriver(browser);

            driver.Maximaze();
            driver.GoToURL();
            welcomePage = new WelcomePage();
            welcomePage.Init(driver);
        }

        [TearDown]
        public virtual void PostCondition()
        {
            report.AfterTest(driver);
            driver.Quit();
        }

        [OneTimeTearDown]
        public void AfterClass() 
            => report.AfterClass();

        public void LogProgress(string message) 
            => TestContext.Out.WriteLine("\n<br>" + message);
    }
}
