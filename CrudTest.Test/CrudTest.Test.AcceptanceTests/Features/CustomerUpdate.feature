Feature: CustomerUpdate

updates customer

@Update
Scenario: Update customer
	Given the Id of an existing customer and data (<IdSeed>,<Email>,<PhoneNumber>,<BankAccountNumber>)
	When updateing this customer using the data
	Then the action should return (<StatusCode>)

	Examples: 
	| IdSeed	| Email                 | PhoneNumber    | BankAccountNumber  | StatusCode |
	|	1		| ipdotsetaf1@gmail.com | +989387016860  | 1212121212121212   | 204        |
	|	1		| ipdotsetaf1@gmail.com | +9816860		 | 1212121212121212   | 400        | #bad phonenumber
	|	1		| ipdotsetaf1@gmail.com | +15417737024	 | 1212121212121212   | 201        | 
	|	1		| ipdotsetaf@gmail.com  | +15417737024	 | 1212121212121212   | 400        | #existing email
	|	5		| test@test.com			| +15417737024	 | 1212121212121212   | 404        | #customer not found
	|	1		| ipdotsetaf1@gmail.com | +15417737024	 | 13513131		      | 400        | #invalid banck account number
	|	1		| gmail.com				| +15417737024	 | 1212121212121212   | 400        | #invlid email
		