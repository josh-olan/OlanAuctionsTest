using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace OlanAuctions.Pages.PageConstants
{
    class ActiveListingsPageConstants
    {
        public static By SEARCH_FIELD = By.Id("search_item");

        /*Sort functionality fields*/
        public static By LOWEST_TO_HIGHEST_RADIO_BTN = By.Id("ascending");
        public static By HIGHEST_TO_LOWEST_RADIO_BTN = By.Id("descending");
        public static By OLDEST_FIRST_RADIO_BTN = By.Id("oldest");
        public static By MOST_RECENT_FIRST_RADIO_BTN = By.Id("newest");
        public static By SORT_BUTTON = By.XPath("//*[@value='Sort']");

        /*Locate current listings displayed */
        public static By CURRENT_ACTIVE_LISTINGS = By.XPath("//div[@class='container-fluid each_item']");
        public static By ITEM_PRICE = By.ClassName("active_price");
    }
}
