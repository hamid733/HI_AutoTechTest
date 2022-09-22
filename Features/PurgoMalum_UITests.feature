Feature: PurgoMalum_UITests

A short summary of the feature

@home_ui
Scenario: Verify home page display
	Given I navigate to the PurgoMalum home page
	Then the home page should be displayed properly with the title 'PurgoMalum — Free Profanity Filter Web Service'
	And the following page headings should display
	| headings            |
	| What is PurgoMalum? |
	| Usage               |
	| Examples            |
	| Advanced Examples   |
	| Error Handling	  |
	| Contact             |
