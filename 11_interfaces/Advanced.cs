using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11_interfaces
{
    interface A
    {
        private int PrivateProperty { get => 4; }
        private void PrivateMethod()
        {
            Console.WriteLine("I am a private method!");
        }
        protected void ProtectedMethod()
        {
            Console.WriteLine("I am a protected method!");
        }

        void DoWorkA()
        {
            Console.WriteLine(PrivateProperty);
            PrivateMethod();
            ProtectedMethod();

            Console.WriteLine("Additional logic...");
        }
    }
    interface B : A
    {
        void DoWorkB()
        {
            //PrivateMethod(); // cannot access private method
            ProtectedMethod();
        }
    }
}
