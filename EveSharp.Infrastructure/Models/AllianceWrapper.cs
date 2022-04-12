using EveSharp.Core.Models;
using EveSharp.Core.Models.Alliance;
using Newtonsoft.Json;

namespace EveSharp.Infrastructure.Models
{
	public class AllianceWrapper
	{
		private readonly HttpClient _client;
		private readonly JsonSerializer _serializer;
		
		public AllianceWrapper()
		{
			_client = new();
			_client.BaseAddress = new($"https://esi.evetech.net/{WrapperConfig._instance.API_VERSION}/alliances");
			_serializer = WrapperConfig._instance.SERIALIZER;
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