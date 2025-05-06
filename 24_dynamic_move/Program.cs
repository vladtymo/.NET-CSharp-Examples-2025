enum Direction
{
    Up,
    Right,
    Down,
    Left
}

class Snake
{
    public int Size { get; set; }
    public char Symbol { get; set; }
    public int X { get; set; }
    public int Y { get; set; }
    public ConsoleColor Color { get; set; }
    public Direction Direction { get; set; }

    public Snake(int x = 0, int y = 0)
    {
        Size = 1;
        Symbol = '\uD83D';
        X = x;
        Y = y;
        Color = ConsoleColor.Green;
        Direction = Direction.Right;
    }

    public void Clear()
    {
        Console.SetCursorPosition(X, Y);
        Console.Write(" ");
    }
    public void Draw()
    {
        Console.SetCursorPosition(X, Y);
        Console.ForegroundColor = Color;
        Console.Write(Symbol);
        Console.ResetColor();
    }

    public void Move()
    {
        Clear();
        switch (Direction)
        {
            case Direction.Up:
                Y--;
                break;
            case Direction.Right:
                X++;
                break;
            case Direction.Down:
                Y++;
                break;
            case Direction.Left:
                X--;
                break;
        }
        Draw();
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.CursorVisible = false;

        Snake snake = new(10, 10);
        snake.Draw();

        while (true)
        {
            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo key = Console.ReadKey(true);
                switch (key.Key)
                {
                    case ConsoleKey.UpArrow:
                        snake.Direction = Direction.Up;
                        break;
                    case ConsoleKey.RightArrow:
                        snake.Direction = Direction.Right;
                        break;
                    case ConsoleKey.DownArrow:
                        snake.Direction = Direction.Down;
                        break;
                    case ConsoleKey.LeftArrow:
                        snake.Direction = Direction.Left;
                        break;
                }
            }
            snake.Move();
            Thread.Sleep(100);
        }
    }
}