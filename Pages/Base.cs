using Microsoft.Office.Interop.Excel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.CSharp;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OlanAuctions.Helpers;
using OlanAuctions.GetDriver;

namespace OlanAuctions.Pages
{
    public class Base
    {
        protected IWebDriver Driver { get; set; }
        protected Wait Wait => new Wait(Driver);
        protected UA UA => new UA(Driver);
        protected IJavaScriptExecutor GetJavaScriptExecutor => (IJavaScriptExecutor)Driver;
        public Base(IWebDriver driver)
        {
            Driver = driver;
        }
    }
}
