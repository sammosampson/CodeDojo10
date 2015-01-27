Feature: PensionerDiscount
	In order to attract more members
	As a gym marketing person
	I want to allow anyone over 65 who joins a 10% discount

Scenario: Joining as an over 65 year old creates membership with discounted membership fees setup
	Given the date is '2010-01-01'
	And a promotion is setup for the over 65's at a discount of 10% 
	When I join the gym stating the following details:
	| Id | Date of birth |
	| 1  | 1944-12-31    |
	Then a gym membership should have been created with an id of 1
	And the account for the membership 1 should have the following debits:
	| payment date | value £ |
	| 2010-02-01   | 45      |
	| 2010-03-01   | 45      |
	| 2010-04-01   | 45      |
	| 2010-05-01   | 45      |
	| 2010-06-01   | 45      |
	| 2010-07-01   | 45      |
	| 2010-08-01   | 45      |
	| 2010-09-01   | 45      |
	| 2010-10-01   | 45      |
	| 2010-11-01   | 45      |
	| 2010-12-01   | 45      |
	| 2011-01-01   | 45      |
