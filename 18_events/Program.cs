namespace _18_events
{
    // --------------- Events
    //public delegate void Reaction(int age);

    class Human
    {
        public string Name { get; set; }
        public DateTime Birthdate { get; set; }
        public int Age => DateTime.Now.Year - Birthdate.Year;

        // [event] - encapsulate delegate and give [+=] and [-=] operators to public
        public event Action<int> Celebration;

        public void Celebrate()
        {
            Console.WriteLine($"I am {Name}! I celebrating my birthdate now...");
            Console.WriteLine($"I'am {Age} years old!");

            // notify friends
            Celebration?.Invoke(Age);
        }
    }

    class Friend
    {
        public string Name { get; set; }

        public void Congratulate(int age)
        {
            Console.WriteLine($"Congratulations from {Name}...");
            if (age < 18)
                Console.WriteLine("I gifting you a packet of milk!");
            else
                Console.WriteLine("I gifting you a red wine!");
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Human human = new Human()
            {
                Name = "Oscar",
                Birthdate = new DateTime(2009, 4, 1)
            };

            Friend friend1 = new() { Name = "Bob" };
            Friend friend2 = new() { Name = "Olga" };
            Friend friend3 = new() { Name = "Viktoria" };

            // subscribe to the event
            human.Celebration += friend1.Congratulate;
            human.Celebration += friend2.Congratulate;
            human.Celebration += friend3.Congratulate;
            // unsubscribe from the event
            human.Celebration -= friend3.Congratulate;

            //human.CelebrationEvent = null;

            // start celebration
            human.Celebrate();
        }
    }
}
