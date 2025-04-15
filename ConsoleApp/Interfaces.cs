using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    // All interface names being with "I" 
    interface IBase
    {
        void Show(); //Method declaration
        string Name { get; } //Property declaration
    }
    interface IDerived : IBase
    {
        void Execute(); 
    }
    interface ITransact
    {
        void Execute();
    }
    internal class InterfaceImplementation : IDerived, ITransact
    {
        public string Name { get { return GetType().Name; } }
        public void Execute()
        {
            Console.WriteLine($"{nameof(InterfaceImplementation)}.{nameof(Execute)}() called.");
        }
        public void Show()
        {
            Console.WriteLine($"{nameof(InterfaceImplementation)}.{nameof(Show)}() called.");
           //Execute();
        }
        //Explicit interface implementation
        //Methods cannot be marked as public - implicitly public 
        // cannot be marked as virtual or abstract
        // Cannot be invoked in the rest of the class 
        void IDerived.Execute()
        {
            Console.WriteLine($"{nameof(IDerived)}.{nameof(Execute)}() called.");
        }
        void ITransact.Execute()
        {
            Console.WriteLine($"{nameof(ITransact)}.{nameof(Execute)}() called.");
        }
    }
    internal class Interfaces
    {
        internal static void Test()
        {
            InterfaceImplementation obj = new InterfaceImplementation();
            obj.Show();
            obj.Execute();
            Console.WriteLine($"Name: {obj.Name}");
            Console.WriteLine("----------------------------------------");
            IBase ib = obj;
            ib.Show();
            Console.WriteLine($"Name: {ib.Name}");
            Console.WriteLine("----------------------------------------");
            IDerived id = obj;
            id.Show();
            id.Execute();
            Console.WriteLine($"Name: {id.Name}");
            Console.WriteLine("----------------------------------------");
            ITransact it = obj;
            it.Execute();
            Console.WriteLine("----------------------------------------");
        }
    }
}
