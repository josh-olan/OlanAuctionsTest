using OpenQA.Selenium.Support.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OlanAuctions.Helpers;
using NLog;

namespace OlanAuctions.GetDriver
{
    public class WebListener : EventFiringWebDriver
    {
        private static Logger log = LogManager.GetCurrentClassLogger();
        private EventFiringWebDriver firingDriver;
        public IWebDriver Driver => firingDriver;
        public WebListener(IWebDriver driver) : base(driver)
        {
            firingDriver = new EventFiringWebDriver(driver);
            firingDriver.ElementClicked += new EventHandler<WebElementEventArgs>(AfterElementIsClicked);
            firingDriver.ElementClicking += new EventHandler<WebElementEventArgs>(WhenElementIsBeingClicked);
            firingDriver.ElementValueChanging += new EventHandler<WebElementValueEventArgs>(WhenValueIsBeingChanged);
            firingDriver.ElementValueChanged += new EventHandler<WebElementValueEventArgs>(WhenValueIsChanged);
            firingDriver.Navigating += new EventHandler<WebDriverNavigationEventArgs>(WhenPageIsLoading);
        }

        private void WhenPageIsLoading(object sender, WebDriverNavigationEventArgs e)
        {
            new Wait(Driver).UntilPageIsDisplayed();
            log.Trace($"Navigating to page => {e.Url}");
        }

        private void WhenValueIsChanged(object sender, WebElementValueEventArgs e)
        {
            log.Debug($"Changed value of {e.Element.TagName} element to {e.Element.Text}");
            firingDriver.ExecuteScript("return arguments[0].style.border = 'initial';", e.Element);
            firingDriver.ExecuteScript("return arguments[0].scrollIntoViewIfNeeded();", e.Element);
        }

        private void WhenValueIsBeingChanged(object sender, WebElementValueEventArgs e)
        {
            firingDriver.ExecuteScript("return arguments[0].style.border = '3px solid red';", e.Element);
            log.Debug($"Changing value of {e.Element.TagName} element to {e.Element.Text}");
        }

        private void WhenElementIsBeingClicked(object sender, WebElementEventArgs e)
        {
            log.Debug($"Clicking on element => {e.Element}");
            firingDriver.ExecuteScript("return arguments[0].style.border = '3px solid red';", e.Element);
        }

        private void AfterElementIsClicked(object sender, WebElementEventArgs e) 
        {
            log.Debug($"Clicked on element => {e.Element}");
            try
            {
                firingDriver.ExecuteScript("return arguments[0].style.border = 'initial';", e.Element);
            }
            catch (StaleElementReferenceException)
            {}
        }
    }
}
