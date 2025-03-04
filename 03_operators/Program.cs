// -=-=-=-=-=-=-=-=-=- Operators -=-=-=-=-=-=-=-=-=-
// ---------- ariphmetic: + - * / %

int a = 5, b = 2;

Console.WriteLine($"A + B: {a + b}");
Console.WriteLine($"A - B: {a - b}");
Console.WriteLine($"A * B: {a * b}");
Console.WriteLine($"A / B: {a / b}");
Console.WriteLine($"A % B: {a % b}");

// return type = biggest operand type

Console.Write("Enter number: ");
a = int.Parse(Console.ReadLine());

Console.WriteLine($"Last number digit: {a % 10}"); // 123 / 10 = 12.3

int result = (2 + 2) * 2; // 8

// midify the value: += -= *= %=
a += 10; // a = a + 10;
Console.WriteLine($"A = {a}");

// ------- increment / decrement: ++ --
++a; // prefix form
Console.WriteLine($"A = {a}");

a = 10;
// postfix form
//int c = a++ * 2; // 20
int c = ++a * 2;   // 22

// ---------- logic: > < >= <= == != 

a = 5;
b = 2;

// logic operator return: true / false (bool)

Console.WriteLine($"A > B: {a > b}");
Console.WriteLine($"A < B: {a < b}");
Console.WriteLine($"A >= B: {a >= b}");
Console.WriteLine($"A <= B: {a <= b}");
Console.WriteLine($"A == B: {a == b}");
Console.WriteLine($"A != B: {a != b}");

if (a > b) 
{
    // do this if condition is TRUE
    Console.WriteLine("A is bigger than B!");
}

// logic combination: && (and) || (or)

Console.Write("Enter number: ");
int number = int.Parse(Console.ReadLine());
// check for range (10...50)

Console.WriteLine($"In range (10...50): {number >= 10 && number <= 50}");
Console.WriteLine($"Out of range (10...50): {number < 10 || number > 50}");

// logic negative: !
Console.WriteLine($"Negative of A > B: {!(a > b)}");

// ---------- ternary operator: (condition ? value_if_true : value_if_false)
if (number > 0)
{
    Console.WriteLine("Positive");
}
else
{
    Console.WriteLine("Negative");
}

Console.WriteLine((number > 0) ? "Positive" : "Negative");


Console.WriteLine($"Your number is: {(number > 0 ? "Positive" : (number < 0) ? "Negative" : "Zero")}");

// avoid negitive values
result = (number >= 0 ? number : 0);