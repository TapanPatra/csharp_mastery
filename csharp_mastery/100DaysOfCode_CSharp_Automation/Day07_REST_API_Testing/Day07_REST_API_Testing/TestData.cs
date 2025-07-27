using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day07_REST_API_Testing
{
    public static class TestData
    {
        public static object BookingPayload => new
        {
            firstname = "John",
            lastname = "Doe",
            totalprice = 150,
            depositpaid = true,
            bookingdates = new
            {
                checkin = "2025-01-01",
                checkout = "2025-01-05"
            },
            additionalneeds = "Breakfast"
        };
    }
}
