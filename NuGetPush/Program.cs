using System;
using System.IO;
using System.Net.Http;

namespace NuGetPush
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			HttpClient client = new HttpClient ();
			client.BaseAddress = new Uri ("http://localhost:8081/repository/nuget-hosted/");
			client.DefaultRequestHeaders.Add ("X-NuGet-ApiKey", "99999999-aaaa-bbbb-ffff-111111111111");

			MultipartFormDataContent mp = new MultipartFormDataContent ("---------------------------012345678901234");
			mp.Add(new ByteArrayContent(File.ReadAllBytes("SimplePackage.1.0.0.nupkg")), "package", "package");

			var response = client.PutAsync ("", mp).Result;
			response.EnsureSuccessStatusCode ();
			Console.WriteLine (response);
		}
	}
}
