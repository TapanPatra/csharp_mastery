using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSharpFundamental._02_DataTypes.Events;
using NUnit.Framework;

namespace Fundamentals
{
    [TestFixture]
    public class ExceptionsTest
    {
        class MyClass
        {
            public static void PrintArg(string arg)
            {
                try
                {
                    if (arg == null)
                    {
                        ArgumentNullException myEx = new ArgumentNullException("arg");
                        throw myEx;
                    }
                    Console.WriteLine(arg);
                }
                catch (ArgumentNullException e)
                {
                    Console.WriteLine($"Message:  {e.Message}");
                }
            }
        }

        static string SecretCode { get { return "Roses are red"; } }


        //What Are Exceptions? 


        //The catch Clause 
        //Examples Using Specific catch Clauses 
        //The catch Clauses Section 
        //The finally Block 
        //Finding a Handler for an Exception 
        //Searching Further 
        //Throwing Exceptions 
        //Throwing Without an Exception Object 
        [Test]
        public void DivideByZeroException()
        {
            int x = 12;
            int y = 0;
            int result = x / y;

        }

        //Handling the Exception 
        //The try Statement 
        [Test]
        public void HandlingTheExceptionTest()
        {
            int x = 12;
            int y = 0;

            try
            {
                int result = x / y;
            }

            catch
            {
                Console.WriteLine("Handling all exception - Keep running!");
            }
        }

        //The Exception Classes 
        [Test]
        public void ExceptionObjectTest()
        {
            int x = 12;
            int y = 0;

            try
            {
                int result = x / y;
            }

            catch (Exception e)
            {
                Console.WriteLine($" Exception Object error message explaining the cause of the exception. : {e.Message}");
                Console.WriteLine($" Exception Object describing where the exception occurred. : {e.StackTrace}");
                Console.WriteLine($" Exception Object reference to the previous exception : {e.InnerException}");
                Console.WriteLine($" Exception Object URL for information on the cause of the exception : {e.HelpLink}");
                Console.WriteLine($" Exception Object name of the assembly where the exception originated : {e.Source}");

            }
        }

        //Examples Using Specific catch Clauses 
        [Test]
        public void ExceptionTest()
        {
            try
            {
                var api = new YouTubeApi();
                var videos = api.GetVideos("mosh");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        [Test]
        public void UsingSpecificCatchClauses()
        {
            int x = 10;

            try
            {
                int y = 0;
                x /= y;           // Raises an exception
            }
            catch (DivideByZeroException e)
            {
                Console.WriteLine("Message: {0}", e.Message);
                Console.WriteLine("Source:  {0}", e.Source);
                Console.WriteLine("Stack:   {0}", e.StackTrace);
            }


        }

        [Test]
        public void FinallyBlock()
        {
            int inVal = 5;

            try
            {
                if (inVal < 10)
                {
                    Console.Write("First Branch - ");
                    return;
                }
                else
                    Console.Write("Second Branch - ");
            }
            finally
            {
                Console.WriteLine("In finally statement");
            }
        }

        [Test]
        public void ThrowingExceptions()
        {
            string s = null;
            MyClass.PrintArg(s);
            MyClass.PrintArg("Hi there!");
        }

        [Test]
        public void ThrowExpressions()
        {
            bool safe = false;
            try
            {
                string secretCode = safe
                            ? SecretCode
                            : throw new Exception("Not safe to get code.");
                Console.WriteLine($"Code is: {secretCode}.");
            }
            catch (Exception e)
            {
                Console.WriteLine($"{e.Message}");
            }
        }
    }

    public class YouTubeException : Exception
    {
        public YouTubeException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }

    public class YouTubeApi
    {
        public List<Video> GetVideos(string user)
        {
            try
            {
                // Access YouTube web service 
                // Read the data 
                // Create a list of Video objects
                throw new Exception("Oops some low level YouTube error.");
            }
            catch (Exception ex)
            {
                // Log 

                throw new YouTubeException("Could not fetch the videos from YouTube.", ex);
            }

            return new List<Video>();
        }
    }

    public class Video
    {
    }

    public class Calculator
    {
        public int Divide(int numerator, int denomenator)
        {
            return numerator / denomenator;
        }
    }
}

