namespace _10_classes
{
    enum Mode { Dry, Cool, Heat }

    public class Conditioner // : object - inheritance base object class by default
    {
        // ------------- fields
        // object attributes
        // default values: numeric = 0, boolean = false, reference = null
        
        string model; // private by default to all class members
        private string color;
        private int temperature; // from 16...32
        private Mode mode; // Dry, Cool, Heat
        private bool isPowerOn;

        // constants - can be initialized only
        public const int MIN_T = 16;
        public const int MAX_T = 32;
        // readonly - can be initialized or set in the constructors
        readonly string serialNumber;

        // ------------- properties
        // getter / setter
        // snippet: propfull
        public int Temperature
        {
            get
            {
                // get block must return a value
                return this.temperature;
            }
            set
            {
                // value - input parameter
                if (value >= MIN_T && value <= MAX_T)
                    this.temperature = value;
            }
        }
        // ---- readonly property
        public string Status
        {
            get
            {
                return this.isPowerOn ? "ON" : "OFF";
            }
        }
        // ---- auto-property
        // snippet: propfull
        //private decimal price;

        //public decimal Price
        //{
        //    get { return price; }
        //    set { price = value; }
        //}
        // ... the same with auto-property
        // snippet: prop
        public decimal Price { get; private set; }
        public DateTime CreationDate { get; } // readonly property

        // ------------- constructors
        // invokes automatically when object is creating
        public Conditioner() : this("no model", "no color") // constructor delegation
        {
        }
        public Conditioner(string model, string color)
        {
            // this - reference to this instance 

            this.model = model;
            this.color = color;
            temperature = MIN_T;
            mode = Mode.Dry;
            isPowerOn = true;
            CreationDate = DateTime.Now;
            serialNumber = $"00{new Random().Next(1000, 9999)}";
        }

        // ------------- methods
        // setter method - to set object property value
        public void SetTemperature(int value)
        {
            // validation - check data correctness 
            if (value >= MIN_T && value <= MAX_T)
                this.temperature = value;
        }
        // getter method - to get object property value
        public int GetTemperature()
        {
            return this.temperature;
        }

        public void SwitchPower()
        {
            isPowerOn = !isPowerOn;
        }
        public void Increase()
        {
            if (temperature < MAX_T)
                ++temperature;
        }
        public void Decrease()
        {
            if (temperature > MIN_T)
                --temperature;
        }

        public override string ToString()
        {
            return $"Conditioner: {model} {color}, Status: {Status}, T: {temperature}^C...  Serial: {serialNumber}";
        }

        // ------------------- overload operators
        // static method does not access to [this]
        
        // syntax: static return_type operator[symbol](parameters) { ... }
        public static Conditioner operator++(Conditioner conditioner)
        {
            conditioner.Increase();
            return conditioner;
        }

        public static bool operator >(Conditioner left, Conditioner right)
        {
            return left.Temperature > right.Temperature;
        }
        public static bool operator <(Conditioner left, Conditioner right)
        {
            return left.Temperature < right.Temperature;
        }

        public static explicit operator int(Conditioner conditioner)
        {
            return conditioner.Temperature;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            // --------- create instance of the class
            Conditioner my = new Conditioner("Samsung", "White"); // invoke constructor
            
            my.SwitchPower();
            Console.WriteLine($"My conditioner status: {my.Status}");

            Console.WriteLine($"My conditioner created at: {my.CreationDate}");

            //my.temperature = -1; // cannot access to private member

            for (int i = 0; i < 50; i++) 
                my.Increase();

            // ---- using get/set methods
            my.SetTemperature(-39); // ignore
            Console.WriteLine($"Current temperature: {my.GetTemperature()}^C");

            // ---- using property
            my.Temperature = -45; // set
            Console.WriteLine($"Current temperature: {my.Temperature}^C"); // get

            Console.WriteLine(my);

            Conditioner your = new Conditioner();
            your.Decrease();

            Console.WriteLine(your);

            // ------------------- Conditioner operators
            Conditioner his = ++my;

            if (my > your)
                Console.WriteLine("My is bigger than your!");

            int number = (int)my; // explicit only
            Console.WriteLine($"Conditioner as a number: {number}");
        }
    }
}