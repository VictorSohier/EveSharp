using System.Net;
using System.Security.Cryptography;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace EveSharp.Infrastructure.Models
{
	internal class WrapperConfig
	{
		public readonly static WrapperConfig _instance = new();
		public readonly string API_VERSION = "latest";
		public readonly string DOMAIN = "https://esi.evetech.net";
		public readonly string OAUTH2_DOMAIN = "login.eveonline.com";
		public readonly JsonSerializer SERIALIZER = JsonSerializer.Create(
			new()
			{
				DateParseHandling = DateParseHandling.DateTime,
				DateFormatHandling = DateFormatHandling.IsoDateFormat,
				ContractResolver = new DefaultContractResolver()
				{
					NamingStrategy = new SnakeCaseNamingStrategy()
				},
				NullValueHandling = NullValueHandling.Include
			}
		);
		
		public readonly HttpStatusCode[] SUCCESS = new HttpStatusCode[]{
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
		public readonly Random RANDOM = new();
		public readonly SHA256 SHA256 = SHA256.Create();
		
		private WrapperConfig()
		{
			
		}
	}
}