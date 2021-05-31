using MarsFramework.Pages;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsFramework.Test
{
    class SearchSkillsTestsuite
    {
        [TestFixture, Description("SearchSkill Testcases")]
        class SearchSkillsTestSuits : Global.Base
        {

            [Test, Description("Check if user is able to search skills by title")]
            public void SearchSkillsByTitle()
            {
                var ProfilePageobj = new Profile();
                ProfilePageobj.SearchSkillByTitle();
                var SearchSkillobj = new SearchSkillsPage();
                SearchSkillobj.SearchSkillByUser();
                SearchSkillobj.ClickOnTargetSkill();
                var TargetSkillobj = new TargetSkillPage();
                String expectedTitle = "Power BI";
                Assert.AreEqual(expectedTitle,TargetSkillobj.TargetSkillPageDisplayed());
            }
        }
    }
}
