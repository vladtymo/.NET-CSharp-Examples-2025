// --------------------- Selection Statements ---------------------
// block statement: if { }, switch { }
// expression; 2 + 2; int a = 3 * 1;

// --------------- if (condition) { ...code... }
Console.Write("Enter your name: ");
string name = Console.ReadLine();

if (char.IsUpper(name[0]))
{
    Console.WriteLine("Name is correct!");
}
else
{
    Console.ForegroundColor = ConsoleColor.Red; // next output will be red
    Console.WriteLine("Name should starts with upper letter!");
    Console.ResetColor();
}

// we can avoid {} if block has only one statement inside
if (name.Length < 3) 
    Console.WriteLine("Name too short!");
else
    Console.WriteLine("Name has a good length!");

// TASK: enter age, check permisstions
Console.Write("Enter your age: ");
int age = int.Parse(Console.ReadLine());

if (age >= 0 && age <= 16)
    Console.WriteLine("You are young boy!");
else if (age > 16 && age < 50)
    Console.WriteLine("You are adult man!");
else
    Console.WriteLine("You are experienced person!");

// TASK: enter a mark number and show it's description
Console.Write("Enter a mark (1-5): ");
int mark = int.Parse(Console.ReadLine());

// --------------- if (condition) { } else { }
//if (mark == 5)
//{
//    Console.WriteLine("Excellent!");
//}
//else if (mark == 4)
//{
//    Console.WriteLine("Good!");
//}
//else if (mark == 3)
//{
//    Console.WriteLine("Normal!");
//}
//else if (mark == 2)
//{
//    Console.WriteLine("Bad!");
//}
//else if (mark == 1)
//{
//    Console.WriteLine("Very Bad!");
//}
//else
//{
//    Console.WriteLine("Mark is incorrrect!");
//}

// --------------- switch (expression) { case 1: ... break; case 2: ... break; }
switch (mark)
{
    case 1: Console.WriteLine("Very Bad!"); break; // go out of the statement
    case 2: Console.WriteLine("Bad!"); break;
    case 3: Console.WriteLine("Normal!"); break;
    case 4: Console.WriteLine("Good!"); break;
    case 5: Console.WriteLine("Excellent!"); break;
    default:
        Console.WriteLine("Incorrect mark!"); 
        break;
}
