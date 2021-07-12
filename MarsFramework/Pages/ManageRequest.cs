using MarsFramework.Global;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MarsFramework.Pages
{
    class ManageRequest
    {
        public ManageRequest()
        {
            
            PageFactory.InitElements(Global.GlobalDefinitions.driver, this);
        }

        [FindsBy(How = How.XPath, Using = "//body/div[@id='account-profile-section']/div[1]/section[1]/div[1]/div[1]")]
        private IWebElement ManageRequestHangover { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[contains(text(),'Received Requests')]")]
        private IWebElement ManageReceivedBtn { get; set; }
        [FindsBy(How = How.XPath, Using = "//a[contains(text(),'Sent Requests')]")]
        private IWebElement ManageSentBtn { get; set; }

        //find target table tr-received request
        [FindsBy(How=How.XPath, Using = "//*[@id='received-request-section']/div[2]/div[1]/table/tbody/tr")]
        private IList<IWebElement> ReceivedTableTr { get; set; }
        //find target table tr - sent request
        [FindsBy(How = How.XPath, Using = "//*[@id='sent-request-section']/div[2]/div[1]/table/tbody/tr")]
        private IList<IWebElement> SentTableTr { get; set; }

        //Actions
        [FindsBy(How = How.XPath, Using = "//button[contains(text(),'Accept')]")]
        private IList<IWebElement> ActionAcceptBtn { get; set; }

        [FindsBy(How = How.XPath, Using = "//button[contains(text(),'Decline')]")]
        private IList<IWebElement> ActionDeclineBtn { get; set; }

        [FindsBy(How = How.XPath, Using = "//button[contains(text(),'Complete')]")]
        private IList<IWebElement> ActionCompleteBtn { get; set; }

        [FindsBy(How = How.XPath, Using = "//button[contains(text(),'Review')]")]
        private IList<IWebElement> ActionReviewBtn { get; set; }
        [FindsBy(How = How.XPath, Using = "//button[contains(text(),'Withdraw')]")]
        private IList<IWebElement> ActionWithdrawBtn { get; set; }

        internal string ReadData(int i, string s)
        {
            return GlobalDefinitions.ExcelLib.ReadData(i, s);
        }

        internal void GotoReceivedOrSentRequest()
        {
            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "SearchSkill");
            GlobalDefinitions.WaitForElement(GlobalDefinitions.driver, By.XPath("//body/div[@id='account-profile-section']/div[1]/section[1]/div[1]/div[1]"), 10);
            //hangover
   

            if (ReadData(2, "SkillType") == "Received Request")
            {   
                Actions action = new Actions(GlobalDefinitions.driver);
                action.MoveToElement(ManageRequestHangover).Perform();
                GlobalDefinitions.WaitForElement(GlobalDefinitions.driver, By.XPath("//a[contains(text(),'Received Requests')]"), 10);
                ManageReceivedBtn.Click();
            }
            if (ReadData(2, "SkillType") == "Sent Request")
            {
                Actions action = new Actions(GlobalDefinitions.driver);
                action.MoveToElement(ManageRequestHangover).Perform();
                GlobalDefinitions.WaitForElement(GlobalDefinitions.driver, By.XPath("//a[contains(text(),'Sent Requests')]"), 10);
                ManageSentBtn.Click();
            }
        }




        internal void ActionForReceivedRequest()
        {
            //when I am on received request page
            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "ReceivedRequest");

            String StatusReceived = ReadData(2, "Status") ;
            String ActionWhenPending = ReadData(2, "Actions");

            if (StatusReceived == "Pending")
            {
                if (ActionWhenPending== "Accecpt")
                {
                    ActionAcceptBtn[0].Click();
                }

                if (ActionWhenPending == "Decline")
                {
                    ActionDeclineBtn[0].Click();
                }
            }
            if (StatusReceived == "Accepted")
            {
                ActionCompleteBtn[0].Click();
            }
        }

        internal void ActionForSentRequest()
        {
            //when I am on sent request page
            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "SentRequest");

            String StatusReceived = GlobalDefinitions.ExcelLib.ReadData(2, "Status");
            String ActionWhenPending = GlobalDefinitions.ExcelLib.ReadData(2, "Actions");

            if (StatusReceived == "Completed")
            {
                ActionReviewBtn[0].Click();
            }
            if (StatusReceived == "Pending")
            {
                ActionWithdrawBtn[0].Click();
            }
        }
        //Go to service Details Page
        internal void PerformActionOnReceivedRequestPage()
        {
            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "SearchSkill");
            for (int i=0; i< 5;  i++ )
            {
                string title = ReceivedTableTr[i].FindElements(By.TagName("Td"))[1].Text;
                string user = ReceivedTableTr[i].FindElements(By.TagName("Td"))[3].Text;
                if ( title.Contains(ReadData(2, "SkillType")) && user.Contains(ReadData(2, "SkillUser")) )
                {
                    ReceivedTableTr[i].FindElements(By.TagName("Td"))[1].Click();
                }
            }
        }
        internal void GotoTagetSkillPage()
        {//////////// STUCK IN THIS !!!!!!!!!!!!!!!!!!!!!!1
            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "SearchSkill");
            for (int i = 1; i < 4; i++)
            {
                string title = ReceivedTableTr[i].FindElements(By.TagName("Td"))[1].Text;
                string user = ReceivedTableTr[i].FindElements(By.TagName("Td"))[2].Text;
                if (title.Contains(ReadData(2, "SkillType")) && user.Contains(ReadData(2, "SkillUser")))
                {
                    ReceivedTableTr[i].FindElements(By.TagName("Td"))[1].Click();
                }
            }
        }



    }
}
