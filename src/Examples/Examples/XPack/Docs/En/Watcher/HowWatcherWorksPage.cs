using Elastic.Xunit.XunitPlumbing;
using Nest;

namespace Examples.XPack.Docs.En.Watcher
{
	public class HowWatcherWorksPage : ExampleBase
	{
		[U(Skip = "Example not implemented")]
		public void Line51()
		{
			// tag::b40ea21b877503cc392b5f17e4730814[]
			var response0 = new SearchResponse<object>();
			// end::b40ea21b877503cc392b5f17e4730814[]

			response0.MatchesExample(@"PUT _watcher/watch/log_errors
			{
			  ""metadata"" : { <1>
			    ""color"" : ""red""
			  },
			  ""trigger"" : { <2>
			    ""schedule"" : {
			      ""interval"" : ""5m""
			    }
			  },
			  ""input"" : { <3>
			    ""search"" : {
			      ""request"" : {
			        ""indices"" : ""log-events"",
			        ""body"" : {
			          ""size"" : 0,
			          ""query"" : { ""match"" : { ""status"" : ""error"" } }
			        }
			      }
			    }
			  },
			  ""condition"" : { <4>
			    ""compare"" : { ""ctx.payload.hits.total.value"" : { ""gt"" : 5 }}
			  },
			  ""transform"" : { <5>
			    ""search"" : {
			        ""request"" : {
			          ""indices"" : ""log-events"",
			          ""body"" : {
			            ""query"" : { ""match"" : { ""status"" : ""error"" } }
			          }
			        }
			    }
			  },
			  ""actions"" : { <6>
			    ""my_webhook"" : {
			      ""webhook"" : {
			        ""method"" : ""POST"",
			        ""host"" : ""mylisteninghost"",
			        ""port"" : 9200,
			        ""path"" : ""/{{watch_id}}"",
			        ""body"" : ""Encountered {{ctx.payload.hits.total.value}} errors""
			      }
			    },
			    ""email_administrator"" : {
			      ""email"" : {
			        ""to"" : ""sys.admino@host.domain"",
			        ""subject"" : ""Encountered {{ctx.payload.hits.total.value}} errors"",
			        ""body"" : ""Too many error in the system, see attached data"",
			        ""attachments"" : {
			          ""attached_data"" : {
			            ""data"" : {
			              ""format"" : ""json""
			            }
			          }
			        },
			        ""priority"" : ""high""
			      }
			    }
			  }
			}");
		}

		[U(Skip = "Example not implemented")]
		public void Line157()
		{
			// tag::1d918e206ad8dab916e59183da24d9ec[]
			var response0 = new SearchResponse<object>();
			// end::1d918e206ad8dab916e59183da24d9ec[]

			response0.MatchesExample(@"PUT .watches/_settings
			{
			  ""index.routing.allocation.include.role"": ""watcher""
			}");
		}
	}
}