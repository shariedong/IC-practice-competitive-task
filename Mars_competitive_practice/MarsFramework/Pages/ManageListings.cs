using MarsFramework.Global;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System.Collections.Generic;

namespace MarsFramework.Pages
{
    internal class ManageListings
    {   
        //initialise the page object 
        public ManageListings()
        {
            PageFactory.InitElements(Global.GlobalDefinitions.driver, this);
        }

        //Click on Manage Listings Link
        [FindsBy(How = How.XPath, Using = "//a[contains(text(),'Manage Listings')]")]
        private IWebElement manageListingsLink { get; set; }

        //View the listing
        [FindsBy(How = How.XPath, Using = "(//i[@class='eye icon'])[1]")]
        private IWebElement view { get; set; }

        //Delete the listing
        [FindsBy(How = How.XPath, Using = "//tbody/tr[1]/td[8]/div[1]/button[3]")]
        private IWebElement delete { get; set; }

        //Edit the listing
        [FindsBy(How = How.XPath, Using = "(//i[@class='outline write icon'])[1]")]
        private IWebElement edit { get; set; }

        //Click on Yes or No
        [FindsBy(How = How.XPath, Using = ".//*[@class='actions']/button")]
        private IList<IWebElement> clickActionsButton { get; set; }
        ////body/div[1]
        [FindsBy(How = How.XPath, Using = "//div[@class='ns-box-inner']")]
        private IWebElement MessageDelete { get; set; }

        internal void DeleteListings()
        {
            //Populate the Excel Sheet
            //GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "ManageListings");
            GlobalDefinitions.WaitForElement(GlobalDefinitions.driver, By.XPath("//a[contains(text(),'Manage Listings')]"), 10);
            manageListingsLink.Click();
            GlobalDefinitions.WaitForElement(GlobalDefinitions.driver, By.XPath("//tbody/tr[1]/td[8]/div[1]/button[3]"), 10);
            delete.Click();
            GlobalDefinitions.WaitForElement(GlobalDefinitions.driver, By.XPath(".//*[@class='actions']/button"), 10);
            clickActionsButton[1].Click();
        }

        internal string DeleteSuccessfully()
        {
            GlobalDefinitions.WaitForElement(GlobalDefinitions.driver, By.XPath("//div[@class='ns-box-inner']"), 10);
            return MessageDelete.Text;
        }
    }
}
