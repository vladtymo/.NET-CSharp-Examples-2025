//const int Forward = 1;
//const int Right = 2;
//const int Left = 3;
//const int Backward = 4;

// ------------------- enumeration (enum)
enum Direction
{
    // start = 0, next = previous + 1
    Forward = 1, Left, Right, Backward
}

internal class Program
{
    private static void Main(string[] args)
    {
        // create enum variable
        Direction startDirection = Direction.Left;

        Console.WriteLine("\tChoose direction:\n" +
        $"{Direction.Forward} - Move Forward\n" +
        $"{(int)Direction.Right} - Turn Rigth\n" +
        "3 - Turn Left\n" +
        "4 - Move Backward");

        Console.Write("Your direction (1-4): ");
        Direction direction = Enum.Parse<Direction>(Console.ReadLine());

        if (direction == Direction.Forward)
            Console.WriteLine("Your are moving North");
        if (direction == Direction.Right)
            Console.WriteLine("Your are moving East");
    }
}