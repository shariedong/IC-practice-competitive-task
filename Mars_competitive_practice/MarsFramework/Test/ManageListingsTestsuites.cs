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
