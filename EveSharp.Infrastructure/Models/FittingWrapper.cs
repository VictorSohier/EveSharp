using System.Net.Http.Json;
using EveSharp.Core.Models.Fitting;
using Newtonsoft.Json;

namespace EveSharp.Infrastructure.Models
{
	public class FittingWrapper
	{
		private readonly HttpClient _client;
		private readonly JsonSerializer _serializer;
		
		public FittingWrapper(string authToken)
		{
			_client = new();
			_client.BaseAddress = new($"https://esi.evetech.net/{WrapperConfig._instance.API_VERSION}/characters");
			_client.DefaultRequestHeaders.Add("authorization", authToken);
			_serializer = WrapperConfig._instance.SERIALIZER;
		}
		
		public async Task<Fit[]> GetFitsAsync(int characterId, string datasource="tranquility")
		{
			HttpResponseMessage message = await _client.GetAsync($"{characterId}/fittings?datasource={datasource}");
			Fit[] ret = _serializer.Deserialize<Fit[]>(new JsonTextReader(new StreamReader(await message.Content.ReadAsStreamAsync())));
			return ret;
		}
		
		public async Task AddFittingAsync(int characterId, Fit fitting, string datasource="tranquility")
		{
			StringWriter sw = new();
			_serializer.Serialize(sw, fitting);
			await _client.PostAsync($"{characterId}/fittings?datasource={datasource}", new StringContent(sw.ToString()));
		}
		
		public async Task DeleteFittingAsync(int characterId, int fittingId, string datasource="tranquility")
		{
			await _client.DeleteAsync($"{characterId}/fittings/{fittingId}?datasource={datasource}");
		}
	}
}