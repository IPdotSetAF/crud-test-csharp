Feature: CustomerCreate

creates customer

@Create
Scenario: Create customer
	Given the customer data (<FirstName>,<LastName>,<DateOfBirth>,<Email>,<PhoneNumber>,<BankAccountNumber>)
	When createing a new customer using this data
	Then the action should return status code (<StatusCode>)

	Examples: 
	| FirstName | LastName | DateOfBirth | Email                 | PhoneNumber   | BankAccountNumber  | StatusCode |
	| Mahdi     | Nazari   | 7/18/1999   | ipdotsetaf1@gmail.com | +989387016860 | 1212121212121212   | 201        |
	| Mahdi     | Nazari   | 7/18/1999   | ipdotsetaf1@gmail.com | +9816860		 | 1212121212121212   | 400        | #bad phonenumber
	| Mahdi     | Nazari   | 7/18/1999   | ipdotsetaf1@gmail.com | +15417737024	 | 1212121212121212   | 201        | 
	| Mahdi     | Nazari   | 7/18/1999   | ipdotsetaf@gmail.com  | +15417737024	 | 1212121212121212   | 400        | #existing email
	| Ali       | Nazari   | 7/18/1999   | test@test.com		 | +15417737024	 | 1212121212121212   | 400        | #existing fName+lName+bDate
	| Mahdi     | Nazari   | 7/18/1999   | ipdotsetaf1@gmail.com | +15417737024	 | 13513131		      | 400        | #invalid banck account number
	| Mahdi     | Nazari   | 7/18/1999   | ipdotsetaf1@gmail	 | +15417737024	 | 1212121212121212   | 201        | 
	| Mahdi     | Nazari   | 7/18/1999   | gmail.com			 | +15417737024	 | 1212121212121212   | 400        | #invlid email
	