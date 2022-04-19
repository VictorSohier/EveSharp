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
		
		public FittingWrapper(string authToken)
		{
			_client = new();
			_client.BaseAddress = new($"{WrapperConfig._instance.DOMAIN}/{WrapperConfig._instance.API_VERSION}/characters");
			_client.DefaultRequestHeaders.Add("authorization", authToken);
			_serializer = WrapperConfig._instance.SERIALIZER;
		}
		
		public async Task<Fit[]> GetFitsAsync(int characterId, DataSources datasource = DataSources.tranquility)
		{
			HttpResponseMessage message = await _client.GetAsync($"{characterId}/fittings?datasource={Enum.GetName(datasource)?.ToLower()}");
			Fit[] ret;
			if (WrapperConfig._instance.SUCCESS.Contains(message.StatusCode))
				throw new Exception(_serializer.Deserialize<Error>(new JsonTextReader(new StreamReader(await message.Content.ReadAsStreamAsync()))).error);
			ret = _serializer.Deserialize<Fit[]>(new JsonTextReader(new StreamReader(await message.Content.ReadAsStreamAsync())));
			return ret;
		}
		
		public async Task AddFittingAsync(int characterId, Fit fitting, DataSources datasource = DataSources.tranquility)
		{
			StringWriter sw = new();
			_serializer.Serialize(sw, fitting);
			HttpResponseMessage message= await _client.PostAsync($"{characterId}/fittings?datasource={Enum.GetName(datasource)?.ToLower()}", new StringContent(sw.ToString()));
			if (message.StatusCode != HttpStatusCode.OK)
				throw new Exception(_serializer.Deserialize<Error>(new JsonTextReader(new StreamReader(await message.Content.ReadAsStreamAsync()))).error);
		}
		
		public async Task DeleteFittingAsync(int characterId, int fittingId, DataSources datasource = DataSources.tranquility)
		{
			await _client.DeleteAsync($"{characterId}/fittings/{fittingId}?datasource={Enum.GetName(datasource)?.ToLower()}");
		}
	}
}