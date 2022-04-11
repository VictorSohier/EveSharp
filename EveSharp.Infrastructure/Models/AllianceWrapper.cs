using EveSharp.Core.Models;
using EveSharp.Core.Models.Alliance;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace EveSharp.Infrastructure.Models
{
	public class AllianceWrapper
	{
		private readonly HttpClient _client;
		private readonly JsonSerializer _serializer;
		
		public AllianceWrapper()
		{
			_client = new();
			_client.BaseAddress = new("https://esi.evetech.net/latest/alliances");
			
			JsonSerializerSettings settings = new()
			{
				DateParseHandling = DateParseHandling.DateTime,
				DateFormatHandling = DateFormatHandling.IsoDateFormat,
				ContractResolver = new DefaultContractResolver()
				{
					NamingStrategy = new SnakeCaseNamingStrategy()
				},
				NullValueHandling = NullValueHandling.Include
			};
			
			_serializer = JsonSerializer.Create(settings);
		}
		
		public async Task<int[]> GetAlliancesAsync(string datasource = "tranquility")
		{
			HttpResponseMessage message = await _client.GetAsync($"?datasource={datasource}");
			int[] ret = _serializer.Deserialize<int[]>(new JsonTextReader(new StreamReader(await message.Content.ReadAsStreamAsync())));
			return ret;
		}
		
		public async Task<Alliance> GetAllianceAsync(int allianceId, string datasource = "tranquility")
		{
			HttpResponseMessage message = await _client.GetAsync($"/{allianceId}?datasource={datasource}");
			Alliance ret = _serializer.Deserialize<Alliance>(new JsonTextReader(new StreamReader(await message.Content.ReadAsStreamAsync())));
			return ret;
		}
		
		public async Task<int[]> GetAllianceCorporationsAsync(int allianceId, string datasource = "tranquility")
		{
			HttpResponseMessage message = await _client.GetAsync($"/{allianceId}/corporations?datasource={datasource}");
			int[] ret = _serializer.Deserialize<int[]>(new JsonTextReader(new StreamReader(await message.Content.ReadAsStreamAsync())));
			return ret;
		}
		
		public async Task<Icon> GetAllianceIconsAsync(int allianceId, string datasource = "tranquility")
		{
			HttpResponseMessage message = await _client.GetAsync($"/{allianceId}/icons?datasource={datasource}");
			Icon ret = _serializer.Deserialize<Icon>(new JsonTextReader(new StreamReader(await message.Content.ReadAsStreamAsync())));
			return ret;
		}
	}
}