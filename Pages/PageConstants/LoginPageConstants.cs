using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace OlanAuctions.Pages.PageConstants
{
    class LoginPageConstants
    {
        /*Top nav bar links*/
        public static By ACTIVE_LISTINGS_LINK = By.XPath("//*[contains(text(), 'Active Listings')]");
        public static By LOG_IN_LINK = By.LinkText("Log In");

        /*Login static fields*/
        public static By USERNAME_FIELD = By.Id("username");
        public static By PASSWORD_FIELD = By.Id("password");
        public static By LOGIN_BUTTON = By.XPath("//*[@type='submit' and text()='Login']");

        public static By ERROR_MESSAGE = By.XPath("//*[@class='message']");

        public static By REGISTER_HERE_LINK = By.LinkText("Register here.");
    }
}
