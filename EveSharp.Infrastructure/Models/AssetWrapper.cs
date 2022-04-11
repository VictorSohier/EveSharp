using System.Net.Http.Json;
using EveSharp.Core.Models.Asset;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace EveSharp.Infrastructure.Models
{
	public class AssetWrapper
	{
		private readonly HttpClient _client;
		private readonly JsonSerializer _serializer;
		
		public AssetWrapper(string authToken)
		{
			_client = new();
			_client.BaseAddress = new("https://esi.evetech.net/latest");
			_client.DefaultRequestHeaders.Add("authorization", authToken);
			
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
		
		public async Task<Asset[]> GetCharacterAssetsAsync(int characterId, string datasource = "tranquility")
		{
			HttpResponseMessage message = await _client.GetAsync($"characters/{characterId}/assets?datasource={datasource}");
			Asset[] ret = _serializer.Deserialize<Asset[]>(new JsonTextReader(new StreamReader(await message.Content.ReadAsStreamAsync())));
			return ret;
		}
		
		public async Task<Location[]> GetCharacterAssetLocationsAsync(int characterId, string datasource = "tranquility", params long[] itemIds)
		{
			HttpResponseMessage message = await _client.PostAsync($"characters/{characterId}/assets/locations?datasource={datasource}", JsonContent.Create<long[]>(itemIds));
			Location[] ret = _serializer.Deserialize<Location[]>(new JsonTextReader(new StreamReader(await message.Content.ReadAsStreamAsync())));
			return ret;
		}
		
		public async Task<AssetName[]> GetCharacterAssetNamesAsync(int characterId, string datasource = "tranquility", params long[] itemIds)
		{
			HttpResponseMessage message = await _client.PostAsync($"characters/{characterId}/assets/names?datasource={datasource}", JsonContent.Create<long[]>(itemIds));
			AssetName[] ret = _serializer.Deserialize<AssetName[]>(new JsonTextReader(new StreamReader(await message.Content.ReadAsStreamAsync())));
			return ret;
		}
		
		public async Task<Asset[]> GetCorporationAssetsAsync(int corporationId, string datasource = "tranquility")
		{
			HttpResponseMessage message = await _client.GetAsync($"corporation/{corporationId}/assets?datasource={datasource}");
			Asset[] ret = _serializer.Deserialize<Asset[]>(new JsonTextReader(new StreamReader(await message.Content.ReadAsStreamAsync())));
			return ret;
		}
		
		public async Task<Location[]> GetCorporationAssetLocationsAsync(int corporationId, string datasource = "tranquility", params long[] itemIds)
		{
			HttpResponseMessage message = await _client.PostAsync($"corporation/{corporationId}/assets/locations?datasource={datasource}", JsonContent.Create<long[]>(itemIds));
			Location[] ret = _serializer.Deserialize<Location[]>(new JsonTextReader(new StreamReader(await message.Content.ReadAsStreamAsync())));
			return ret;
		}
		
		public async Task<AssetName[]> GetCorporationAssetNamesAsync(int corporationId, string datasource = "tranquility", params long[] itemIds)
		{
			HttpResponseMessage message = await _client.PostAsync($"corporation/{corporationId}/assets/names?datasource={datasource}", JsonContent.Create<long[]>(itemIds));
			AssetName[] ret = _serializer.Deserialize<AssetName[]>(new JsonTextReader(new StreamReader(await message.Content.ReadAsStreamAsync())));
			return ret;
		}
	}
}