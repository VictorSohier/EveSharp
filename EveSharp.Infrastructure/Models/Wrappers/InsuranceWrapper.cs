using EveSharp.Core.Models.Insurance;
using EveSharp.Infrastructure.Enums;
using Newtonsoft.Json;

namespace EveSharp.Infrastructure.Models.Wrappers
{
	public class InsuranceWrapper
	{
		private readonly HttpClient _client;
		private readonly JsonSerializer _serializer;
		
		public InsuranceWrapper()
		{
			_client = new();
			_client.BaseAddress = new($"{WrapperConfig._instance.DOMAIN}/{WrapperConfig._instance.API_VERSION}/incursions");
			_serializer = WrapperConfig._instance.SERIALIZER;
		}

		public async Task<Prices[]> GetInsurancePricesAsync(DataSources datasource = DataSources.TRANQUILITY)
		{
			HttpResponseMessage message = await _client.GetAsync($"?datasource={Enum.GetName<DataSources>(datasource)?.ToLower()}");
			Prices[] ret;
			if (WrapperConfig._instance.SUCCESS.Contains(message.StatusCode))
				throw new Exception(_serializer.Deserialize<Error>(new JsonTextReader(new StreamReader(await message.Content.ReadAsStreamAsync()))).error);
			ret = _serializer.Deserialize<Prices[]>(new JsonTextReader(new StreamReader(await message.Content.ReadAsStreamAsync())));
			return ret;
		}
	}
}