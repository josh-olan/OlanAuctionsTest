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
            GetWait(Driver, TimeLength.TwentySecondsWait).Until((d) =>
            {
                return GetJavaScriptExecutor(Driver).ExecuteScript("return document.readyState == 'complete';");
            });
        }

        public void UntilElementIsPresent(By locatorString)
        {
            GetWait(Driver, TimeLength.TenSecondsWait).Until((d) =>
            {
                return d.FindElement(locatorString);
            });
        }

        /* Returns an instance of the WebDriverWait class
         * @params: IWebDriver object, Timespan object
         * @return: new WebDriverWait object
         */
        private WebDriverWait GetWait(IWebDriver driver, TimeSpan time) => new WebDriverWait(driver, time);

        /*Returns the IJavaScript Executor interface
         * @params: IWebDriver object
         * @returns: IJavaScriptExecutor interface
         */
        private IJavaScriptExecutor GetJavaScriptExecutor(IWebDriver driver) => (IJavaScriptExecutor)driver; 
    }
}
