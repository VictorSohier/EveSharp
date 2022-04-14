using EveSharp.Core.Models.FactionWarfare;
using EveSharp.Core.Models.FactionWarfare.Leaderboard;
using EveSharp.Core.Models.FactionWarfare.Statistics;
using EveSharp.Core.Models.FactionWarfare.Statistics.Faction;
using Newtonsoft.Json;

namespace EveSharp.Infrastructure.Models
{
	public class FactionWarfareWrapper
	{
		private readonly HttpClient _client;
		private readonly JsonSerializer _serializer;
		
		public FactionWarfareWrapper(string authToken)
		{
			_client = new();
			_client.BaseAddress = new($"https://esi.evetech.net/{WrapperConfig._instance.API_VERSION}");
			_client.DefaultRequestHeaders.Add("authorization", authToken);
			_serializer = WrapperConfig._instance.SERIALIZER;
		}
		
		public FactionWarfareWrapper()
		{
			_client = new();
			_client.BaseAddress = new($"https://esi.evetech.net/{WrapperConfig._instance.API_VERSION}");
			_serializer = WrapperConfig._instance.SERIALIZER;
		}
		
		public async Task<Record> GetCharacterStatsAsync(int characterId, string datasource="tranquility")
		{
			Record ret;
			if (_client.DefaultRequestHeaders.Any(e => e.Key == "authorization" & e.Value.Any(f => !string.IsNullOrWhiteSpace(f))))
			{
				HttpResponseMessage message = await _client.GetAsync($"character/{characterId}/fw/stats?datasource={datasource}");
				ret = _serializer.Deserialize<Record>(new JsonTextReader(new StreamReader(await message.Content.ReadAsStreamAsync())));
			}
			else
			{
				throw new Exception("No Authorization Token, this endpoint will fail.");
			}
			return ret;
		}
		
		public async Task<Record> GetCorporationStatsAsync(int corporationId, string datasource="tranquility")
		{
			Record ret;
			if (_client.DefaultRequestHeaders.Any(e => e.Key == "authorization" & e.Value.Any(f => !string.IsNullOrWhiteSpace(f))))
			{
				HttpResponseMessage message = await _client.GetAsync($"corporation/{corporationId}/fw/stats?datasource={datasource}");
				ret = _serializer.Deserialize<Record>(new JsonTextReader(new StreamReader(await message.Content.ReadAsStreamAsync())));
			}
			else
			{
				throw new Exception("No Authorization Token, this endpoint will fail.");
			}
			return ret;
		}
		
		public async Task<Leaderboard> GetLeaderboardAsync(string datasource="tranquility")
		{
			HttpResponseMessage message = await _client.GetAsync($"fw/leaderboards?datasource={datasource}");
			Leaderboard ret = _serializer.Deserialize<Leaderboard>(new JsonTextReader(new StreamReader(await message.Content.ReadAsStreamAsync())));
			return ret;
		}
		
		public async Task<Leaderboard> GetCharacterLeaderboardAsync(string datasource="tranquility")
		{
			HttpResponseMessage message = await _client.GetAsync($"fw/leaderboards/characters?datasource={datasource}");
			Leaderboard ret = _serializer.Deserialize<Leaderboard>(new JsonTextReader(new StreamReader(await message.Content.ReadAsStreamAsync())));
			return ret;
		}
		
		public async Task<Leaderboard> GetCorporationLeaderboardAsync(string datasource="tranquility")
		{
			HttpResponseMessage message = await _client.GetAsync($"fw/leaderboards/corporations?datasource={datasource}");
			Leaderboard ret = _serializer.Deserialize<Leaderboard>(new JsonTextReader(new StreamReader(await message.Content.ReadAsStreamAsync())));
			return ret;
		}
		
		public async Task<Aggregate[]> GetAggregateStatisticsAsync(string datasource="tranquility")
		{
			HttpResponseMessage message = await _client.GetAsync($"fw/stats?datasource={datasource}");
			Aggregate[] ret = _serializer.Deserialize<Aggregate[]>(new JsonTextReader(new StreamReader(await message.Content.ReadAsStreamAsync())));
			return ret;
		}
		
		public async Task<Core.Models.FactionWarfare.System[]> GetLastKnownSystemsStateAsync(string datasource="tranquility")
		{
			HttpResponseMessage message = await _client.GetAsync($"fw/systems?datasource={datasource}");
			Core.Models.FactionWarfare.System[] ret = _serializer.Deserialize<Core.Models.FactionWarfare.System[]>(new JsonTextReader(new StreamReader(await message.Content.ReadAsStreamAsync())));
			return ret;
		}
		
		public async Task<War[]> GetWarsAsync(string datasource="tranquility")
		{
			HttpResponseMessage message = await _client.GetAsync($"fw/wars?datasource={datasource}");
			War[] ret = _serializer.Deserialize<War[]>(new JsonTextReader(new StreamReader(await message.Content.ReadAsStreamAsync())));
			return ret;
		}
	}
}