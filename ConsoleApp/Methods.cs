using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    public class Methods
    {
        public static void Test()
        {
            int x=10, y=20;
            string byVal=nameof(SwapByValue), byRef=nameof(SwapByRef);
            string msg = "{0} calling {1}, x: {2}, y: {3}";
            string line = "".PadLeft(50, '=');
            Console.WriteLine(line);
            Console.WriteLine(msg, "Before", byVal, x, y);
            SwapByValue(x, y);
            Console.WriteLine(msg, "After", byVal, x, y);
            Console.WriteLine(line);
            Console.WriteLine(msg, "Before", byRef, x, y);
            SwapByRef(ref x, ref y);
            Console.WriteLine(msg, "After", byRef, x, y);
            Console.WriteLine(line);
            int num = 2;//, sq, cube, result; 
            var result = Power(
                num: num, 
                cube: out int cube, 
                square: out int sq
                );
            Console.WriteLine($"POwer {num}, sq:{sq}, cube:{cube}, result:{result}");
            Console.WriteLine(line);
            Params(message: "No args passed");
            Params(message: "One arg passed", args: 1);
            Params(message: "Multiple args passed", 1,2,3,4,5);
            Console.WriteLine(line);

            Optional();
            Optional(name: "Name assigned");
            Optional(name: "Name and Salary assigned", salary: 1234);
            Optional(name: "All assigned", salary: 999, id:123);
            Console.WriteLine(line);
        }
        static void Optional(int id=0, string name="Unassigned", double salary = 0)
        {
            Console.WriteLine($"Id:{id}, Name: {name}, Salary:{salary}");
        }
        static void Params(string message, params int[] args)
        {
            Console.WriteLine(message);
            foreach (int arg in args) Console.Write($"{arg},"); 
            Console.WriteLine();
        }
        static int Power(int num, out int square, out int cube)
        {
            //all out parameters have to initialized before leaving the function
            square = num * num;
            cube = square * num;
            return cube * num;
        }

        static void SwapByRef(ref int first, ref int second)
        {
            int temp = first;
            first = second;
            second = temp;
        }
        static void SwapByValue(int first, int second)
        {
            int temp = first;
            first = second;
            second = temp;
        }
    }
}
