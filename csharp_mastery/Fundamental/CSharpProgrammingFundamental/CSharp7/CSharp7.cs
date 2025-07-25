using NUnit.Framework.Constraints;
using static System.Console;


namespace CSharpFundamental._05WhatIsNew
{
    public interface IOne
    {
        int SampleIntProperty { get; set; }
    }

    public interface ITwo
    {
        int SampleIntProperty2 { get; set; }
    }

    public class BaseClass
    {
        public string SampleStringProperty { get; set; }
    }

    public class DerivedClass : BaseClass, IOne, ITwo
    {
        public int SampleIntProperty { get; set; }
        public int SampleIntProperty2 { get; set; }
    }

    public abstract class Investment
    {
        public string Name { get; set; }
        public double MinPurchaseAmt { get; set; }
    }

    public class Stock : Investment { }

    public class Bond : Investment { }

    public class BankAccount : Investment { }

    public class RealEstate : Investment { }

    [TestFixture]
    public class CSharp7
    {
        [Test]
        public void PatternMatching()
        {
            var dc = new DerivedClass();
            if (dc is DerivedClass)
            {
                Console.WriteLine("Derived Class found");
            }

            if (dc is BaseClass)
            {
                Console.WriteLine("Base Class found");
            }

            if (dc is IOne)
            {
                Console.WriteLine("Interface One found");
            }

            if (dc is ITwo)
            {
                Console.WriteLine("Interface Two found");
            }
        }

        [Test]
        public void PatternMatchingWithSwitch()
        {
            var myStock = new Stock() { Name = "Tesla", MinPurchaseAmt = 1000 };
            var myBond = new Bond() { Name = "California Municipal", MinPurchaseAmt = 500 };
            var myBankAccount = new BankAccount() { Name = "ABC Bank", MinPurchaseAmt = 10 };
            var myBankAccount2 = new BankAccount() { Name = "XYZ Bank", MinPurchaseAmt = 20 };
            var myRealEstate = new RealEstate() { Name = "My Vacation Home", MinPurchaseAmt = 100_000 };

            CheckInvestmentType(myStock);
            CheckInvestmentType(myBond);
            CheckInvestmentType(myBankAccount);
            CheckInvestmentType(myBankAccount2);
            myBankAccount2 = null;
            CheckInvestmentType(myBankAccount2);
            CheckInvestmentType(myRealEstate);
        }

        public static void CheckInvestmentType(Investment investment)
        {
            switch (investment)
            {
                case Stock stock:
                    WriteLine($"This investment is a stock named {stock.Name}");
                    break;

                case Bond bond:
                    WriteLine($"This investment is a bond named {bond.Name}");
                    break;

                case BankAccount bankAccount when bankAccount.Name.Contains("ABC"):
                    WriteLine($"This investment is my ABC Bank account");
                    break;

                case BankAccount bankAccount:
                    WriteLine($"This investment is any bank account other than ABC Bank");
                    break;

                case null:
                    WriteLine("For whatever reason, this investment is null. ");
                    break;

                default:
                    WriteLine("The default case will always be evaluated last. ");
                    WriteLine("Even if its position is not last.");
                    break;
            }
        }

        public void BinaryLiteralsAndNumericSeparators()
        {
            int transparency = 0b11111111;
            int transparency2 = 0b11_11_11_11;
            int transparency3 = 0xff;

            Console.WriteLine("Binary: " + transparency);
            Console.WriteLine("Binary with separators: " + transparency2);
            Console.WriteLine("Hex: " + transparency3);
        }

        public void LocalFunctions()
        {
            var corvette = GetRemainingRange(.25, 24, "British");
            Console.WriteLine($"Remaining range is {corvette.distance} {corvette.units}");
            var prius = GetRemainingRange(.04, 12, "Metric");
            Console.WriteLine($"Remaining range is {prius.distance} {prius.units}");
        }

        // This method returns a ValueTuple.
        public static (double distance, string units) GetRemainingRange
        (double fuelConsumptionRate, double remainingFuel, string systemOfUnits)
        {
            string units = string.Empty;
            switch (systemOfUnits)
            {
                case "Metric":
                    units = "Kilometers";
                    break;

                case "British":
                    units = "Miles";
                    break;
            }

            //Notice that this local function has no parameters
            double CalculateRemainingRange()
            {
                return remainingFuel / fuelConsumptionRate;
            }
            return (CalculateRemainingRange(), units);
        }


    }
}
