using EveSharp.Core.Models.Contracts;
using EveSharp.Infrastructure.Enums;
using Newtonsoft.Json;

namespace EveSharp.Infrastructure.Models.Wrappers
{
	public class ContractWrapper
	{
		private readonly HttpClient _client;
		private readonly JsonSerializer _serializer;
		
		public ContractWrapper()
		{
			_client = new();
			_client.BaseAddress = new($"{WrapperConfig._instance.DOMAIN}");
			_serializer = WrapperConfig._instance.SERIALIZER;
		}
		
		public async Task<Contract[]> GetCharacterContractsAsync(OAuth2Token token, int characterId, int page = 1, DataSources datasource = DataSources.tranquility)
		{
			_client.DefaultRequestHeaders.Remove("Authorization");
			_client.DefaultRequestHeaders.Add("Authorization", $"{token.tokenType} {token.accessToken}");
			Contract[] ret;
			HttpResponseMessage message = await _client.GetAsync($"/{WrapperConfig._instance.API_VERSION}/characters/{characterId}/contracts?datasource={Enum.GetName(datasource)?.ToLower()}&page={page}");
			if (WrapperConfig._instance.SUCCESS.Contains(message.StatusCode))
			{
				ret = _serializer.Deserialize<Contract[]>(new JsonTextReader(new StreamReader(await message.Content.ReadAsStreamAsync())));
				return ret;
			}
			throw new Exception(_serializer.Deserialize<Error>(new JsonTextReader(new StreamReader(await message.Content.ReadAsStreamAsync()))).error);
		}
		
		public async Task<Bid[]> GetCharacterContractBidsAsync(OAuth2Token token, int characterId, int contractId, DataSources datasource = DataSources.tranquility)
		{
			_client.DefaultRequestHeaders.Remove("Authorization");
			_client.DefaultRequestHeaders.Add("Authorization", $"{token.tokenType} {token.accessToken}");
			Bid[] ret;
			HttpResponseMessage message = await _client.GetAsync($"/{WrapperConfig._instance.API_VERSION}/characters/{characterId}/contracts/{contractId}/bids?datasource={Enum.GetName(datasource)?.ToLower()}");
			if (WrapperConfig._instance.SUCCESS.Contains(message.StatusCode))
			{
				ret = _serializer.Deserialize<Bid[]>(new JsonTextReader(new StreamReader(await message.Content.ReadAsStreamAsync())));
				return ret;
			}
			throw new Exception(_serializer.Deserialize<Error>(new JsonTextReader(new StreamReader(await message.Content.ReadAsStreamAsync()))).error);
		}
		
		public async Task<Item[]> GetCharacterContractItemsAsync(OAuth2Token token, int characterId, int contractId, DataSources datasource = DataSources.tranquility)
		{
			_client.DefaultRequestHeaders.Remove("Authorization");
			_client.DefaultRequestHeaders.Add("Authorization", $"{token.tokenType} {token.accessToken}");
			Item[] ret;
			HttpResponseMessage message = await _client.GetAsync($"/{WrapperConfig._instance.API_VERSION}/characters/{characterId}/contracts/{contractId}/items?datasource={Enum.GetName(datasource)?.ToLower()}");
			if (WrapperConfig._instance.SUCCESS.Contains(message.StatusCode))
			{
				ret = _serializer.Deserialize<Item[]>(new JsonTextReader(new StreamReader(await message.Content.ReadAsStreamAsync())));
				return ret;
			}
			throw new Exception(_serializer.Deserialize<Error>(new JsonTextReader(new StreamReader(await message.Content.ReadAsStreamAsync()))).error);
		}
		
		public async Task<Contract[]> GetPublicContractsAsync(int regionId, int page = 1, DataSources datasource = DataSources.tranquility)
		{
			Contract[] ret;
			HttpResponseMessage message = await _client.GetAsync($"/{WrapperConfig._instance.API_VERSION}/contracts/public/{regionId}?datasource={Enum.GetName(datasource)?.ToLower()}&page={page}");
			if (WrapperConfig._instance.SUCCESS.Contains(message.StatusCode))
			{
				ret = _serializer.Deserialize<Contract[]>(new JsonTextReader(new StreamReader(await message.Content.ReadAsStreamAsync())));
				return ret;
			}
			throw new Exception(_serializer.Deserialize<Error>(new JsonTextReader(new StreamReader(await message.Content.ReadAsStreamAsync()))).error);
		}
		
		public async Task<Bid[]> GetPublicContractBidsAsync(int contractId, DataSources datasource = DataSources.tranquility)
		{
			Bid[] ret;
			HttpResponseMessage message = await _client.GetAsync($"/{WrapperConfig._instance.API_VERSION}//contracts/public/bids/{contractId}?datasource={Enum.GetName(datasource)?.ToLower()}");
			if (WrapperConfig._instance.SUCCESS.Contains(message.StatusCode))
			{
				ret = _serializer.Deserialize<Bid[]>(new JsonTextReader(new StreamReader(await message.Content.ReadAsStreamAsync())));
				return ret;
			}
			throw new Exception(_serializer.Deserialize<Error>(new JsonTextReader(new StreamReader(await message.Content.ReadAsStreamAsync()))).error);
		}
		
		public async Task<Item[]> GetPublicContractItemsAsync(int contractId, DataSources datasource = DataSources.tranquility)
		{
			Item[] ret;
			HttpResponseMessage message = await _client.GetAsync($"/{WrapperConfig._instance.API_VERSION}/contracts/public/items/{contractId}?datasource={Enum.GetName(datasource)?.ToLower()}");
			if (WrapperConfig._instance.SUCCESS.Contains(message.StatusCode))
			{
				ret = _serializer.Deserialize<Item[]>(new JsonTextReader(new StreamReader(await message.Content.ReadAsStreamAsync())));
				return ret;
			}
			throw new Exception(_serializer.Deserialize<Error>(new JsonTextReader(new StreamReader(await message.Content.ReadAsStreamAsync()))).error);
		}
		
		public async Task<Contract[]> GetCorporationContractsAsync(OAuth2Token token, int corporationId, int page = 1, DataSources datasource = DataSources.tranquility)
		{
			_client.DefaultRequestHeaders.Remove("Authorization");
			_client.DefaultRequestHeaders.Add("Authorization", $"{token.tokenType} {token.accessToken}");
			Contract[] ret;
			HttpResponseMessage message = await _client.GetAsync($"/{WrapperConfig._instance.API_VERSION}/corporations/{corporationId}/contracts?datasource={Enum.GetName(datasource)?.ToLower()}&page={page}");
			if (WrapperConfig._instance.SUCCESS.Contains(message.StatusCode))
			{
				ret = _serializer.Deserialize<Contract[]>(new JsonTextReader(new StreamReader(await message.Content.ReadAsStreamAsync())));
				return ret;
			}
			throw new Exception(_serializer.Deserialize<Error>(new JsonTextReader(new StreamReader(await message.Content.ReadAsStreamAsync()))).error);
		}
		
		public async Task<Bid[]> GetCorporationContractBidsAsync(OAuth2Token token, int corporationId, int contractId, DataSources datasource = DataSources.tranquility)
		{
			_client.DefaultRequestHeaders.Remove("Authorization");
			_client.DefaultRequestHeaders.Add("Authorization", $"{token.tokenType} {token.accessToken}");
			Bid[] ret;
			HttpResponseMessage message = await _client.GetAsync($"/{WrapperConfig._instance.API_VERSION}/corporations/{corporationId}/contracts/{contractId}/bids?datasource={Enum.GetName(datasource)?.ToLower()}");
			if (WrapperConfig._instance.SUCCESS.Contains(message.StatusCode))
			{
				ret = _serializer.Deserialize<Bid[]>(new JsonTextReader(new StreamReader(await message.Content.ReadAsStreamAsync())));
				return ret;
			}
			throw new Exception(_serializer.Deserialize<Error>(new JsonTextReader(new StreamReader(await message.Content.ReadAsStreamAsync()))).error);
		}
		
		public async Task<Item[]> GetCorporationContractItemsAsync(OAuth2Token token, int corporationId, int contractId, DataSources datasource = DataSources.tranquility)
		{
			_client.DefaultRequestHeaders.Remove("Authorization");
			_client.DefaultRequestHeaders.Add("Authorization", $"{token.tokenType} {token.accessToken}");
			Item[] ret;
			HttpResponseMessage message = await _client.GetAsync($"/{WrapperConfig._instance.API_VERSION}/corporations/{corporationId}/contracts/{contractId}/items?datasource={Enum.GetName(datasource)?.ToLower()}");
			if (WrapperConfig._instance.SUCCESS.Contains(message.StatusCode))
			{
				ret = _serializer.Deserialize<Item[]>(new JsonTextReader(new StreamReader(await message.Content.ReadAsStreamAsync())));
				return ret;
			}
			throw new Exception(_serializer.Deserialize<Error>(new JsonTextReader(new StreamReader(await message.Content.ReadAsStreamAsync()))).error);
		}
	}
}