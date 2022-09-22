using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin.Model;
using HI_TechTest_BDD.Support;
using NUnit.Framework;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace HI_TechTest_BDD
{
    [Binding]
    internal class TestSetup:General
    {
       
        [BeforeTestRun]
        
        public static void before_all()
        {
            browser = readConfig("browser_name");
            url = readConfig("url");
            poll_frequency = readConfig("poll_freq");
            InitializeReport("HomePage");
            

        }
        [BeforeFeature]
        public static void before_feature_run()
        {
            feature_name = ext.CreateTest<Feature>(FeatureContext.Current.FeatureInfo.Title);
        }

        [BeforeScenario]
        public void reporting()
        {
            
            scenario_name = ext.CreateTest<Scenario>(ScenarioContext.Current.ScenarioInfo.Title);

        }

        [AfterScenario]

        public void end_browser()
        {
            driver.Quit();
            ext.Flush();

        }
        [AfterStep]
        public static void report_after_step()
        {
            var step_type = ScenarioStepContext.Current.StepInfo.StepDefinitionType.ToString();
           
            if(ScenarioContext.Current.TestError is null)
            {
                if (step_type.Equals("Given"))
                    scenario_name.CreateNode<Given>(ScenarioContext.Current.StepContext.StepInfo.Text);
                else if (step_type.Equals("Then"))
                    scenario_name.CreateNode<Then>(ScenarioContext.Current.StepContext.StepInfo.Text);
                else if (step_type.Equals("When"))
                    scenario_name.CreateNode<When>(ScenarioContext.Current.StepContext.StepInfo.Text);
                else if (step_type.Equals("And"))
                    scenario_name.CreateNode<And>(ScenarioContext.Current.StepContext.StepInfo.Text);

            }
            else
            {
                if (step_type.Equals("Given"))
                    scenario_name.CreateNode<Given>(ScenarioContext.Current.StepContext.StepInfo.Text).Fail(ScenarioContext.Current.TestError.InnerException);
                else if (step_type.Equals("Then"))
                {
                    scenario_name.CreateNode<Then>(ScenarioContext.Current.StepContext.StepInfo.Text).Fail(ScenarioContext.Current.TestError.InnerException);
                    scenario_name.Fail(MediaEntityBuilder.CreateScreenCaptureFromPath(@"C:\Users\hamid.iqbal\source\repos\HI_TechTest\Reports","test").Build());
                }
                else if (step_type.Equals("When"))
                    scenario_name.CreateNode<When>(ScenarioContext.Current.StepContext.StepInfo.Text).Fail(ScenarioContext.Current.TestError.InnerException);
                else if (step_type.Equals("And"))
                    scenario_name.CreateNode<And>(ScenarioContext.Current.StepContext.StepInfo.Text).Fail(ScenarioContext.Current.TestError.InnerException);
                //scenario_name.Fail(MediaEntityBuilder.CreateScreenCaptureFromPath("img.png").Build());
                // base64
               
            }

            // for Skip steps
            if (ScenarioContext.Current.ScenarioExecutionStatus.ToString().Equals("StepDefinitionPending"))
            {
                if (step_type.Equals("Given"))
                    scenario_name.CreateNode<Given>(ScenarioContext.Current.StepContext.StepInfo.Text).Skip("PendingStepException");
                else if (step_type.Equals("Then"))
                    scenario_name.CreateNode<Then>(ScenarioContext.Current.StepContext.StepInfo.Text).Skip("PendingStepException");
                else if (step_type.Equals("When"))
                    scenario_name.CreateNode<When>(ScenarioContext.Current.StepContext.StepInfo.Text).Skip("PendingStepException");
                else if (step_type.Equals("And"))
                    scenario_name.CreateNode<And>(ScenarioContext.Current.StepContext.StepInfo.Text).Skip("PendingStepException");
            }
           

        }

        [AfterTestRun]
        public static void after_run()
        {

        }

       
    }
}
