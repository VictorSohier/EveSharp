using System.Net.Http.Json;
using EveSharp.Core.Models;
using EveSharp.Core.Models.Character;
using EveSharp.Core.Models.Character.Clone;
using EveSharp.Core.Models.Character.Skills;
using EveSharp.Infrastructure.Enums;
using Newtonsoft.Json;

namespace EveSharp.Infrastructure.Models.Wrappers
{
	public class CharacterWrapper
	{
		private readonly HttpClient _client;
		private readonly JsonSerializer _serializer;
		
		public CharacterWrapper(string authToken) : this()
		{
			_client.DefaultRequestHeaders.Add("authorization", authToken);
		}
		
		public CharacterWrapper()
		{
			_client = new();
			_client.BaseAddress = new($"{WrapperConfig._instance.DOMAIN}/{WrapperConfig._instance.API_VERSION}/characters");
			_serializer = WrapperConfig._instance.SERIALIZER;
		}
		
		public async Task<Character> GetCharacterAsync(int characterId, DataSources datasource = DataSources.tranquility)
		{
			HttpResponseMessage message = await _client.GetAsync($"{characterId}?datasource={Enum.GetName(datasource)?.ToLower()}");
			Character ret;
			if (WrapperConfig._instance.SUCCESS.Contains(message.StatusCode))
				throw new Exception(_serializer.Deserialize<Error>(new JsonTextReader(new StreamReader(await message.Content.ReadAsStreamAsync()))).error);
			ret = _serializer.Deserialize<Character>(new JsonTextReader(new StreamReader(await message.Content.ReadAsStreamAsync())));
			return ret;
		}
		
		public async Task<AgentsResearch[]> GetAgentsAsync(int characterId, DataSources datasource = DataSources.tranquility)
		{
			AgentsResearch[] ret;
			if (_client.DefaultRequestHeaders.Any(e => e.Key == "authorization" & e.Value.Any(f => !string.IsNullOrWhiteSpace(f))))
			{
				HttpResponseMessage message = await _client.GetAsync($"{characterId}/agents_research?datasource={Enum.GetName(datasource)?.ToLower()}");
				if (WrapperConfig._instance.SUCCESS.Contains(message.StatusCode))
					throw new Exception(_serializer.Deserialize<Error>(new JsonTextReader(new StreamReader(await message.Content.ReadAsStreamAsync()))).error);
				ret = _serializer.Deserialize<AgentsResearch[]>(new JsonTextReader(new StreamReader(await message.Content.ReadAsStreamAsync())));
			}
			else
			{
				throw new Exception("No Authorization Token, this endpoint will fail.");
			}
			return ret;
		}
		
		public async Task<Blueprint[]> GetBlueprintsAsync(int characterId, int page = 1, DataSources datasource = DataSources.tranquility)
		{
			Blueprint[] ret;
			if (_client.DefaultRequestHeaders.Any(e => e.Key == "authorization" & e.Value.Any(f => !string.IsNullOrWhiteSpace(f))))
			{
				HttpResponseMessage message = await _client.GetAsync($"{characterId}/blueprints?datasource={Enum.GetName(datasource)?.ToLower()}&page={page}");
			if (WrapperConfig._instance.SUCCESS.Contains(message.StatusCode))
				throw new Exception(_serializer.Deserialize<Error>(new JsonTextReader(new StreamReader(await message.Content.ReadAsStreamAsync()))).error);
			ret = _serializer.Deserialize<Blueprint[]>(new JsonTextReader(new StreamReader(await message.Content.ReadAsStreamAsync())));
			}
			else
			{
				throw new Exception("No Authorization Token, this endpoint will fail.");
			}
			return ret;
		}
		
		public async Task<CorpHistoryEntry> GetCorporationHistoryAsync(int characterId, DataSources datasource = DataSources.tranquility)
		{
			HttpResponseMessage message = await _client.GetAsync($"{characterId}/corporationhistory?datasource={Enum.GetName(datasource)?.ToLower()}");
			CorpHistoryEntry ret = _serializer.Deserialize<CorpHistoryEntry>(new JsonTextReader(new StreamReader(await message.Content.ReadAsStreamAsync())));
			return ret;
		}
		
		public async Task<float> GetCPSAAsync(int characterId, DataSources datasource = DataSources.tranquility, params int[] recipientIds)
		{
			float ret;
			if (_client.DefaultRequestHeaders.Any(e => e.Key == "authorization" & e.Value.Any(f => !string.IsNullOrWhiteSpace(f))))
			{
				HttpResponseMessage message = await _client.PostAsync($"{characterId}/cspa?datasource={Enum.GetName(datasource)?.ToLower()}", JsonContent.Create(recipientIds));
				if (WrapperConfig._instance.SUCCESS.Contains(message.StatusCode))
					throw new Exception(_serializer.Deserialize<Error>(new JsonTextReader(new StreamReader(await message.Content.ReadAsStreamAsync()))).error);
				ret = _serializer.Deserialize<float>(new JsonTextReader(new StreamReader(await message.Content.ReadAsStreamAsync())));
			}
			else
			{
				throw new Exception("No Authorization Token, this endpoint will fail.");
			}
			return ret;
		}
		
		public async Task<JumpFatigue> GetJumpFatigueAsync(int characterId, DataSources datasource = DataSources.tranquility)
		{
			JumpFatigue ret;
			if (_client.DefaultRequestHeaders.Any(e => e.Key == "authorization" & e.Value.Any(f => !string.IsNullOrWhiteSpace(f))))
			{
				HttpResponseMessage message = await _client.GetAsync($"{characterId}/fatigue?datasource={Enum.GetName(datasource)?.ToLower()}");
				if (WrapperConfig._instance.SUCCESS.Contains(message.StatusCode))
					throw new Exception(_serializer.Deserialize<Error>(new JsonTextReader(new StreamReader(await message.Content.ReadAsStreamAsync()))).error);
				ret = _serializer.Deserialize<JumpFatigue>(new JsonTextReader(new StreamReader(await message.Content.ReadAsStreamAsync())));
			}
			else
			{
				throw new Exception("No Authorization Token, this endpoint will fail.");
			}
			return ret;
		}
		
		public async Task<Medal[]> GetMedalsAsync(int characterId, DataSources datasource = DataSources.tranquility)
		{
			Medal[] ret;
			if (_client.DefaultRequestHeaders.Any(e => e.Key == "authorization" & e.Value.Any(f => !string.IsNullOrWhiteSpace(f))))
			{
				HttpResponseMessage message = await _client.GetAsync($"{characterId}/medals?datasource={Enum.GetName(datasource)?.ToLower()}");
				if (WrapperConfig._instance.SUCCESS.Contains(message.StatusCode))
					throw new Exception(_serializer.Deserialize<Error>(new JsonTextReader(new StreamReader(await message.Content.ReadAsStreamAsync()))).error);
				ret = _serializer.Deserialize<Medal[]>(new JsonTextReader(new StreamReader(await message.Content.ReadAsStreamAsync())));
			}
			else
			{
				throw new Exception("No Authorization Token, this endpoint will fail.");
			}
			return ret;
		}
		
		public async Task<Notification[]> GetNotificationsAsync(int characterId, DataSources datasource = DataSources.tranquility)
		{
			Notification[] ret;
			if (_client.DefaultRequestHeaders.Any(e => e.Key == "authorization" & e.Value.Any(f => !string.IsNullOrWhiteSpace(f))))
			{
				HttpResponseMessage message = await _client.GetAsync($"{characterId}/notifications?datasource={Enum.GetName(datasource)?.ToLower()}");
				if (WrapperConfig._instance.SUCCESS.Contains(message.StatusCode))
					throw new Exception(_serializer.Deserialize<Error>(new JsonTextReader(new StreamReader(await message.Content.ReadAsStreamAsync()))).error);
				ret = _serializer.Deserialize<Notification[]>(new JsonTextReader(new StreamReader(await message.Content.ReadAsStreamAsync())));
			}
			else
			{
				throw new Exception("No Authorization Token, this endpoint will fail.");
			}
			return ret;
		}
		
		public async Task<NotificationContact[]> GetContactNotificationsAsync(int characterId, DataSources datasource = DataSources.tranquility)
		{
			NotificationContact[] ret;
			if (_client.DefaultRequestHeaders.Any(e => e.Key == "authorization" & e.Value.Any(f => !string.IsNullOrWhiteSpace(f))))
			{
				HttpResponseMessage message = await _client.GetAsync($"{characterId}/roles?datasource={Enum.GetName(datasource)?.ToLower()}");
				if (WrapperConfig._instance.SUCCESS.Contains(message.StatusCode))
					throw new Exception(_serializer.Deserialize<Error>(new JsonTextReader(new StreamReader(await message.Content.ReadAsStreamAsync()))).error);
				ret = _serializer.Deserialize<NotificationContact[]>(new JsonTextReader(new StreamReader(await message.Content.ReadAsStreamAsync())));
			}
			else
			{
				throw new Exception("No Authorization Token, this endpoint will fail.");
			}
			return ret;
		}
		
		public async Task<Icon> GetPortraitAsync(int characterId, DataSources datasource = DataSources.tranquility)
		{
			HttpResponseMessage message = await _client.GetAsync($"{characterId}/portrait?datasource={Enum.GetName(datasource)?.ToLower()}");
			Icon ret;
			if (WrapperConfig._instance.SUCCESS.Contains(message.StatusCode))
				throw new Exception(_serializer.Deserialize<Error>(new JsonTextReader(new StreamReader(await message.Content.ReadAsStreamAsync()))).error);
			ret = _serializer.Deserialize<Icon>(new JsonTextReader(new StreamReader(await message.Content.ReadAsStreamAsync())));
			return ret;
		}
		
		public async Task<CharacterRoles> GetRolesAsync(int characterId, DataSources datasource = DataSources.tranquility)
		{
			CharacterRoles ret;
			if (_client.DefaultRequestHeaders.Any(e => e.Key == "authorization" & e.Value.Any(f => !string.IsNullOrWhiteSpace(f))))
			{
				HttpResponseMessage message = await _client.GetAsync($"{characterId}/portrait?datasource={Enum.GetName(datasource)?.ToLower()}");
				if (WrapperConfig._instance.SUCCESS.Contains(message.StatusCode))
					throw new Exception(_serializer.Deserialize<Error>(new JsonTextReader(new StreamReader(await message.Content.ReadAsStreamAsync()))).error);
				ret = _serializer.Deserialize<CharacterRoles>(new JsonTextReader(new StreamReader(await message.Content.ReadAsStreamAsync())));
			}
			else
			{
				throw new Exception("No Authorization Token, this endpoint will fail.");
			}
			return ret;
		}
		
		public async Task<StandingEntry[]> GetStandingsAsync(int characterId, DataSources datasource = DataSources.tranquility)
		{
			StandingEntry[] ret;
			if (_client.DefaultRequestHeaders.Any(e => e.Key == "authorization" & e.Value.Any(f => !string.IsNullOrWhiteSpace(f))))
			{
				HttpResponseMessage message = await _client.GetAsync($"{characterId}/standingss?datasource={Enum.GetName(datasource)?.ToLower()}");
				if (WrapperConfig._instance.SUCCESS.Contains(message.StatusCode))
					throw new Exception(_serializer.Deserialize<Error>(new JsonTextReader(new StreamReader(await message.Content.ReadAsStreamAsync()))).error);
				ret = _serializer.Deserialize<StandingEntry[]>(new JsonTextReader(new StreamReader(await message.Content.ReadAsStreamAsync())));
			}
			else
			{
				throw new Exception("No Authorization Token, this endpoint will fail.");
			}
			return ret;
		}
		
		public async Task<Title[]> GetTitlesAsync(int characterId, DataSources datasource = DataSources.tranquility)
		{
			Title[] ret;
			if (_client.DefaultRequestHeaders.Any(e => e.Key == "authorization" & e.Value.Any(f => !string.IsNullOrWhiteSpace(f))))
			{
				HttpResponseMessage message = await _client.GetAsync($"{characterId}/titles?datasource={Enum.GetName(datasource)?.ToLower()}");
				if (WrapperConfig._instance.SUCCESS.Contains(message.StatusCode))
					throw new Exception(_serializer.Deserialize<Error>(new JsonTextReader(new StreamReader(await message.Content.ReadAsStreamAsync()))).error);
				ret = _serializer.Deserialize<Title[]>(new JsonTextReader(new StreamReader(await message.Content.ReadAsStreamAsync())));
			}
			else
			{
				throw new Exception("No Authorization Token, this endpoint will fail.");
			}
			return ret;
		}
		
		public async Task<Affiliation[]> BulkAffiliationLookupAsync(DataSources datasource = DataSources.tranquility, params int[] characterIds)
		{
			Affiliation[] ret;
			if (_client.DefaultRequestHeaders.Any(e => e.Key == "authorization" & e.Value.Any(f => !string.IsNullOrWhiteSpace(f))))
			{
				HttpResponseMessage message = await _client.PostAsync($"affiliation?datasource={Enum.GetName(datasource)?.ToLower()}", JsonContent.Create(characterIds));
				if (WrapperConfig._instance.SUCCESS.Contains(message.StatusCode))
					throw new Exception(_serializer.Deserialize<Error>(new JsonTextReader(new StreamReader(await message.Content.ReadAsStreamAsync()))).error);
				ret = _serializer.Deserialize<Affiliation[]>(new JsonTextReader(new StreamReader(await message.Content.ReadAsStreamAsync())));
			}
			else
			{
				throw new Exception("No Authorization Token, this endpoint will fail.");
			}
			return ret;
		}
		
		public async Task<Clone> GetClonesAsync(int characterId, DataSources datasource = DataSources.tranquility)
		{
			Clone ret;
			if (_client.DefaultRequestHeaders.Any(e => e.Key == "authorization" & e.Value.Any(f => !string.IsNullOrWhiteSpace(f))))
			{
				HttpResponseMessage message = await _client.GetAsync($"{characterId}/clones?datasource={Enum.GetName(datasource)?.ToLower()}");
				if (WrapperConfig._instance.SUCCESS.Contains(message.StatusCode))
					throw new Exception(_serializer.Deserialize<Error>(new JsonTextReader(new StreamReader(await message.Content.ReadAsStreamAsync()))).error);
				ret = _serializer.Deserialize<Clone>(new JsonTextReader(new StreamReader(await message.Content.ReadAsStreamAsync())));
			}
			else
			{
				throw new Exception("No Authorization Token, this endpoint will fail.");
			}
			return ret;
		}
		
		public async Task<int[]> GetCurrentCloneImplantsAsync(int characterId, DataSources datasource = DataSources.tranquility)
		{
			int[] ret;
			if (_client.DefaultRequestHeaders.Any(e => e.Key == "authorization" & e.Value.Any(f => !string.IsNullOrWhiteSpace(f))))
			{
				HttpResponseMessage message = await _client.GetAsync($"{characterId}/implants?datasource={Enum.GetName(datasource)?.ToLower()}");
				if (WrapperConfig._instance.SUCCESS.Contains(message.StatusCode))
					throw new Exception(_serializer.Deserialize<Error>(new JsonTextReader(new StreamReader(await message.Content.ReadAsStreamAsync()))).error);
				ret = _serializer.Deserialize<int[]>(new JsonTextReader(new StreamReader(await message.Content.ReadAsStreamAsync())));
			}
			else
			{
				throw new Exception("No Authorization Token, this endpoint will fail.");
			}
			return ret;
		}
		
		public async Task<Attributes> GetCurrentCloneAttributesAsync(int characterId, DataSources datasource = DataSources.tranquility)
		{
			Attributes ret;
			if (_client.DefaultRequestHeaders.Any(e => e.Key == "authorization" & e.Value.Any(f => !string.IsNullOrWhiteSpace(f))))
			{
				HttpResponseMessage message = await _client.GetAsync($"{characterId}/attributes?datasource={Enum.GetName(datasource)?.ToLower()}");
				if (WrapperConfig._instance.SUCCESS.Contains(message.StatusCode))
					throw new Exception(_serializer.Deserialize<Error>(new JsonTextReader(new StreamReader(await message.Content.ReadAsStreamAsync()))).error);
				ret = _serializer.Deserialize<Attributes>(new JsonTextReader(new StreamReader(await message.Content.ReadAsStreamAsync())));
			}
			else
			{
				throw new Exception("No Authorization Token, this endpoint will fail.");
			}
			return ret;
		}
		
		public async Task<QueuedSkill[]> GetSkillQueueAsync(int characterId, DataSources datasource = DataSources.tranquility)
		{
			QueuedSkill[] ret;
			if (_client.DefaultRequestHeaders.Any(e => e.Key == "authorization" & e.Value.Any(f => !string.IsNullOrWhiteSpace(f))))
			{
				HttpResponseMessage message = await _client.GetAsync($"{characterId}/skillqueue?datasource={Enum.GetName(datasource)?.ToLower()}");
				if (WrapperConfig._instance.SUCCESS.Contains(message.StatusCode))
					throw new Exception(_serializer.Deserialize<Error>(new JsonTextReader(new StreamReader(await message.Content.ReadAsStreamAsync()))).error);
				ret = _serializer.Deserialize<QueuedSkill[]>(new JsonTextReader(new StreamReader(await message.Content.ReadAsStreamAsync())));
			}
			else
			{
				throw new Exception("No Authorization Token, this endpoint will fail.");
			}
			return ret;
		}
		
		public async Task<Skills> GetSkillsAsync(int characterId, DataSources datasource = DataSources.tranquility)
		{
			Skills ret;
			if (_client.DefaultRequestHeaders.Any(e => e.Key == "authorization" & e.Value.Any(f => !string.IsNullOrWhiteSpace(f))))
			{
				HttpResponseMessage message = await _client.GetAsync($"{characterId}/skills?datasource={Enum.GetName(datasource)?.ToLower()}");
				if (WrapperConfig._instance.SUCCESS.Contains(message.StatusCode))
					throw new Exception(_serializer.Deserialize<Error>(new JsonTextReader(new StreamReader(await message.Content.ReadAsStreamAsync()))).error);
				ret = _serializer.Deserialize<Skills>(new JsonTextReader(new StreamReader(await message.Content.ReadAsStreamAsync())));
			}
			else
			{
				throw new Exception("No Authorization Token, this endpoint will fail.");
			}
			return ret;
		}
	}
}