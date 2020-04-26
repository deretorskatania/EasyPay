using EasyPayLibrary;
using NUnit.Framework;

namespace EasyPayTests
{
    [TestFixture]
    [Category("All")]
    [Category("Inspector")]
    [Parallelizable(ParallelScope.Fixtures)]
    public class Inspector : BaseTest
    {
        InspectorHomePage homePage;
        string address = "вулиця Університетська 2/5, Чернівці, Чернівецька область";

        [SetUp]
        public override void PreCondition()
        {
            base.PreCondition();
            var loginPage = welcomePage.SignIn();
            LogProgress("Try authorized as 'Inspector's' role");
            homePage = loginPage.LoginAsInspector("inspector1@gmail.com", "Admin123");
        }

        [Test]
        public void SignInInspectorCorrect()
        {
            var header = driver.GetByXpath("//h3[contains(text(),'Inspector')]");
            var headerText = header.GetText();
            Assert.AreEqual("INSPECTOR", headerText, "Inspector isn't loged in");
        }

        //schedule Page
        [Test]
        public void ScheduleAvailable()
        {
            LogProgress("Try navigate to Schedule page");
            var schedulePage = homePage.NavigateToSchedule();
            var isDisplayed = schedulePage.IsScheduleDisplayed();
            Assert.AreEqual(true, isDisplayed, "Not found calendar");
        }

        //Check counters Page
        [Test]
        public void AccessListAddresses()
        {
            LogProgress("Try navigate to Check Counters page");
            var checkCounters = homePage.NavigateToCheckCounters();
            LogProgress($"Try sellect address + {address}");
            checkCounters.ClickOnDropDown();
            var addresses = checkCounters.ReturnListOfDropDown();
            foreach (var element in addresses)
            {
                var isDisplayed = element.IsDisplayed();
                Assert.AreEqual(true, isDisplayed, "Element not found");
            }
        }

        [Test]
        public void AbleActivateOrDeactivateMetrix()
        {
            LogProgress("Try navigate to Check Counters page");
            var checkCountersPage = homePage.NavigateToCheckCounters();
            LogProgress($"Try sellect address + {address}");
            var utility = checkCountersPage.SelectAddress(address);
            LogProgress("Try activate or deactivate metrix");
            var row = utility.GetFirstRow();
            var isActivate = row.IsActivate();
            Assert.AreEqual(true, isActivate, "Error message on page");
            driver.Refresh();
        }

        [Test]
        public void AbleFixedOrUnfixedMetrix()
        {
            LogProgress("Try navigate to Check Counters page");
            var checkCounters = homePage.NavigateToCheckCounters();
            LogProgress($"Try sellect address + {address}");
            var utility = checkCounters.SelectAddress(address);
            LogProgress("Try fix or unfixed metrix");
            var row = utility.GetFirstRow();
            var isFixed = row.IsFixed();
            Assert.AreEqual(true, isFixed, "Error message on page");
            driver.Refresh();
        }

        [Test]
        public void AbleSetNewValueMetrix()
        {
            LogProgress("Try navigate to Check Counters page");
            var checkCounters = homePage.NavigateToCheckCounters();
            LogProgress($"Try sellect address + {address}");
            var utility = checkCounters.SelectAddress(address);
            LogProgress("Try set new value metrix");
            var row = utility.GetFirstRow();

            using (var db = new DatabaseManipulation.DatabaseManager())
            {
                db.Open();
                db.ChangeInDB("update counters set is_active = true, is_fixed = false where address_id = 9");
            }
            var setCurrentValue = row.SetNewValueUtility(address);
            LogProgress("Try set value '44' metrix");
            setCurrentValue.FillNewCurrentValue("44");
            LogProgress("Try click on btn apply");
            setCurrentValue.ClickApplyButton();
            var isSuccsess = setCurrentValue.IsSuccsess();
            Assert.AreEqual(true, isSuccsess, "Error message on page");
        }

        [Test]
        public void ListOfClientsAble()
        {
            LogProgress("Try navigate to Rate clients page");
            var rateClients = homePage.NavigateToRateClients();
            var isDisplayed = rateClients.IsRateClientsTableDisplayed();
            Assert.AreEqual(true, isDisplayed, "List of clients empty");
        }

        [Test]
        public void RateClients()
        {
            LogProgress("Try navigate to Rate clients page");
            var rateClients = homePage.NavigateToRateClients();
            var clientPage = rateClients.ReturnRateClientsTable();
            var lastRow = clientPage.GetLastRow();
            LogProgress("Try click on stars rate");
            var isRated = lastRow.IsRated(4, true);
            Assert.AreEqual(true, isRated, "Error message on page");
        }
    }
}