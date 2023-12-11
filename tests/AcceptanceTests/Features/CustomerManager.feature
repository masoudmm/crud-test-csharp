Feature: Customer Manager

As a an operator I wish to be able to Create, Update, Delete customers and list all customers
	
Scenario: Create customer
    Given I am on the customer management page
    When I click the "Create Customer" button
    When I fill in the customer details
    When I click the Create button
    Then the customer should be created successfully

Scenario: Edit customer
    When I click the first customer details
    When I edit the customer first name
    And I click the Save button
    Then the customer should be edited successfully

Scenario: Delete customer
    When I click the "Delete" button
    Then the customer should be deleted successfully