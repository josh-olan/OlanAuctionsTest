using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OlanAuctions.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace OlanAuctions.Helpers
{
    public class Wait : Base
    {
        public Wait(IWebDriver driver) : base(driver) { }
        public void UntilPageIsDisplayed()
        {
            new WebDriverWait(Driver, TimeLength.TwentySecondsWait).Until((d) =>
            {
                return GetJavaScriptExecutor.ExecuteScript("return document.readyState == 'complete';");
            });
        }

        public void UntilElementIsPresent(By locatorString)
        {
            new WebDriverWait(Driver, TimeLength.TenSecondsWait).Until((d) =>
            {
                return d.FindElement(locatorString);
            });
        }

        public void UntilElementIsDisplayed(IWebElement element)
        {
            new WebDriverWait(Driver, TimeLength.TenSecondsWait).Until((d) =>
            {
                return GetJavaScriptExecutor.ExecuteScript("return window.getComputedStyle(arguments[0]).display != false;", element);
            });
        }
    }
}
