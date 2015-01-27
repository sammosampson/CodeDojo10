Feature: JoinGym
	In order to get fit
	As a potential gym member
	I want to join the gym

Scenario: Joining creates membership standard membership fees setup
	Given the date is '2010-01-01'
	When I join the gym stating the following details:
	| Id | Date of birth |
	| 1  | 1975-09-21    |
	Then a gym membership should have been created with an id of 1
	And that membership should be for a member who was born on '1975-09-21'
	And the account for the membership 1 should have the following debits:
	| payment date | debit £ |
	| 2010-02-01   | 50      |
	| 2010-03-01   | 50      |
	| 2010-04-01   | 50      |
	| 2010-05-01   | 50      |
	| 2010-06-01   | 50      |
	| 2010-07-01   | 50      |
	| 2010-08-01   | 50      |
	| 2010-09-01   | 50      |
	| 2010-10-01   | 50      |
	| 2010-11-01   | 50      |
	| 2010-12-01   | 50      |
	| 2011-01-01   | 50      |
