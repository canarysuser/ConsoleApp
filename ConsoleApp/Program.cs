using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*  ConsoleOps();
              Constructs();
              ArraysTest();*/
            //Methods.Test();
            /*Employee employee = new Employee();
            employee.Show();
            Employee emp2 = new Employee(
                id: 999,
                name: "ABB",
                salary: 1234.56,
                hiredate: new DateTime(
                    year: 2020,
                    month: 1,
                    day: 31
                    )
                );
            emp2.Show();
            emp2.Id = 98765; //emp2.set_Id(98765)
            emp2.Show();*/

            //Inheritance.Test();
            //AbstractImplementation.Test();
            //Interfaces.Test();
            // MemoryManagement.Test();
            //ExceptionHandling.Test();
            //Console.WriteLine("After the exceptionhandler is executed."); 
            //Delegates1.Test();
            DelegateEvents.Test();
        }
        static void ArraysTest()
        {
            //Fixed sized - ref types
            //An array is an instance of System.Array class 
            // holds a collection of pointers to locations on the heap 
            //all array elements are initialized to the default values 
            //numeric types = 0, bool = false, object = null 
            int[] arr = new int[10];
            arr[0] = 100; //Boxing 
            int x = arr[0]; //Unboxing
            Console.WriteLine($"{x}\nForeach array");
            foreach (var i in arr)
            {
                Console.Write($"{i},");
            }
            Console.WriteLine("\nFor array : ");
            for(int i=0;i<arr.Length; i++)
            {
                Console.Write($"{arr[i]},");
            }
            Console.WriteLine();
            //Multi-Dimension arrays 
            int[,] twoD = new int[5, 5];
            for (int i = 0; i < twoD.GetLength(0); i++)
                for (int j = 0; j < twoD.GetLength(1); j++)
                    twoD[i, j] = i * j + 1;

            for (int i = 0; i < twoD.GetLength(0); i++)
            {
                for (int j = 0; j < twoD.GetLength(1); j++)
                    Console.Write($"{twoD[i, j]:000}\t");
                Console.WriteLine();
            }
        }
        static void Constructs()
        {
            int i = 10;
            var k = 20; //Implicitly typed variable - value assignment is required
            if (i>k)
            {
                Console.WriteLine($"{i} is greater than {k}");
            } else
                Console.WriteLine($"{k} is greater than {i}");
            do
            {
                Console.Write($"Do {i},");
            } while( i-- > 0 );
            Console.WriteLine();
            while( i++ < 10)
            {
                Console.Write($"While {i},");
            }
            Console.WriteLine();
            for(i=0; i < 10; i++)
                Console.Write($"For {i},");
            Console.WriteLine();
        }
        static void ConsoleOps()
        {
            Console.WriteLine("Hello World");
            Console.WriteLine(10 + " + " + 20 + " = " + (10 + 20));
            Console.WriteLine("{0} + {1} = {2}", 10, 20, (10 + 20));
            Console.WriteLine("{0} - {1} = {1}", 20, 10);
            // ==> 20 - 10 = 10
            //Formatted output - currency, number, datetime, ... 
            Console.WriteLine("{0:C} + {1:N} = {2:N3}", 100.1, 1234.56, 1334.66);
            // => 
            //$100.10 + 1,234.56 = 1,334.660
            Console.WriteLine($"{100.1:C} + {1234.56:N}={13345.66:N3}");

            int i = 10;
            Console.WriteLine(i);
        }
    }
}
