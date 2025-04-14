using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    public /*sealed*/ class BaseClass
    {
        private int _private;
        public int _public;
        protected int _protected;
        internal int _internal;
        protected internal int _pI;

        public BaseClass()
        {
            Console.WriteLine("BaseClass.ctor( void ) called.");
        }
        public BaseClass(int num)
        {
            _private = _public = _protected = _internal = _pI = num;
            Console.WriteLine("BaseClass.ctor( int ) called.");
        }
        public virtual void Show()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("BaseClass.Show() called with: ")
                .AppendLine($"Private Field: {_private}")
                .AppendLine($"Public Field: {_public}")
                .AppendLine($"Protected Field: {_protected}")
                .AppendLine($"Internal Field: {_internal}")
                .AppendLine($"Protected Internal Field: {_pI}");
            Console.WriteLine(sb.ToString());
        }
        public abstract void Hide(); 
    }
    public class DerivedClass : BaseClass
    {
        public DerivedClass()
        {
            Console.WriteLine("DerivedClass.ctor ( void ) called.");
        }
        public DerivedClass(int num) : base(num)
        {
            Console.WriteLine("DerivedClass.ctor ( int ) called. ");
        }
        public override void Show()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("DerivedClass.Show() called with: ")
               // .AppendLine($"Private Field: {_private}")
                .AppendLine($"Public Field: {_public}")
                .AppendLine($"Protected Field: {_protected}")
                .AppendLine($"Internal Field: {_internal}")
                .AppendLine($"Protected Internal Field: {_pI}");
            Console.WriteLine(sb.ToString());
        }
        public override void Hide() { }
    }

    public class Inheritance
    {
        static void DoWork(BaseClass dc)
        {
            dc.Hide();
        }
        public static void Test()
        {
            
            BaseClass bc1 = new BaseClass();
            bc1.Show();
            Console.WriteLine("---------------------------------------------");
            BaseClass bc2 = new BaseClass(9999);
            bc2.Show();
            Console.WriteLine("---------------------------------------------");
            DerivedClass dc1 = new DerivedClass();
            dc1 .Show();
            Console.WriteLine("---------------------------------------------");
            DerivedClass dc2 = new DerivedClass(4321); 
            dc2.Show();
            Console.WriteLine("---------------------------------------------");

            bc1 = dc1; //implicit base object is assigned to bc1 
            //bc1 = dc1.base; 

            bc1.Show(); //==> print the derived class Show() 
            DoWork(dc1);

        }
    }
}
