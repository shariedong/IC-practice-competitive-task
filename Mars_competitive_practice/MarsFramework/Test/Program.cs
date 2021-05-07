using NUnit.Framework;
using MarsFramework.Pages;
using MarsFramework.Global;

namespace MarsFramework
{
    public class Program
    {
        
        [TestFixture, Description("Share skills Testcases")]
        class ShareskillTestSuites : Global.Base 
        {
            [Test,Description("Check if the user is able to Enter the Title")]
            public void EnterTheTitle()
            {
                var ShareSkillobj = new ShareSkill();
                ShareSkillobj.EnterShareSkill();
                ShareSkillobj.EnterTitle();
                string titleshouldbe = "Selenium";
                Assert.AreEqual(titleshouldbe, ShareSkillobj.validTitle());
            }


            [Test, Description("Check if the user is able to upload sample work")]
            public void UploadSampleWork()
            {
                var ShareSkillobj = new ShareSkill();
                ShareSkillobj.EnterShareSkill();
                ShareSkillobj.AddworkSample();
                string fileshouldbe = "1111.txt";
                Assert.AreEqual(fileshouldbe, ShareSkillobj.WorkFileIsDisplayed());

            }
            /*[Test, Description("Check if the user is able to save")]
            public void SaveAllInfo()
            {
                var ShareSkillobj = new ShareSkill();
                ShareSkillobj.EnterShareSkill();
                ShareSkillobj.EnterTitle();
                ShareSkillobj.EnterDescription();
                ShareSkillobj.SelectCategoryandSubCategory();
                ShareSkillobj.AddTags();
                ShareSkillobj.SelectServiceType();
                ShareSkillobj.SelectLocationType();
                ShareSkillobj.AvailableDays();
                ShareSkillobj.AvailableTime();
                ShareSkillobj.SelectSkillTrade();
                ShareSkillobj.AddSkillExchange();
                ShareSkillobj.SelectActive();
                ShareSkillobj.AddworkSample();
                ShareSkillobj.SaveAllDetialed();
                
            }*/
        }

        [TestFixture, Description("ManageListing Testcases")]
        class ManageListingTestSuits:Global.Base
        {

            [Test, Description("Check if the user is able to click on Delete service in any listing")]
            public void DeleteService()
            {
                var ManageListingsobj = new ManageListings();
                ManageListingsobj.DeleteListings();
                string expecteDeleteMessage = "Selenium has been deleted";
                Assert.AreEqual(expecteDeleteMessage, ManageListingsobj.DeleteSuccessfully());
            }
        }
        
    }
}