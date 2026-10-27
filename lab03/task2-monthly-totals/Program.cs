// Лабораторна 3, задача 2. Підсумки за місяцями.
// Масив фіксованого розміру на 12 місяців: номер місяця — це індекс (month - 1), перебору немає.

Console.OutputEncoding = System.Text.Encoding.UTF8;

(int Month, decimal Amount)[] operations =
[
    (1, 1200m), (3, 450.50m), (1, 300m), (12, 999.99m), (6, 75m),
    (3, 149.50m), (9, 2000m), (12, 0.01m), (6, 25m), (11, 640m)
];

var totals = new decimal[12];           // розмір відомий наперед і не змінюється

foreach (var op in operations)
    totals[op.Month - 1] += op.Amount;  // прямий доступ за індексом, O(1)

string[] names = ["Січень", "Лютий", "Березень", "Квітень", "Травень", "Червень",
                  "Липень", "Серпень", "Вересень", "Жовтень", "Листопад", "Грудень"];

Console.WriteLine("Підсумки за місяцями:");
for (int m = 0; m < 12; m++)
    Console.WriteLine($"{m + 1,2}. {names[m],-9} {totals[m],10:F2}");
