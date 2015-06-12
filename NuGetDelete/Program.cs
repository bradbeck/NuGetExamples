using System;
using System.Net.Http;

namespace NuGetDelete
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			HttpClient client = new HttpClient ();
			client.BaseAddress = new Uri ("http://localhost:8081/repository/nuget-hosted/");
			client.DefaultRequestHeaders.Add ("X-NuGet-ApiKey", "99999999-aaaa-bbbb-ffff-111111111111");

			var response = client.DeleteAsync ("SimplePackage/1.0.0").Result;
			response.EnsureSuccessStatusCode ();
			Console.WriteLine (response);
		}
	}
}
