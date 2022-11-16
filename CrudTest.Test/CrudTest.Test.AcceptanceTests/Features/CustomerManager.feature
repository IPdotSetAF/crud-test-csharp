Feature: Create Read Edit Delete Customer

    Background:
        Given system error codes are following
          | Code | Description                                                |
          | 101  | Invalid Mobile Number                                      |
          | 102  | Invalid Email address                                      |
          | 103  | Invalid Bank Account Number                                |
          | 201  | Duplicate customer by First-name, Last-name, Date-of-Birth |
          | 202  | Duplicate customer by Email address                        |

    @ignore
    Scenario: Create Read Edit Delete Customer
        When user creates a customer with following data
          | ID | FirstName | LastName | Email        | PhoneNumber   | DateOfBirth | BankAccountNumber |
          | 1  | John      | Doe      | john@doe.com | +989121234567 | 01-JAN-2000 | IR000000000000001 |
        Then user can lookup all customers and filter by below properties and get "1" records
          | ID | FirstName | LastName | Email        | PhoneNumber   | DateOfBirth | BankAccountNumber |
          | 1  | John      | Doe      | john@doe.com | +989121234567 | 01-JAN-2000 | IR000000000000001 |
        When user creates a customer with following data
          | ID | FirstName | LastName | Email         | PhoneNumber   | DateOfBirth | BankAccountNumber |
          | 1  | john      | doe      | other@doe.com | +989121234567 | 01-JAN-2000 | IR000000000000001 |
        Then user will get error code of "201"
        When user creates a customer with following data
          | ID | FirstName | LastName | Email        | PhoneNumber   | DateOfBirth | BankAccountNumber |
          | 1  | Jane      | Williams | john@doe.com | +989121234111 | 01-JAN-2001 | IR000000000000001 |
        Then user will get error code of "201"
        When user edit customer with new data
          | ID | FirstName | LastName | Email        | PhoneNumber | DateOfBirth | BankAccountNumber |
          | 1  | Jane      | William  | jane@doe.com | +3161234567 | 01-FEB-2010 | IR000000000000002 |
        Then user can lookup all customers and filter by below properties and get "0" records
          | ID | FirstName | LastName | Email        | PhoneNumber   | DateOfBirth | BankAccountNumber |
          | 1  | John      | Doe      | john@doe.com | +989121234567 | 01-JAN-2000 | IR000000000000001 |
        And user can lookup all customers and filter by below properties and get "0" records
          | ID | FirstName | LastName | Email        | PhoneNumber | DateOfBirth | BankAccountNumber |
          | 1  | Jane      | William  | jane@doe.com | +3161234567 | 01-FEB-2010 | IR000000000000002 |
        When user delete customer by ID of "1"
        Then user can request to get all customer and it will return "0" records