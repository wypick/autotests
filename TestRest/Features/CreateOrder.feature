Feature: Create Order

@createOrder @all
Scenario: Создание заказа на животное
	* add pet
	* create order
	* check order
