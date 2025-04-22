// ------------------- Multi-Dimentions Arrays -------------------

// create two-dimention array
int[,] matrix = new int[3, 4]
                                {
                                    { 1, 4, 6, 2 },
                                    { 6, 1, 6, 7 },
                                    { 1, 5, 0, 2 }
                                };

matrix[1, 0] = 20;
Console.WriteLine($"Element [2:1] = {matrix[2, 1]}"); // 5

Console.WriteLine($"Length: {matrix.Length}");
Console.WriteLine($"Dim-1 Length: {matrix.GetLength(0)}");
Console.WriteLine($"Dim-2 Length: {matrix.GetLength(1)}");

Console.WriteLine("-----------\nMatrix:");
for (int r = 0; r < matrix.GetLength(0); r++)
{
    for (int c = 0; c < matrix.GetLength(1); c++)
    {
        Console.Write(matrix[r, c] + "\t");
    }
    Console.WriteLine();
}

// 0 - empty
// 1 - white
// 2 - black
// 3 - queen

int[,] board = new int[8, 8]
                        {
                            { 0, 1, 3, 1, 0, 1, 3, 1 },
                            { 0, 1, 2, 1, 0, 3, 3, 1 },
                            { 2, 1, 2, 0, 0, 2, 1, 1 },
                            { 0, 1, 1, 1, 0, 1, 3, 1 },
                            { 3, 1, 1, 3, 1, 0, 3, 1 },
                            { 0, 1, 2, 1, 0, 1, 2, 3 },
                            { 1, 1, 1, 2, 3, 1, 3, 1 },
                            { 0, 2, 2, 1, 0, 1, 3, 1 },
                        };

Console.WriteLine("-----------\nMatrix:");
for (int r = 0; r < board.GetLength(0); r++)
{
    for (int c = 0; c < board.GetLength(1); c++)
    {
        switch (board[r, c])
        {
            case 0: Console.Write("  "); break;
            case 1: Console.Write("+ "); break;
            case 2: Console.Write("- "); break;
            case 3: Console.Write("* "); break;
            default:
                break;
        }
        
    }
    Console.WriteLine();
}

enum Cell
{
    N, W, B, Q
};