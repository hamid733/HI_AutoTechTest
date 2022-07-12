using HI_TechTest_BDD.Support;
using NUnit.Framework;
using RestSharp;
using System;
using TechTalk.SpecFlow;

namespace HI_TechTest_BDD.StepDefinitions
{
    [Binding]
    public class PurgoMalumFUnctionalTestsStepDefinitions
    {
        [Given(@"I send the get request to the '([^']*)' api")]

        public void GivenISendTheGetRequestToTheApi(string method)
        {
            var comm = new Common();
            var status = comm.Call_ApiAsync(method);
            Assert.That(status, Is.EqualTo("200"));
        }
        [Then(@"the status code should be success")]
        public void check_status_code()
        {

        }
        [Given(@"the Profanity api is up and running")]
        public void GivenTheProfanityApiIsUpAndRunning()
        {
            
        }
        [When(@"I call the profanity api")]
        public void WhenICallTheProfanityApi()
        {
            
        }

        [Then(@"the response should be (.*) against the (.*)")]
        public void GivenICallTheProfanityApiWithTheInput(string result, string word)
        {
            var comm = new Common();
            var response=comm.check_profanity_result(word);
            Assert.That(response, Is.EqualTo(result));
        }

        [When(@"I send the request to the xml api")]
        public void WhenISendTheRequestToTheXmlApi()
        {
            
        }

        [Then(@"the response should be processed input text '([^']*)' as XML")]
        public void ThenTheResponseShouldBeProcessedInputTextAsXML(string text)
        {
            var comm = new Common();
            var results = comm.check_api_result(text,"xml");
            Assert.That(results, Does.Contain("<?xml version="), "Unexpected Response");
            Assert.That(results, Does.Contain("<result>"+text+"</result>"), "Unexpected Response");

        }

        [When(@"I send the request to the json api")]
        public void WhenISendTheRequestToTheJsonApi()
        {
        }

        [Then(@"the response should be processed input text '([^']*)' as json")]
        public void ThenTheResponseShouldBeProcessedInputTextAsJson(string text)
        {
            var comm = new Common();
            var results = comm.check_api_result(text, "json");
            string expected = "{" + "\"result\"" + ":" + "\"" + text + "\"" + "}";

            Assert.That(results, Is.EqualTo(expected), "Unexpected Response");
        }

        [When(@"I send the request to the plain api")]
        public void WhenISendTheRequestToThePlainApi()
        {
        }

        [Then(@"the response should be processed input text '([^']*)' as plain")]
        public void ThenTheResponseShouldBeProcessedInputTextAsPlain(string text)
        {
            var comm = new Common();
            var results = comm.check_api_result(text, "plain");
            string expected = text;

            Assert.That(results, Is.EqualTo(expected), "Unexpected Response");
        }
       
        [Then(@"the response should filter the profanity (.*) from the input text as (.*)")]
        public void check_filter_words(string input, string result)
        {
            var comm = new Common();
            //var actual_result = comm.check_api_result(input, "json");
            var actual_result = comm.get_api_result_only(input, "json");
            //var expected_text = input.Split(' ');
            //int count = expected_text[2].Length;
            //string ex = new string('*', count);
            string expected = result;
            Assert.That(actual_result, Is.EqualTo(expected), "Unexpected response text");
        }


    }
}
