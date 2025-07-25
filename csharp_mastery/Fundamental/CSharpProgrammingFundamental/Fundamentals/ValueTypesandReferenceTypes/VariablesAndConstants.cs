using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;
using NUnit.Framework;
namespace CSharpFundamentals.DataTypes
{
    [TestFixture]
    public class VariablesAndConstants
    {
        [Test]
        public void DisplayValues()
        {
            /*
             * int = System.Int32
             * uint = System.UInt32
             * 
             * long = System.Int64
             * ulong = System.UInt64
             * 
             * byte = System.Byte (8 bits)
             * sbyte = System.SByte
             
            short = System.Int16
            ushort = System.UInt16 
            
            int x = 10;
            x++;
            x+= 10;
            
            int y = (x << 2) & 5 ;
             
             */


            /*
             *float = System.Single 16bit
             * double = System.Double 32 bit --- Binary 
             * decimal = System.Decimal 64bit 
             * float v1 = 0.2f;
               double v2 = 0.2d;
            /  decimal v3 = 0.2m;
             * 
             * sign bit
             * Mantisa
             * exponent
             * 
             * in Decimal 
             * 12345.25 ----- 
             *          1.234525 * 10^4 ------ 
             *                  sign 0 
             *                  Mantisa 1
             *                  exponent 4
             *                  
             *  3.25 in Decimal 
                11.01 in Binary 
                11.01× 2^0 = 11.01
                1.101 × 2^1 = = 11.01
                Sign: 0 (a positive number)
                Exponent (unadjusted): 1
                Mantissa (not normalized): 1.101
             */

            double v2 = 0.2d;
            decimal v4 = (decimal)v2;
            Console.WriteLine(v4);
            int sign = Math.Sign(5);
            Console.WriteLine(sign);

        }

        [Test]
        public void PrimitiveTypesTest()
        {
            Console.WriteLine("Primitive types");
            int cSharpInt = 1;
            System.Int32 ctsInt = 2;

            Console.WriteLine("cSharpInt and ctsInt are of same type {0}", 
                cSharpInt.GetType() == ctsInt.GetType());

            Console.WriteLine("{0} is primitive type {1}", 
                typeof(int).Name, typeof(int).IsPrimitive);

            Console.WriteLine("{0} i sprimitive tyep {1}", 
                typeof(System.Int32).Name, typeof(System.Int32).IsPrimitive);

            Console.WriteLine("{0} is primitive type {1}", typeof(string).Name, typeof(string).IsPrimitive);
            Console.WriteLine("{0} is primituve type ?=> {1}", typeof(List<string>).Name, typeof(List<string>).IsPrimitive);

            
        }



    }
}
