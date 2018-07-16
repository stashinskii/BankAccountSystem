## Tasks from *Day 9* 
Includes:
### Sorting Arrays Rows:

* **Sorting**:
    * Содержит класс **ArraySorter**, который реализует абстрагированное решение, которое принимает объект класса, реализующего IComparer (**в предыдущей версии фабрика ошибочно использовалась как стратегия**)
	* Содержит **метод-расширение** для сортировки
	* Строки могут быть разной длинны
* **Sorting.NUnitTests**:
	* Реализация IComparer
    * Тесты для сортировки по сумме элементов строки
	* Тестры для сортировки по максимальному и минимальному элементу в строке
	* Тесты для валидации данных
	
### Bank Account:

* **BankAccount**:
    * Содержит описание всех сущностей, которые предоставляют полную информацию об аккаунта:
        * **Account** - class
        * **Customer** - class 
		* **AccountType** - enum
		* **AccountException** - custom exception class
		* **InvalidAccountOperationException** - custom exception class
		* **AccountStatus** - enum
		* **IAccount** - interface 
* **BankAccount.NUnitTests**:
    * Модульные тесты
* **BankAccount.ConsoleUI**:
    * Консольное клиент-приложение для работы с банковским счетом
	

