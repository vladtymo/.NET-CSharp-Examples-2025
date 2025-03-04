using System.Net.Mail;

namespace _11_interfaces
{
    // --------------- interface - defines public object interface members
    // interface can contains: methods, properties, indexers, events

    // create syntax: interface Name { ... members ... }
    // interface naming: I{Behaviour}

    interface IMovable
    {
        // public by default
        float Speed { get; set; }

        // interface can has a default realizations
        void Move()
        {
            Console.WriteLine($"Animal is moving with speed of {Speed}km/h...");
        }
    }

    // interface inheritance: interface IA : IB
    interface IRunnable : IMovable
    {
        void Run();
    }
    interface ISwimable
    {
        float SwimmingDepth { get; set; }
        void Swim();
    }
    interface IFlyable
    {
        float FlyingHeight { get; set; }
        void Fly();
    }

    // realization syntax: class Name : Interface, Interface2...
    class Tiger : IRunnable
    {
        public float Speed { get; set; }
        public double Weight { get; set; }

        // Move() - has a default realization

        public void Run()
        {
            Console.WriteLine($"Tiger is running with the speed of {Speed}km/h...");
        }
    }

    class Parrot : IFlyable
    {
        public float FlyingHeight { get; set; }
        public double Weight { get; set; }

        public void Fly()
        {
            Console.WriteLine($"Parrot is flying up to the {FlyingHeight}m of height...");
        }
    }
    class Shark : ISwimable
    {
        public float SwimmingDepth { get; set; }
        public double Weight { get; set; }

        public void Swim()
        {
            Console.WriteLine($"Shark is swimming up to the {SwimmingDepth}m of depth...");
        }
    }
    class Chicken : IRunnable, IFlyable
    {
        public float Speed { get; set; }
        public float FlyingHeight { get; set; }
        public double Weight { get; set; }

        // custom Move() method realization
        public void Move()
        {
            Console.WriteLine("Chicken is moving in a custom way...");
        }
        public void Run()
        {
            Console.WriteLine($"Chicken is running with the speed of {Speed}km/h...");
        }
        public void Fly()
        {
            Console.WriteLine($"Chicken is flying up to the {FlyingHeight}m of height...");
        }
    }

    class Kangaroo : IRunnable
    {
        public float Speed { get; set; }
        public float JumpingHeight { get; set; }

        public void Run()
        {
            Console.WriteLine($"Kangaroo is running with the speed of {Speed}km/h...");
        }

        public void Jump()
        {
            Console.WriteLine($"Kangaroo can jump up to the {JumpingHeight}m...");
        }
    }

    internal class Program
    {
        static void RunAnimal(IRunnable animal)
        {
            Console.WriteLine(new String('-', 40));
            Console.WriteLine($"Animal can run up to the speed of {animal.Speed}km/h!");
            animal.Move();
            animal.Run();
        }
        static void Main(string[] args)
        {
            Tiger tiger = new Tiger()
            {
                Speed = 56,
                Weight = 60.5
            };
            Shark shark = new() { Weight = 205.5, SwimmingDepth = 1890 };
            Parrot parrot = new() { Weight = 205.5, FlyingHeight = 2400 };
            Chicken chicken = new() { Weight = 205.5, FlyingHeight = 25, Speed = 33.4F };
            Kangaroo kangaroo = new() { Speed = 70, JumpingHeight = 4.3F };

            // --------- test methods
            tiger.Run();
            chicken.Fly();
            chicken.Run();

            // --------- interface references
            //IRunnable runnable = new IRunnable(); // cannot create interface instance
            IRunnable runnable = tiger;
            runnable = chicken;

            //runnable.Run(); // chicken is running...

            RunAnimal(tiger);
            RunAnimal(chicken);
            RunAnimal(kangaroo);

            // --------- array of the interface
            IFlyable[] birds = new IFlyable[]
            {
                chicken,
                parrot,
                new Chicken() { Weight = 15, FlyingHeight = 19.5F, Speed = 29 }
            };
            Console.WriteLine("---------- Birds ----------");
            foreach (IFlyable bird in birds)
            {
                Console.WriteLine($"Bird can fly up to the {bird.FlyingHeight}m!");
                //bird.Fly();
            }
        }
    }
}