using EveSharp.Core.Models;
using EveSharp.Core.Models.Alliance;
using EveSharp.Infrastructure.Enums;
using Newtonsoft.Json;

namespace EveSharp.Infrastructure.Models.Wrappers
{
	public class AllianceWrapper
	{
		private readonly HttpClient _client;
		private readonly JsonSerializer _serializer;
		
		public AllianceWrapper()
		{
			_client = new();
			_client.BaseAddress = new($"{WrapperConfig._instance.DOMAIN}");
			_serializer = WrapperConfig._instance.SERIALIZER;
		}
		
		public async Task<int[]> GetAlliancesAsync(DataSources datasource = DataSources.tranquility)
		{
			HttpResponseMessage message = await _client.GetAsync($"/{WrapperConfig._instance.API_VERSION}/alliances?datasource={Enum.GetName(datasource)?.ToLower()}");
			int[] ret = _serializer.Deserialize<int[]>(new JsonTextReader(new StreamReader(await message.Content.ReadAsStreamAsync())));
			return ret;
		}
		
		public async Task<Alliance> GetAllianceAsync(int allianceId, DataSources datasource = DataSources.tranquility)
		{
			HttpResponseMessage message = await _client.GetAsync($"/{WrapperConfig._instance.API_VERSION}/alliances/{allianceId}?datasource={Enum.GetName(datasource)?.ToLower()}");
			Alliance ret;
			if (WrapperConfig._instance.SUCCESS.Contains(message.StatusCode))
			{
				ret = _serializer.Deserialize<Alliance>(new JsonTextReader(new StreamReader(await message.Content.ReadAsStreamAsync())));
				return ret;
			}
			throw new Exception(_serializer.Deserialize<Error>(new JsonTextReader(new StreamReader(await message.Content.ReadAsStreamAsync()))).error);
		}
		
		public async Task<int[]> GetAllianceCorporationsAsync(int allianceId, DataSources datasource = DataSources.tranquility)
		{
			HttpResponseMessage message = await _client.GetAsync($"/{WrapperConfig._instance.API_VERSION}/alliances/{allianceId}/corporations?datasource={Enum.GetName(datasource)?.ToLower()}");
			int[] ret;
			if (WrapperConfig._instance.SUCCESS.Contains(message.StatusCode))
			{
				ret = _serializer.Deserialize<int[]>(new JsonTextReader(new StreamReader(await message.Content.ReadAsStreamAsync())));
				return ret;
			}
			throw new Exception(_serializer.Deserialize<Error>(new JsonTextReader(new StreamReader(await message.Content.ReadAsStreamAsync()))).error);
			
		}
		
		public async Task<Icon> GetAllianceIconsAsync(int allianceId, DataSources datasource = DataSources.tranquility)
		{
			HttpResponseMessage message = await _client.GetAsync($"/{WrapperConfig._instance.API_VERSION}/alliances/{allianceId}/icons?datasource={Enum.GetName(datasource)?.ToLower()}");
			Icon ret;
			if (WrapperConfig._instance.SUCCESS.Contains(message.StatusCode))
			{
				ret = _serializer.Deserialize<Icon>(new JsonTextReader(new StreamReader(await message.Content.ReadAsStreamAsync())));
				return ret;
			}
			throw new Exception(_serializer.Deserialize<Error>(new JsonTextReader(new StreamReader(await message.Content.ReadAsStreamAsync()))).error);
		}
	}
}