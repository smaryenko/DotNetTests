Feature: LoginFeature

@login
Scenario Outline: Login with invalid credentials
	Given Login page is loaded
	When <email> and <password> are entered and login button pressed
	Then User sees error message <error>

Examples: 
	| email              | password     | error                                                                     |
	| invalidmail1       | password     | Epic sadface: Username and password do not match any user in this service |
	|                    | password     | Epic sadface: Username is required                                        |
	| invalidmail3@gmail |              | Epic sadface: Password is required                                        |
	| locked_out_user    | secret_sauce | Epic sadface: Sorry, this user has been locked out.                       |

@login
Scenario: Login with valid credentials
	Given Login page is loaded
	When standard_user and secret_sauce are entered and login button pressed
	Then Inventory page is loaded