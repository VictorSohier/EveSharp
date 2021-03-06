using EveSharp.Core.Models.Dogma;
using EveSharp.Core.Models.Dogma.Dynamic;
using EveSharp.Infrastructure.Enums;
using Newtonsoft.Json;

namespace EveSharp.Infrastructure.Models.Wrappers
{
	public class DogmaWrapper
	{
		private readonly HttpClient _client;
		private readonly JsonSerializer _serializer;
		
		public DogmaWrapper()
		{
			_client = new();
			_client.BaseAddress = new($"{WrapperConfig._instance.DOMAIN}");
			_serializer = WrapperConfig._instance.SERIALIZER;
		}
		
		public async Task<int[]> GetAttributeIdsAsync(DataSources datasource = DataSources.tranquility)
		{
			HttpResponseMessage message = await _client.GetAsync($"/{WrapperConfig._instance.API_VERSION}/dogma/attributes?datasource={Enum.GetName(datasource)?.ToLower()}");
			int[] ret = _serializer.Deserialize<int[]>(new JsonTextReader(new StreamReader(await message.Content.ReadAsStreamAsync())));
			return ret;
		}
		
		public async Task<DogmaAttribute> GetAttributeAsync(int attributeId, DataSources datasource = DataSources.tranquility)
		{
			HttpResponseMessage message = await _client.GetAsync($"/{WrapperConfig._instance.API_VERSION}/dogma/attributes/{attributeId}?datasource={Enum.GetName(datasource)?.ToLower()}");
			DogmaAttribute ret;
			if (WrapperConfig._instance.SUCCESS.Contains(message.StatusCode))
			{
				ret = _serializer.Deserialize<DogmaAttribute>(new JsonTextReader(new StreamReader(await message.Content.ReadAsStreamAsync())));
				return ret;
			}
			throw new Exception(_serializer.Deserialize<Error>(new JsonTextReader(new StreamReader(await message.Content.ReadAsStreamAsync()))).error);
		}
		
		public async Task<Item> GetDynamicItemInstanceAsync(int typeId, int instanceId, DataSources datasource = DataSources.tranquility)
		{
			HttpResponseMessage message = await _client.GetAsync($"/{WrapperConfig._instance.API_VERSION}/dogma/dynamic/items/{typeId}/{instanceId}?datasource={Enum.GetName(datasource)?.ToLower()}");
			Item ret;
			if (WrapperConfig._instance.SUCCESS.Contains(message.StatusCode))
			{
				ret = _serializer.Deserialize<Item>(new JsonTextReader(new StreamReader(await message.Content.ReadAsStreamAsync())));
				return ret;
			}
			throw new Exception(_serializer.Deserialize<Error>(new JsonTextReader(new StreamReader(await message.Content.ReadAsStreamAsync()))).error);
		}
		
		public async Task<int[]> GetEffectIdsAsync(DataSources datasource = DataSources.tranquility)
		{
			HttpResponseMessage message = await _client.GetAsync($"/{WrapperConfig._instance.API_VERSION}/dogma/effects?datasource={Enum.GetName(datasource)?.ToLower()}");
			int[] ret = _serializer.Deserialize<int[]>(new JsonTextReader(new StreamReader(await message.Content.ReadAsStreamAsync())));
			return ret;
		}
		
		public async Task<EveSharp.Core.Models.Dogma.Effect.Effect> GetEffectAsync(int effectId, DataSources datasource = DataSources.tranquility)
		{
			HttpResponseMessage message = await _client.GetAsync($"/{WrapperConfig._instance.API_VERSION}/dogma/effects/{effectId}?datasource={Enum.GetName(datasource)?.ToLower()}");
			EveSharp.Core.Models.Dogma.Effect.Effect ret;
			if (WrapperConfig._instance.SUCCESS.Contains(message.StatusCode))
				throw new Exception(_serializer.Deserialize<Error>(new JsonTextReader(new StreamReader(await message.Content.ReadAsStreamAsync()))).error);
			ret = _serializer.Deserialize<EveSharp.Core.Models.Dogma.Effect.Effect>(new JsonTextReader(new StreamReader(await message.Content.ReadAsStreamAsync())));
			return ret;
		}
	}
}