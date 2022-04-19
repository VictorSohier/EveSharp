using EveSharp.Core.Models.Locations;
using EveSharp.Infrastructure.Enums;
using Newtonsoft.Json;

namespace EveSharp.Infrastructure.Models.Wrappers
{
	public class LocationWrapper
	{
		private readonly HttpClient _client;
		private readonly JsonSerializer _serializer;
		
		public LocationWrapper(string authToken, int characterId)
		{
			_client = new();
			_client.BaseAddress = new($"{WrapperConfig._instance.DOMAIN}/{WrapperConfig._instance.API_VERSION}/characters/{characterId}");
			_client.DefaultRequestHeaders.Add("authorization", authToken);
			_serializer = WrapperConfig._instance.SERIALIZER;
		}

		public async Task<CharacterLocation> GetLocationAsync(DataSources datasource = DataSources.tranquility)
		{
			HttpResponseMessage message = await _client.GetAsync($"location?datasource={Enum.GetName(datasource)?.ToLower()}");
			CharacterLocation ret;
			if (WrapperConfig._instance.SUCCESS.Contains(message.StatusCode))
				throw new Exception(_serializer.Deserialize<Error>(new JsonTextReader(new StreamReader(await message.Content.ReadAsStreamAsync()))).error);
			ret = _serializer.Deserialize<CharacterLocation>(new JsonTextReader(new StreamReader(await message.Content.ReadAsStreamAsync())));
			return ret;
		}

		public async Task<CharacterLoginEntry> GetOnlineStatusAsync(DataSources datasource = DataSources.tranquility)
		{
			HttpResponseMessage message = await _client.GetAsync($"online?datasource={Enum.GetName(datasource)?.ToLower()}");
			CharacterLoginEntry ret;
			if (WrapperConfig._instance.SUCCESS.Contains(message.StatusCode))
				throw new Exception(_serializer.Deserialize<Error>(new JsonTextReader(new StreamReader(await message.Content.ReadAsStreamAsync()))).error);
			ret = _serializer.Deserialize<CharacterLoginEntry>(new JsonTextReader(new StreamReader(await message.Content.ReadAsStreamAsync())));
			return ret;
		}

		public async Task<CharacterShip> GetShipAsync(DataSources datasource = DataSources.tranquility)
		{
			HttpResponseMessage message = await _client.GetAsync($"ship?datasource={Enum.GetName(datasource)?.ToLower()}");
			CharacterShip ret;
			if (WrapperConfig._instance.SUCCESS.Contains(message.StatusCode))
				throw new Exception(_serializer.Deserialize<Error>(new JsonTextReader(new StreamReader(await message.Content.ReadAsStreamAsync()))).error);
			ret = _serializer.Deserialize<CharacterShip>(new JsonTextReader(new StreamReader(await message.Content.ReadAsStreamAsync())));
			return ret;
		}
	}
}