using HI_TechTest_BDD.Support;
using NUnit.Framework;
using System;
using TechTalk.SpecFlow;

namespace HI_TechTest_BDD.StepDefinitions
{
    [Binding]
    internal class Common_Steps:General
    {
        [Given(@"I navigate to the PurgoMalum home page")]
        public void GivenINavigateToThePurgoMalumHomePage()
        {
            driver = open_url(url, browser, driver);
        }

        [Then(@"the home page should be displayed properly with the title '([^']*)'")]
        public void ThenTheHomePageShouldBeDisplayedProperlyWithTheTitle(string expec_title)
        {
            var actual_title = Home_Page.get_page_title(driver);
            Assert.AreEqual(expec_title, actual_title, "Unexpected page title");
        }
        [Then(@"the following page headings should display")]
        public void ThenTheFollowingPageHeadingsShouldDisplay(Table table)
        {
           //var dictionary = ToDictionary(table);
            var expected_headings = create_list_from_table("headings", table);
            var actual_headings = Home_Page.fetch_page_headings();
            Assert.AreEqual(expected_headings, actual_headings, "Unexpected page heading");

        }
       



    }
}
