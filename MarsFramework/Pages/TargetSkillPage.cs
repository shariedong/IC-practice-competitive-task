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

        [FindsBy(How = How.XPath, Using = ".//*[@class='skill-title']")]
        private IWebElement SkillTileDetails { get; set; }

        [FindsBy(How = How.XPath, Using = ".//*[@placeholder='I am interested in trading my cooking skills with your coding skills..']")]
        private IWebElement MessageInput { get; set; }

        [FindsBy(How = How.XPath, Using = ".//*[@class='send outline icon']")]
        private IWebElement MessageRequestBtn { get; set; }

        [FindsBy(How = How.XPath, Using = "//button[contains(text(),'Yes')]")]
        private IWebElement PopupMessageYesBtn{ get; set; }

        [FindsBy(How = How.XPath, Using = ".//*[@class='ns-box-inner']")]
        private IWebElement MessageNotification { get; set; }

        internal String TargetSkillPageDisplayed()
        {
            GlobalDefinitions.WaitForElement(GlobalDefinitions.driver, By.XPath(".//*[@class='skill-title']"), 10);
            return SkillTileDetails.Text;
        }

        internal void WriteMessageAndSend()
        {
            GlobalDefinitions.WaitForElement(GlobalDefinitions.driver, By.XPath(".//*[@placeholder='I am interested in trading my cooking skills with your coding skills..']"), 10);
            MessageInput.SendKeys("I want to share my skills with you");
            GlobalDefinitions.WaitForElement(GlobalDefinitions.driver, By.XPath(".//*[@class='send outline icon']"), 10);
            MessageRequestBtn.Click();
        }

        internal void EnableNotificationDisplayed()
        {
            GlobalDefinitions.WaitForElement(GlobalDefinitions.driver, By.XPath("//button[contains(text(),'Yes')]"), 10);
    
            PopupMessageYesBtn.Click();
        }
        internal string NotificationDisplayed()
        {
            GlobalDefinitions.WaitForElement(GlobalDefinitions.driver, By.XPath(".//*[@class='ns-box-inner']"), 10);

            return MessageNotification.Text;
        }

    }
}
