using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using OlanAuctions.Pages;
using OpenQA.Selenium;

namespace OlanAuctions.Helpers
{
    public class UA : Base
    {
        public UA(IWebDriver driver) : base(driver) { }

        public void ScrollIntoViewIfNeeded(IWebElement element)
        {
            Wait.UntilElementIsDisplayed(element);
            GetJavaScriptExecutor.ExecuteScript("return arguments[0].scrollIntoViewIfNeeded();", element);
        }
    }
}
