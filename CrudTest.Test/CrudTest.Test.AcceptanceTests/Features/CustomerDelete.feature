Feature: CustomerDelete

deletes customer

@Delete
Scenario: Delete customer
	Given The Id (<IdSeed>) of a customer
	When sending delete request to action
	Then the action should return Status code (<StatusCode>)

	Examples: 
	| IdSeed	| StatusCode |
	|	1		| 204        |
	|	5		| 404        | #customer not found
		

