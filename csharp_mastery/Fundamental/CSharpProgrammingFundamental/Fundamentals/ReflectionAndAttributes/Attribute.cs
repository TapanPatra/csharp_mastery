#define DoTrace

using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpFundamental._03_Fundamentals.ReflectionAndAttributes
{
    [AttributeUsage(AttributeTargets.Class)]
    public sealed class ReviewCommentAttribute : System.Attribute
    {
        public string Description { get; set; }
        public string VersionNumber { get; set; }
        public string ReviewerID { get; set; }
        public ReviewCommentAttribute(string desc, string ver)
        {
            Description = desc;
            VersionNumber = ver;
        }
    }

    [AttributeUsage(AttributeTargets.Class)]
    public sealed class MyAttributeAttribute : System.Attribute
    {
        public string Description { get; set; }
        public string VersionNumber { get; set; }
        public string ReviewerID { get; set; }

        public MyAttributeAttribute(string desc, string ver)
        {
            Description = desc;
            VersionNumber = ver;
        }
    }

    [ReviewComment("Check it out", "2.4")]
    class MyClass
    {
    }

    [MyAttribute("Check it out", "2.4")]
    class OtherClass
    {

    }


    [TestFixture]
    public class Attribute
    {
        [Test]
        public void ObsoleteAttribute()
        {
            PrintOut("Start of Main"); // Invoke obsolete method.
        }

        [Obsolete("Use method SuperPrintOut")] // Apply attribute to method.
        static void PrintOut(string str)
        {
            Console.WriteLine(str);
        }

        [Test]
        public void ConditionalAttribute()
        {
            TraceMessage("Start of Main");
            Console.WriteLine("Doing work in Main.");
            TraceMessage("End of Main");
        }

        [Conditional("DoTrace")]
        static void TraceMessage(string str)
        {
            Console.WriteLine(str);
        }

        [Test]
        public void CallerInformationAttributes()
        {
            MyTrace("Simple message");
        }

        public static void MyTrace(string message,
                              [CallerFilePath] string fileName = "",
                              [CallerLineNumber] int lineNumber = 0,
                              [CallerMemberName] string callingMember = "")
        {
            Console.WriteLine($"File: {fileName}");
            Console.WriteLine($"Line: {lineNumber}");
            Console.WriteLine($"Called From: {callingMember}");
            Console.WriteLine($"Message: {message}");
        }

        [Test]
        public void AccessingAnAttributeUsingTheIsDefinedMethod()
        {
            MyClass mc = new MyClass();   // Create an instance of the class.
            Type t = mc.GetType();        // Get the Type object from the instance.
            bool isDefined =              // Check the Type for the attribute.
               t.IsDefined(typeof(ReviewCommentAttribute), false);

            if (isDefined)
                Console.WriteLine($"ReviewComment is applied to type {t.Name}");
        }

        [Test]
        public void UsingTheGetCustomAttributesMethod()
        {
            Type t = typeof(OtherClass);
            object[] AttArr = t.GetCustomAttributes(false);
            foreach (Attribute a in AttArr)
            {
                //if (a is MyAttributeAttribute attr)
                //{
                //    Console.WriteLine($"Description    : {attr.Description}");
                //    Console.WriteLine($"Version Number : {attr.VersionNumber}");
                //    Console.WriteLine($"Reviewer ID    : {attr.ReviewerID}");
                //}
            }
        }

    }
}
