Feature: Login

  # Scenario: User can log in with valid credentials
  #   Given the user is on the Sauce Demo login page
  #   When I login with username "standard_user" and password "secret_sauce"
  #   # Then the inventory page should be displayed

  Scenario: User is unable to log in with valid credentials
    Given the user is on the Sauce Demo login page
    When I login with username "standard_user" and password "wrong_password"
    Then the error message is displayed
