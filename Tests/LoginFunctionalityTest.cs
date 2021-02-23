using Microsoft.VisualStudio.TestTools.UnitTesting;
using OlanAuctions.Pages;
using System;
using OpenQA.Selenium;
using OlanAuctions.GetDriver;
using OlanAuctions.Pages.PageMethods;
using OlanAuctions.TestData;

namespace OlanAuctions.Tests
{
    [TestClass]
    [TestCategory("Login")]
    public class LoginFunctionalityTest
    {
        private string username = "username";
        private string password = "password";
        private string errorMessage = "Invalid Username/Password message is not displayed.";
        private static ExcelFile testFile = new ExcelFile();
        private IWebDriver Driver { get; set; }
        private LoginPage loginPage;

        [TestInitialize]
        public void RunBeforeEachTest()
        {
            WebDriverFactory factory = new WebDriverFactory();
            Driver = factory.Create(BrowserType.Chrome);
            loginPage = new LoginPage(Driver);
            loginPage.GoTo();
        }

        [Description("Verify login with blank username and blank password.")]
        [TestProperty("Author", "JoshOlaniyan")]
        [TestMethod]
        public void Test1()
        {
            loginPage.FillOutFormAndSubmit(testFile.GetDataWithKey(1, username), testFile.GetDataWithKey(1, password));
            Assert.IsTrue(loginPage.IsIncorrectUsernamePasswordMessageDisplayed, errorMessage);
        }

        [Description("Verify login with blank username and invalid password.")]
        [TestProperty("Author", "JoshOlaniyan")]
        [TestMethod]
        public void Test2()
        {
            loginPage.FillOutFormAndSubmit(testFile.GetDataWithKey(2, username), testFile.GetDataWithKey(2, password));
            Assert.IsFalse(!loginPage.IsIncorrectUsernamePasswordMessageDisplayed, errorMessage);
        }

        [Description("Verify login with username and blank password.")]
        [TestProperty("Author", "JoshOlaniyan")]
        [TestMethod]
        public void Test3()
        {
            loginPage.FillOutFormAndSubmit(testFile.GetDataWithKey(3, username), testFile.GetDataWithKey(3, password));
            Assert.IsTrue(loginPage.IsIncorrectUsernamePasswordMessageDisplayed, errorMessage);
        }


        [Description("Verify login with valid username and invalid password.")]
        [TestProperty("Author", "JoshOlaniyan")]
        [TestMethod]
        public void Test4()
        {
            loginPage.FillOutFormAndSubmit(testFile.GetDataWithKey(4, username), testFile.GetDataWithKey(4, password));
            Assert.IsTrue(loginPage.IsIncorrectUsernamePasswordMessageDisplayed, errorMessage);
        }

        [Description("Verify login with invalid username and valid password.")]
        [TestProperty("Author", "JoshOlaniyan")]
        [TestMethod]
        public void Test5()
        {
            loginPage.FillOutFormAndSubmit(testFile.GetDataWithKey(5, username), testFile.GetDataWithKey(5, password));
            Assert.IsTrue(loginPage.IsIncorrectUsernamePasswordMessageDisplayed, errorMessage);
        }

        [Description("Verify login with sql inejction.")]
        [TestProperty("Author", "JoshOlaniyan")]
        [TestMethod]
        public void Test6()
        {
            loginPage.FillOutFormAndSubmit(testFile.GetDataWithKey(6, username), testFile.GetDataWithKey(6, password));
            Assert.IsTrue(loginPage.IsIncorrectUsernamePasswordMessageDisplayed, errorMessage);
        }

        [Description("Verify login with valid username and valid password.")]
        [TestProperty("Author", "JoshOlaniyan")]
        [TestMethod]
        public void Test7()
        {
            ActiveListingsPage activeListingsPage =  loginPage.FillOutFormAndSubmit(testFile.GetDataWithKey(7, username), testFile.GetDataWithKey(7, password));
            Assert.IsTrue(activeListingsPage.IsDisplayed, "Active Listings page is not displayed with valid login details.");
        }

        [Description("Verify login page is displayed when the user is not logged in and clicks 'Active Listings'.")]
        [TestProperty("Author", "JoshOlaniyan")]
        [TestMethod]
        public void Test8()
        {
            LoginPage lPage = loginPage.ClickActiveListingsLink();
            Assert.IsTrue(lPage.IsPageDisplayed, "The user can access Active Listings when user is not logged in.");
        }

        [Description("Verify login page is displayed when the user clicks 'Log in'.")]
        [TestProperty("Author", "JoshOlaniyan")]
        [TestMethod]
        public void Test9()
        {
            LoginPage lPage = loginPage.ClickLoginLink();
            Assert.IsTrue(lPage.IsPageDisplayed, "The Login page is not displayed when the user clicks the 'Log In' link.");
        }

        [Description("Verify login page is displayed when the user clicks 'Log In here' in the 'Register page'.")]
        [TestProperty("Author", "JoshOlaniyan")]
        [TestMethod]
        public void Test10()
        {
            RegisterPage rPage = loginPage.ClickRegisterHereLink();
            LoginPage lPage = rPage.ClickLoginHereLink();
            Assert.IsTrue(lPage.IsPageDisplayed, "Login Page is not displayed when the user clicks 'Log in here' link.");
        }

        [TestCleanup]
        public void RunAfterEachTest()
        {
            Driver.Close();
            Driver.Quit();
            Driver = null;
        }

        [ClassCleanup]
        public static void RunAfterClass()
        {
            testFile.CloseWorkBook();
        }
    }
}
