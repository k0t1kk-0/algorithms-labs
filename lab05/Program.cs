// ЛАБОРАТОРНА 5. Сортування об'єктів
// Використано стандартне сортування LINQ (OrderBy / ThenBy) — воно стабільне за документацією .NET.

using System.Globalization;

Console.OutputEncoding = System.Text.Encoding.UTF8;

// Порівняння рядків за українською абеткою (інакше «Іваненко» опиниться перед «Бондар»)
var ukrainian = StringComparer.Create(new CultureInfo("uk-UA"), ignoreCase: false);

var students = new List<Student>
{
    new("Ткаченко",  "ІПЗ-3/1", 85, 2024),
    new("Бондар",    "ІПЗ-3/2", 92, 2023),
    new("Іваненко",  "ІПЗ-3/1", 85, 2024),
    new("Коваль",    "ІПЗ-3/2", 78, 2024),
    new("Сидоренко", "ІПЗ-3/1", 85, 2023),
    new("Мельник",   "ІПЗ-3/2", 92, 2024),
    new("Гриценко",  "ІПЗ-3/1", 78, 2023),
    new("Дяченко",   "ІПЗ-3/2", 85, 2023),
};

void PrintAll(string title, IEnumerable<Student> items)   // готово, не змінювати
{
    Console.WriteLine(title);
    foreach (var s in items)
        Console.WriteLine($"  {s.Surname,-10} {s.Group,-8} {s.Grade,3} {s.Year}");
    Console.WriteLine();
}

PrintAll("Вихідний список:", students);

// TODO 1: за прізвищем, за абеткою
PrintAll("1. За прізвищем:", students.OrderBy(s => s.Surname, ukrainian));

// TODO 2: за балом, від вищого до нижчого
PrintAll("2. За балом (спадання):", students.OrderByDescending(s => s.Grade));

// TODO 3: за групою, а всередині групи — за балом від вищого
PrintAll("3. За групою, потім за балом:",
    students.OrderBy(s => s.Group, ukrainian).ThenByDescending(s => s.Grade));

// Частина 2: серед однакових балів — прізвища за абеткою
PrintAll("Частина 2. За балом, однакові — за прізвищем:",
    students.OrderByDescending(s => s.Grade).ThenBy(s => s.Surname, ukrainian));

record Student(string Surname, string Group, int Grade, int Year);
