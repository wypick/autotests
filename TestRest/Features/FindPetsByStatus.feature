Feature: FindPetsByStatus

@mytag @all
Scenario Outline: Получить животное по статусу
	* add pet with status "<value>"
	* get animals with status "<value>"
	* check contain pet

	Examples: 
	| value     |
	| available |
	| pending   |
	| sold      |