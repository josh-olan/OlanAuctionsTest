using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using OpenQA.Selenium;
using OlanAuctions.GetDriver;
using OlanAuctions.ExcelData;
using OlanAuctions.Pages.PageMethods;

namespace OlanAuctions.Tests
{
    [TestClass]
    [TestCategory("Sort Functionality")]
    public class SortFunctionalityTest
    {
        private IWebDriver Driver { get; set; }
        private static ExcelFile TestFile { get; set; }
        private LoginPage loginPage;
        private ActiveListingsPage activePage;

        [ClassInitialize]
        public static void RunBeforeClass(TestContext testContext)
        {
            TestFile = new ExcelFile();
        }

        [TestInitialize]
        public void RunBeforeEachTest()
        {
            Driver = new WebDriverFactory().Create(BrowserType.Chrome);
            loginPage = new LoginPage(Driver);
            loginPage.GoTo();
            activePage = loginPage.FillOutFormAndSubmit(TestFile.GetDataWithKey(7, "username"), TestFile.GetDataWithKey(7, "password"));
            activePage.AssertPageIsDisplayed();
        }

        [TestMethod]
        [TestProperty("Author", "JoshOlaniyan")]
        [Description("Verify the user can sort listings from lowest to highest.")]
        public void Test11()
        {
            activePage.AssertSortingFromLowestToHighest();
        }
        
        [TestMethod]
        [TestProperty("Author", "JoshOlaniyan")]
        [Description("Verify the user can sort listings from highest price to lowest.")]
        public void Test12()
        {
            activePage.AssertSortingFromHighestToLowest();
        }
        /*
        [TestMethod]
        [TestProperty("Author", "JoshOlaniyan")]
        [Description("Verify the user can sort listings with oldest listings first.")]
        public void Test13()
        {
            activePage.AssertSortingWithOldestFirst();
        }

        [TestMethod]
        [TestProperty("Author", "JoshOlaniyan")]
        [Description("Check that the user can sort listings with the most recent first.")]
        public void Test14()
        {
            activePage.AssertSortingWithMostRecentFirst();
        }*/

        [TestCleanup]
        public void RunAfterEachTest()
        {
            Driver.Quit();
            Driver = null;
        }

        [ClassCleanup]
        public static void RunAfterClass()
        {
            TestFile.CloseWorkBook();
        }
    }
}
