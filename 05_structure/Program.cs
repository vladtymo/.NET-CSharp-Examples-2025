struct User
{
    public int ID { get; set; }
    public string Email { get; set; }
    public string? Address { get; set; }
    public double Bonus { get; set; }
    public bool IsAdmin { get; set; }

    public override string ToString()
    {
        return $"[{ID}] - {Email} Address: {Address ?? "Bomj"} Bonus: {Bonus}";
    }
}

internal class Program
{
    private static void Main(string[] args)
    {
        //int id = 1002;
        //string email = "vlad@ukr.net";
        //string address = "Rivne, Ukraine";
        //double bonus = 50.5;
        //bool isAdmin = false;

        User me = new User()
        {
            ID = 1004,
            Email = "vlad@ukr.net",
            Bonus = 33.5,
            IsAdmin = true
        };
        // name.member
        me.Address = "Rivne, Ukraine";
        //...

        Console.WriteLine($"User ID: {me.ID}");
        Console.WriteLine($"User information: {me}");
    }
}