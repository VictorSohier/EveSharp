using EveSharp.Core.Models.Killmails;
using EveSharp.Infrastructure.Enums;
using Newtonsoft.Json;

namespace EveSharp.Infrastructure.Models.Wrappers
{
	public class KillmailWrapper
	{
		private readonly HttpClient _client;
		private readonly JsonSerializer _serializer;
		
		public KillmailWrapper(string authToken) : this()
		{
			_client.DefaultRequestHeaders.Add("authorization", authToken);
		}
		
		public KillmailWrapper()
		{
			_client = new();
			_client.BaseAddress = new($"{WrapperConfig._instance.DOMAIN}/{WrapperConfig._instance.API_VERSION}");
			_serializer = WrapperConfig._instance.SERIALIZER;
		}
		
		public async Task<Killmail[]> GetCharacterKillmailsAsync(int characterId, DataSources datasource = DataSources.tranquility)
		{
			Killmail[] ret;
			if (_client.DefaultRequestHeaders.Any(e => e.Key == "authorization" & e.Value.Any(f => !string.IsNullOrWhiteSpace(f))))
			{
				HttpResponseMessage message = await _client.GetAsync($"characters/{characterId}/killmails/recent?datasource={Enum.GetName(datasource)?.ToLower()}");
				if (WrapperConfig._instance.SUCCESS.Contains(message.StatusCode))
					throw new Exception(_serializer.Deserialize<Error>(new JsonTextReader(new StreamReader(await message.Content.ReadAsStreamAsync()))).error);
				ret = _serializer.Deserialize<Killmail[]>(new JsonTextReader(new StreamReader(await message.Content.ReadAsStreamAsync())));
			}
			else
			{
				throw new Exception("No Authorization Token, this endpoint will fail.");
			}
			return ret;
		}
		
		public async Task<Killmail[]> GetCorporationKillmailsAsync(int corporationId, DataSources datasource = DataSources.tranquility)
		{
			Killmail[] ret;
			if (_client.DefaultRequestHeaders.Any(e => e.Key == "authorization" & e.Value.Any(f => !string.IsNullOrWhiteSpace(f))))
			{
				HttpResponseMessage message = await _client.GetAsync($"corporations/{corporationId}/killmails/recent?datasource={Enum.GetName(datasource)?.ToLower()}");
				if (WrapperConfig._instance.SUCCESS.Contains(message.StatusCode))
					throw new Exception(_serializer.Deserialize<Error>(new JsonTextReader(new StreamReader(await message.Content.ReadAsStreamAsync()))).error);
				ret = _serializer.Deserialize<Killmail[]>(new JsonTextReader(new StreamReader(await message.Content.ReadAsStreamAsync())));
			}
			else
			{
				throw new Exception("No Authorization Token, this endpoint will fail.");
			}
			return ret;
		}

		public async Task<KillmailDetails> GetFacilitiesAsync(Killmail killmail, DataSources datasource = DataSources.tranquility)
		{
			HttpResponseMessage message = await _client.GetAsync($"killmails/{killmail.killmailId}/{killmail.killmailHash}?datasource={Enum.GetName(datasource)?.ToLower()}");
			KillmailDetails ret;
			if (WrapperConfig._instance.SUCCESS.Contains(message.StatusCode))
				throw new Exception(_serializer.Deserialize<Error>(new JsonTextReader(new StreamReader(await message.Content.ReadAsStreamAsync()))).error);
			ret = _serializer.Deserialize<KillmailDetails>(new JsonTextReader(new StreamReader(await message.Content.ReadAsStreamAsync())));
			return ret;
		}
	}
}