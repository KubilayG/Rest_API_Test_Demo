using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rest_API_Test_Demo.Model
{
	public class Posts
	{

		public class PostsContainer
		{
			public Post[] Posts { get; set; }
		}

		public class Post
		{
			public int userId { get; set; }
			public int id { get; set; }
			public string title { get; set; }
			public string body { get; set; }
		}


	}
}
