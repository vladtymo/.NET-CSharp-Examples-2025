internal class Program
{
    private static void Main(string[] args)
    {
        // string str = null;
        // str.Replace('#', '@'); // NullReferenceException
        // Unhandled exception -> app aborted 

        //ExceptionsExample();
        //FinallyExample();
        ThrowExample();

        Console.WriteLine("Continue........");
    }

    private static void ExceptionsExample()
    {
        try
        {
            // code with exceptions

            Console.Write("Enter current year: ");
            int year = int.Parse(Console.ReadLine()); // Exception reised

            // try block is stoped -> go to the catch block

            Console.WriteLine($"Next year is {year + 1}");
        }
        catch (ArgumentNullException ex)
        {
            // handle exception logic...
            Console.WriteLine($"Argument Null: {ex.Message}");
        }
        //catch (FormatException ex)
        //{
        //    Console.WriteLine($"Invalid format: {ex.Message}");
        //}
        //catch (OverflowException ex)
        //{
        //    Console.WriteLine($"Overflow: {ex.Message}");
        //}
        catch (Exception ex)
        {
            Console.WriteLine($"Something went wrong: {ex.Message}");
        }
    }
    private static void FinallyExample()
    {
        var writer = File.AppendText("text.txt"); // create file near .exe

        //stream.Write(); - write data to file
        //stream.Read();  - read data from file

        try
        {
            Console.Write("Enter current year: ");
            int year = int.Parse(Console.ReadLine()); // ! might be exception

            writer.WriteLine($"Current year is {year}");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        finally
        {
            // invoke whether exception was raised or not

            // clear resources
            Console.WriteLine("Clear resources...");
            writer.Close();
        }
    }
    private static void ThrowExample()
    {
        User user = new() { Name = "Nazar", Age = 44 };

        //bool isValid = false;
        //do
        //{
        //    try
        //    {
        //        Console.Write("Enter user name: ");
        //        user.Name = Console.ReadLine();
        //        isValid = true;
        //    }
        //    catch (ArgumentException ex)
        //    {
        //        Console.WriteLine(ex.Message);
        //    }

        //} while (!isValid);

        Console.WriteLine(user);
    }
}

public class User
{
    private string name;
    private int age;

    public string Name
    {
        get { return name; }
        set 
        {
            if (value.Length < 3 || !char.IsUpper(value[0]))
                throw new ArgumentException("Name must be start with upper letter and has more then 2 characters");
            name = value; 
        }
    }

    public int Age
    {
        get { return age; }
        set 
        {
            if (value < 0 || value > 120)
                throw new ArgumentException("Age must be in the range 0...120");
            age = value;
        }
    }


    public override string ToString()
    {
        //if (Age < 18) return "Young user";
        //else return "Old user";
        // using thernary operator
        //return Age < 18 ? "Young user" : "Old user";

        //if (Name == null) return "no name";
        // using [??] null-condition operator
        //Name ?? "no name"

        return $"User: {Name ?? "no name"} is {Age} years old";
    }
}