Feature: PensionerDiscount
	In order to attract more members
	As a gym marketing person
	I want to allow anyone over 65 who joins a 10% discount

Scenario: Joining as an over 65 year old creates membership with discounted membership fees setup
	Given the date is '2010-01-01'
	And A promotion is setup for the over 65's at a discount of 10% 
	When I join the gym stating the following details:
	| Id | Date of birth |
	| 1  | 1975-09-21    |
	Then a gym membership should have been created with an id of 1
	And that membership should have a monthly fee of £45.00
