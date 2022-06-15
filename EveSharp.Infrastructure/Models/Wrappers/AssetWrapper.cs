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
		
		public AssetWrapper()
		{
			_client = new();
			_client.BaseAddress = new($"{WrapperConfig._instance.DOMAIN}");
			_serializer = WrapperConfig._instance.SERIALIZER;
		}
		
		public async Task<Asset[]> GetCharacterAssetsAsync(OAuth2Token token, int characterId, int page = 1, DataSources datasource = DataSources.tranquility)
		{
			_client.DefaultRequestHeaders.Remove("Authorization");
			_client.DefaultRequestHeaders.Add("Authorization", $"{token.tokenType} {token.accessToken}");
			HttpResponseMessage message = await _client.GetAsync(
				$"/{WrapperConfig._instance.API_VERSION}/characters/{characterId}/assets?datasource={Enum.GetName(datasource)?.ToLower()}&page={page}"
			);
			Asset[] ret;
			if (WrapperConfig._instance.SUCCESS.Contains(message.StatusCode))
			{
				ret = _serializer.Deserialize<Asset[]>(new JsonTextReader(new StreamReader(await message.Content.ReadAsStreamAsync())));
				return ret;
			}
			throw new Exception(_serializer.Deserialize<Error>(new JsonTextReader(new StreamReader(await message.Content.ReadAsStreamAsync()))).error);
		}
		
		public async Task<Location[]> GetCharacterAssetLocationsAsync(OAuth2Token token, int characterId, DataSources datasource = DataSources.tranquility, params long[] itemIds)
		{
			_client.DefaultRequestHeaders.Remove("Authorization");
			_client.DefaultRequestHeaders.Add("Authorization", $"{token.tokenType} {token.accessToken}");
			HttpResponseMessage message = await _client.PostAsync(
				$"/{WrapperConfig._instance.API_VERSION}/characters/{characterId}/assets/locations?datasource={Enum.GetName(datasource)?.ToLower()}", JsonContent.Create(itemIds)
			);
			Location[] ret;
			if (WrapperConfig._instance.SUCCESS.Contains(message.StatusCode))
			{
				ret = _serializer.Deserialize<Location[]>(new JsonTextReader(new StreamReader(await message.Content.ReadAsStreamAsync())));
				return ret;
			}
			throw new Exception(_serializer.Deserialize<Error>(new JsonTextReader(new StreamReader(await message.Content.ReadAsStreamAsync()))).error);
		}
		
		public async Task<AssetName[]> GetCharacterAssetNamesAsync(OAuth2Token token, int characterId, DataSources datasource = DataSources.tranquility, params long[] itemIds)
		{
			_client.DefaultRequestHeaders.Remove("Authorization");
			_client.DefaultRequestHeaders.Add("Authorization", $"{token.tokenType} {token.accessToken}");
			HttpResponseMessage message = await _client.PostAsync(
				$"/{WrapperConfig._instance.API_VERSION}/characters/{characterId}/assets/names?datasource={Enum.GetName(datasource)?.ToLower()}", JsonContent.Create(itemIds)
			);
			AssetName[] ret;
			if (WrapperConfig._instance.SUCCESS.Contains(message.StatusCode))
			{
				ret = _serializer.Deserialize<AssetName[]>(new JsonTextReader(new StreamReader(await message.Content.ReadAsStreamAsync())));
				return ret;
			}
			throw new Exception(_serializer.Deserialize<Error>(new JsonTextReader(new StreamReader(await message.Content.ReadAsStreamAsync()))).error);
		}
		
		public async Task<Asset[]> GetCorporationAssetsAsync(OAuth2Token token, int corporationId, int page = 1, DataSources datasource = DataSources.tranquility)
		{
			_client.DefaultRequestHeaders.Remove("Authorization");
			_client.DefaultRequestHeaders.Add("Authorization", $"{token.tokenType} {token.accessToken}");
			HttpResponseMessage message = await _client.GetAsync(
				$"/{WrapperConfig._instance.API_VERSION}/corporation/{corporationId}/assets?datasource={Enum.GetName(datasource)?.ToLower()}&page={page}"
			);
			Asset[] ret;
			if (WrapperConfig._instance.SUCCESS.Contains(message.StatusCode))
			{
				ret = _serializer.Deserialize<Asset[]>(new JsonTextReader(new StreamReader(await message.Content.ReadAsStreamAsync())));
				return ret;
			}
			throw new Exception(_serializer.Deserialize<Error>(new JsonTextReader(new StreamReader(await message.Content.ReadAsStreamAsync()))).error);
		}
		
		public async Task<Location[]> GetCorporationAssetLocationsAsync(OAuth2Token token, int corporationId, DataSources datasource = DataSources.tranquility, params long[] itemIds)
		{
			_client.DefaultRequestHeaders.Remove("Authorization");
			_client.DefaultRequestHeaders.Add("Authorization", $"{token.tokenType} {token.accessToken}");
			HttpResponseMessage message = await _client.PostAsync(
				$"/{WrapperConfig._instance.API_VERSION}/corporation/{corporationId}/assets/locations?datasource={Enum.GetName(datasource)?.ToLower()}", JsonContent.Create(itemIds)
			);
			Location[] ret;
			if (WrapperConfig._instance.SUCCESS.Contains(message.StatusCode))
			{
				ret = _serializer.Deserialize<Location[]>(new JsonTextReader(new StreamReader(await message.Content.ReadAsStreamAsync())));
				return ret;
			}
			throw new Exception(_serializer.Deserialize<Error>(new JsonTextReader(new StreamReader(await message.Content.ReadAsStreamAsync()))).error);
		}
		
		public async Task<AssetName[]> GetCorporationAssetNamesAsync(OAuth2Token token, int corporationId, DataSources datasource = DataSources.tranquility, params long[] itemIds)
		{
			_client.DefaultRequestHeaders.Remove("Authorization");
			_client.DefaultRequestHeaders.Add("Authorization", $"{token.tokenType} {token.accessToken}");
			HttpResponseMessage message = await _client.PostAsync(
				$"/{WrapperConfig._instance.API_VERSION}/corporation/{corporationId}/assets/names?datasource={Enum.GetName(datasource)?.ToLower()}", JsonContent.Create(itemIds)
			);
			AssetName[] ret;
			if (WrapperConfig._instance.SUCCESS.Contains(message.StatusCode))
			{
				ret = _serializer.Deserialize<AssetName[]>(new JsonTextReader(new StreamReader(await message.Content.ReadAsStreamAsync())));
				return ret;
			}
			throw new Exception(_serializer.Deserialize<Error>(new JsonTextReader(new StreamReader(await message.Content.ReadAsStreamAsync()))).error);
		}
	}
}