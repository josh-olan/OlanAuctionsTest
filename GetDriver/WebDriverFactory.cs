using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace OlanAuctions.GetDriver
{
    class WebDriverFactory
    {
        private string FilePath => Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

        public IWebDriver Create(BrowserType browserType)
        {
            switch (browserType)
            {
                case BrowserType.Chrome:
                    return GetChromeDriver();
                case BrowserType.Edge:
                    return GetEdgeDriver();
                default:
                    throw new ArgumentOutOfRangeException("No such driver exists.");
            }
        }

        private IWebDriver GetChromeDriver()
        {
            return new ChromeDriver(FilePath);
        }

        private IWebDriver GetEdgeDriver()
        {
            return new EdgeDriver(FilePath);
        }
    }
}
