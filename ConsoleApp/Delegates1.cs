using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    //Step 1: Declaration of delegate
    public delegate int ArithmeticDelegate(int a, int b);


    internal class Delegates1
    {
        //Step 2: Method that matches the delegate signature
        public static int Add(int a, int b)
        {
            return a + b;
        }
        public int Subtract(int a, int b)
        {
            return a - b;
        }
        public static void Test()
        {
            //Step 3: Create an instance of the delegate
            ArithmeticDelegate arithmeticDelegate = new ArithmeticDelegate(Add);

            //Step 4: Invoke the delegate
            int result = arithmeticDelegate(10, 20);
            Console.WriteLine($"Addition Result: {result}");
            
            //Step 5: INvoke the delegate 
            result = arithmeticDelegate.Invoke(10, 20);
            Console.WriteLine($"Addition Result: {result}");

            //Step 6: Multi-cast the delegate 
            var d1 = new Delegates1(); 
            arithmeticDelegate += new ArithmeticDelegate(d1.Subtract);
            //Step 7: Invoke the delegate
            result = arithmeticDelegate.Invoke(100,200);
            Console.WriteLine($"Final Result: {result}");
            InvokeDelegateMethodsManually(arithmeticDelegate);

            /*   arithmeticDelegate -= new ArithmeticDelegate(d1.Subtract);
               Console.WriteLine("After removing the SUbtract method" );
               InvokeDelegateMethodsManually(arithmeticDelegate);*/
            Console.WriteLine("==================");
            Console.WriteLine("Anonymous methods.");
            //Anonymous Method - unnamed method 
            int x = 100; 
            arithmeticDelegate += delegate (int a, int b)
            {
                //are inline methods and they can access local variables of the outer function 
                x += 200;
                return a * b;
            };
           
            InvokeDelegateMethodsManually(arithmeticDelegate);
            Console.WriteLine(x);

            //Lambda expression - shorthand syntax for anonymous methods
            arithmeticDelegate += (a, b) => (b>0) ? a / b: 0;
            Console.WriteLine("==================");
            Console.WriteLine("Lambda Expression.");
            InvokeDelegateMethodsManually(arithmeticDelegate);
            /* Lambdas are of two types: 
             * 1. Expression Lambda  - single line of expression 
             * 2. Statement Lambda - multiple lines of code { ... } 
             * Passing parameters to lambda expression
             * 1. No parameters         = () => {} 
             * 2. One parameter         = a => {}  OR (a) => {}
             * 3. Two or more           = (a, b) => {}
             */

        }
        static void InvokeDelegateMethodsManually(ArithmeticDelegate ad)
        {
            foreach(Delegate item in ad.GetInvocationList())
            {
                object result = item.DynamicInvoke(999, 9);
                Console.WriteLine($"Result of {item.Method.Name} is {result}");
            }
        }
    }
}
