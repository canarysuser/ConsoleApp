using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    public class CustomException : Exception
    {
        public CustomException(string message) : base(message)
        {
        }
        public CustomException(string message, Exception innerException) : base(message, innerException)
        {
        }
        public CustomException(string message, string customData) : base(message)
        {
            CustomData = customData;
        }
        public string CustomData { get; set; }
    }
    internal class ExceptionHandling
    {
        static void ThrowException()
        {
            int a = 10, b = 0, c = 0;
            c = a / b; //System.DivideByZeroException
        }
        static void CallThrowException()
        {
            try
            {
                ThrowException();
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine("Divide by zero exception caught.");
                Console.WriteLine("Message: " + ex.Message);
                Console.WriteLine("Stack Trace: " + ex.StackTrace);
            }
            finally
            {
                Console.WriteLine("Finally block executed.");
            }
        }
        static void ThrowCustomException()
        {
            throw new CustomException("This is a custom exception", "Custom data");
        }
        internal static void Test()
        {
            try
            {
                ThrowCustomException();
                CallThrowException();
                Console.WriteLine("Next Line after CallThrowException() is invoked.");
            } 
            catch(CustomException cex)
            {
                Console.WriteLine("ERROR: " + cex.CustomData);
                throw cex; // rethrowing the exception without preserving the call stack 
                //new call stack is created at this point. 

            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR: " + ex.Message);
                Console.WriteLine("Stack Trace: " + ex.StackTrace);
                throw; // rethrowing the exception with preserving the call stack
            }
        }
    }
}
