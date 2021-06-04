using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using MarsFramework.Global;
using NUnit.Framework;
using System.Collections.Generic;
using AutoItX3Lib;
using System.Threading;
using MarsFramework.Config;
using System.IO;
using AutoIt;
using System;

namespace MarsFramework.Pages
{
    internal class ShareSkill
    {
        public ShareSkill()
        {
          
            PageFactory.InitElements(Global.GlobalDefinitions.driver, this);
          
        }

        #region elements needed
        //Click on ShareSkill Button
        [FindsBy(How = How.LinkText, Using = "Share Skill")]
        private IWebElement ShareSkillButton { get; set; }

        //Enter the Title in textbox
        [FindsBy(How = How.Name, Using = "title")]
        private IWebElement Title { get; set; }

        //Enter the Description in textbox
        [FindsBy(How = How.Name, Using = "description")]
        private IWebElement Description { get; set; }

        //Click on Category Dropdown
        [FindsBy(How = How.Name, Using = "categoryId")]
        private IWebElement CategoryDropDown { get; set; }

        //Click on SubCategory Dropdown
        [FindsBy(How = How.Name, Using = "subcategoryId")]
        private IWebElement SubCategoryDropDown { get; set; }

        //Enter Tag names in textbox
        [FindsBy(How = How.XPath, Using = "//body/div[1]/div[1]/div[1]/div[2]/div[1]/form[1]/div[4]/div[2]/div[1]/div[1]/div[1]/div[1]/input[1]")]
        private IWebElement Tags { get; set; }

        //Select the Service type
        [FindsBy(How = How.XPath, Using = ".//*[@name='serviceType']")]
        private IList<IWebElement> ServiceTypeOption { get; set; }

        //Select the Location Type
        [FindsBy(How = How.XPath, Using = ".//*[@name='locationType']")]
        private IList<IWebElement> LocationTypeOption { get; set; }

        //Click on Start Date dropdown
        [FindsBy(How = How.Name, Using = "startDate")]
        private IWebElement StartDateDropDown { get; set; }

        //Click on End Date dropdown
        [FindsBy(How = How.Name, Using = "endDate")]
        private IWebElement EndDateDropDown { get; set; }

        //Storing the table of available days
        [FindsBy(How = How.XPath, Using = "//body/div/div/div[@id='service-listing-section']/div[@class='ui container']/div[@class='listing']/form[@class='ui form']/div[7]/div[2]/div[1]")]
        private IWebElement Days { get; set; }

        //Storing the starttime
        [FindsBy(How = How.XPath, Using = ".//*[@name='Available']")]
        private IList<IWebElement> StartTime { get; set; }

        //Click on StartTime dropdown
        [FindsBy(How = How.XPath, Using = "/.//*[@name='StartTime']")]
        private IList<IWebElement> StartTimeDropDown { get; set; }
        //Click on EndTime dropdown
        [FindsBy(How = How.XPath, Using = "/.//*[@name='EndTime']")]
        private IList<IWebElement> EndTimeDropDown { get; set; }

        //Click on Skill Trade option
        [FindsBy(How = How.XPath, Using = ".//*[@name='skillTrades']")]
        private IList<IWebElement> SkillTradeOption { get; set; }

        //Enter Skill Exchange
        [FindsBy(How = How.XPath, Using = "//div[@class='form-wrapper']//input[@placeholder='Add new tag']")]
        private IWebElement SkillExchange { get; set; }

        //add work sample
        [FindsBy(How = How.XPath, Using = "//body/div[1]/div[1]/div[1]/div[2]/div[1]/form[1]/div[9]/div[1]/div[2]/section[1]/div[1]/label[1]/div[1]/span[1]/i[1]")]
        private IWebElement AddworksampleButton { get; set; }

        //work after loaded icon
        
        [FindsBy(How = How.XPath, Using = ".//*[@class='file pdf']")]
        private IWebElement Afterworksample { get; set; }
        //Click on Active/Hidden option

        [FindsBy(How = How.XPath, Using = ".//*[@name='isActive']")]
        private IList<IWebElement> ActiveOption { get; set; }

        //Click on Save button
        [FindsBy(How = How.XPath, Using = "//input[@value='Save']")]
        private IWebElement Save { get; set; }

        
        [FindsBy(How = How.XPath, Using = "//div[@class='ns-box-inner']")]
        private IWebElement Message { get; set; }

        #endregion

        #region Add a new skill
        internal void EnterShareSkill()
        {
            GlobalDefinitions.WaitForElement(GlobalDefinitions.driver, By.LinkText("Share Skill"), 10);
            ShareSkillButton.Click();
            //populateincollection
            
        }

        internal void EnterTitle()
        {
            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "ShareSkill");
            GlobalDefinitions.WaitForElement(GlobalDefinitions.driver, By.Name("title"), 10);
            Title.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Title"));
        }

        internal string validTitle()
        {
            
            return Title.GetAttribute("value");
        }

        internal void AddworkSample()
        {

            AddworksampleButton.Click();

            AutoItX3 autoIt = new AutoItX3();

            autoIt.WinWait("Open", "File Upload", 1);

            autoIt.WinActivate("Open");

            Thread.Sleep(2000);

            var SampleWorkPath = MarsResource.SampleWork;

            autoIt.Send(Path.GetFullPath(SampleWorkPath)); //using System.IO.Path

            Thread.Sleep(2000);

            autoIt.Send("{Enter}");

            Thread.Sleep(2000);
            


        }

        internal string WorkFileIsDisplayed()
        {

            return Afterworksample.Text;
        }
       
        
        internal void EnterDescription()
        {
            
            GlobalDefinitions.WaitForElement(GlobalDefinitions.driver, By.Name("description"), 10);
            Description.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Description"));
        }

        internal void SelectCategoryandSubCategory()
        {
            
            GlobalDefinitions.WaitForElement(GlobalDefinitions.driver, By.Name("categoryId"), 10);
            CategoryDropDown.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Category"));
            SubCategoryDropDown.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "SubCategory"));


        }

        internal void AddTags()
        {
            
            GlobalDefinitions.WaitForElement(GlobalDefinitions.driver, By.XPath("//body/div[1]/div[1]/div[1]/div[2]/div[1]/form[1]/div[4]/div[2]/div[1]/div[1]/div[1]/div[1]/input[1]"), 10);
            Tags.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Tags"));
            //Press enter
            Tags.SendKeys(Keys.Enter);
        }

        internal void SelectServiceType()
        {
            
          
            if (GlobalDefinitions.ExcelLib.ReadData(2, "ServiceType") ==  "Hourly basis service")
            {
                ServiceTypeOption[0].Click();
            }

            if (GlobalDefinitions.ExcelLib.ReadData(2, "ServiceType") == "One-off service")
            {
                ServiceTypeOption[1].Click();
            }
        }

        internal void SelectLocationType()
        {
            

            if (GlobalDefinitions.ExcelLib.ReadData(2, "LocationType") == "On-site")
            {
                LocationTypeOption[0].Click();
            }

            if (GlobalDefinitions.ExcelLib.ReadData(2, "LocationType") == "Online")
            {
                LocationTypeOption[1].Click();
            }
        }

        internal void AvailableDays()
        {
            
            
            StartDateDropDown.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Startdate"));
            EndDateDropDown.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Enddate"));

        }

        internal void AvailableTime()
        {
            
            string dayofweek = GlobalDefinitions.ExcelLib.ReadData(2, "Selectday");
            if (dayofweek == "Sun")
            {
                StartTime[0].Click();
                StartTimeDropDown[0].SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Starttime"));
                EndTimeDropDown[0].SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Endtime"));
            }
            if (dayofweek == "Mon")
            {
                StartTime[1].Click();
                StartTimeDropDown[1].SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Starttime"));
                EndTimeDropDown[1].SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Endtime"));
            }
            if (dayofweek == "Tue")
            {
                StartTime[2].Click();
                StartTimeDropDown[2].SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Starttime"));
                EndTimeDropDown[2].SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Endtime"));
            }
            if (dayofweek == "Wed")
            {
                StartTime[3].Click();
                StartTimeDropDown[3].SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Starttime"));
                EndTimeDropDown[3].SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Endtime"));
            }
            if (dayofweek == "Thu")
            {
                StartTime[4].Click();
                StartTimeDropDown[4].SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Starttime"));
                EndTimeDropDown[4].SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Endtime"));
            }
            if (dayofweek == "Fri")
            {
                StartTime[5].Click();
                StartTimeDropDown[5].SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Starttime"));
                EndTimeDropDown[5].SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Endtime"));
            }
            if (dayofweek == "Sat")
            {
                StartTime[6].Click();
                StartTimeDropDown[6].SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Starttime"));
                EndTimeDropDown[6].SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Endtime"));
            }
            if (dayofweek == "Sun")
            {
                StartTime[7].Click();
                StartTimeDropDown[7].SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Starttime"));
                EndTimeDropDown[7].SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Endtime"));
            }

        }

        internal void SelectSkillTrade()
        {
           

            if (GlobalDefinitions.ExcelLib.ReadData(2, "SkillTrade") == "Skill-exchange")
            {
                LocationTypeOption[0].Click();
            }

            if (GlobalDefinitions.ExcelLib.ReadData(2, "SkillTrade") == "Credit")
            {
                LocationTypeOption[1].Click();
            }
        }

        internal void AddSkillExchange()
        {
            
            SkillExchange.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Skill-Exchange"));
            //Press enter
            SkillExchange.SendKeys(Keys.Enter);
        }

        internal void SelectActive()
        {
           

            if (GlobalDefinitions.ExcelLib.ReadData(2, "Active") == "Active")
            {
                ActiveOption[0].Click();
            }

            if (GlobalDefinitions.ExcelLib.ReadData(2, "Active") == "Hidden")
            {
                ActiveOption[1].Click();
            }
        }

        internal void SaveAllDetialed()
        {
            Save.Click(); 
        }
        #endregion
        
        internal string SaveSuccessfulleMessage()
        {
            GlobalDefinitions.WaitForElement(GlobalDefinitions.driver, By.XPath("//div[@class='ns-box-inner']"), 10);
            return Message.Text;

        }

    }
}
