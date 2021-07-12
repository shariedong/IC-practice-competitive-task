using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarsFramework.Pages;

namespace MarsFramework.Test
{
    class ManageListingsTestsuites
    {
        [TestFixture, Description("ManageListing Testcases")]
        class ManageListingTestSuits : Global.Base
        {
           

            [Test, Description("Check if the user is able to Click on Manage Listings link in the home page")]
            public void ManageListingslink()
            {
                var ManageListingsobj2 = new ManageListings();
                ManageListingsobj2.LinkClick();
                string exceptedPageTitle = "Manage Listings";
                Assert.AreEqual(exceptedPageTitle, ManageListingsobj2.JumpToManageListingSuccessfully());

            }
            [Test, Description("Check if user is able to view all the listings entered")]
            public void ViewAllListings()
            {
                var ManageListingsobj3 = new ManageListings();

                int exceptedPageTitle = 11;
                Assert.AreEqual(exceptedPageTitle, ManageListingsobj3.CountAllListingSkills());

            }

            [Test, Description("Check if the user is able to view the service details by clicking eye icon")]
            public void ViewService()
            {
                var ManageListingsobj4 = new ManageListings();
                var TargetSkillobj = new TargetSkillPage();
                ManageListingsobj4.ViewListings();
                string expectedTitle = "Selenium";
                Assert.AreEqual(expectedTitle, TargetSkillobj.TargetSkillPageDisplayed());
            }


            [Test, Description("Check if the user is able to edit the service details by clicking edit icon")]
            public void EditService()
            {
                var ManageListingsobj5 = new ManageListings();
                var TargetSkillobj = new TargetSkillPage();
                var ShareSkillobj = new ShareSkill();
                var NavigationMethodobj = new NavigationMethod();
                ManageListingsobj5.ViewListings();
                string EditBeforeTitle = TargetSkillobj.TargetSkillPageDisplayed();
                NavigationMethodobj.NavigationBack();
                ManageListingsobj5.EditListings();
                ShareSkillobj.EnterANewTitle();
                ManageListingsobj5.ViewListings();
                string EditAfterTitle = TargetSkillobj.TargetSkillPageDisplayed();
                Assert.AreNotEqual(EditBeforeTitle,EditAfterTitle);
            }

            [Test, Description("Check if the user is able to click on Delete service in any listing")]
            public void DeleteService()
            {
                var ManageListingsobj1 = new ManageListings();
                ManageListingsobj1.DeleteListings();
                string expecteDeleteMessage = "Selenium has been deleted";
                Assert.AreEqual(expecteDeleteMessage, ManageListingsobj1.DeleteSuccessfully());
            }

            [Test, Description("Check if the user is able to click on Delete service in any listing")]
            public void CancelDeleteService()
            {
                var ManageListingsobj6 = new ManageListings();
                var TargetSkillobj = new TargetSkillPage();
                var ShareSkillobj = new ShareSkill();
                var NavigationMethodobj = new NavigationMethod();
                ManageListingsobj6.ViewListings();
                string CancelDeleteBeforeTitle = TargetSkillobj.TargetSkillPageDisplayed();
                NavigationMethodobj.NavigationBack();
                ManageListingsobj6.CancelDeleteListings();
                ManageListingsobj6.ViewListings();
                string CancelDeleteAfterTitle = TargetSkillobj.TargetSkillPageDisplayed();
                Assert.AreEqual(CancelDeleteBeforeTitle, CancelDeleteAfterTitle);
            }


        }
    }
}
