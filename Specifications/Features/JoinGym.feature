Feature: JoinGym
	In order to get fit
	As a potential gym member
	I want to join the gym

@mytag
Scenario: Joining creates membership with a year of standard membership payments setup
	When I join the gym stating the following details:
	| Id | Date of birth |
	| 1  | 1975-09-21    |
	Then a gym membership should have been created with an id of 1
	And that membership should be for a member who was born on '1975-09-21'
	And that membership should have a monthly fee of £50.00