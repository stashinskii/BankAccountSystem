## Tasks from *Day 9* 
Includes:
### Sorting Arrays Rows:

* **Sorting**:
    * Содержит класс **ArraySorter**, который реализует абстрагированное решение, которое принимает объект с методом-фабрикой, корый производит *типы сортировки (SortingType)*
	* Содержит **метод-расширение** для сортировки
	* Строки могут быть разной длинны
* **Sorting.Factory**:
    * Содрежит ряд классов, которые реализуют паттерн **Фабрика (Factory)**
	* Благодаря этому, можно добавлять сюда дополнительные типы сортировки и класс ArraySorter будет работать с ними, ничего не меняя в коде
* **Sorting.NUnitTests**:
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
	

