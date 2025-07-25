using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpFundamental._02_DataTypes.ValueTypesandReferenceTypes
{
    enum TrafficLight
    {
        Green,
        Yellow,
        Red
    }

    public enum ShippingMethod
    {
        RegularAirMail =1,
        RegisteredAirMail=2,
        Express =3
    }

    [Flags]
    enum CardDeckSettings : uint
    {
        SingleDeck = 0x01, // bit 0
        LargePictures = 0x02, // bit 1
        FancyNumbers = 0x04, // bit 2
        Animation = 0x08  // bit 3
    }

    class CardDeckSettingsOption
    {
        bool UseSingleDeck = false,
        UseBigPics = false,
        UseFancyNumbers = false,
        UseAnimation = false,
        UseAnimationAndFancyNumbers = false;

        public void SetOptions(CardDeckSettings ops)
        {
            UseSingleDeck = ops.HasFlag(CardDeckSettings.SingleDeck);
            UseBigPics = ops.HasFlag(CardDeckSettings.LargePictures);
            UseFancyNumbers = ops.HasFlag(CardDeckSettings.FancyNumbers);
            UseAnimation = ops.HasFlag(CardDeckSettings.Animation);

            CardDeckSettings testFlags =
                        CardDeckSettings.Animation | CardDeckSettings.FancyNumbers;
            UseAnimationAndFancyNumbers = ops.HasFlag(testFlags);
        }

        public void PrintOptions()
        {
            Console.WriteLine("Option settings:");
            Console.WriteLine($"  Use Single Deck                 - {UseSingleDeck}");
            Console.WriteLine($"  Use Large Pictures              - {UseBigPics}");
            Console.WriteLine($"  Use Fancy Numbers               - {UseFancyNumbers}");
            Console.WriteLine($"  Show Animation                  - {UseAnimation}");
            Console.WriteLine("  Show Animation and FancyNumbers – {0}", UseAnimationAndFancyNumbers);
        }
    }


    [TestFixture]
    public class Enums
    {
        [Test]
        public void EnumsTest()
        {
            var method = ShippingMethod.Express;
            Console.WriteLine((int)method);
            Console.WriteLine(method.ToString());


            var methodId = 3;
            Console.WriteLine((ShippingMethod)methodId);

            var methodName = "Express";
            var shippingMethod = (ShippingMethod) Enum.Parse(typeof(ShippingMethod), methodName);
            Console.WriteLine(shippingMethod);

            Console.WriteLine("Second member of TrafficLight is {0}\n", Enum.GetName(typeof(TrafficLight), 1));
            foreach (var name in Enum.GetNames(typeof(TrafficLight)))
                Console.WriteLine(name);
        }

        [Test]
        public void FlagsAttribute()
        {
            var option = new CardDeckSettingsOption();
            CardDeckSettings ops = CardDeckSettings.SingleDeck
                                    | CardDeckSettings.FancyNumbers
                                    | CardDeckSettings.Animation;
            option.SetOptions(ops);
            option.PrintOptions();
        }
    }


}
