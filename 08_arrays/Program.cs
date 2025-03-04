// -------------------- Arrays --------------------

// bad practice
int mark1 = 4;
int mark2 = 12;
int mark3 = 7;

// array can stora multile values of the same type
// type[] name = new type[size] { initial values };

//int[] marks = new int[10]; // 0 by default
//int[] marks = new int[10] { 4, 9, 10, 12, 5, 2, 7, 3, 7, 12 };
int[] marks = { 4, 9, 10, 12, 5, 2, 7, 3, 7, 12 }; // simplify

// access array item: array[index]
// index starts with 0

marks[0] += 2;
Console.WriteLine($"First mark: {marks[0]}");
Console.WriteLine($"Last mark: {marks[9]}");

Console.WriteLine($"Marks count: {marks.Length}");

// show all marks
for (int i = 0; i < marks.Length; i++)
{
    Console.WriteLine($"[{i}]: Student mark = {marks[i]}");
}

// show student's average mark
int summ = 0;
//for (int i = 0; i < marks.Length; i++)
//{
//    summ += marks[i];
//}
foreach (int m in marks)
{
    summ += m;
}
Console.WriteLine($"Average mark: {(float)summ / marks.Length}");

// ---------- foreach (type name in collection) { ...code... }
Console.Write("Marks: ");
foreach(int m in marks)
{
    //m += 2; // cannot change the value
    Console.Write($"{m} ");
}
