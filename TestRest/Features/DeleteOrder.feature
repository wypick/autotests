Feature: Delete Order

@mytag @all
Scenario: Удаление заказа на животное
	* add pet
	* create order
	* delete order
	* check deleted order