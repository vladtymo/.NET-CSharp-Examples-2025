// ------------------- Multi-Dimentions Arrays -------------------

// create two-dimention array
int[,] matrix = new int[3, 4]
                                {
                                    { 1, 4, 6, 2 },
                                    { 6, 1, 6, 7 },
                                    { 1, 5, 0, 2 }
                                };

matrix[1, 0] = 20;
Console.WriteLine($"Element [2:1] = {matrix[2, 1]}");

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
