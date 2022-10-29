Feature: CustomerObject

validations for customer object

@CustomerObject
Scenario: Object Validation
	Given The customer data as (<FirstName>,<LastName>,<DateOfBirth>,<Email>,<PhoneNumber>,<BankAccountNumber>)
	When Creating a Customer object
	Then We should have a (<Valid>) Customer

	Examples: 
	| FirstName | LastName | DateOfBirth | Email				 | PhoneNumber   | BankAccountNumber  | Valid	|
	| mahdi     | nazari   | 7/18/1999   | ipdotsetaf1@gmail.com | +989387016860 | 1212121212121212   | true    |
	| mahdi     | nazari   | 7/18/1999   | ipdotsetaf1@gmail.com |				 | 1212121212121212   | false   | #null phone number
	| Mahdi     | Nazari   | 7/18/1999   |						 | +15417737024	 | 1212121212121212   | false   | #null email
	| Ali       | Nazari   | 1/20/2012   | test@test.com		 | +9816860		 | 1212121212121212   | false   | #invalid phone number
	| Mahdi     | Nazari   | 7/18/1999   | ipdotsetaf1@gmail.com | +15417737024	 | 13513131		      | false   | #invalid banck account number
	| Mahdi     | Nazari   | 7/18/1999   | ipdotsetaf1@gmail.com | +15417737024	 | 1212121212121212   | true    | 
	| Mahdi     | Nazari   | 7/18/1999   | test.com				 | +15417737024	 | 1212121212121212   | false   | #invlid email
