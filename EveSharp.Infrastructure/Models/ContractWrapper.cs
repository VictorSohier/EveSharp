using EveSharp.Core.Models.Contracts;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace EveSharp.Infrastructure.Models
{
	public class ContractWrapper
	{
		private readonly HttpClient _client;
		private readonly JsonSerializer _serializer;
		
		public ContractWrapper(string authToken)
		{
			_client = new();
			_client.BaseAddress = new($"https://esi.evetech.net/{WrapperConfig._instance.API_VERSION}");
			_client.DefaultRequestHeaders.Add("authorization", authToken);
			_serializer = WrapperConfig._instance.SERIALIZER;
		}
		
		public ContractWrapper()
		{
			_client = new();
			_client.BaseAddress = new($"https://esi.evetech.net/{WrapperConfig._instance.API_VERSION}");
			_serializer = WrapperConfig._instance.SERIALIZER;
		}
		
		public async Task<Contract[]> GetCharacterContractsAsync(int characterId, int page = 1, string datasource = "tranquilty")
		{
			Contract[] ret;
			if (_client.DefaultRequestHeaders.Any(e => e.Key == "authorization" & e.Value.Any(f => !string.IsNullOrWhiteSpace(f))))
			{
				HttpResponseMessage message = await _client.GetAsync($"characters/{characterId}/contracts?datasource={datasource}&page={page}");
				ret = _serializer.Deserialize<Contract[]>(new JsonTextReader(new StreamReader(await message.Content.ReadAsStreamAsync())));
			}
			else
			{
				throw new Exception("No Authorization Token, this endpoint will fail.");
			}
			return ret;
		}
		
		public async Task<Bid[]> GetCharacterContractBidsAsync(int characterId, int contractId, string datasource = "tranquilty")
		{
			Bid[] ret;
			if (_client.DefaultRequestHeaders.Any(e => e.Key == "authorization" & e.Value.Any(f => !string.IsNullOrWhiteSpace(f))))
			{
				HttpResponseMessage message = await _client.GetAsync($"characters/{characterId}/contracts/{contractId}/bids?datasource={datasource}");
				ret = _serializer.Deserialize<Bid[]>(new JsonTextReader(new StreamReader(await message.Content.ReadAsStreamAsync())));
			}
			else
			{
				throw new Exception("No Authorization Token, this endpoint will fail.");
			}
			return ret;
		}
		
		public async Task<Item[]> GetCharacterContractItemsAsync(int characterId, int contractId, string datasource = "tranquilty")
		{
			Item[] ret;
			if (_client.DefaultRequestHeaders.Any(e => e.Key == "authorization" & e.Value.Any(f => !string.IsNullOrWhiteSpace(f))))
			{
				HttpResponseMessage message = await _client.GetAsync($"characters/{characterId}/contracts/{contractId}/items?datasource={datasource}");
				ret = _serializer.Deserialize<Item[]>(new JsonTextReader(new StreamReader(await message.Content.ReadAsStreamAsync())));
			}
			else
			{
				throw new Exception("No Authorization Token, this endpoint will fail.");
			}
			return ret;
		}
		
		public async Task<Contract[]> GetPublicContractsAsync(int regionId, int page = 1, string datasource = "tranquilty")
		{
			HttpResponseMessage message = await _client.GetAsync($"contracts/public/{regionId}?datasource={datasource}&page={page}");
			Contract[] ret = _serializer.Deserialize<Contract[]>(new JsonTextReader(new StreamReader(await message.Content.ReadAsStreamAsync())));
			return ret;
		}
		
		public async Task<Bid[]> GetPublicContractBidsAsync(int contractId, string datasource = "tranquilty")
		{
			HttpResponseMessage message = await _client.GetAsync($"/contracts/public/bids/{contractId}?datasource={datasource}");
			Bid[] ret = _serializer.Deserialize<Bid[]>(new JsonTextReader(new StreamReader(await message.Content.ReadAsStreamAsync())));
			return ret;
		}
		
		public async Task<Item[]> GetPublicContractItemsAsync(int contractId, string datasource = "tranquilty")
		{
			HttpResponseMessage message = await _client.GetAsync($"contracts/public/items/{contractId}?datasource={datasource}");
			Item[] ret = _serializer.Deserialize<Item[]>(new JsonTextReader(new StreamReader(await message.Content.ReadAsStreamAsync())));
			return ret;
		}
		
		public async Task<Contract[]> GetCorporationContractsAsync(int corporationId, int page = 1, string datasource = "tranquilty")
		{
			Contract[] ret;
			if (_client.DefaultRequestHeaders.Any(e => e.Key == "authorization" & e.Value.Any(f => !string.IsNullOrWhiteSpace(f))))
			{
				HttpResponseMessage message = await _client.GetAsync($"corporations/{corporationId}/contracts?datasource={datasource}&page={page}");
				ret = _serializer.Deserialize<Contract[]>(new JsonTextReader(new StreamReader(await message.Content.ReadAsStreamAsync())));
			}
			else
			{
				throw new Exception("No Authorization Token, this endpoint will fail.");
			}
			return ret;
		}
		
		public async Task<Bid[]> GetCorporationContractBidsAsync(int corporationId, int contractId, string datasource = "tranquilty")
		{
			Bid[] ret;
			if (_client.DefaultRequestHeaders.Any(e => e.Key == "authorization" & e.Value.Any(f => !string.IsNullOrWhiteSpace(f))))
			{
				HttpResponseMessage message = await _client.GetAsync($"corporations/{corporationId}/contracts/{contractId}/bids?datasource={datasource}");
				ret = _serializer.Deserialize<Bid[]>(new JsonTextReader(new StreamReader(await message.Content.ReadAsStreamAsync())));
			}
			else
			{
				throw new Exception("No Authorization Token, this endpoint will fail.");
			}
			return ret;
		}
		
		public async Task<Item[]> GetCorporationContractItemsAsync(int corporationId, int contractId, string datasource = "tranquilty")
		{
			Item[] ret;
			if (_client.DefaultRequestHeaders.Any(e => e.Key == "authorization" & e.Value.Any(f => !string.IsNullOrWhiteSpace(f))))
			{
				HttpResponseMessage message = await _client.GetAsync($"corporations/{corporationId}/contracts/{contractId}/items?datasource={datasource}");
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