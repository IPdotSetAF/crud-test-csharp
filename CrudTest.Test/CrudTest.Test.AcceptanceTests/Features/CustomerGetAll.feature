Feature: CustomerGetAll

gets all customers list

@CustomerGetAll
Scenario: Get all customers
	When I request to get all customers
	Then the action should return a list of all customers with Status code 200