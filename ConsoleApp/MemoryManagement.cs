using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    internal class MemoryManagement : IDisposable
    {
        private int _counter;
        private readonly int MaxSize = 10_000;  //_ is a digit separator and is ignored by the compiler
        private string[] names;

        public MemoryManagement(int ctr)
        {
            _counter = ctr;
            names = new string[MaxSize];
            for (int i = 0; i < MaxSize; i++)
            {
                // each array element is 60 * 2 char long = 120 bytes long
                // 120 * 10_000 = 1.2 MB
                // 10000 * 4 = 40 KB
                names[i] = $"A very long string intended to fill up memory quickly {i}";
            }
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"CREATE {_counter} OBJECT");
            Console.ResetColor();
        }
        ~MemoryManagement()
        {
            names = null; //Release the reference to the array
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"\t\tDESTROY {_counter} OBJECT");
            Console.ResetColor();
        }
        public void Dispose()
        {
            names = null; //Release the reference to the array
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.WriteLine($"\t\t\tDISPOSED {_counter} OBJECT");
            Console.ResetColor();
            GC.SuppressFinalize(this); //Suppresses the finalizer/destructor
            //GC removes the entry of this object from the finalizer list.
        }

        internal static void Test()
        {
            string format = "{0} {1} collection attempt: Generation of 'mm' is {2}"; 
            string before = "Before", after = "After";
            string first = "1st", second = "2nd";
            MemoryManagement mm;
            for (int i = 0; i < 100; i++)
            {
                mm = new MemoryManagement(i);

                if (i > 25 && i < 66)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine(format, before, first, GC.GetGeneration(mm));
                    Console.ResetColor();
                    GC.Collect();
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine(format, after, first, GC.GetGeneration(mm));
                    Console.ResetColor();
                    if(i > 35 && i < 46)
                    {
                        GC.Collect();
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine(format, after, second, GC.GetGeneration(mm));
                        Console.ResetColor();
                    }
                }
                if(i> 80 && i < 91)
                {
                    mm.Dispose();
                }
            }
            //using block 
            using (MemoryManagement mm2 = new MemoryManagement(9999))
            {
                Console.BackgroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("Inside using block");
                Console.ResetColor();
            }
            //C# compiler writes this code. 
            //try { .. } finally { mm2.Dispose(); } 



            Console.WriteLine("Press any key to continue...");
            Console.ReadKey(); 

        }

    }
}
