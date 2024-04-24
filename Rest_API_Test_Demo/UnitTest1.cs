using Newtonsoft.Json.Linq;
using Rest_API_Test_Demo.Model;
using RestSharp;

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
			var endPoint = "posts/1";

			var request = new RestRequest(endPoint, Method.Get);

			var response = _client.Execute<Posts.Post>(request);

			Assert.That(response.IsSuccessful, Is.True, $"Es gibt einen Fehler im Get Method: {response.StatusCode}-{response.ErrorMessage}");

			if (response.IsSuccessful && response.Data != null)
			{
				var post = response.Data;

				Assert.That(post.title,
				Is.EqualTo("sunt aut facere repellat provident occaecati excepturi optio reprehenderit"), $"Falscher Titel zurückgegeben: {response.Data?.title}");
			}
		}

		[Test]
		public void TestPost()
		{
			var endPoint = "todos";

			var request = new RestRequest(endPoint, Method.Post);

			request.AddJsonBody(new Todos { userId = 11, id = 201, title = "Ich bin ein Praktikant", completed = true });

			var response = _client.Execute<Todos>(request);

			Assert.That(response.Data?.title, Is.EqualTo("Ich bin ein Praktikant"), $"Es gibt einen Fehler im Post Method: {response.StatusCode}-{response.ErrorMessage}");

		}

		public async Task TestPostAsync()
		{
			var endPoint = "todos";

			var request = new RestRequest(endPoint, Method.Post);

			request.AddJsonBody(new Todos { userId = 11, id = 201, title = "Ich bin ein Praktikant", completed = true });

			var response = await _client.ExecuteAsync<Todos>(request);

			Assert.That(response.IsSuccessful, Is.True, $"Es gibt einen Fehler im Post Async Method: {response.StatusCode} - {response.ErrorMessage}");

			if (response.IsSuccessful)
			{
				Assert.That(response.Data?.title, Is.EqualTo("Ich bin ein Praktikant"), $"Falscher Titel zurückgegeben: {response.Data?.title}");
			}
		}


		[Test]
		public void TestPut()
		{
			var endPoint = "todos/11";

			var request = new RestRequest(endPoint, Method.Put);

			request.AddJsonBody(new Todos { userId = 11, id = 201, title = "Ich bin ein Lehrer", completed = false });

			var response = _client.Execute(request);

			Assert.That(response.IsSuccessful, Is.True, $"Es gibt einen Fehler im Put Method: {response.StatusCode}-{response.ErrorMessage}");

		}
		[Test]
		public void TestPatch()
		{
			var endPoint = "todos/11";

			var request = new RestRequest(endPoint, Method.Patch);

			request.AddJsonBody(new Todos { title = "Ich bin ein Architekt" });

			var response = _client.Execute(request);

			Assert.That(response.IsSuccessful, Is.True, $"Es gibt einen Fehler im Patch Method: {response.StatusCode}-{response.ErrorMessage}");

		}
		[Test]
		public void TestDelete()
		{
			var endPoint = "todos/11";

			var request = new RestRequest(endPoint, Method.Delete);

			var response = _client.Execute(request);

			Assert.That(response.IsSuccessful, Is.True, $"Es gibt einen Fehler im Delete Method: {response.StatusCode}-{response.ErrorMessage}");

		}

		[TearDown]
		public void TearDown()
		{
			_client.Dispose();
		}

	}
}