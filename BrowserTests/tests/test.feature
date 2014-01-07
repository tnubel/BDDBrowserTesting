Feature: HelloWorld
  A narrative is optional

Scenario: Load Wikipedia
	Given a browser
	When I visit "http://www.wikipedia.org"
	And I fill in "search" with "West Monroe Partners"
	And I press "go"
	And I wait for 2 seconds
	Then I should see "West Monroe Partners LLC"