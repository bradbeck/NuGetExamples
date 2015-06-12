using System;
using System.Net.Http;

namespace NuGetQuery
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			var client = new HttpClient ();
			var response = client.GetAsync ("http://localhost:8081/repository/nuget-group/Packages(Id='jQuery',Version='2.1.4')").Result;

			response.EnsureSuccessStatusCode ();

			string content = response.Content.ReadAsStringAsync ().Result;
			Console.WriteLine (response.Headers);
			Console.WriteLine (content);
		}
	}
}
