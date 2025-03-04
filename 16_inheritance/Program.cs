namespace _16_inheritance
{
    interface ICanDisplay
    {
        float Diagonal { get; }
        void ShowPicture();
    }

    // -------------- Inheritance --------------
    public enum DisplayType { OLED, IPS, LCD, LED, AMOLED };

    // base class - class which inherited by another class
    abstract class Device
    {
        // [protected] - give an access in derived classes also
        protected bool isPowerOn;
        public string Model { get; set; }
        public string SerialNumber { get; } // readonly property
        public string PowerStatus => isPowerOn ? "ON" : "OFF";

        public Device(string model, string serialN, bool power = false)
        {
            this.Model = model;

            if (string.IsNullOrWhiteSpace(serialN) || serialN.Length < 3) 
                SerialNumber = "00000000";
            else
                this.SerialNumber = serialN;

            this.isPowerOn = power;
        }

        public void SwitchPower()
        {
            isPowerOn = !isPowerOn;
        }

        // we can implement polymorphism by using [virtual] and [override] keywords
        public abstract void DoWork();

        public void ShowInfo()
        {
            Console.WriteLine($"Model: {Model} | Power: {PowerStatus}");
        }

        public override string ToString()
        {
            return $"-----------------\n" +
                $"Device {Model} | Serial Number: {SerialNumber.First()}{new string('X', SerialNumber.Length - 2)}{SerialNumber.Last()}";
        }
    }

    // derived classes - which inherite a base class
    // inheritance syntax: class DerivedClass : ParentClass, Interface1, Interface2...
    // C# does not support multiple inheritance
    class Printer : Device
    {
        // additional members
        public int TotalPages { get; set; }
        public int Cartridges { get; set; }

        // [base] - reference to the parent class instance
        public Printer(string model, string serialN, int cartridges) : base(model, serialN)
        {
            TotalPages = 0;
            this.Cartridges = cartridges;
        }

        public void PrintDocument(string name)
        {
            if (!isPowerOn)
            {
                Console.WriteLine("Printed should be turner ON to print!");
                return;
            }

            Console.WriteLine($"Printing {name} document using {Cartridges} colors...");
            ++TotalPages;
        }

        // create [new] ShowInfo() methods and hide the inherited one
        public new void ShowInfo()
        {
            base.ShowInfo();
            Console.WriteLine($"Printed pages: {TotalPages}");
        }

        // [override] methods change the base method realisation
        public override void DoWork()
        {
            PrintDocument("test.rtf");
        }
    }

    class Monitor : Device, ICanDisplay
    {
        public int PixelDensity { get; set; }
        public DisplayType DisplayType { get; set; }
        public float Diagonal { get; set; }

        public Monitor(string model, string serialN, int density, DisplayType type) : base(model, serialN)
        {
            this.PixelDensity = density;
            this.DisplayType = type;
        }

        public void ShowPicture()
        {
            Console.WriteLine($"Showing picture on {DisplayType} display with {PixelDensity} ppi...");
        }

        public override void DoWork()
        {
            ShowPicture();
        }
    }

    class TV : Monitor
    {
        private int? currentChannel;
        public int? CurrentChannel
        {
            get => currentChannel;
            set
            {
                if (value > 0 && value <= Channels)
                    this.currentChannel = value;
            }
        }
        public int Channels { get; set; }

        public TV(string model, string serialN, int density, DisplayType type)
            : base(model, serialN, density, type)
        {
            Channels = 0;
            CurrentChannel = null;
        }

        public void SearchChannels()
        {
            Channels = new Random().Next(1, 32);
            Console.WriteLine($"Searching for channels... {Channels} found!");
            CurrentChannel = 1;
        }

        public new void ShowInfo()
        {
            base.ShowInfo();
            Console.WriteLine($"Channel {(CurrentChannel == null ? "none" : CurrentChannel)} / {Channels}");
        }

        public override void DoWork()
        {
            if (CurrentChannel == null)
                Console.WriteLine("No channels to show. Please, search for channels before!");
            else
                Console.WriteLine($"Showing channel {CurrentChannel}...");
        }
    }

    internal class Program
    {
        static void TestDevice(Device device)
        {
            Console.WriteLine($"... Statring to test {device.Model} device ...");
            device.DoWork();
        }

        static void Main(string[] args)
        {
            // -------------- Device
            // ! we can not create an instance of an abstract class
            //Device device = new Device("HP Pavillion", "GYT47582FB4J");

            //Console.WriteLine(device);
            //Console.WriteLine($"Status: {device.PowerStatus}");
            //device.SwitchPower();
            //Console.WriteLine($"Status: {device.PowerStatus}");

            //device.DoWork();

            // -------------- Printer
            Printer printer = new Printer("Canon Pixma", "DF342MF", 5);
            Console.WriteLine(printer);

            printer.SwitchPower();
            printer.PrintDocument("text.pdf");
            printer.PrintDocument("my.png");

            printer.ShowInfo();

            // -------------- Monitor
            Monitor monitor = new Monitor("LG R56", "GF843", 324, DisplayType.IPS);

            Console.WriteLine(monitor);
            monitor.ShowPicture();

            // -------------- TV
            TV tv = new TV("Samsung KL", "7902F", 280, DisplayType.OLED);

            Console.WriteLine(tv);

            tv.SearchChannels();
            tv.CurrentChannel = 20; // ingore if the channel not exist

            tv.ShowInfo();

            // ------------------- Polymorphism -------------------
            Console.WriteLine("--------- Polymorphism ---------");
            Monitor officeMonitor = tv;

            Device device = monitor;

            //officeMonitor.CurrentChannel = 10;
            officeMonitor.ShowInfo();

            Console.WriteLine("----------- Testing Devices -----------");
            TestDevice(tv);
            TestDevice(monitor);
            TestDevice(printer);

            Device[] devices =
            {
                tv,
                monitor,
                printer,
                new TV("LG Smart P", "RE435P", 311, DisplayType.LCD)
            };

            Console.WriteLine("--------- All Devices ---------");
            foreach (Device d in devices)
            {
                d.ShowInfo(); // Device class realisation
                d.DoWork();   // actual class instace realisation
            }
        }
    }
}