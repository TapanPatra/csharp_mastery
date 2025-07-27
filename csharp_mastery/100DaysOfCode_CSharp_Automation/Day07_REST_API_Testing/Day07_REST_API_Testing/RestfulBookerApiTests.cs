using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Day07_REST_API_Testing
{
    [TestFixture]
    public class RestfulBookerApiTests
    {
        private RestClient _client;

        [SetUp]
        public void Setup()
        {
            _client = RestClientHelper.GetClient();
        }

        [TearDown]
        public void Teardown()
        {
            _client.Dispose();
        }

        [Test]
        public void Test_GetPing_Returns201()
        {
            var request = new RestRequest("/ping", Method.Get);
            var response = _client.Execute(request);

            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.Created));

        }

        [Test]
        public void Test_CreateBooking_Returns200AndBookingId()
        {
            var request = new RestRequest("/booking", Method.Post);
            request.AddHeader("Accept", "application/json");
            request.AddHeader("User-Agent", "RestSharp");
            request.AddJsonBody(TestData.BookingPayload);

            var response = _client.Execute(request);

            Assert.Multiple(() =>
            {
                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
                Assert.That(response.Content.Contains("bookingid"), Is.True);
            });


        }

        [Test]
        public void Test_GetBooking_Returns200()
        {
            var request = new RestRequest("/booking/1", Method.Get);
            request.AddHeader("Accept", "application/json");
            request.AddHeader("User-Agent", "RestSharp");
            var response = _client.Execute(request);

            Console.WriteLine($"Status Code: {(int)response.StatusCode}");
            Console.WriteLine(response.Content);

            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));

        }
    }
}
