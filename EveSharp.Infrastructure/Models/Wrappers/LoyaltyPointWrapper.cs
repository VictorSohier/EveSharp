using EveSharp.Core.Models.Loyalty;
using EveSharp.Infrastructure.Enums;
using Newtonsoft.Json;

namespace EveSharp.Infrastructure.Models.Wrappers
{
	public class LoyaltyPointWrapper
	{
		private readonly HttpClient _client;
		private readonly JsonSerializer _serializer;
		
		public LoyaltyPointWrapper()
		{
			_client = new();
			_client.BaseAddress = new($"{WrapperConfig._instance.DOMAIN}/{WrapperConfig._instance.API_VERSION}");
			_serializer = WrapperConfig._instance.SERIALIZER;
		}
		
		public async Task<LoyaltyPointCount[]> GetLoyaltyPointsAsync(OAuth2Token token, int characterId, DataSources datasource = DataSources.tranquility)
		{
			_client.DefaultRequestHeaders.Remove("Authorization");
			_client.DefaultRequestHeaders.Add("Authorization", $"{token.tokenType} {token.accessToken}");
			LoyaltyPointCount[] ret;
			
			HttpResponseMessage message = await _client.GetAsync($"characters/{characterId}/loyalty/points?datasource={Enum.GetName(datasource)?.ToLower()}");
			if (WrapperConfig._instance.SUCCESS.Contains(message.StatusCode))
				throw new Exception(_serializer.Deserialize<Error>(new JsonTextReader(new StreamReader(await message.Content.ReadAsStreamAsync()))).error);
			ret = _serializer.Deserialize<LoyaltyPointCount[]>(new JsonTextReader(new StreamReader(await message.Content.ReadAsStreamAsync())));
			return ret;
		}

		public async Task<LoyaltyPointStore[]> GetFacilitiesAsync(int corporationId, DataSources datasource = DataSources.tranquility)
		{
			HttpResponseMessage message = await _client.GetAsync($"loyalty/stores/{corporationId}/offers?datasource={Enum.GetName(datasource)?.ToLower()}");
			LoyaltyPointStore[] ret;
			if (WrapperConfig._instance.SUCCESS.Contains(message.StatusCode))
			{
				ret = _serializer.Deserialize<LoyaltyPointStore[]>(new JsonTextReader(new StreamReader(await message.Content.ReadAsStreamAsync())));
				return ret;
			}
			throw new Exception(_serializer.Deserialize<Error>(new JsonTextReader(new StreamReader(await message.Content.ReadAsStreamAsync()))).error);
		}
	}
}