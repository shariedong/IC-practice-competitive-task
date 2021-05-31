using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using MarsFramework.Global;


namespace MarsFramework.Pages
{
    class SignIn
    {
        public SignIn()
        {
            PageFactory.InitElements(Global.GlobalDefinitions.driver, this);
        }

        #region  Initialize Web Elements 
        //Finding the Sign Link
        [FindsBy(How = How.XPath, Using = "//a[contains(text(),'Sign In')]")]
        private IWebElement SignIntab { get; set; }

        // Finding the Email Field
        [FindsBy(How = How.Name, Using = "email")]
        private IWebElement Email { get; set; }

        //Finding the Password Field
        [FindsBy(How = How.Name, Using = "password")]
        private IWebElement Password { get; set; }

        //Finding the Login Button
        [FindsBy(How = How.XPath, Using = "//button[contains(text(),'Login')]")]
        private IWebElement LoginBtn { get; set; }

        #endregion done

        internal void LoginSteps()
        {
            //populateincollection
            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "SignIn");


            GlobalDefinitions.driver.Navigate().GoToUrl(GlobalDefinitions.ExcelLib.ReadData(2,"Url"));
            GlobalDefinitions.WaitForElement(GlobalDefinitions.driver, By.XPath("//a[contains(text(),'Sign In')]"), 10);
            SignIntab.Click();
            GlobalDefinitions.WaitForElement(GlobalDefinitions.driver, By.Name("email"), 10);
            Email.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Username"));
            Password.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Password"));
            LoginBtn.Click();

        }
    }
}