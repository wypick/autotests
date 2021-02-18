Feature: FindPetsByStatus

@mytag
Scenario Outline: Получить животное по статусу
	* get animals with status "<value>"

	Examples: 
	| value     |
	| available |
	| pending   |
	| sold      |