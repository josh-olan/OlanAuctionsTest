using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace OlanAuctions.Pages.PageMethods
{
    class ActiveListingsPage : Base
    {
        public ActiveListingsPage(IWebDriver driver) : base(driver) { }

        public bool IsDisplayed => Driver.Title == "Active Listings";
    }
}
