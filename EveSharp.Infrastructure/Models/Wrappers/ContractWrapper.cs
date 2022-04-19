using EveSharp.Core.Models.Contracts;
using EveSharp.Infrastructure.Enums;
using Newtonsoft.Json;

namespace EveSharp.Infrastructure.Models.Wrappers
{
	public class ContractWrapper
	{
		private readonly HttpClient _client;
		private readonly JsonSerializer _serializer;
		
		public ContractWrapper(string authToken) : this()
		{
			_client.DefaultRequestHeaders.Add("authorization", authToken);
		}
		
		public ContractWrapper()
		{
			_client = new();
			_client.BaseAddress = new($"{WrapperConfig._instance.DOMAIN}/{WrapperConfig._instance.API_VERSION}");
			_serializer = WrapperConfig._instance.SERIALIZER;
		}
		
		public async Task<Contract[]> GetCharacterContractsAsync(int characterId, int page = 1, DataSources datasource = DataSources.tranquility)
		{
			Contract[] ret;
			if (_client.DefaultRequestHeaders.Any(e => e.Key == "authorization" & e.Value.Any(f => !string.IsNullOrWhiteSpace(f))))
			{
				HttpResponseMessage message = await _client.GetAsync($"characters/{characterId}/contracts?datasource={Enum.GetName(datasource)?.ToLower()}&page={page}");
				if (WrapperConfig._instance.SUCCESS.Contains(message.StatusCode))
					throw new Exception(_serializer.Deserialize<Error>(new JsonTextReader(new StreamReader(await message.Content.ReadAsStreamAsync()))).error);
				ret = _serializer.Deserialize<Contract[]>(new JsonTextReader(new StreamReader(await message.Content.ReadAsStreamAsync())));
			}
			else
			{
				throw new Exception("No Authorization Token, this endpoint will fail.");
			}
			return ret;
		}
		
		public async Task<Bid[]> GetCharacterContractBidsAsync(int characterId, int contractId, DataSources datasource = DataSources.tranquility)
		{
			Bid[] ret;
			if (_client.DefaultRequestHeaders.Any(e => e.Key == "authorization" & e.Value.Any(f => !string.IsNullOrWhiteSpace(f))))
			{
				HttpResponseMessage message = await _client.GetAsync($"characters/{characterId}/contracts/{contractId}/bids?datasource={Enum.GetName(datasource)?.ToLower()}");
				if (WrapperConfig._instance.SUCCESS.Contains(message.StatusCode))
					throw new Exception(_serializer.Deserialize<Error>(new JsonTextReader(new StreamReader(await message.Content.ReadAsStreamAsync()))).error);
				ret = _serializer.Deserialize<Bid[]>(new JsonTextReader(new StreamReader(await message.Content.ReadAsStreamAsync())));
			}
			else
			{
				throw new Exception("No Authorization Token, this endpoint will fail.");
			}
			return ret;
		}
		
		public async Task<Item[]> GetCharacterContractItemsAsync(int characterId, int contractId, DataSources datasource = DataSources.tranquility)
		{
			Item[] ret;
			if (_client.DefaultRequestHeaders.Any(e => e.Key == "authorization" & e.Value.Any(f => !string.IsNullOrWhiteSpace(f))))
			{
				HttpResponseMessage message = await _client.GetAsync($"characters/{characterId}/contracts/{contractId}/items?datasource={Enum.GetName(datasource)?.ToLower()}");
				if (WrapperConfig._instance.SUCCESS.Contains(message.StatusCode))
					throw new Exception(_serializer.Deserialize<Error>(new JsonTextReader(new StreamReader(await message.Content.ReadAsStreamAsync()))).error);
				ret = _serializer.Deserialize<Item[]>(new JsonTextReader(new StreamReader(await message.Content.ReadAsStreamAsync())));
			}
			else
			{
				throw new Exception("No Authorization Token, this endpoint will fail.");
			}
			return ret;
		}
		
		public async Task<Contract[]> GetPublicContractsAsync(int regionId, int page = 1, DataSources datasource = DataSources.tranquility)
		{
			Contract[] ret;
			HttpResponseMessage message = await _client.GetAsync($"contracts/public/{regionId}?datasource={Enum.GetName(datasource)?.ToLower()}&page={page}");
			if (WrapperConfig._instance.SUCCESS.Contains(message.StatusCode))
				throw new Exception(_serializer.Deserialize<Error>(new JsonTextReader(new StreamReader(await message.Content.ReadAsStreamAsync()))).error);
			ret = _serializer.Deserialize<Contract[]>(new JsonTextReader(new StreamReader(await message.Content.ReadAsStreamAsync())));
			return ret;
		}
		
		public async Task<Bid[]> GetPublicContractBidsAsync(int contractId, DataSources datasource = DataSources.tranquility)
		{
			Bid[] ret;
			HttpResponseMessage message = await _client.GetAsync($"/contracts/public/bids/{contractId}?datasource={Enum.GetName(datasource)?.ToLower()}");
			if (WrapperConfig._instance.SUCCESS.Contains(message.StatusCode))
				throw new Exception(_serializer.Deserialize<Error>(new JsonTextReader(new StreamReader(await message.Content.ReadAsStreamAsync()))).error);
			ret = _serializer.Deserialize<Bid[]>(new JsonTextReader(new StreamReader(await message.Content.ReadAsStreamAsync())));
			return ret;
		}
		
		public async Task<Item[]> GetPublicContractItemsAsync(int contractId, DataSources datasource = DataSources.tranquility)
		{
			Item[] ret;
			HttpResponseMessage message = await _client.GetAsync($"contracts/public/items/{contractId}?datasource={Enum.GetName(datasource)?.ToLower()}");
			if (WrapperConfig._instance.SUCCESS.Contains(message.StatusCode))
				throw new Exception(_serializer.Deserialize<Error>(new JsonTextReader(new StreamReader(await message.Content.ReadAsStreamAsync()))).error);
			ret = _serializer.Deserialize<Item[]>(new JsonTextReader(new StreamReader(await message.Content.ReadAsStreamAsync())));
			return ret;
		}
		
		public async Task<Contract[]> GetCorporationContractsAsync(int corporationId, int page = 1, DataSources datasource = DataSources.tranquility)
		{
			Contract[] ret;
			if (_client.DefaultRequestHeaders.Any(e => e.Key == "authorization" & e.Value.Any(f => !string.IsNullOrWhiteSpace(f))))
			{
				HttpResponseMessage message = await _client.GetAsync($"corporations/{corporationId}/contracts?datasource={Enum.GetName(datasource)?.ToLower()}&page={page}");
				if (WrapperConfig._instance.SUCCESS.Contains(message.StatusCode))
					throw new Exception(_serializer.Deserialize<Error>(new JsonTextReader(new StreamReader(await message.Content.ReadAsStreamAsync()))).error);
				ret = _serializer.Deserialize<Contract[]>(new JsonTextReader(new StreamReader(await message.Content.ReadAsStreamAsync())));
			}
			else
			{
				throw new Exception("No Authorization Token, this endpoint will fail.");
			}
			return ret;
		}
		
		public async Task<Bid[]> GetCorporationContractBidsAsync(int corporationId, int contractId, DataSources datasource = DataSources.tranquility)
		{
			Bid[] ret;
			if (_client.DefaultRequestHeaders.Any(e => e.Key == "authorization" & e.Value.Any(f => !string.IsNullOrWhiteSpace(f))))
			{
				HttpResponseMessage message = await _client.GetAsync($"corporations/{corporationId}/contracts/{contractId}/bids?datasource={Enum.GetName(datasource)?.ToLower()}");
				if (WrapperConfig._instance.SUCCESS.Contains(message.StatusCode))
					throw new Exception(_serializer.Deserialize<Error>(new JsonTextReader(new StreamReader(await message.Content.ReadAsStreamAsync()))).error);
				ret = _serializer.Deserialize<Bid[]>(new JsonTextReader(new StreamReader(await message.Content.ReadAsStreamAsync())));
			}
			else
			{
				throw new Exception("No Authorization Token, this endpoint will fail.");
			}
			return ret;
		}
		
		public async Task<Item[]> GetCorporationContractItemsAsync(int corporationId, int contractId, DataSources datasource = DataSources.tranquility)
		{
			Item[] ret;
			if (_client.DefaultRequestHeaders.Any(e => e.Key == "authorization" & e.Value.Any(f => !string.IsNullOrWhiteSpace(f))))
			{
				HttpResponseMessage message = await _client.GetAsync($"corporations/{corporationId}/contracts/{contractId}/items?datasource={Enum.GetName(datasource)?.ToLower()}");
				if (WrapperConfig._instance.SUCCESS.Contains(message.StatusCode))
					throw new Exception(_serializer.Deserialize<Error>(new JsonTextReader(new StreamReader(await message.Content.ReadAsStreamAsync()))).error);
				ret = _serializer.Deserialize<Item[]>(new JsonTextReader(new StreamReader(await message.Content.ReadAsStreamAsync())));
			}
			else
			{
				throw new Exception("No Authorization Token, this endpoint will fail.");
			}
			return ret;
		}
	}
}