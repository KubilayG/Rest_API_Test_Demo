using Newtonsoft.Json.Linq;
using RestSharp;
using System.Net.Http.Json;
using System.Text.Json;


namespace Rest_API_Test_Demo
{
    public class Tests
    {
        private RestClient _client;
        private string _baseUrl;

        [SetUp]
        public void Setup()
        {
            _baseUrl = "https://jsonplaceholder.typicode.com/";
            _client = new RestClient(_baseUrl);
        }

        [Test]
        public void TestGet()
        {
            var endPoint = "posts/{userId}";
            
            var request = new RestRequest(endPoint, Method.Get);
            
            request.AddUrlSegment("userId", 1);

            var response = _client.Execute(request);

            JObject obs = JObject.Parse(response.Content);

            Assert.That(obs["title"].ToString, Is.EqualTo("sunt aut facere repellat provident occaecati excepturi optio reprehenderit"), "Es gibt einen Fehler im Get Method");
        }

        [Test]
        public void TestPost() 
        {
            var endPoint = "posts";

            var request = new RestRequest(endPoint, Method.Post);

            request.RequestFormat = DataFormat.Json;

            request.AddBody(new { title = "Ich bin ein Praktikant" });

            request.AddUrlSegment("userId", 1);

            var response = _client.Execute(request);

            Assert.That(response.IsSuccessful, Is.True, "Es gibt einen Fehler im Post Method");

        }

        [TearDown]
        public void TearDown() 
        {
            _client.Dispose();
        }

    }
}