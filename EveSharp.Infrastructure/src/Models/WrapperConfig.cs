using System.Net;
using System.Security.Cryptography;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace EveSharp.Infrastructure.Models
{
	internal class WrapperConfig
	{
		internal readonly static WrapperConfig _instance = new();
		internal readonly string API_VERSION = "latest";
		internal readonly string DOMAIN = "https://esi.evetech.net";
		internal readonly string OAUTH2_DOMAIN = "login.eveonline.com";
		internal readonly JsonSerializer SERIALIZER = JsonSerializer.Create(
			new()
			{
				DateParseHandling = DateParseHandling.DateTime,
				DateFormatHandling = DateFormatHandling.IsoDateFormat,
				ContractResolver = new DefaultContractResolver()
				{
					NamingStrategy = new SnakeCaseNamingStrategy(true, true, true)
				},
				NullValueHandling = NullValueHandling.Include,
				TypeNameHandling = TypeNameHandling.All
			}
		);
		
		internal readonly HttpStatusCode[] SUCCESS = new HttpStatusCode[]{
			HttpStatusCode.OK,
			HttpStatusCode.Created,
			HttpStatusCode.Accepted,
			HttpStatusCode.NonAuthoritativeInformation,
			HttpStatusCode.NoContent,
			HttpStatusCode.ResetContent,
			HttpStatusCode.PartialContent,
			HttpStatusCode.MultiStatus,
			HttpStatusCode.AlreadyReported,
			HttpStatusCode.IMUsed
		};
		internal readonly Random RANDOM = new();
		internal readonly SHA256 SHA256 = SHA256.Create();
		
		private WrapperConfig()
		{
			
		}
	}
}