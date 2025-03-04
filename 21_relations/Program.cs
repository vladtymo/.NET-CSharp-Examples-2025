using System.Reflection;

namespace _21_relations
{
    public class Processor
    {
        public string Model { get; set; }
        public int Cores { get; set; }
        public float Frequency { get; set; }

        public override string ToString()
        {
            return $"Processor {Model} has {Cores} cores, {Frequency}Ghz";
        }
    }
    public class Battery
    {
        public int Capacity { get; set; }
        public float Voltage { get; set; }

        public override string ToString()
        {
            return $"Battery capacity is {Capacity}mAh on {Voltage} volts";
        }
    }

    public enum Type { IPS, OLED, AMOLED }
    public class Display
    {
        public float Diagonal { get; set; }
        public Type Type { get; set; }
        public int PixelDensity { get; set; }
        public override string ToString()
        {
            return $"{Type} display `{Diagonal} has {PixelDensity}ppi";
        }
    }
    public class Camera
    {
        public string Model { get; set; }
        public int Megapixels { get; set; }
        public float Aperture { get; set; }

        public override string ToString()
        {
            return $"Camera {Model} has {Megapixels}MP and {Aperture}F";
        }
    }

    public class SimCard
    {
        public string Provider { get; set; }
        public string Number { get; set; }

        public override string ToString()
        {
            return $"SIM: {Provider} - {Number}";
        }
    }

    public class SmartPhone
    {
        public string Model { get; set; }
        public string Color { get; set; }

        // composition of the phone
        public Display Display { get; set; }
        public Battery Battery { get; set; }
        public Camera Camera { get; set; }
        public Processor Processor { get; set; }

        // aggregation of the phone
        public SimCard? SIM { get; set; }
        public bool IsSimExists => SIM != null;

        public SmartPhone(string m, string c, int mp, int ppi, float f)
        {
            Model = m;
            Color = c;

            // the SmartPhone is responsible for creating/deleting composition items
            Display = new()
            {
                Diagonal = 4.7F,
                Type = Type.IPS,
                PixelDensity = ppi
            };
            Battery = new()
            {
                Capacity = 4220,
                Voltage = 2.8F
            };
            Processor = new()
            {
                Model = "Snapdragon S500",
                Frequency = 2.5F,
                Cores = 8
            };
            Camera = new()
            {
                Megapixels = mp,
                Aperture = f,
                Model = "Sony X33"
            };
        }

        public void MakeCall(string contact)
        {
            if (!IsSimExists) 
                Console.WriteLine("Insert SIM card to make a call!");
            else
                Console.WriteLine($"Calling {contact}...");
        }
        public void TakePhoto()
        {
            Console.WriteLine("Taking a photo...");
        }

        public void InjectSIM(SimCard sim)
        {
            if (IsSimExists)
            {
                Console.WriteLine("SIM Card is already injected!");
                return;
            }
            SIM = sim;
        }
        public SimCard? EjectSIM()
        {
            var temp = SIM;
            SIM = null;
            return temp;
        }

        public void ShowSpecs()
        {
            Console.WriteLine("---------- Device specifications:");
            Console.WriteLine(Processor);
            Console.WriteLine(Display);
            Console.WriteLine(Camera);
            Console.WriteLine(Battery);
            Console.WriteLine(new string('-', 40));
        }

        public override string ToString()
        {
            return $"Smart Phone: {Model} {Color}";
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            SmartPhone smartPhone = new SmartPhone("Samsung S17", "Black", 12, 332, 1.8F);

            Console.WriteLine(smartPhone);
            smartPhone.ShowSpecs();

            smartPhone.MakeCall("+38097546264");
            smartPhone.TakePhoto();

            // create SIM card instance
            SimCard card = new() { Number = "+38098080808", Provider = "Life" };

            smartPhone.InjectSIM(card);
            smartPhone.InjectSIM(card); // ignore

            smartPhone.MakeCall("911");

            smartPhone.EjectSIM();
            smartPhone.MakeCall("22-55-22"); // not allowed
        }
    }
}