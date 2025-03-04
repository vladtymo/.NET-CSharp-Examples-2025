using System.Collections;

namespace _12_system_interfaces
{
    class Player : IComparable<Player>, ICloneable
    {
        public int Number { get; set; }
        public string? Name { get; set; }
        public int Goals { get; set; }
        public int Games { get; set; }
        public double Productivity => Math.Round((double)Goals / Games, 1);

        public object Clone()
        {
            // shallow copy - copy value types only
            Player copy = (Player)this.MemberwiseClone();

            // deep copy - copy all referece objects
            copy.Name = (string)this.Name?.Clone();
            // copy other reference types...

            return copy;
        }

        public int CompareTo(Player? other)
        {
            // you can write custom logic here...
            return this.Productivity.CompareTo(other.Productivity);
        }

        public override string ToString()
        {
            return $"Player [{Number}]: {Goals}/{Games} - KPD: {Productivity}";
        }
    }

    class Team : IEnumerable
    {
        private Player[] players;
        public string Name { get; set; }

        public Team(string name)
        {
            Name = name;

            var rand = new Random();

            int count = rand.Next(5, 10);
            players = new Player[count];

            for (int i = 0; i < players.Length; i++)
            {
                players[i] = new Player()
                {
                    Number = rand.Next(100),
                    Games = rand.Next(20, 200),
                    Goals = rand.Next(10, 500)
                };
            }
        }

        public IEnumerator GetEnumerator()
        {
            return players.GetEnumerator();
        }
        public void Sort()
        {
            // Array.Sort() - requires IComparable<> interface from array item
            Array.Sort(this.players);
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Team team = new Team("Dream Team");

            team.Sort();

            // foreach() - requires IEnumerable interface implementation
            foreach (var p in team)
            {
                Console.WriteLine(p);
            }

            Player player = new Player() { Number = 9, Games = 44, Goals = 67 };

            Player copy = (Player)player.Clone();

            Console.WriteLine("Player copy...");
            player.Games++;
            Console.WriteLine(copy);
        }
    }
}