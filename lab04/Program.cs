// ЛАБОРАТОРНА 4. Пошук у даних
// Дописано лише TODO 1 (лінійний пошук) і TODO 2 (бінарний пошук). Решту не змінено.

Console.OutputEncoding = System.Text.Encoding.UTF8;

int[] data = [42, 8, 60, 19, 3, 55, 12, 31, 68, 24, 49, 37, 71, 5, 27];
int[] sortedData = (int[])data.Clone();
Array.Sort(sortedData);                                    // готово

int comparisons = 0;   // лічильник порівнянь, обнуляється перед кожним пошуком

// TODO 1: лінійний пошук — повертає індекс знайденого значення або -1
int LinearSearch(int[] items, int target)
{
    for (int i = 0; i < items.Length; i++)
    {
        comparisons++;                     // порівняння items[i] з target
        if (items[i] == target)
            return i;
    }
    return -1;
}

// TODO 2: бінарний пошук циклом — повертає індекс знайденого значення або -1
int BinarySearch(int[] items, int target)
{
    int low = 0;
    int high = items.Length - 1;           // для порожнього масиву high = -1, цикл не виконається

    while (low <= high)
    {
        int mid = low + (high - low) / 2;  // без переповнення
        comparisons++;                     // одне порівняння items[mid] з target
        int cmp = items[mid].CompareTo(target);

        if (cmp == 0)
            return mid;
        if (cmp < 0)
            low = mid + 1;                 // шукане правіше
        else
            high = mid - 1;                // шукане лівіше
    }
    return -1;
}

void Report(string name, int[] items, int target)     // готово, не змінювати
{
    comparisons = 0;
    int index = name == "linear" ? LinearSearch(items, target)
                                 : BinarySearch(items, target);
    Console.WriteLine($"{name,-7} target={target,3} index={index,3} comparisons={comparisons}");
}

Console.WriteLine("sortedData = [" + string.Join(", ", sortedData) + "]");
Console.WriteLine();

// Частина 2. Вісім випадків перевірки
var cases = new (string Title, int[] Items, int Target)[]
{
    ("1. Значення стоїть першим",      sortedData, 3),
    ("2. Значення стоїть останнім",    sortedData, 71),
    ("3. Значення посередині",         sortedData, 31),
    ("4. Відсутнє, менше за всі",      sortedData, 1),
    ("5. Відсутнє, більше за всі",     sortedData, 99),
    ("6. Відсутнє, між сусідніми",     sortedData, 50),
    ("7. Масив з одного елемента [42]", [42], 42),
    ("8. Порожній масив []",           [], 42),
};

foreach (var c in cases)
{
    Console.WriteLine(c.Title);
    Report("linear", c.Items, c.Target);
    Report("binary", c.Items, c.Target);
    Console.WriteLine();
}

// Частина 3. Бінарний пошук на НЕвідсортованих даних
Console.WriteLine("Частина 3. Бінарний пошук 55 у невідсортованому data:");
Report("binary", data, 55);
Report("linear", data, 55);
