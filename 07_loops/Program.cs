// ------------------------ Iteration Statements ------------------------
// loops: while, do while, for

// bad practice
Console.WriteLine("Order 1: ");
Console.WriteLine("Order 1: ");
Console.WriteLine("Order 3: ");

// ------------ while (condition) { ...do iteration... }

Console.Write("How much many do you have?\nEnter a value (UAH): ");
decimal money = decimal.Parse(Console.ReadLine());

while (money >= 100)
{
    Console.WriteLine("You can buy a product by 100UAH!");
    money -= 100;
    Console.WriteLine($"Now you have {money} UAH...");
}

// check if age is correct

// ------------ do { ...code... } while(condition);
int age = 0;
do
{
    Console.Write("Enter your age: ");
    age = int.Parse(Console.ReadLine());

} while (age < 0 || age > 120);

Console.WriteLine("Continue...");

// iteration loop
int count = 0; // create counter

while (count < 10) // check condition
{
    Console.WriteLine($"while: [{count}] Iteration!");
    ++count; // do expression
}

// we can do the same with the for loop

// ------------ for (initialize; condition; expression) { ...code... }
for (int i = 0; i < 10; ++i)
{
    Console.WriteLine($"\tfor: [{i}] Iteration!");
}

// TASK: show numbers in the range except even by 3

// break    - go out of this statement
// continue - skip current loop iteration

for (int i = 1; i <= 20; i++)
{
    if (i % 10 == 0) break;   // end loop
    if (i % 3 == 0) continue; // go to the next iteration
    Console.WriteLine($"Number: {i}");
}
