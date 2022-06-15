using System.Net;
using EveSharp.Core.Models.Fitting;
using EveSharp.Infrastructure.Enums;
using Newtonsoft.Json;

namespace EveSharp.Infrastructure.Models.Wrappers
{
	public class FittingWrapper
	{
		private readonly HttpClient _client;
		private readonly JsonSerializer _serializer;
		
		public FittingWrapper()
		{
			_client = new();
			_client.BaseAddress = new($"{WrapperConfig._instance.DOMAIN}/{WrapperConfig._instance.API_VERSION}/characters");
			_serializer = WrapperConfig._instance.SERIALIZER;
		}
		
		public async Task<Fit[]> GetFitsAsync(OAuth2Token token, int characterId, DataSources datasource = DataSources.tranquility)
		{
			_client.DefaultRequestHeaders.Remove("Authorization");
			_client.DefaultRequestHeaders.Add("Authorization", $"{token.tokenType} {token.accessToken}");
			HttpResponseMessage message = await _client.GetAsync($"{characterId}/fittings?datasource={Enum.GetName(datasource)?.ToLower()}");
			Fit[] ret;
			if (WrapperConfig._instance.SUCCESS.Contains(message.StatusCode))
			{
				ret = _serializer.Deserialize<Fit[]>(new JsonTextReader(new StreamReader(await message.Content.ReadAsStreamAsync())));
				return ret;
			}
			throw new Exception(_serializer.Deserialize<Error>(new JsonTextReader(new StreamReader(await message.Content.ReadAsStreamAsync()))).error);
		}
		
		public async Task AddFittingAsync(OAuth2Token token, int characterId, Fit fitting, DataSources datasource = DataSources.tranquility)
		{
			_client.DefaultRequestHeaders.Remove("Authorization");
			_client.DefaultRequestHeaders.Add("Authorization", $"{token.tokenType} {token.accessToken}");
			StringWriter sw = new();
			_serializer.Serialize(sw, fitting);
			HttpResponseMessage message= await _client.PostAsync($"{characterId}/fittings?datasource={Enum.GetName(datasource)?.ToLower()}", new StringContent(sw.ToString()));
			if (message.StatusCode != HttpStatusCode.OK)
				throw new Exception(_serializer.Deserialize<Error>(new JsonTextReader(new StreamReader(await message.Content.ReadAsStreamAsync()))).error);
		}
		
		public async Task DeleteFittingAsync(OAuth2Token token, int characterId, int fittingId, DataSources datasource = DataSources.tranquility)
		{
			_client.DefaultRequestHeaders.Remove("Authorization");
			_client.DefaultRequestHeaders.Add("Authorization", $"{token.tokenType} {token.accessToken}");
			await _client.DeleteAsync($"{characterId}/fittings/{fittingId}?datasource={Enum.GetName(datasource)?.ToLower()}");
		}
	}
}