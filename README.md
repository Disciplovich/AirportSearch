# Airport Search.

Программа для быстрого поиска данных аэропортов из CSV-файла по указанной колонке. Программа создает индекс для ускорения поиска и предоставляет интерактивный интерфейс для ввода запросов.

## Описание.

Программа читает данные из файла `airports.dat` (или другого CSV-файла) и позволяет выполнять поиск по значениям указанной колонки. Она поддерживает:
- Поиск строк, начинающихся с заданного текста.
- Вывод результатов в формате `<Найденное значение нужной колонки>[<Полностью строка>]`.
- Сортировку результатов по указанной колонке.
- Подсчет количества найденных строк и время выполнения поиска.
- Повторный ввод запросов без перезапуска программы.
- Завершение работы по команде `!quit`.

Программа использует индексацию данных для обеспечения высокой скорости поиска при минимальном использовании памяти.

---

## Установка.

1. **Клонирование репозитория.**
- Открываем Git Bash и вводим команду для клонирования репозитория:
- **"git clone https://github.com/Disciplovich/AirportSearch.git"**.
- Переходим в папку с проектом:
- **"cd AirportSearch"**.
2. **Убедитесь, что у вас установлен .NET SDK.**
- Для проверки выполните:
- **"dotnet --version"**.
- Если .NET SDK не установлен, скачайте его с [официального сайта](https://dotnet.microsoft.com/ru-ru/download?spm=a2ty_o01.29997173.0.0.22d63feaDgQdpC).
3. **Компиляция программы.**
- **"dotnet build"**
4. **Подготовка файла данных.**
- Поместите файл airports.dat в корневую папку проекта **(AirportSearch\AirportSearch\bin\Debug)** или укажите путь к нему при запуске программы.

---

## Использование программы

1. **Запускаем программу.**
- Открываем терминал и вводим команду для перехода к корневой папке проекта, например:
- **"cd C:\AirportSearch\AirportSearch\bin\Debug"**.
- Далее вводим название файла .exe, название файла airports.dat (если поместили файл в корневую папку проекта) или путь к нему, номер колонки поиска данных:
- **AirportSearch.exe <путь_к_файлу> <номер_колонки>**.
- Пример: **"AirportSearch.exe airports.dat 2"**.
2. **Вводим тест для поиска.**
- После запуска программа предложит ввести текст для поиска: **"Введите текст для поиска (для выхода введите '!quit'):"**
- Например, введите **Bo** и нажмите Enter.
3. **Результаты.**
- Программа выведет все строки, где значение указанной колонки начинается с введенного текста.
- Формат вывода: **<Найденное значение нужной колонки>[<Полностью строка>]**.
- Также программа автоматически подсчитывает количество найденных строк и время выполнения поиска, например:
- **"Найдено строк: 76
Время поиска: 5 мс"**.
4. **Завершение программы.**
- Введите **!quit**, чтобы завершить работу программы.

---

## Структура проекта
1. **Airport.cs**
- Класс для представления одной записи аэропорта.
- Методы для парсинга CSV-строки.
2. **AirportIndex.cs**
- Класс для создания индекса для ускоренного поиска.
- Хранит значения колонок и соответствующие строки в SortedDictionary.
3. **AirportSearchService.cs**
- Класс для управления индексацией и поиском.
- Предоставляет методы для инициализации индекса и выполнения поиска.
4. **Program.cs**
- Главный класс, управляющий взаимодействием с пользователем.
- Обрабатывает ввод данных, вызывает поиск и выводит результаты.
