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
            [Test, Description("Check if the user is able to Click on 'search skill' icon in the home page")]
            public void SearchSkillsByTitle()
            {
                var ProfilePageobj = new Profile();
                ProfilePageobj.SearchSkillByTitle();
                var SearchSkillobj = new SearchSkillsPage();
                SearchSkillobj.SearchSkillByUser();
                SearchSkillobj.ClickOnTargetSkill();
                var TargetSkillobj = new TargetSkillPage();
                String expectedTitle = "Power BI";
                Assert.AreEqual(expectedTitle, TargetSkillobj.TargetSkillPageDisplayed());
            }

            [Test, Description("Check if user is able to search skills by title")]
            public void GoToSearchSkills()
            {
                var ProfilePageobj = new Profile();
                ProfilePageobj.ClickOnSearchSkillIcon();
                var NavigationMethodobj = new NavigationMethod();

                String expectedTitle = "Search";
                Assert.AreEqual(expectedTitle,NavigationMethodobj.ReturnPageTtile());
            }


            [Test, Description("Check if user is able to search skills by all catogories ")]
            public void SearchSkillsByAllCategory()
            {
                var ProfilePageobj = new Profile();
                ProfilePageobj.ClickOnSearchSkillIcon();
                var SearchSkillobj = new SearchSkillsPage();
                int expectedNumber = SearchSkillobj.ReturnAllCatogoryNumber();
                int actualNumber = SearchSkillobj.CountActualAllCatogoryNumber();
                Assert.AreEqual(expectedNumber,actualNumber );
            }

            [Test, Description("Check if user is able to search skills by GD catogories ")]
            public void SearchSkillsByGDCategory()
            {
                var ProfilePageobj = new Profile();
                ProfilePageobj.ClickOnSearchSkillIcon();
                var SearchSkillobj = new SearchSkillsPage();
                int expectedNumber = SearchSkillobj.ReturnSubCatogoryNumber();
                int actualNumber = SearchSkillobj.CountActualGDNumber();
                Assert.AreEqual(expectedNumber, actualNumber);
            }

            [Test, Description("Check if user is able to search skills by filter ")]
            public void SearchSkillsByFilter()
            {
                var ProfilePageobj = new Profile();
                ProfilePageobj.ClickOnSearchSkillIcon();
                var SearchSkillobj = new SearchSkillsPage();
                int expectedNumber = SearchSkillobj.ReturnAllCatogoryNumberByFilter();
                int actualNumber = SearchSkillobj.CountActualAllCatogoryNumber();
                Assert.AreEqual(expectedNumber, actualNumber);
            }

        }
    }
}
