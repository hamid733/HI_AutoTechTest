using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Support.Extensions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace HI_TechTest_BDD.Support
{
    internal class General
    {
        public static IWebDriver driver;
        public static IJavaScriptExecutor js;
        public static string browser;
        public static string url;
        public static string poll_frequency;
        public static WebDriverWait wt;
        public static ExtentReports ext;
        public static ExtentTest scenario_name;
        public static ExtentTest feature_name;


        //string[] names;
        //string[] address = { "123 abc"};
        //string[] cars = new string[4];
        //string[] cars2 = new string[] {"skoda","bmw"};
        //List<General> list = new List<General>();
        //IList<int> list2 = new List<int>();
       

        public static string readConfig(string key)
        {
            try
            {
                ExeConfigurationFileMap configFileMap = new ExeConfigurationFileMap();
                configFileMap.ExeConfigFilename = @"C:\Users\hamid.iqbal\source\repos\HI_TechTest\Library\Config.config";
                Configuration config = ConfigurationManager.OpenMappedExeConfiguration(configFileMap, ConfigurationUserLevel.None);
                AppSettingsSection section = (AppSettingsSection)config.GetSection("appSettings");
                return section.Settings[key].Value;
            }
            catch (Exception)
            {

                throw;
            }
            
        }
        public static string readOR(string key)
        {
            try
            {
                ExeConfigurationFileMap configFileMap = new ExeConfigurationFileMap();
                configFileMap.ExeConfigFilename = @"C:\Users\hamid.iqbal\source\repos\HI_TechTest\Library\OR.config";
                Configuration config = ConfigurationManager.OpenMappedExeConfiguration(configFileMap, ConfigurationUserLevel.None);
                AppSettingsSection section = (AppSettingsSection)config.GetSection("appSettings");
                return section.Settings[key].Value;
            }
            catch (Exception)
            {

                throw;
            }

        }

        public static IWebDriver open_url(string url, string browser, IWebDriver driver)
        {
            try
            {
                if (browser.Equals("chrome"))
                {
                    ChromeOptions options = new ChromeOptions();
                    driver = new ChromeDriver(options);
                    driver.Navigate().GoToUrl(url);

                }
                else if (browser.Equals("Edge"))
                    driver = new EdgeDriver();
                driver.Manage().Window.Maximize();
            }
            catch (Exception)
            {

                throw;
            }
            return driver;
        }

        public static void wait_for_page_load(IWebDriver driver)
        {
            wt = new WebDriverWait(driver, TimeSpan.FromSeconds(Double.Parse(readConfig("exp_wait"))));
            Thread.Sleep(Int32.Parse(poll_frequency));
            wt.Until(drv => drv.ExecuteJavaScript<string>("return document.readyState")).Equals("Complete");
        }

        public static Dictionary<string, string> ToDictionary(Table table)
        {
            var dictionary = new Dictionary<string, string>();
            foreach (var row in table.Rows)
            {
                dictionary.Add(row[0], row[1]);
            }
            return dictionary;
        }

        public static List<string> create_list_from_table(string column, Table table)
        {
            List<string> val_list = new List<string>();
            foreach (var row in table.Rows)
            {
                val_list.Add(row[column]);
            }
            return val_list;

        }
        public static void InitializeReport(string ReportName)
        {
            try
            {
                string pth = System.Reflection.Assembly.GetCallingAssembly().CodeBase;
                string actualPath = pth.Substring(0, pth.LastIndexOf("bin"));
                string projectPath = new Uri(actualPath).LocalPath;
                string reportPath = projectPath + "Reports\\" + ReportName + ".html";
                ExtentSparkReporter spark = new ExtentSparkReporter(reportPath);
                ext = new ExtentReports();
                ext.AttachReporter(spark);
            }
            catch (Exception)
            {

                throw;
            }
            
            
        }


    }
}
