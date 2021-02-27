using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OlanAuctions.Pages.PageConstants;
using OpenQA.Selenium;

namespace OlanAuctions.Pages.PageMethods
{
    class ActiveListingsPage : Base
    {
        public ActiveListingsPage(IWebDriver driver) : base(driver) { }
        public bool IsDisplayed => Driver.Title == "Active Listings";

        public void AssertPageIsDisplayed()
        {
            Assert.IsTrue(IsDisplayed, "Active listings page is not displayed. Expected true but is false.");
        }

        internal void AssertSortingFromLowestToHighest()
        {
            Driver.FindElement(ActiveListingsPageConstants.LOWEST_TO_HIGHEST_RADIO_BTN).Click();
            Driver.FindElement(ActiveListingsPageConstants.SORT_BUTTON).Click();
            AssertEachItemByPrice(Driver.FindElements(ActiveListingsPageConstants.CURRENT_ACTIVE_LISTINGS), Order.LowestToHighest);
        }

        internal void AssertSortingFromHighestToLowest()
        {
            Driver.FindElement(ActiveListingsPageConstants.HIGHEST_TO_LOWEST_RADIO_BTN).Click();
            Driver.FindElement(ActiveListingsPageConstants.SORT_BUTTON).Click();
            AssertEachItemByPrice(Driver.FindElements(ActiveListingsPageConstants.CURRENT_ACTIVE_LISTINGS), Order.HighestToLowest);
        }

        private void AssertEachItemByPrice(IReadOnlyCollection<IWebElement> elements, Order order)
        {
            double currentPrice = 0;
            int counter = 0;
            foreach (IWebElement element in elements)
            {
                double item_price = Convert.ToDouble(element.FindElement(ActiveListingsPageConstants.ITEM_PRICE).Text.Substring(1));
                if (counter == 0)
                    currentPrice = item_price;
                else
                {
                    UA.ScrollIntoViewIfNeeded(element);
                    switch (order)
                    {
                        case Order.LowestToHighest:
                            Assert.IsTrue(item_price >= currentPrice, $"Assertion failed. " +
                            $"Expected {item_price} to be greater than or equal to {currentPrice}.");
                            break;
                        case Order.HighestToLowest:
                            Assert.IsTrue(item_price <= currentPrice, $"Assertion failed. " +
                            $"Expected {item_price} to be lesser than or equal to {currentPrice}.");
                            break;
                        default:
                            throw new ArgumentOutOfRangeException("Expected order by price.");
                    }
                }
                counter++;
            }
        }

        private enum Order
        {
            LowestToHighest,
            HighestToLowest,
            OldestFirst,
            RecentFirst
        }
    }
}
