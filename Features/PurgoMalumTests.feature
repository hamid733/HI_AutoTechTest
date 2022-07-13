Feature: PurgoMalum Functional Tests

A short summary of the feature

@profanity @SmokeTests
Scenario: Verify PurgoMalum containsprofanity api status
	Given I send the get request to the 'containsprofanity' api
	Then the status code should be success

@xml @SmokeTests
Scenario: Verify PurgoMalum xml api status
	Given I send the get request to the 'xml' api
	Then the status code should be success

@json @SmokeTests
Scenario: Verify PurgoMalum json api status
	Given I send the get request to the 'json' api
	Then the status code should be success

@plain @SmokeTests
Scenario: Verify PurgoMalum plain api status
	Given I send the get request to the 'plain' api
	Then the status code should be success

@profanity
Scenario Outline: Verify the profanity api results based on the input text
	Given the Profanity api is up and running
	When I call the profanity api
	Then the response should be <result> against the <input>
Examples: 
| input                          | result |
| this is some test input bollox | true   |
| this is some test input shit   | true   |
| this is some test input arse   | true   |
| wop                            | true   |
| wiseasses                      | true   |
| skank                          | true   |
| panooch                        | true   |
| bitch                          | true   |
| dear	                         | false  |
| sir	                         | false  |
| madam	                         | false  |
| mr	                         | false  |
| mrs	                         | false  |

@xml
Scenario: Verify PurgoMalum xml api response
	When I send the request to the xml api
	Then the response should be processed input text 'sample text test' as XML
	
@json
Scenario: Verify PurgoMalum json api response
	When I send the request to the json api
	Then the response should be processed input text 'sample text test' as json

@plain
Scenario: Verify PurgoMalum plain api response
	When I send the request to the plain api
	Then the response should be processed input text 'sample text test' as plain

@profanity
Scenario Outline: Verify the api filters words which contain from the profanity list
	When I send the request to the json api
	Then the response should filter the profanity <words> from the input text as <result>
Examples: 
| words                    | result                  |
| sample text test bollox  | sample text test ****** |
| sample text shit test    | sample text **** test   |
| wop                      | ***                     |
| wiseasses text shit test | ********* text **** test|
| sample bitch text        | sample ***** text       |
| panooch                  | *******                 |
| skank                    | *****                   |

@json @optional_parameters @potential_bug
Scenario: Verify user can add/replace words to the profanity list using optional parameters
Given the PurgoMalum api service is up and running
When I send the request to the json api with the optional parameters add and fill_text
Then the new word 'neww_ord' should be added and replaced by 'fill_text' value '|replace_word|' in the input text 'new_word is some test input' 

@json @optional_parameters
Scenario: Verify user can add and replace profanity words with a single character using optional parameter  
Given the PurgoMalum api service is up and running
When I send the request to the json api with the optional parameters add and fill_char
Then the new word 'newword' should be added and replaced by 'fill_char' value '~' in the input text 'newword is some test input'











