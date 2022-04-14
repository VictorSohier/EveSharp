using EveSharp.Core.Models.Dogma;
using EveSharp.Core.Models.Dogma.Dynamic;
using Newtonsoft.Json;

namespace EveSharp.Infrastructure.Models
{
	public class DogmaWrapper
	{
		private readonly HttpClient _client;
		private readonly JsonSerializer _serializer;
		
		public DogmaWrapper()
		{
			_client = new();
			_client.BaseAddress = new($"https://esi.evetech.net/{WrapperConfig._instance.API_VERSION}/dogma");
			_serializer = WrapperConfig._instance.SERIALIZER;
		}
		
		public async Task<int[]> GetAttributeIdsAsync(string datasource="tranquility")
		{
			HttpResponseMessage message = await _client.GetAsync($"attributes?datasource={datasource}");
			int[] ret = _serializer.Deserialize<int[]>(new JsonTextReader(new StreamReader(await message.Content.ReadAsStreamAsync())));
			return ret;
		}
		
		public async Task<DogmaAttribute> GetAttributeAsync(int attributeId, string datasource="tranquility")
		{
			HttpResponseMessage message = await _client.GetAsync($"attributes/{attributeId}?datasource={datasource}");
			DogmaAttribute ret = _serializer.Deserialize<DogmaAttribute>(new JsonTextReader(new StreamReader(await message.Content.ReadAsStreamAsync())));
			return ret;
		}
		
		public async Task<Item> GetDynamicItemInstanceAsync(int typeId, int instanceId, string datasource="tranquility")
		{
			HttpResponseMessage message = await _client.GetAsync($"dynamic/items/{typeId}/{instanceId}?datasource={datasource}");
			Item ret = _serializer.Deserialize<Item>(new JsonTextReader(new StreamReader(await message.Content.ReadAsStreamAsync())));
			return ret;
		}
		
		public async Task<int[]> GetEffectIdsAsync(string datasource="tranquility")
		{
			HttpResponseMessage message = await _client.GetAsync($"effects?datasource={datasource}");
			int[] ret = _serializer.Deserialize<int[]>(new JsonTextReader(new StreamReader(await message.Content.ReadAsStreamAsync())));
			return ret;
		}
		
		public async Task<Core.Models.Dogma.Effect.Effect> GetEffectAsync(int effectId, string datasource="tranquility")
		{
			HttpResponseMessage message = await _client.GetAsync($"effects/{effectId}?datasource={datasource}");
			Core.Models.Dogma.Effect.Effect ret = _serializer.Deserialize<Core.Models.Dogma.Effect.Effect>(new JsonTextReader(new StreamReader(await message.Content.ReadAsStreamAsync())));
			return ret;
		}
	}
}