Feature: CustomerGetById

gets customer by id

@GetById
Scenario: Get customer by id
	Given the Id (<IdSeed>) of a customer
	When I request to get the customer by that Id
	Then the action returns customer with Status code (<StatusCode>)

	Examples: 
	| IdSeed	| StatusCode |
	|	1		| 200        |
	|	5		| 404        | #customer not found
