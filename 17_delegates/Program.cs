namespace _17_delegates
{
    // --------------- Delegates ---------------
    // delegate store references to the methods
    // method prototype: return_type + (param1, param2...)
    // create delegate syntax: delegate return_type Name(parameters);
    public delegate void Greeting(string message);
    public delegate void Operation(double a, double b);
    public delegate bool CheckValue(int value);

    internal class Program
    {
        static void Main(string[] args)
        {
            // -------------------- Greeting Delegate
            // create delegate instance
            Greeting greeting = ShowMessage; // save method reference

            // delegate invokation
            greeting.Invoke("Hello from Delegate!"); // invoke using Invoke()
            greeting("Hello...");                    // invoke using operator()

            // change method reference
            greeting = ShowYourName; 
            greeting("Vladyslav");

            // -------------------- Operation Delegate
            Operation operation = Add; // new Operation(Add);

            //operation = null;
            operation?.Invoke(3, 5); // check if operation delegate is not null here

            // change method reference
            operation = Div;

            operation?.Invoke(30, 5);

            // -------------------- Multicast Delegate
            // add method reference: +=
            operation += Mult;
            operation += Sub;
            operation += Sub;
            // substract reference: -=
            operation -= Div;

            Console.WriteLine("---------- Multicast invoke");
            // invoke all methods and return the last one result value
            operation(20, 5);

            // -------------------- Array Filter 
            int[] numbers = { 4, 6, -13, 0, -4, 1, 66, 3, 8, 120, 23, -9, 0, 3 };

            Filter(numbers, IsTwoDigits);                               // IsTwoDigits method
            Filter(numbers, delegate (int n) { return n % 2 == 0; });   // anonymous delegate
            Filter(numbers, (n) => n < 0);                              // lambda expression

            // -------------------- Built-In Delegates
            // Action<> - can store methods without return value (void)
            Action<string> show = ShowMessage;

            Action action = () => Console.WriteLine("Hello Action!");
            action += () =>
            {
                Console.ForegroundColor = ConsoleColor.Black;
                Console.BackgroundColor = ConsoleColor.White;
                Console.WriteLine("Second Action!");
                Console.ResetColor();
            };

            action();

            // Func<> - always return a value
            Func<float, float, double> ariphmetic = (a, b) =>
            {
                return (a - b) + a * b;
            };
            double result = ariphmetic(10, 53);
            Console.WriteLine($"Result: {result}");

            // Predicate<> - always return a boolean type
            Predicate<int> check = IsTwoDigits;
        }

        static void Filter(int[] array, CheckValue check)
        {
            Console.Write("Filtered Array: ");
            foreach (int item in array)
            {
                if (check(item))
                    Console.Write(item + " ");
            }
            Console.WriteLine();
        }

        // ------------- Check Number methods
        static bool IsTwoDigits(int number)
        {
            return Math.Abs(number).ToString().Length == 2;
        }

        // ------------- Greeting methods
        static void ShowMessage(string message)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(message);
            Console.ResetColor();
        }
        static void ShowYourName(string name)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Hi, dear {name}!");
            Console.ResetColor();
        }

        // ------------- Operations Methods
        static void Add(double a, double b)
        {
            Console.WriteLine($"Add operation: {a} + {b} = {a + b}");
        }
        static void Div(double a, double b)
        {
            Console.WriteLine($"Divide operation: {a} / {b} = {a / b}");
        }
        static void Mult(double a, double b)
        {
            Console.WriteLine($"Multiply operation: {a} * {b} = {a * b}");
        }
        static void Sub(double a, double b)
        {
            Console.WriteLine($"Substract operation: {a} - {b} = {a - b}");
        }
    }
}