using NUnit.Framework;
using MarsFramework.Pages;
using MarsFramework.Global;

namespace MarsFramework.Test
{
    public class ShareSkillsTestSuites
    {
        
        [TestFixture, Description("Share skills Testcases")]
        class ShareskillTestSuites : Global.Base 
        {
            [Test, Description("Check if the user is able to Add a new skill")]
            public void AddaNewSkill()
            {
                
                ShareSkill ShareSkillobj = new ShareSkill();
                ShareSkillobj.ShareNewSkillWholeSteps();
                string expectedMsg = "Manage Listings";
                Assert.AreEqual(expectedMsg, ShareSkillobj.AddskillSuccessfully());

            }
        }


        
    }
}