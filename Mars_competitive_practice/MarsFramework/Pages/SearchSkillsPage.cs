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
    class SearchSkillsPage
    {
        public SearchSkillsPage()
        {
            PageFactory.InitElements(Global.GlobalDefinitions.driver, this);
        }

        [FindsBy(How = How.XPath, Using = ".//*[@placeholder='Search user']")]
        private IWebElement SearchByuserInput { get; set; }

        [FindsBy(How = How.XPath, Using = ".//*[@score='1']")]
        private IWebElement SearchByuserResult { get; set; }

        [FindsBy(How = How.XPath, Using = ".//*[@class='image']")]
        private IWebElement TargetResult { get; set; }

        internal void SearchSkillByUser()
        {
 
            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "SearchSkill");
            GlobalDefinitions.WaitForElement(GlobalDefinitions.driver, By.XPath(".//*[@placeholder='Search user']"), 10);
            SearchByuserInput.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "SkillUser"));
            GlobalDefinitions.WaitForElement(GlobalDefinitions.driver, By.XPath(".//*[@score='1']"), 10);
            SearchByuserInput.Click();

        }

        internal void ClickOnTargetSkill()
        {

            GlobalDefinitions.WaitForElement(GlobalDefinitions.driver, By.XPath(".//*[@class='image']"), 10);
            TargetResult.Click();
        }
    }
}
