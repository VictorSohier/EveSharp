using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace EveSharp.Infrastructure.Models
{
	public class WrapperConfig
	{
		public readonly static WrapperConfig _instance = new();
		
		public readonly string API_VERSION = "latest";
		public readonly JsonSerializerSettings settings = new()
		{
			DateParseHandling = DateParseHandling.DateTime,
			DateFormatHandling = DateFormatHandling.IsoDateFormat,
			ContractResolver = new DefaultContractResolver()
			{
				NamingStrategy = new SnakeCaseNamingStrategy()
			},
			NullValueHandling = NullValueHandling.Include
		};
		
		private WrapperConfig()
		{
			
		}
	}
}