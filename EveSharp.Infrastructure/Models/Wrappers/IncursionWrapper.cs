using EveSharp.Core.Models.Incursions;
using EveSharp.Infrastructure.Enums;
using Newtonsoft.Json;

namespace EveSharp.Infrastructure.Models.Wrappers
{
	public class IncursionWrapper
	{
		private readonly HttpClient _client;
		private readonly JsonSerializer _serializer;
		
		public IncursionWrapper()
		{
			_client = new();
			_client.BaseAddress = new($"https://esi.evetech.net/{WrapperConfig._instance.API_VERSION}/incursions");
			_serializer = WrapperConfig._instance.SERIALIZER;
		}

		public async Task<Incursion[]> GetIncursionsAsync(DataSources datasource = DataSources.TRANQUILITY)
		{
			HttpResponseMessage message = await _client.GetAsync($"?datasource={Enum.GetName<DataSources>(datasource)?.ToLower()}");
			Incursion[] ret;
			if (WrapperConfig._instance.SUCCESS.Contains(message.StatusCode))
				throw new Exception(_serializer.Deserialize<Error>(new JsonTextReader(new StreamReader(await message.Content.ReadAsStreamAsync()))).error);
			ret = _serializer.Deserialize<Incursion[]>(new JsonTextReader(new StreamReader(await message.Content.ReadAsStreamAsync())));
			return ret;
		}
	}
}