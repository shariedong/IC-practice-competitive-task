using MarsFramework.Global;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MarsFramework.Pages
{
    class SearchSkillsPage
    {
        public SearchSkillsPage()
        {
            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "SearchSkill");
            PageFactory.InitElements(Global.GlobalDefinitions.driver, this);
        }

        [FindsBy(How = How.XPath, Using = ".//*[@placeholder='Search user']")]
        private IWebElement SearchByuserInput { get; set; }

        [FindsBy(How = How.XPath, Using = ".//*[@class='result']")]
        private IList<IWebElement> SearchByuserResult { get; set; }

        [FindsBy(How = How.XPath, Using = ".//*[@class='image']")]
        private IWebElement TargetResult { get; set; }


        //locate all category button
        [FindsBy(How = How.XPath, Using = ".//*[@class='ui link list']/a[1]/span[1]")]
        private IWebElement NumberOfAllcategory { get; set; }
        [FindsBy(How = How.XPath, Using = "//b[contains(text(),'All Categories')]")]
        private IWebElement AllcategoryButton { get; set; }
        //locate subcategory
        [FindsBy(How = How.XPath, Using = "//a[contains(text(),'Graphics & Design')]/span[1]")]
        private IWebElement NumberGDcategory { get; set; }
        [FindsBy(How = How.XPath, Using = "//a[contains(text(),'Graphics & Design')]")]
        private IWebElement GDcategoryButton { get; set; }


        //locate filter button
        [FindsBy(How = How.XPath, Using = "//button[contains(text(),'Online')]")]
        private IWebElement FilterOnline { get; set; }
        [FindsBy(How = How.XPath, Using = "//button[contains(text(),'Onsite')]]")]
        private IWebElement FilterOnsite { get; set; }
        [FindsBy(How = How.XPath, Using = "//button[contains(text(),'ShowAll')]")]
        private IWebElement FilterShowAll { get; set; }


        //Define search result 
        [FindsBy(How = How.XPath, Using = "//button[contains(text(),'18')]")]
        private IWebElement Results18PerPage { get; set; }

        [FindsBy(How = How.XPath, Using = "//button[contains(text(),'12')]")]
        private IWebElement Results12PerPage { get; set; }

        [FindsBy(How = How.XPath, Using = "//button[contains(text(),'9')]")]
        private IWebElement Results9PerPage { get; set; }

        //all button list for PageNavigation
        [FindsBy(How = How.XPath, Using = ".//*[@class='ui button otherPage']")]
        private IList<IWebElement> PageButton { get; set; }

        //all cards shown on page
        [FindsBy(How = How.XPath, Using = ".//*[@class='ui card']")]
        private IList<IWebElement> PageCards { get; set; }


        internal string ReadData(int i,string s)
        {
            return GlobalDefinitions.ExcelLib.ReadData(i, s);
        }

        internal void SearchSkillByUser()
        {
            GlobalDefinitions.WaitForElement(GlobalDefinitions.driver, By.XPath(".//*[@placeholder='Search user']"), 10);
            SearchByuserInput.SendKeys(ReadData(2, "SkillUser"));
            GlobalDefinitions.WaitForElement(GlobalDefinitions.driver, By.XPath(".//*[@class='result']"), 10);
            SearchByuserResult[0].Click();
        }
        internal void ClickOnTargetSkill()
        {
            GlobalDefinitions.WaitForElement(GlobalDefinitions.driver, By.XPath(".//*[@class='image']"), 10);
            TargetResult.Click();
        }

        internal int ReturnAllCatogoryNumberByFilter()
        {
            if(ReadData(2, "Filter") == "Online")
            {
                FilterOnline.Click();
                GlobalDefinitions.WaitForElement(GlobalDefinitions.driver, By.XPath("//b[contains(text(),'All Categories')]"), 10);
                return ReturnAllCatogoryNumber();
            }
            if (ReadData(2, "Filter") == "Onsite")
            {
                FilterOnsite.Click();
                GlobalDefinitions.WaitForElement(GlobalDefinitions.driver, By.XPath("//b[contains(text(),'All Categories')]"), 10);
                return ReturnAllCatogoryNumber();
            }
            if (ReadData(2, "Filter") == "ShowAll")
            {
                FilterShowAll.Click();
                GlobalDefinitions.WaitForElement(GlobalDefinitions.driver, By.XPath("//b[contains(text(),'All Categories')]"), 10);
                return ReturnAllCatogoryNumber();
            }
            return 0;
        }

        internal int ReturnAllCatogoryNumber()
        {
            Thread.Sleep(2000);
            string NumberListed = NumberOfAllcategory.Text;
            
            return int.Parse(NumberListed);
        }

        internal int ReturnSubCatogoryNumber()
        {
            if (ReadData(2, "SearchBySubCategories") == "Graphics & Design")
            {
                Thread.Sleep(2000);
                return int.Parse(NumberGDcategory.Text);
            }

            return 0;
        }

        internal int CountActualGDNumber()
        {

            GDcategoryButton.Click();
            DefineResultsPerPage();
            return GetTotalCardsNumber();
        }



        internal int CountActualAllCatogoryNumber()
        {
            AllcategoryButton.Click();
            DefineResultsPerPage();
            return GetTotalCardsNumber();
        }




        internal int LastPageListingsNumber()
        {
            int totalPageButton = PageButton.Count;
            if (totalPageButton == 7)
            {
                Thread.Sleep(1000);//need change
                GlobalDefinitions.WaitForElement(GlobalDefinitions.driver, By.XPath(".//*[@class='ui button otherPage']"), 10);
                PageButton[5].Click();
                Thread.Sleep(1000);//needchange
                return PageListingsNumber();
            }

            Thread.Sleep(1000);
            GlobalDefinitions.WaitForElement(GlobalDefinitions.driver, By.XPath(".//*[@class='ui button otherPage']"), 10);
            PageButton[totalPageButton-2].Click();
            Thread.Sleep(1000);
            return PageListingsNumber();
        }


        internal int PageListingsNumber()
        {
            GlobalDefinitions.WaitForElement(GlobalDefinitions.driver, By.XPath(".//*[@class='ui card']"), 10);
            return PageCards.Count;

        }

        internal int PageTotalNumber()
        {
            GlobalDefinitions.WaitForElement(GlobalDefinitions.driver, By.XPath(".//*[@class='ui button otherPage']"), 10);
            string LastPageNumber = PageButton[5].Text;
            int lastPageNumberInt = int.Parse(LastPageNumber);
            return lastPageNumberInt;

        }

        internal void DefineResultsPerPage()
        {
            if (ReadData(2, "ResultPerPage") == "18")
            {
                GlobalDefinitions.WaitForElement(GlobalDefinitions.driver, By.XPath("//button[contains(text(),'18')]"), 10);
                Results18PerPage.Click();
            }
            if (ReadData(2, "ResultPerPage") == "12")
            {
                GlobalDefinitions.WaitForElement(GlobalDefinitions.driver, By.XPath("//button[contains(text(),'12')]]"), 10);
                Results12PerPage.Click();
            }

            if (ReadData(2, "ResultPerPage") == "9")
            {

                GlobalDefinitions.WaitForElement(GlobalDefinitions.driver, By.XPath("//button[contains(text(),'8')]]"), 10);

                Results9PerPage.Click();
            }

        }
        
        internal int GetTotalCardsNumber()
        {
            if (ReadData(2, "ResultPerPage") == "18")
            {
                int Total = (PageTotalNumber() - 1) * 18 + LastPageListingsNumber();
                return Total;
            }
            if (ReadData(2, "ResultPerPage") == "12")
            {
                int Total = (PageTotalNumber() - 1) * 12 + LastPageListingsNumber();
                return Total;
            }

            if (ReadData(2, "ResultPerPage") == "9")
            {
                int Total = (PageTotalNumber() - 1) * 9 + LastPageListingsNumber();
                return Total;
            }
            return 0;
        }

    }
}
