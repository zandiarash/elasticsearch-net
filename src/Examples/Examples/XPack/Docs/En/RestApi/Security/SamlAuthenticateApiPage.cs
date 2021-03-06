using Elastic.Xunit.XunitPlumbing;
using Nest;

namespace Examples.XPack.Docs.En.RestApi.Security
{
	public class SamlAuthenticateApiPage : ExampleBase
	{
		[U(Skip = "Example not implemented")]
		public void Line73()
		{
			// tag::8e208098a0156c4c92afe0a06960b230[]
			var response0 = new SearchResponse<object>();
			// end::8e208098a0156c4c92afe0a06960b230[]

			response0.MatchesExample(@"POST /_security/saml/authenticate
			{
			  ""content"" : ""PHNhbWxwOlJlc3BvbnNlIHhtbG5zOnNhbWxwPSJ1cm46b2FzaXM6bmFtZXM6dGM6U0FNTDoyLjA6cHJvdG9jb2wiIHhtbG5zOnNhbWw9InVybjpvYXNpczpuYW1lczp0YzpTQU1MOjIuMD....."",
			  ""ids"" : [""4fee3b046395c4e751011e97f8900b5273d56685""]
			}");
		}
	}
}