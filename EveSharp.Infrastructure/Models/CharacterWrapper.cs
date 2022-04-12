using System.Net.Http.Json;
using EveSharp.Core.Models;
using EveSharp.Core.Models.Character;
using EveSharp.Core.Models.Character.Clone;
using EveSharp.Core.Models.Character.Skills;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace EveSharp.Infrastructure.Models
{
	public class CharacterWrapper
	{
		private readonly HttpClient _client;
		private readonly JsonSerializer _serializer;
		
		public CharacterWrapper(string authToken)
		{
			_client = new();
			_client.BaseAddress = new($"https://esi.evetech.net/{WrapperConfig._instance.API_VERSION}/characters");
			_client.DefaultRequestHeaders.Add("authorization", authToken);
			_serializer = JsonSerializer.Create(WrapperConfig._instance.settings);
		}
		
		public CharacterWrapper()
		{
			_client = new();
			_client.BaseAddress = new($"https://esi.evetech.net/{WrapperConfig._instance.API_VERSION}/characters");
			
			JsonSerializerSettings settings = new()
			{
				DateParseHandling = DateParseHandling.DateTime,
				DateFormatHandling = DateFormatHandling.IsoDateFormat,
				ContractResolver = new DefaultContractResolver()
				{
					NamingStrategy = new SnakeCaseNamingStrategy()
				},
				NullValueHandling = NullValueHandling.Include
			};
			
			_serializer = JsonSerializer.Create(settings);
		}
		
		public async Task<Character> GetCharacterAsync(int characterId, string datasource = "tranquilty")
		{
			HttpResponseMessage message = await _client.GetAsync($"{characterId}?datasource={datasource}");
			Character ret = _serializer.Deserialize<Character>(new JsonTextReader(new StreamReader(await message.Content.ReadAsStreamAsync())));
			return ret;
		}
		
		public async Task<AgentsResearch[]> GetAgentsAsync(int characterId, string datasource = "tranquilty")
		{
			AgentsResearch[] ret;
			if (_client.DefaultRequestHeaders.Any(e => e.Key == "authorization" & e.Value.Any(f => !string.IsNullOrWhiteSpace(f))))
			{
				HttpResponseMessage message = await _client.GetAsync($"{characterId}/agents_research?datasource={datasource}");
				ret = _serializer.Deserialize<AgentsResearch[]>(new JsonTextReader(new StreamReader(await message.Content.ReadAsStreamAsync())));
			}
			else
			{
				throw new Exception("No Authorization Token, this endpoint will fail.");
			}
			return ret;
		}
		
		public async Task<Blueprint> GetBlueprintsAsync(int characterId, int page = 1, string datasource = "tranquilty")
		{
			Blueprint ret;
			if (_client.DefaultRequestHeaders.Any(e => e.Key == "authorization" & e.Value.Any(f => !string.IsNullOrWhiteSpace(f))))
			{
				HttpResponseMessage message = await _client.GetAsync($"{characterId}/blueprints?datasource={datasource}&page={page}");
				ret = _serializer.Deserialize<Blueprint>(new JsonTextReader(new StreamReader(await message.Content.ReadAsStreamAsync())));
			}
			else
			{
				throw new Exception("No Authorization Token, this endpoint will fail.");
			}
			return ret;
		}
		
		public async Task<CorpHistoryEntry> GetCorporationHistoryAsync(int characterId, string datasource = "tranquilty")
		{
			HttpResponseMessage message = await _client.GetAsync($"{characterId}/corporationhistory?datasource={datasource}");
			CorpHistoryEntry ret = _serializer.Deserialize<CorpHistoryEntry>(new JsonTextReader(new StreamReader(await message.Content.ReadAsStreamAsync())));
			return ret;
		}
		
		public async Task<float> GetCPSAAsync(int characterId, string datasource = "tranquilty", params int[] recipientIds)
		{
			float ret;
			if (_client.DefaultRequestHeaders.Any(e => e.Key == "authorization" & e.Value.Any(f => !string.IsNullOrWhiteSpace(f))))
			{
				HttpResponseMessage message = await _client.PostAsync($"{characterId}/cspa?datasource={datasource}", JsonContent.Create(recipientIds));
				ret = _serializer.Deserialize<float>(new JsonTextReader(new StreamReader(await message.Content.ReadAsStreamAsync())));
			}
			else
			{
				throw new Exception("No Authorization Token, this endpoint will fail.");
			}
			return ret;
		}
		
		public async Task<JumpFatigue> GetJumpFatigueAsync(int characterId, string datasource = "tranquilty")
		{
			JumpFatigue ret;
			if (_client.DefaultRequestHeaders.Any(e => e.Key == "authorization" & e.Value.Any(f => !string.IsNullOrWhiteSpace(f))))
			{
				HttpResponseMessage message = await _client.GetAsync($"{characterId}/fatigue?datasource={datasource}");
				ret = _serializer.Deserialize<JumpFatigue>(new JsonTextReader(new StreamReader(await message.Content.ReadAsStreamAsync())));
			}
			else
			{
				throw new Exception("No Authorization Token, this endpoint will fail.");
			}
			return ret;
		}
		
		public async Task<Medal[]> GetMedalsAsync(int characterId, string datasource = "tranquilty")
		{
			Medal[] ret;
			if (_client.DefaultRequestHeaders.Any(e => e.Key == "authorization" & e.Value.Any(f => !string.IsNullOrWhiteSpace(f))))
			{
				HttpResponseMessage message = await _client.GetAsync($"{characterId}/medals?datasource={datasource}");
				ret = _serializer.Deserialize<Medal[]>(new JsonTextReader(new StreamReader(await message.Content.ReadAsStreamAsync())));
			}
			else
			{
				throw new Exception("No Authorization Token, this endpoint will fail.");
			}
			return ret;
		}
		
		public async Task<Notification[]> GetNotificationsAsync(int characterId, string datasource = "tranquilty")
		{
			Notification[] ret;
			if (_client.DefaultRequestHeaders.Any(e => e.Key == "authorization" & e.Value.Any(f => !string.IsNullOrWhiteSpace(f))))
			{
				HttpResponseMessage message = await _client.GetAsync($"{characterId}/notifications?datasource={datasource}");
				ret = _serializer.Deserialize<Notification[]>(new JsonTextReader(new StreamReader(await message.Content.ReadAsStreamAsync())));
			}
			else
			{
				throw new Exception("No Authorization Token, this endpoint will fail.");
			}
			return ret;
		}
		
		public async Task<NotificationContact[]> GetContactNotificationsAsync(int characterId, string datasource = "tranquilty")
		{
			NotificationContact[] ret;
			if (_client.DefaultRequestHeaders.Any(e => e.Key == "authorization" & e.Value.Any(f => !string.IsNullOrWhiteSpace(f))))
			{
				HttpResponseMessage message = await _client.GetAsync($"{characterId}/roles?datasource={datasource}");
				ret = _serializer.Deserialize<NotificationContact[]>(new JsonTextReader(new StreamReader(await message.Content.ReadAsStreamAsync())));
			}
			else
			{
				throw new Exception("No Authorization Token, this endpoint will fail.");
			}
			return ret;
		}
		
		public async Task<Icon> GetPortraitAsync(int characterId, string datasource = "tranquilty")
		{
			HttpResponseMessage message = await _client.GetAsync($"{characterId}/portrait?datasource={datasource}");
			Icon ret = _serializer.Deserialize<Icon>(new JsonTextReader(new StreamReader(await message.Content.ReadAsStreamAsync())));
			return ret;
		}
		
		public async Task<CharacterRoles> GetRolesAsync(int characterId, string datasource = "tranquilty")
		{
			CharacterRoles ret;
			if (_client.DefaultRequestHeaders.Any(e => e.Key == "authorization" & e.Value.Any(f => !string.IsNullOrWhiteSpace(f))))
			{
				HttpResponseMessage message = await _client.GetAsync($"{characterId}/portrait?datasource={datasource}");
				ret = _serializer.Deserialize<CharacterRoles>(new JsonTextReader(new StreamReader(await message.Content.ReadAsStreamAsync())));
			}
			else
			{
				throw new Exception("No Authorization Token, this endpoint will fail.");
			}
			return ret;
		}
		
		public async Task<StandingEntry[]> GetStandingsAsync(int characterId, string datasource = "tranquilty")
		{
			StandingEntry[] ret;
			if (_client.DefaultRequestHeaders.Any(e => e.Key == "authorization" & e.Value.Any(f => !string.IsNullOrWhiteSpace(f))))
			{
				HttpResponseMessage message = await _client.GetAsync($"{characterId}/standingss?datasource={datasource}");
				ret = _serializer.Deserialize<StandingEntry[]>(new JsonTextReader(new StreamReader(await message.Content.ReadAsStreamAsync())));
			}
			else
			{
				throw new Exception("No Authorization Token, this endpoint will fail.");
			}
			return ret;
		}
		
		public async Task<Title[]> GetTitlesAsync(int characterId, string datasource = "tranquilty")
		{
			Title[] ret;
			if (_client.DefaultRequestHeaders.Any(e => e.Key == "authorization" & e.Value.Any(f => !string.IsNullOrWhiteSpace(f))))
			{
				HttpResponseMessage message = await _client.GetAsync($"{characterId}/titles?datasource={datasource}");
				ret = _serializer.Deserialize<Title[]>(new JsonTextReader(new StreamReader(await message.Content.ReadAsStreamAsync())));
			}
			else
			{
				throw new Exception("No Authorization Token, this endpoint will fail.");
			}
			return ret;
		}
		
		public async Task<Affiliation[]> BulkAffiliationLookupAsync(string datasource = "tranquilty", params int[] characterIds)
		{
			Affiliation[] ret;
			if (_client.DefaultRequestHeaders.Any(e => e.Key == "authorization" & e.Value.Any(f => !string.IsNullOrWhiteSpace(f))))
			{
				HttpResponseMessage message = await _client.PostAsync($"affiliation?datasource={datasource}", JsonContent.Create(characterIds));
				ret = _serializer.Deserialize<Affiliation[]>(new JsonTextReader(new StreamReader(await message.Content.ReadAsStreamAsync())));
			}
			else
			{
				throw new Exception("No Authorization Token, this endpoint will fail.");
			}
			return ret;
		}
		
		public async Task<Clone> GetClonesAsync(int characterId, string datasource = "tranquilty")
		{
			Clone ret;
			if (_client.DefaultRequestHeaders.Any(e => e.Key == "authorization" & e.Value.Any(f => !string.IsNullOrWhiteSpace(f))))
			{
				HttpResponseMessage message = await _client.GetAsync($"{characterId}/clones?datasource={datasource}");
				ret = _serializer.Deserialize<Clone>(new JsonTextReader(new StreamReader(await message.Content.ReadAsStreamAsync())));
			}
			else
			{
				throw new Exception("No Authorization Token, this endpoint will fail.");
			}
			return ret;
		}
		
		public async Task<int[]> GetCurrentCloneImplantsAsync(int characterId, string datasource = "tranquilty")
		{
			int[] ret;
			if (_client.DefaultRequestHeaders.Any(e => e.Key == "authorization" & e.Value.Any(f => !string.IsNullOrWhiteSpace(f))))
			{
				HttpResponseMessage message = await _client.GetAsync($"{characterId}/implants?datasource={datasource}");
				ret = _serializer.Deserialize<int[]>(new JsonTextReader(new StreamReader(await message.Content.ReadAsStreamAsync())));
			}
			else
			{
				throw new Exception("No Authorization Token, this endpoint will fail.");
			}
			return ret;
		}
		
		public async Task<Attributes> GetCurrentCloneAttributesAsync(int characterId, string datasource = "tranquilty")
		{
			Attributes ret;
			if (_client.DefaultRequestHeaders.Any(e => e.Key == "authorization" & e.Value.Any(f => !string.IsNullOrWhiteSpace(f))))
			{
				HttpResponseMessage message = await _client.GetAsync($"{characterId}/attributes?datasource={datasource}");
				ret = _serializer.Deserialize<Attributes>(new JsonTextReader(new StreamReader(await message.Content.ReadAsStreamAsync())));
			}
			else
			{
				throw new Exception("No Authorization Token, this endpoint will fail.");
			}
			return ret;
		}
		
		public async Task<QueuedSkill[]> GetSkillQueueAsync(int characterId, string datasource = "tranquilty")
		{
			QueuedSkill[] ret;
			if (_client.DefaultRequestHeaders.Any(e => e.Key == "authorization" & e.Value.Any(f => !string.IsNullOrWhiteSpace(f))))
			{
				HttpResponseMessage message = await _client.GetAsync($"{characterId}/skillqueue?datasource={datasource}");
				ret = _serializer.Deserialize<QueuedSkill[]>(new JsonTextReader(new StreamReader(await message.Content.ReadAsStreamAsync())));
			}
			else
			{
				throw new Exception("No Authorization Token, this endpoint will fail.");
			}
			return ret;
		}
		
		public async Task<Skills> GetSkillsAsync(int characterId, string datasource = "tranquilty")
		{
			Skills ret;
			if (_client.DefaultRequestHeaders.Any(e => e.Key == "authorization" & e.Value.Any(f => !string.IsNullOrWhiteSpace(f))))
			{
				HttpResponseMessage message = await _client.GetAsync($"{characterId}/skills?datasource={datasource}");
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