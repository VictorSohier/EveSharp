using EveSharp.Core.Models.Loyalty;
using EveSharp.Infrastructure.Enums;
using Newtonsoft.Json;

namespace EveSharp.Infrastructure.Models.Wrappers
{
	public class LoyaltyPointWrapper
	{
		private readonly HttpClient _client;
		private readonly JsonSerializer _serializer;
		
		public LoyaltyPointWrapper(string authToken) : this()
		{
			_client.DefaultRequestHeaders.Add("authorization", authToken);
		}
		
		public LoyaltyPointWrapper()
		{
			_client = new();
			_client.BaseAddress = new($"{WrapperConfig._instance.DOMAIN}/{WrapperConfig._instance.API_VERSION}");
			_serializer = WrapperConfig._instance.SERIALIZER;
		}
		
		public async Task<LoyaltyPointCount[]> GetLoyaltyPointsAsync(int characterId, DataSources datasource = DataSources.tranquility)
		{
			LoyaltyPointCount[] ret;
			if (_client.DefaultRequestHeaders.Any(e => e.Key == "authorization" & e.Value.Any(f => !string.IsNullOrWhiteSpace(f))))
			{
				HttpResponseMessage message = await _client.GetAsync($"characters/{characterId}/loyalty/points?datasource={Enum.GetName(datasource)?.ToLower()}");
				if (WrapperConfig._instance.SUCCESS.Contains(message.StatusCode))
					throw new Exception(_serializer.Deserialize<Error>(new JsonTextReader(new StreamReader(await message.Content.ReadAsStreamAsync()))).error);
				ret = _serializer.Deserialize<LoyaltyPointCount[]>(new JsonTextReader(new StreamReader(await message.Content.ReadAsStreamAsync())));
			}
			else
			{
				throw new Exception("No Authorization Token, this endpoint will fail.");
			}
			return ret;
		}

		public async Task<LoyaltyPointStore[]> GetFacilitiesAsync(int corporationId, DataSources datasource = DataSources.tranquility)
		{
			HttpResponseMessage message = await _client.GetAsync($"loyalty/stores/{corporationId}/offers?datasource={Enum.GetName(datasource)?.ToLower()}");
			LoyaltyPointStore[] ret;
			if (WrapperConfig._instance.SUCCESS.Contains(message.StatusCode))
				throw new Exception(_serializer.Deserialize<Error>(new JsonTextReader(new StreamReader(await message.Content.ReadAsStreamAsync()))).error);
			ret = _serializer.Deserialize<LoyaltyPointStore[]>(new JsonTextReader(new StreamReader(await message.Content.ReadAsStreamAsync())));
			return ret;
		}
	}
}