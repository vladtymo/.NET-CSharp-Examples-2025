using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Xml.Serialization;

namespace _23_serialization
{
    // Attribute - add some metadata to a member (field, property, method, class...)

    [Serializable]
    public class Address
    {
        public string City { get; set; }
        public string Street { get; set; }
        public int BuilingNumber { get; set; }

        public override string ToString()
        {
            return $"{City}, {Street} {BuilingNumber}";
        }
    }

    [Serializable] // create graph of all object dependencies
    public class User
    {
        // Ignore all fields by default in JSON and XML
        [NonSerialized]
        public const string type = "User";

        //[JsonInclude] // mark field as serializable (public only)
        private int id;

        public string Username { get; set; }
        public string Email { get; set; }

        [JsonIgnore]
        [XmlIgnore]
        public string? Password { get; set; }
        public DateTime Birthdate { get; set; }
        public string[] Roles { get; set; }
        public Address Address { get; set; }

        // Serializaers required a default constructro
        public User() { }
        public User(int id)
        {
            this.id = id;
        }

        public override string ToString()
        {
            return $"User [{id}]: {Username}, " +
                $"Email: {Email}, " +
                $"Password: {Password ?? "hidden"}, " +
                $"Birthdate: {Birthdate.ToLongDateString()}\n" +
                $"Address: {Address}\n" +
                $"Roles: {string.Join('/', Roles)}";
        }

    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            User me = new(3322)
            {
                Email = "tymo@gmail.com",
                Username = "vlad33",
                Birthdate = new DateTime(2000, 2, 2),
                Password = "Qwer#@",
                Roles = new[] {"Moderator", "Admin", "Manager" },
                Address = new() { City = "Rinve", Street = "Soborna", BuilingNumber = 45 }
            };

            List<User> users = new()
            {
                me,
                new User(1004) { Username = "Test", Email = "test@ukr.net", Password = "1", Birthdate = DateTime.Now }
            };

            // ----------------- Serialization -----------------
            // -------------------------------------------------
            // .Serialize()   - convert object type to format (JSON, XML...)
            // .Deserialize() - create object from serialized data

            // ----------------- JSON -----------------
            // create JSON from object
            string json = JsonSerializer.Serialize(me);

            // save JSON string to file
            File.WriteAllText("data.json", json);

            // read JSON from file
            string jsonResult = File.ReadAllText("data.json");
            User? userResult = JsonSerializer.Deserialize<User>(jsonResult);

            Console.WriteLine(userResult?.ToString());

            // serialize collection of the objects
            File.WriteAllText("users.json", JsonSerializer.Serialize(users));

            // ----------------- XML -----------------
            XmlSerializer xmlSerializer = new(typeof(User));

            using (FileStream fs = File.Create("user.xml"))
            {
                xmlSerializer.Serialize(fs, me);
            }

            User? userFromXML = null;
            using (FileStream fs = File.OpenRead("user.xml"))
            {
                userFromXML = xmlSerializer.Deserialize(fs) as User;
            }
            Console.WriteLine(userFromXML?.ToString());

            // ----------------- Binary -----------------
            BinaryFormatter formatter = new();

            using (FileStream fs = File.Create("user.bin"))
            {
                formatter.Serialize(fs, me);
            }

            User? userFromBanary = null;
            using (FileStream fs = File.OpenRead("user.bin"))
            {
                userFromBanary = formatter.Deserialize(fs) as User;
            }
            Console.WriteLine(userFromBanary?.ToString());
        }
    }
}