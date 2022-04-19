using System.Net.Http.Json;
using EveSharp.Core.Models.Asset;
using EveSharp.Infrastructure.Enums;
using Newtonsoft.Json;

namespace EveSharp.Infrastructure.Models.Wrappers
{
	public class AssetWrapper
	{
		private readonly HttpClient _client;
		private readonly JsonSerializer _serializer;
		
		public AssetWrapper(string authToken)
		{
			_client = new();
			_client.BaseAddress = new($"{WrapperConfig._instance.DOMAIN}/{WrapperConfig._instance.API_VERSION}");
			_client.DefaultRequestHeaders.Add("authorization", authToken);
			_serializer = WrapperConfig._instance.SERIALIZER;
		}
		
		public async Task<Asset[]> GetCharacterAssetsAsync(int characterId, int page = 1, DataSources datasource = DataSources.tranquility)
		{
			HttpResponseMessage message = await _client.GetAsync($"characters/{characterId}/assets?datasource={Enum.GetName(datasource)?.ToLower()}&page={page}");
			Asset[] ret;
			if (WrapperConfig._instance.SUCCESS.Contains(message.StatusCode))
				throw new Exception(_serializer.Deserialize<Error>(new JsonTextReader(new StreamReader(await message.Content.ReadAsStreamAsync()))).error);
			ret = _serializer.Deserialize<Asset[]>(new JsonTextReader(new StreamReader(await message.Content.ReadAsStreamAsync())));
			return ret;
		}
		
		public async Task<Location[]> GetCharacterAssetLocationsAsync(int characterId, DataSources datasource = DataSources.tranquility, params long[] itemIds)
		{
			HttpResponseMessage message = await _client.PostAsync($"characters/{characterId}/assets/locations?datasource={Enum.GetName(datasource)?.ToLower()}", JsonContent.Create(itemIds));
			Location[] ret;
			if (WrapperConfig._instance.SUCCESS.Contains(message.StatusCode))
				throw new Exception(_serializer.Deserialize<Error>(new JsonTextReader(new StreamReader(await message.Content.ReadAsStreamAsync()))).error);
			ret = _serializer.Deserialize<Location[]>(new JsonTextReader(new StreamReader(await message.Content.ReadAsStreamAsync())));
			return ret;
		}
		
		public async Task<AssetName[]> GetCharacterAssetNamesAsync(int characterId, DataSources datasource = DataSources.tranquility, params long[] itemIds)
		{
			HttpResponseMessage message = await _client.PostAsync($"characters/{characterId}/assets/names?datasource={Enum.GetName(datasource)?.ToLower()}", JsonContent.Create(itemIds));
			AssetName[] ret;
			if (WrapperConfig._instance.SUCCESS.Contains(message.StatusCode))
				throw new Exception(_serializer.Deserialize<Error>(new JsonTextReader(new StreamReader(await message.Content.ReadAsStreamAsync()))).error);
			ret = _serializer.Deserialize<AssetName[]>(new JsonTextReader(new StreamReader(await message.Content.ReadAsStreamAsync())));
			return ret;
		}
		
		public async Task<Asset[]> GetCorporationAssetsAsync(int corporationId, int page = 1, DataSources datasource = DataSources.tranquility)
		{
			HttpResponseMessage message = await _client.GetAsync($"corporation/{corporationId}/assets?datasource={Enum.GetName(datasource)?.ToLower()}&page={page}");
			Asset[] ret;
			if (WrapperConfig._instance.SUCCESS.Contains(message.StatusCode))
				throw new Exception(_serializer.Deserialize<Error>(new JsonTextReader(new StreamReader(await message.Content.ReadAsStreamAsync()))).error);
			ret = _serializer.Deserialize<Asset[]>(new JsonTextReader(new StreamReader(await message.Content.ReadAsStreamAsync())));
			return ret;
		}
		
		public async Task<Location[]> GetCorporationAssetLocationsAsync(int corporationId, DataSources datasource = DataSources.tranquility, params long[] itemIds)
		{
			HttpResponseMessage message = await _client.PostAsync($"corporation/{corporationId}/assets/locations?datasource={Enum.GetName(datasource)?.ToLower()}", JsonContent.Create(itemIds));
			Location[] ret;
			if (WrapperConfig._instance.SUCCESS.Contains(message.StatusCode))
				throw new Exception(_serializer.Deserialize<Error>(new JsonTextReader(new StreamReader(await message.Content.ReadAsStreamAsync()))).error);
			ret = _serializer.Deserialize<Location[]>(new JsonTextReader(new StreamReader(await message.Content.ReadAsStreamAsync())));
			return ret;
		}
		
		public async Task<AssetName[]> GetCorporationAssetNamesAsync(int corporationId, DataSources datasource = DataSources.tranquility, params long[] itemIds)
		{
			HttpResponseMessage message = await _client.PostAsync($"corporation/{corporationId}/assets/names?datasource={Enum.GetName(datasource)?.ToLower()}", JsonContent.Create(itemIds));
			AssetName[] ret;
			if (WrapperConfig._instance.SUCCESS.Contains(message.StatusCode))
				throw new Exception(_serializer.Deserialize<Error>(new JsonTextReader(new StreamReader(await message.Content.ReadAsStreamAsync()))).error);
			ret = _serializer.Deserialize<AssetName[]>(new JsonTextReader(new StreamReader(await message.Content.ReadAsStreamAsync())));
			return ret;
		}
	}
}