// Task 1 - example
public class Evaluation
{
    public static void Main()
    {
        if (int.TryParse(Console.ReadLine(), out int side))
        {
            Console.WriteLine($"Area: {side * side}");
        }
        else
        {
            Console.WriteLine("Please, enter an integer value");
        }
    }
}