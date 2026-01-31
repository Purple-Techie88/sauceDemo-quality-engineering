Feature: Checkout items in the basket
  @UI
  Scenario: Check item total cost and tax
    Given I log in with valid credentials
      | userName      | password     |
      | standard_user | secret_sauce |

    And I add the following items to the basket
      | itemName               |
      | Sauce Labs Fleece Jacket |
      | Sauce Labs Onesie        |
      | Sauce Labs Bolt T-Shirt  |

    And I should see 3 items added to the shopping cart
    And I click on the shopping cart
    And I verify that the QTY count for each item should be 1
    And I remove the following item:
      | itemName               |
      | Sauce Labs Fleece Jacket |
      
    And I should see 2 items added to the shopping cart
    And I click on the CHECKOUT button
    And I type "FirstName" for "First Name"
    And I type "LastName" for "Last Name"
    And I type "LS88 MOB" for "ZIP/Postal Code"

    When I click on the CONTINUE button
    Then Item total will be equal to the "subtotal" for item in the list
    And a "Tax" rate of 8 % is applied to the total