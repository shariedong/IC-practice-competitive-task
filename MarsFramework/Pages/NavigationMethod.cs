using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarsFramework.Global;

namespace MarsFramework.Pages
{
    internal class NavigationMethod
    {

        public NavigationMethod()
        {
            PageFactory.InitElements(Global.GlobalDefinitions.driver, this);
        }

        internal void NavigationBack()
        {
            GlobalDefinitions.driver.Navigate().Back();
            
        }

        internal string ReturnPageTtile()
        {
            return GlobalDefinitions.driver.Title;
        }
       
    }
}
