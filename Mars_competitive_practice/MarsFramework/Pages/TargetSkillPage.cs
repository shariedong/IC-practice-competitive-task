using MarsFramework.Global;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsFramework.Pages
{
    class TargetSkillPage
    {
        public TargetSkillPage()
        {
            PageFactory.InitElements(Global.GlobalDefinitions.driver, this);
        }

        [FindsBy(How = How.XPath, Using = "//span[contains(text(),'Power BI')]")]
        private IWebElement SkillTileDetails { get; set; }

        [FindsBy(How = How.XPath, Using = ".//*[@placeholder='I am interested in trading my cooking skills with your coding skills..']")]
        private IWebElement MessageInput { get; set; }

        [FindsBy(How = How.XPath, Using = ".//*[@class='send outline icon']")]
        private IWebElement MessageRequestBtn { get; set; }

        [FindsBy(How = How.XPath, Using = "//button[contains(text(),'Yes')]")]
        private IWebElement PopupMessageYesBtn{ get; set; }

        //[FindsBy(How = How.XPath, Using = "")]
        //private IWebElement MessageNotification { get; set; }

        internal String TargetSkillPageDisplayed()
        {
            GlobalDefinitions.WaitForElement(GlobalDefinitions.driver, By.XPath("//span[contains(text(),'Power BI')]"), 10);
            return SkillTileDetails.Text;
        }

        internal void WriteMessageAndSend()
        {
            MessageInput.SendKeys("Test Message");
            MessageRequestBtn.Click();
        }

        internal bool EnableNotificationDisplayed()
        {
            GlobalDefinitions.WaitForElement(GlobalDefinitions.driver, By.XPath("//button[contains(text(),'Yes')]"), 10);
    
            PopupMessageYesBtn.Click();
            //GlobalDefinitions.WaitForElement(GlobalDefinitions.driver, By.XPath("//span[contains(text(),'Power BI')]"), 10);
            //notification display
            //please write this function based on your username
            return true;

        }

    }
}
