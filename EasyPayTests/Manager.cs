using EasyPayLibrary;
using NUnit.Framework;
using System;

namespace EasyPayTests
{
    [TestFixture]
    [Category("All")]
    [Category("Manager")]
    [Parallelizable(ParallelScope.Fixtures)]
    public class Manager : BaseTest
    {
        ManagerHomePage homePage;

        [SetUp]
        public override void PreCondition()
        {
            base.PreCondition();
            LogProgress("Manager is signing in");
            var loginPage = welcomePage.SignIn();
            homePage = loginPage.LoginAsManager("manager1@gmail.com", "Admin123");
        }

        [Test]
        public void ReviewInformation()
        {
            LogProgress("Manager is going to list of inspectors");
            var listOfInspectors = homePage.NavigateToInspectorsList();
            LogProgress("Manager is choosing Oleg Adamov");
            var schedule = listOfInspectors.NavigateToInspectorsSchedule("Oleg Adamov");
            var btnAddInspector = schedule.GetAddScheduleItem();
            var isDisplayedButton = btnAddInspector.IsDisplayed();
            Assert.AreEqual(true, isDisplayedButton, "Button 'Add schedule item' isn't displayed");
        }

        [Test]
        public void AddTasksToInspectorsSchedule()
        {
            LogProgress("Manager is going to list of inspectors");
            var listOfInspectors = homePage.NavigateToInspectorsList();
            LogProgress("Manager is choosing Oleg Adamov");
            var schedule = listOfInspectors.NavigateToInspectorsSchedule("Oleg Adamov");
            LogProgress("Manager is adding an item to inspector's schedule");
            var addItem = schedule.AddItem();
            var deleteItem = addItem.ApplyToAdd(DateTime.Now.AddDays(2).ToString("yyyyMMdd"), "вулиця Руська 241/245, Чернівці, Чернівецька область");

            var isVisibleTask = schedule.GetTask().IsDisplayed();
            Assert.AreEqual(true, isVisibleTask, "Task isn't displayed");
            // postCondition
            LogProgress("Manager is remowing an item from inspector's schedule");
            var confirm = deleteItem.DeleteItem();
            confirm.ApplyToDelete();
        }

        [Test]
        public void EditTasksToInspectorsSchedule()
        {
            LogProgress("Manager is going to list of inspectors");
            var listOfInspectors = homePage.NavigateToInspectorsList();
            LogProgress("Manager is choosing Oleg Adamov");
            var schedule = listOfInspectors.NavigateToInspectorsSchedule("Oleg Adamov");

            // preCondition
            LogProgress("Manager is adding an item to inspector's schedule");
            var addItem = schedule.AddItem();
            var chooseItemToEdit = addItem.ApplyToAdd(DateTime.Now.AddDays(2).ToString("yyyyMMdd"), "вулиця Руська 241/245, Чернівці, Чернівецька область");

            LogProgress("Manager is editing an item in inspector's schedule");
            var editItem = chooseItemToEdit.EditItem();
            var deleteItem = editItem.ApplyToEdit(DateTime.Now.AddDays(3).ToString("yyyyMMdd"), "вулиця Горіхівська 100/2, Чернівці, Чернівецька область");

            var isVisibleTask = schedule.GetTask().IsDisplayed();
            Assert.AreEqual(true, isVisibleTask, "Task isn't displayed");

            // postCondition
            LogProgress("Manager is remowing an item from inspector's schedule");
            var confirm = deleteItem.DeleteItem();
            confirm.ApplyToDelete();
        }

        [Test]
        public void DeleteTasksFromInspectorsSchedule()
        {
            LogProgress("Manager is going to list of inspectors");
            var listOfInspectors = homePage.NavigateToInspectorsList();
            LogProgress("Manager is choosing Oleg Adamov");
            var schedule = listOfInspectors.NavigateToInspectorsSchedule("Oleg Adamov");

            //preCondition
            LogProgress("Manager is adding an item to inspector's schedule");
            var addItem = schedule.AddItem();
            var deleteItem = addItem.ApplyToAdd(DateTime.Now.AddDays(2).ToString("yyyyMMdd"), "вулиця Руська 241/245, Чернівці, Чернівецька область");

            LogProgress("Manager is remowing an item from inspector's schedule");
            var confirm = deleteItem.DeleteItem();
            var result = confirm.ApplyToDelete();
            var status = result.GetStatusOfOperation();

            Assert.AreEqual(status, "Success");
        }

        [Test]
        public void NotAvailableToAddInspector()
        {
            using (var conn = new DatabaseManipulation.DatabaseManager())
            {
                conn.Open();
                conn.ChangeInDB("insert into users values(1209, null, null, 'inspector09@gmail.com', null, 'Ivan', 'Admin123', '+380968780876', 'INSPECTOR', 'Ivanov', 'ACTIVE')");
            }

            LogProgress("Manager is going to list of inspectors");
            var listOfInspectors = homePage.NavigateToInspectorsList();

            // preCondition
            LogProgress("Manager is adding Ivan Ivanov to the list of inspectors");
            var addIvan = listOfInspectors.ClickToAddInspector();
            addIvan.AddInspector("Ivan Ivanov");

            LogProgress("Manager is trying to add an inspector to the list of inspectors");
            var close = listOfInspectors.ClickToAddInspector();
            var actualCaption = close.GetCaption();
            Assert.AreEqual("All inspectors are busy", actualCaption, "Busy isn't displayed");
            close.CloseWindow();

            // postCondition
            LogProgress("Manager is removing Ivan Ivanov from the list of inspectors");
            var removeIvan = listOfInspectors.RemoveInspector("Ivan Ivanov");
            removeIvan.ConfirmRemoving();

            using (var conn = new DatabaseManipulation.DatabaseManager())
            {
                conn.Open();
                conn.ChangeInDB("delete from utilities_users where user_id = 1209;");
                conn.ChangeInDB("delete from users where user_id = 1209");
            }
        }

        [Test]
        public void RemoveInspector()
        {
            using (var conn = new DatabaseManipulation.DatabaseManager())
            {
                conn.Open();
                conn.ChangeInDB("insert into users values(113, null, null, 'inspector5@gmail.com', null, 'Ivan', 'Admin123', '+380968780876', 'INSPECTOR', 'Ivanov', 'ACTIVE')");
            }

            LogProgress("Manager is going to list of inspectors");
            var listOfInspectors = homePage.NavigateToInspectorsList();

            // preCondition
            LogProgress("Manager is adding Ivan Ivanov to the list of inspectors");
            var addIvan = listOfInspectors.ClickToAddInspector();
            addIvan.AddInspector("Ivan Ivanov");

            LogProgress("Manager is removing Ivan Ivanov from the list of inspectors");
            var removeIvan = listOfInspectors.RemoveInspector("Ivan Ivanov");
            var result = removeIvan.ConfirmRemoving();
            var status = result.GetStatusOfOperation();
            Assert.AreEqual(status, "Success");

            using (var conn = new DatabaseManipulation.DatabaseManager())
            {
                conn.Open();
                conn.ChangeInDB("delete from users where user_id = 113");
            }
        }

        [Test]
        public void AddInspector()
        {
            using (var conn = new DatabaseManipulation.DatabaseManager())
            {
                conn.Open();
                conn.ChangeInDB("insert into users values(113, null, null, 'inspector5@gmail.com', null, 'Ivan', 'Admin123', '+380968780876', 'INSPECTOR', 'Ivanov', 'ACTIVE')");
            }

            LogProgress("Manager is going to list of inspectors");
            var listOfInspectors = homePage.NavigateToInspectorsList();
            LogProgress("Manager is adding Ivan Ivanov to the list of inspectors");
            var addIvan = listOfInspectors.ClickToAddInspector();
            addIvan.AddInspector("Ivan Ivanov");
            var isInspectorDisplayed = listOfInspectors.GetInspector("Ivan Ivanov").IsDisplayed();
            Assert.AreEqual(true, isInspectorDisplayed, "Ivan Ivanov isn't displayed");

            // postCondition
            LogProgress("Manager is removing Ivan Ivanov from the list of inspectors");
            var removeIvan = listOfInspectors.RemoveInspector("Ivan Ivanov");
            removeIvan.ConfirmRemoving();

            using (var conn = new DatabaseManipulation.DatabaseManager())
            {
                conn.Open();
                conn.ChangeInDB("delete from users where user_id = 113");
            }
        }

        [Test]
        public void SetNewPrice()
        {
            LogProgress("Manager is going to utility price page");
            var setNewPrice = homePage.NavigateToUtilityPrice();
            LogProgress("Manager is setting a new price");
            setNewPrice.ClickSetNewPriceButton();
            var formSetNewPrice = setNewPrice.ClickSetNewPriceButton();
            formSetNewPrice.SetNewPrice("7");
            var actualPrice = setNewPrice.GetCurrentPrice();
            Assert.AreEqual("Current price: ₴7", actualPrice, "Wrong price");
        }

        [Test]
        public void SetFuturePrice()
        {
            LogProgress("Manager is going to utility price page");
            var setFuturePrice = homePage.NavigateToUtilityPrice();
            LogProgress("Manager is setting a future price");
            setFuturePrice.ClickSetFuturePriceButton();
            var formSetFuturePrice = setFuturePrice.ClickSetFuturePriceButton();
            formSetFuturePrice.SetFuturePrice("20", DateTime.Now.AddDays(2).ToString("yyyy-MM-dd"));
            var actualPrice = setFuturePrice.GetFuturePrice();
            var actualActivationDate = setFuturePrice.GetActivationDate();
            Assert.AreEqual("Future price: ₴20", actualPrice, "Wrong price");
            Assert.AreEqual("Next activation date: 27 APRIL 2020", actualActivationDate, "Wrong  activation date");
        }

        [Test]
        public void VerifyThatManagerHasAccesToAccount()
        {
            Assert.IsTrue(driver.GetUrl().Contains("http://localhost:8080/home"), "Wrong Url");
            Assert.AreEqual("MANAGER", GeneralPage.GetRole(driver), "manager can't access his account");
        }

        [Test]
        public void VerifyScheduleIsVisible()
        {
            LogProgress("Manager is navigating to inspectors list page");
            var inspectorPage = homePage.NavigateToInspectorsList();
            LogProgress("Manager is choosing inspector: Oleg Adamov");
            var schedulePage = inspectorPage.NavigateToInspectorsSchedule("Oleg Adamov");
            LogProgress("Manager is clicking on Add Schedule Item Button");
            var addScheduleItemPage = schedulePage.AddItem();
            LogProgress("Manager is entering date and address");
            addScheduleItemPage.ApplyToAdd(DateTime.Now.AddDays(1).ToString("yyyy-MM-dd"), "Немирівська вулиця 1/2, Чернівці, Чернівецька область");
            var isAddressFromScheduleDisplayed = addScheduleItemPage.IsAddressFromScheduleDisplayed();
            Assert.AreEqual(true, isAddressFromScheduleDisplayed, "Address from schedule is not displayed");
        }

        [Test]
        public void VerifyHistoryIsVisible()
        {
            using (var conn = new DatabaseManipulation.DatabaseManager())
            {
                var prevMonthDate = DateTime.Today.AddMonths(-1);
                var currentMothDate = DateTime.Today;
                var todayStr = currentMothDate.ToString().Replace('.', '-');
                var prevMothStr = prevMonthDate.ToString().Replace('.', '-');
                conn.Open();
                conn.ChangeInDB("Truncate table schedule_history");
                conn.ChangeInDB($"insert into schedule_history values (16,'Overdue visit','{todayStr}','OVERDUE','{todayStr}',16,109)");
                conn.ChangeInDB($"insert into schedule_history values (17,'Overdue visit','{prevMothStr}','OVERDUE','{prevMothStr}',16,109)");
            }

            var inspectorPage = homePage.NavigateToInspectorsList();
            LogProgress("Manager is choosing inspector: Oleg Adamov");
            var schedulePage = inspectorPage.NavigateToInspectorsSchedule("Oleg Adamov");
            LogProgress("Manager is clicking on tab history");
            var tabHistory = schedulePage.ClickOnTabHistory();
            LogProgress("Manager is clicking on current month button");
            var tabCurrentMonth = tabHistory.ClickOnCurrentMonthButton();
            var currentMonthContainsAddress = tabHistory.CurrentMonthContainsAddress("вулиця Пушкіна ", $"{DateTime.Today.ToString("dd.M.yyyy")}");
            Assert.AreEqual(true, currentMonthContainsAddress, "Current month history is not visible");
            var tabPreviousMonth = tabHistory.ClickOnPreviousMonthButton();
            var previousMonthContainsAddress = tabHistory.PreviousMonthContainsAddress($"{DateTime.Today.AddMonths(-1).ToString("dd.M.yyyy")}");
            Assert.AreEqual(true, previousMonthContainsAddress, $"Previous month history doesn't contain date: {DateTime.Today.AddMonths(-1).ToString("dd.M.yyyy")}");
        }

        [Test]
        public void VerifyStatisticsIsVisible()
        {
            LogProgress("Manager is navigating to inspectors list page");
            var inspectorPage = homePage.NavigateToInspectorsList();
            LogProgress("Manager is choosing inspector: Oleg Adamov");
            var schedulePage = inspectorPage.NavigateToInspectorsSchedule("Oleg Adamov");
            LogProgress("Manager is clicking on tab statistics");
            var tabStatistics = schedulePage.ClickOnTabStatistics();
            var isCurrentAppointmentVisible = tabStatistics.IsCurrentAppointmentVisible();
            var isPreviousAppointmentsVisible = tabStatistics.IsPreviousAppointmentsVisible();
            Assert.AreEqual(true, isCurrentAppointmentVisible, "Current appointment is not visible");
            Assert.AreEqual(true, isPreviousAppointmentsVisible, "Previous appointment is not visible");
        }

        [Test]
        public void VerifyCurrentPriceAndFuturePrice()
        {
            LogProgress("Manager is navigating to utility price page");
            var utilityPricePage = homePage.NavigateToUtilityPrice();
            LogProgress("Manager is setting new price");
            var formSetNewPrice = utilityPricePage.ClickSetNewPriceButton();
            formSetNewPrice.SetNewPrice("24");
            utilityPricePage.Init(driver);
            LogProgress("Manager is setting new future price");
            var formSetFuturePrice = utilityPricePage.ClickSetFuturePriceButton();
            formSetFuturePrice.SetFuturePrice("30", DateTime.Now.AddDays(2).ToString("yyyy-MM-dd"));
            Assert.AreEqual("Current price: ₴24", "Current price: ₴24", "Current price is not 24");
            Assert.AreEqual("Future price: ₴30", "Future price: ₴30", "Future price is not 30");
        }
    }
}
