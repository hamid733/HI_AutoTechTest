using HI_TechTest_BDD.Support;
using OpenQA.Selenium;


namespace HI_TechTest_BDD
{
    internal class Home_Page:General
    {

        
        internal static string get_page_title(IWebDriver driver)
        {
            wait_for_page_load(driver);
            return driver.Title;
        }

        internal static object fetch_page_headings()
        {
            var headings = driver.FindElements(By.XPath(readOR("main_heading")));
            IList<object> page_h1_text = new List<object>();
            foreach(var element in headings)
            {
                page_h1_text.Add(element.Text);
            }
            return page_h1_text;
        }
    }
}
