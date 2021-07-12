using MarsFramework.Global;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Threading;

namespace MarsFramework.Pages
{
    internal class ManageListings
    {   
        //initialise the page object 
        public ManageListings()
        {
           
            PageFactory.InitElements(GlobalDefinitions.driver, this);
        }

        //Click on Manage Listings Link
        [FindsBy(How = How.XPath, Using = "//a[contains(text(),'Manage Listings')]")]
        private IWebElement manageListingsLink { get; set; }

        //View the listing
        [FindsBy(How = How.XPath, Using = "(//i[@class='eye icon'])[1]")]
        private IWebElement view { get; set; }

        //Delete the listing
        [FindsBy(How = How.XPath, Using = "(//i[@class='remove icon'])[1]")]
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

        [FindsBy(How = How.XPath, Using = "//h2[contains(text(),'Manage Listings')]")]
        private IWebElement ManageListPageTitle { get; set; }

        [FindsBy(How = How.XPath, Using = "//button[contains(text(),'<')]")]
        private IWebElement ButtonBackIcon { get; set; }

        [FindsBy(How = How.XPath, Using = "//button[contains(text(),'>')]")]
        private IWebElement ButtonNextIcon { get; set; }

        [FindsBy(How = How.XPath, Using = ".//*[@class='ui active button currentPage']")]
        private IWebElement LastPageNumber { get; set; }

        [FindsBy(How = How.XPath, Using = "//tbody//tr")]
        private IList<IWebElement> Listingtr { get; set; }



        internal void LinkClick()
        {
            //Populate the Excel Sheet
            //GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "ManageListings");
            GlobalDefinitions.WaitForElement(GlobalDefinitions.driver, By.XPath("//a[contains(text(),'Manage Listings')]"), 10);
            manageListingsLink.Click();

        }
        internal string DeleteSuccessfully()
        {
            GlobalDefinitions.WaitForElement(GlobalDefinitions.driver, By.XPath("//div[@class='ns-box-inner']"), 10);
            return MessageDelete.Text;
        }

        internal string JumpToManageListingSuccessfully()
        {
            GlobalDefinitions.WaitForElement(GlobalDefinitions.driver, By.XPath("//h2[contains(text(),'Manage Listings')]"), 10);
            return ManageListPageTitle.Text;
        }



        internal void ClickOnNextButtonUntilLastPage()
        {
            GlobalDefinitions.WaitForElement(GlobalDefinitions.driver, By.XPath("//button[contains(text(),'>')]"), 10);
            while (ButtonNextIcon.Enabled == true)
            {
                GlobalDefinitions.WaitForElement(GlobalDefinitions.driver, By.XPath("//button[contains(text(),'>')]"), 10);
                ButtonNextIcon.Click();
                Thread.Sleep(1000);
            }
        }

        internal int CountListingSkillNumber()
        {
            GlobalDefinitions.WaitForElement(GlobalDefinitions.driver, By.XPath("//tbody//tr"), 10);
            return Listingtr.Count;
        }


        internal int CountAllListingSkills()
        {
            LinkClick();
            int fisrtPageListingNumber = CountListingSkillNumber();

            ClickOnNextButtonUntilLastPage();
            Thread.Sleep(10);
            int lastPageListingNumber = CountListingSkillNumber();
            int pageNumber = int.Parse(LastPageNumber.Text);

            return fisrtPageListingNumber * (pageNumber-1) + lastPageListingNumber;
        }

        internal void ViewListings()
        {
            LinkClick();
            GlobalDefinitions.WaitForElement(GlobalDefinitions.driver, By.XPath("(//i[@class='eye icon'])[1]"), 10);
            view.Click();

        }


        internal void EditListings()
        {
            LinkClick();
            GlobalDefinitions.WaitForElement(GlobalDefinitions.driver, By.XPath("(//i[@class='outline write icon'])[1]"), 10);
            edit.Click();
        }

        internal void CancelDeleteListings()
        {
            LinkClick();
            GlobalDefinitions.WaitForElement(GlobalDefinitions.driver, By.XPath("//tbody/tr[1]/td[8]/div[1]/button[3]"), 10);
            delete.Click();
            GlobalDefinitions.WaitForElement(GlobalDefinitions.driver, By.XPath(".//*[@class='actions']/button"), 10);
            clickActionsButton[0].Click();
        }


        internal void DeleteListings()
        {
            //Populate the Excel Sheet
            //GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "ManageListings");
            LinkClick();
            GlobalDefinitions.WaitForElement(GlobalDefinitions.driver, By.XPath("//tbody/tr[1]/td[8]/div[1]/button[3]"), 10);
            delete.Click();
            GlobalDefinitions.WaitForElement(GlobalDefinitions.driver, By.XPath(".//*[@class='actions']/button"), 10);
            clickActionsButton[0].Click();
        }

    }
}
