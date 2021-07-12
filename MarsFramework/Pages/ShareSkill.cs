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
            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "ShareSkill");
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


        [FindsBy(How = How.XPath, Using = "//h2[contains(text(),'Manage Listings')]")]
        private IWebElement JumpNewPageTitle { get; set; }

        #endregion

        #region read and store data from excel 
        //reading data from file

        /*private string titleIn = GlobalDefinitions.ExcelLib.ReadData(1, "Title");
        private string description = GlobalDefinitions.ExcelLib.ReadData(2, "Description");
        private string category = GlobalDefinitions.ExcelLib.ReadData(2, "Category");
        private string subcategory = GlobalDefinitions.ExcelLib.ReadData(2, "SubCategory");
        private string tag = GlobalDefinitions.ExcelLib.ReadData(2, "Tags");
        private string serviceType = GlobalDefinitions.ExcelLib.ReadData(2, "ServiceType");
        private string locationType = GlobalDefinitions.ExcelLib.ReadData(2, "LocationType");
        private string startDate = GlobalDefinitions.ExcelLib.ReadData(2, "Startdate");
        private string endDate = GlobalDefinitions.ExcelLib.ReadData(2, "Enddate");
        private string dayofweek = GlobalDefinitions.ExcelLib.ReadData(2, "Selectday");
        private string startTime = GlobalDefinitions.ExcelLib.ReadData(2, "Starttime");
        private string endTime = GlobalDefinitions.ExcelLib.ReadData(2, "Endtime");
        private string skillTrade = GlobalDefinitions.ExcelLib.ReadData(2, "SkillTrade");
        private string skillExchange = GlobalDefinitions.ExcelLib.ReadData(2, "Skill-Exchange");
        private string acive = GlobalDefinitions.ExcelLib.ReadData(2, "Active");*/
        #endregion
        internal string ReadData(string s)
        {
            return GlobalDefinitions.ExcelLib.ReadData(2, s);
        }
        

        //sharing a new skill -whole process
        internal void ShareNewSkillWholeSteps()
        {
            EnterShareSkill();
            EnterTitle(ReadData("Title"));
            EnterDescription();
            SelectCategoryandSubCategory();
            AddTags();
            SelectServiceType();
            SelectLocationType();
            AvailableDays();
            AvailableTime();
            SelectSkillTrade();
            AddSkillExchange();
            AddworkSample();
            SelectActive();
            SaveAllDetialed();
        }

        internal void EnterANewTitle()
        {
            
            EnterTitle(ReadData("AfterEditTtile"));
            SaveAllDetialed();
       
        }

        #region Populate new skill form
        //click on share skill and jump on share skill page
        internal void EnterShareSkill()
        {
            GlobalDefinitions.WaitForElement(GlobalDefinitions.driver, By.LinkText("Share Skill"), 10);
            ShareSkillButton.Click();
            //populateincollection

        }
        //enter Titile
        internal void EnterTitle(string s)
        {
            Title.Clear();
            Title.SendKeys(s);
        }
        //enter Description
        internal void EnterDescription()
        {

            GlobalDefinitions.WaitForElement(GlobalDefinitions.driver, By.Name("description"), 10);
            Description.SendKeys(ReadData("Description"));
            

        }
        //enter category
        internal void SelectCategoryandSubCategory()
        {

            GlobalDefinitions.WaitForElement(GlobalDefinitions.driver, By.Name("categoryId"), 10);
            CategoryDropDown.SendKeys(ReadData("Category"));
            SubCategoryDropDown.SendKeys(ReadData("SubCategory"));
        }
        //add tags
        internal void AddTags()
        {

                GlobalDefinitions.WaitForElement(GlobalDefinitions.driver, By.XPath("//body/div[1]/div[1]/div[1]/div[2]/div[1]/form[1]/div[4]/div[2]/div[1]/div[1]/div[1]/div[1]/input[1]"), 10);
                Tags.SendKeys(ReadData("Tags"));
                //Press enter
                Tags.SendKeys(Keys.Enter);


        }
        //select service type
        internal void SelectServiceType()
        {

            if (ReadData("ServiceType") == "Hourly basis service")
            {
                ServiceTypeOption[0].Click();
            }

            if (ReadData("ServiceType") == "One-off service")
            {
                ServiceTypeOption[1].Click();

            }
        }
        //select select location type
        internal void SelectLocationType()
        {


            if (ReadData("LocationType") == "On-site")
            {
                LocationTypeOption[0].Click();
            }

            if (ReadData("LocationType") == "Online")
            {
                LocationTypeOption[1].Click();
            }
        }
        //select available day
        internal void AvailableDays()
        {

           
                StartDateDropDown.SendKeys(ReadData("Startdate"));
                EndDateDropDown.SendKeys(ReadData("Enddate"));
            


        }
        //select available time
        internal void AvailableTime()
        {
           
                if (ReadData("Selectday") == "Sun")
                {
                    StartTime[0].Click();
                    StartTimeDropDown[0].SendKeys(ReadData("Starttime"));
                    EndTimeDropDown[0].SendKeys(ReadData("Endtime"));
                }
                if (ReadData("Selectday") == "Mon")
                {
                    StartTime[1].Click();
                    StartTimeDropDown[1].SendKeys(ReadData("Starttime"));
                    EndTimeDropDown[1].SendKeys(ReadData("Endtime"));
                }
                if (ReadData("Selectday") == "Tue")
                {
                    StartTime[2].Click();
                    StartTimeDropDown[2].SendKeys(ReadData("Starttime"));
                    EndTimeDropDown[2].SendKeys(ReadData("Endtime"));
                }
                if (ReadData("Selectday") == "Wed")
                {
                    StartTime[3].Click();
                    StartTimeDropDown[3].SendKeys(ReadData("Starttime"));
                    EndTimeDropDown[3].SendKeys(ReadData("Endtime"));
                }
                if (ReadData("Selectday") == "Thu")
                {
                    StartTime[4].Click();
                    StartTimeDropDown[4].SendKeys(ReadData("Starttime"));
                    EndTimeDropDown[4].SendKeys(ReadData("Endtime"));
                }
                if (ReadData("Selectday") == "Fri")
                {
                    StartTime[5].Click();
                    StartTimeDropDown[5].SendKeys(ReadData("Starttime"));
                    EndTimeDropDown[5].SendKeys(ReadData("Endtime"));
                }
                if (ReadData("Selectday") == "Sat")
                {
                    StartTime[6].Click();
                    StartTimeDropDown[6].SendKeys(ReadData("Starttime"));
                    EndTimeDropDown[6].SendKeys(ReadData("Endtime"));
                }
                if (ReadData("Selectday") == "Sun")
                {
                    StartTime[7].Click();
                    StartTimeDropDown[7].SendKeys(ReadData("Starttime"));
                    EndTimeDropDown[7].SendKeys(ReadData("Endtime"));
                }
            

           

        }
        //select skill trade
        internal void SelectSkillTrade()
        {

      
                if (ReadData("SkillTrade") == "Skill-exchange")
                {
                    LocationTypeOption[0].Click();
                }

                if (ReadData("SkillTrade") == "Credit")
                {
                    LocationTypeOption[1].Click();
                }
       

        }
        //add skill change
        internal void AddSkillExchange()
        {
  
                SkillExchange.SendKeys(ReadData("Skill-Exchange"));
                //Press enter
                SkillExchange.SendKeys(Keys.Enter);


        }
        //add new file
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
        //enable active
        internal void SelectActive()
        {


                if (ReadData("Active") == "Active")
                {
                    ActiveOption[0].Click();
                }

                if (ReadData("Active") == "Hidden")
                {
                    ActiveOption[1].Click();
                }
           

        }
        //click on save button and share skill
        internal void SaveAllDetialed()
        {
            Save.Click();
           
        }
        #endregion
        #region Validation method for all test cases
        //valid if Title is able to display
        internal string ValidTitle()
        {

            return Title.GetAttribute("value");
        }
        //valid if work file is able to display
        internal string WorkFileIsDisplayed()
        {

            return Afterworksample.Text;
        }
        internal string AddskillSuccessfully()
        {
            GlobalDefinitions.WaitForElement(GlobalDefinitions.driver, By.XPath("//h2[contains(text(),'Manage Listings')]"), 10);
            return JumpNewPageTitle.Text;
        }
        #endregion

    }
}
