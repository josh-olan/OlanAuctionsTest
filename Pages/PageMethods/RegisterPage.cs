using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OlanAuctions.Pages.PageConstants;
using OpenQA.Selenium;

namespace OlanAuctions.Pages.PageMethods
{
    class RegisterPage : Base
    {
        public RegisterPage(IWebDriver driver) : base(driver) { }

        internal LoginPage ClickLoginHereLink()
        {
            Driver.FindElement(RegisterPageConstants.LOGIN_HERE_LINK).Click();
            Wait.UntilPageIsDisplayed();
            return new LoginPage(Driver);
        }
    }
}
