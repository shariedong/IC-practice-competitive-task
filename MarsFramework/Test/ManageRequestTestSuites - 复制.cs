using NUnit.Framework;
using MarsFramework.Pages;
using MarsFramework.Global;

namespace MarsFramework.Test
{
    public class ManageRequestTestSuites
    {
        
        [TestFixture, Description("Manage Request Testcases")]
        class ManageRequestsTestSuites : Global.Base 
        {
 
            [Test, Description("Check if user is able to click on Sent request and navigate to Sent reuest Page")]
            public void GoToManageRequestLink()
            {
                
                var ManageRequestobj = new ManageRequest();
                var navigateobj = new NavigationMethod();
                ManageRequestobj.GotoReceivedOrSentRequest();
                string expectedTitle = "SentRequest";
                Assert.AreEqual(expectedTitle,navigateobj.ReturnPageTtile() );
            }
            [Test, Description("Check if user is able to see skill details by clicking on skill title")]
            public void SeeSkillDetailsbyclickingOnTtile()
            {

                var ManageRequestobj = new ManageRequest();
                var navigateobj = new NavigationMethod();
                ManageRequestobj.GotoReceivedOrSentRequest();
                ManageRequestobj.GotoTagetSkillPage();
               // string expectedTitle = "ReceivedRequest";
                //Assert.AreEqual(expectedTitle, navigateobj.ReturnPageTtile());
            }

            [Test, Description("Check if user is able to click on Sent request and navigate to Sent reuest Page")]
            public void SendARequest()
            {

                var ProfilePageobj = new Profile();
                ProfilePageobj.SearchSkillByTitle();
                var SearchSkillobj = new SearchSkillsPage();
                SearchSkillobj.SearchSkillByUser();
                SearchSkillobj.ClickOnTargetSkill();
                var TargetSkillobj = new TargetSkillPage();
                TargetSkillobj.WriteMessageAndSend();
                TargetSkillobj.EnableNotificationDisplayed();
                string expectedTitle = "Request sent";
                Assert.AreEqual(expectedTitle, TargetSkillobj.NotificationDisplayed());
            }

            [Test, Description("Check if user is able to click accept on pending skill on received page")]
            public void AcceptPendingSkill()
            {

              
            }



        }


        
    }
}