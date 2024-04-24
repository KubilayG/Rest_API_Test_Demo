using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rest_API_Test_Demo.Model
{
	public class Todos
	{
		public int userId { get; set; }
		public int id { get; set; }
		public string title { get; set; }
		public bool completed { get; set; }

	}
}
