using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace CSharpFundamentals.DataTypes
{
    public class DateTest
    {
        [Test]
        public void TimeSpanUsage()
        {
            TimeSpan fiveSeconds = TimeSpan.FromSeconds(5d);
            TimeSpan halfAMinute = TimeSpan.FromMinutes(0.5d);
            TimeSpan result = halfAMinute + fiveSeconds;

            Console.WriteLine(result.TotalMinutes);

            Assert.AreEqual(TimeSpan.FromMilliseconds(35000), halfAMinute + fiveSeconds);

            Assert.AreEqual(5000d, fiveSeconds.TotalMilliseconds);
            Assert.AreEqual(0.5d, halfAMinute.TotalMinutes);

        }

        [Test]
        public void DateTimeUsage()
        {
            DateTime myTime = new DateTime(2018, 07, 10, 17, 30, 36, DateTimeKind.Local);
            DateTime utcTime = new DateTime(2018, 07, 10, 12, 00, 36, DateTimeKind.Utc);
                     

            Assert.AreEqual(utcTime, myTime.ToUniversalTime());
            Assert.AreEqual(myTime, utcTime.ToLocalTime());

            Assert.AreEqual(myTime, myTime.ToLocalTime());
            Assert.AreEqual(utcTime, utcTime.ToUniversalTime());


            DateTime utcTimeUnspecified = new DateTime(2018, 07, 10, 12, 00, 36, DateTimeKind.Unspecified);
            Assert.AreNotEqual(utcTime, utcTimeUnspecified.ToUniversalTime());

            DateTime myTimePlusTwoHrs = myTime + TimeSpan.FromHours(2);

            Assert.AreEqual(new DateTime(2018, 07, 10, 19, 30, 36, DateTimeKind.Local), myTimePlusTwoHrs);

        }

        [Test]
        public void DateTimeOffSet()
        {
            DateTimeOffset myTime = new DateTimeOffset(2018, 07, 10, 12, 30, 36, TimeSpan.FromHours(5.5d)) ;
            DateTimeOffset UkTime = new DateTimeOffset(2018, 07, 10, 08, 00, 36, TimeSpan.FromHours(1));

            Assert.AreEqual(myTime.ToUniversalTime(), UkTime.ToUniversalTime());


        }

        [Test]
        public void TimeZoneInfoUsage()
        {
            TimeZoneInfo zone = TimeZoneInfo.Local;

            Assert.AreEqual(TimeSpan.FromHours(5.5d), zone.GetUtcOffset(new DateTime(2018, 07, 10, 17, 30, 36, DateTimeKind.Local)));

            Console.WriteLine(zone.Id + "\r\n" + zone.DisplayName + "\r\n" + zone.DaylightName);
        }

    }
}
