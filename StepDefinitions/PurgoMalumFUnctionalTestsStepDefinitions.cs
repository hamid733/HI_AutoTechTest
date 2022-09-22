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
        Common comm = new Common();

        [Given(@"I send the get request to the '([^']*)' api")]

        public void GivenISendTheGetRequestToTheApi(string method)
        {
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
            var results = comm.check_api_result(text, "plain");
            string expected = text;

            Assert.That(results, Is.EqualTo(expected), "Unexpected Response");
        }
       
        [Then(@"the response should filter the profanity (.*) from the input text as (.*)")]
        public void check_filter_words(string input, string result)
        {
            var actual_result = comm.get_api_result_only(input, "json");
            string expected = result;
            Assert.That(actual_result, Is.EqualTo(expected), "Unexpected response text");
        }

        [Given(@"the PurgoMalum api service is up and running")]
        public void GivenThePurgoMalumApiServiceIsUpAndRunning()
        {
            GivenISendTheGetRequestToTheApi("json");
        }

        [When(@"I send the request to the json api with the optional parameters add and fill_char")]
        [When(@"I send the request to the json api with the optional parameters add and fill_text")]
        public void WhenISendTheRequestToTheJsonApiWithTheOptionalParametersAddAndFill_Text()
        {
            
        }

        [Then(@"the new word '([^']*)' should be added and replaced by '([^']*)' value '([^']*)' in the input text '([^']*)'")]
        public void ThenTheNewWordShouldBeAddedAndReplacedByInTheInputText(string new_word, string opt_prmtr,string replacement,string input_text)
        {
           var actual_processed_input = comm.check_optional_parameters(new_word, replacement, input_text, opt_prmtr);
           string expected_text = null;
           //var allowed_chars = new List<char> {'=', '_', '-', '|', '~' };
           if (opt_prmtr == "fill_char")
            {
                char rep_char = char.Parse(replacement);
                string expected_word = new string(rep_char, new_word.Length);
                expected_text = input_text.Replace(new_word, expected_word);
            }
                       
            else
                expected_text = input_text.Replace(new_word, replacement);
                
           Assert.That(actual_processed_input, Is.EqualTo(expected_text), "Unexpected response text");

        }

    }
}
