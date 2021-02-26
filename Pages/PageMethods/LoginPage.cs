using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OlanAuctions.GetDriver;
using OlanAuctions.Pages.PageConstants;
using OpenQA.Selenium;

namespace OlanAuctions.Pages.PageMethods
{
    class LoginPage : Base
    {
        public LoginPage(IWebDriver driver) : base(driver) { }
        public bool IsIncorrectUsernamePasswordMessageDisplayed => Driver.FindElement(LoginPageConstants.ERROR_MESSAGE).Displayed;
        public bool IsPageDisplayed => Driver.Title == "Login";

        public LoginPage ClickActiveListingsLink() 
        {
            Driver.FindElement(LoginPageConstants.ACTIVE_LISTINGS_LINK).Click();
            return new LoginPage(Driver);
        }

        internal LoginPage ClickLoginLink()
        {
            Driver.FindElement(LoginPageConstants.LOG_IN_LINK).Click();
            return new LoginPage(Driver);
        }

        internal RegisterPage ClickRegisterHereLink()
        {
            Driver.FindElement(LoginPageConstants.REGISTER_HERE_LINK).Click();
            return new RegisterPage(Driver);
        }

        public void GoTo()
        {
            Driver.Navigate().GoToUrl("http://olan-auctions.herokuapp.com");
            Driver.Manage().Window.Maximize();
        }

        public ActiveListingsPage FillOutFormAndSubmit(string username, string password)
        {
            var usernameField = Driver.FindElement(LoginPageConstants.USERNAME_FIELD);
            var passwordField = Driver.FindElement(LoginPageConstants.PASSWORD_FIELD);
            usernameField.Clear();
            usernameField.SendKeys(username);
            passwordField.Clear();
            passwordField.SendKeys(password);
            Driver.FindElement(LoginPageConstants.LOGIN_BUTTON).Click();
            return new ActiveListingsPage(Driver);
        }
    }
}
