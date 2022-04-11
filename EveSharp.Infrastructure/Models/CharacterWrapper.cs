using System.Net.Http.Json;
using EveSharp.Core.Models;
using EveSharp.Core.Models.Character;
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
			HttpResponseMessage message = await _client.GetAsync($"{characterId}/agents_research?datasource={datasource}");
			AgentsResearch[] ret;
			if (_client.DefaultRequestHeaders.Any(e => e.Key == "authorization" & e.Value.Any(f => !string.IsNullOrWhiteSpace(f))))
			{
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
			HttpResponseMessage message = await _client.GetAsync($"{characterId}/blueprints?datasource={datasource}&page={page}");
			Blueprint ret;
			if (_client.DefaultRequestHeaders.Any(e => e.Key == "authorization" & e.Value.Any(f => !string.IsNullOrWhiteSpace(f))))
			{
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
			HttpResponseMessage message = await _client.PostAsync($"{characterId}/cspa?datasource={datasource}", JsonContent.Create(recipientIds));
			float ret;
			if (_client.DefaultRequestHeaders.Any(e => e.Key == "authorization" & e.Value.Any(f => !string.IsNullOrWhiteSpace(f))))
			{
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
			HttpResponseMessage message = await _client.GetAsync($"{characterId}/fatigue?datasource={datasource}");
			JumpFatigue ret;
			if (_client.DefaultRequestHeaders.Any(e => e.Key == "authorization" & e.Value.Any(f => !string.IsNullOrWhiteSpace(f))))
			{
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
			HttpResponseMessage message = await _client.GetAsync($"{characterId}/medals?datasource={datasource}");
			Medal[] ret;
			if (_client.DefaultRequestHeaders.Any(e => e.Key == "authorization" & e.Value.Any(f => !string.IsNullOrWhiteSpace(f))))
			{
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
			HttpResponseMessage message = await _client.GetAsync($"{characterId}/notifications?datasource={datasource}");
			Notification[] ret;
			if (_client.DefaultRequestHeaders.Any(e => e.Key == "authorization" & e.Value.Any(f => !string.IsNullOrWhiteSpace(f))))
			{
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
			HttpResponseMessage message = await _client.GetAsync($"{characterId}/roles?datasource={datasource}");
			NotificationContact[] ret;
			if (_client.DefaultRequestHeaders.Any(e => e.Key == "authorization" & e.Value.Any(f => !string.IsNullOrWhiteSpace(f))))
			{
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
			HttpResponseMessage message = await _client.GetAsync($"{characterId}/portrait?datasource={datasource}");
			CharacterRoles ret;
			if (_client.DefaultRequestHeaders.Any(e => e.Key == "authorization" & e.Value.Any(f => !string.IsNullOrWhiteSpace(f))))
			{
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
			HttpResponseMessage message = await _client.GetAsync($"{characterId}/standingss?datasource={datasource}");
			StandingEntry[] ret;
			if (_client.DefaultRequestHeaders.Any(e => e.Key == "authorization" & e.Value.Any(f => !string.IsNullOrWhiteSpace(f))))
			{
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
			HttpResponseMessage message = await _client.GetAsync($"{characterId}/titles?datasource={datasource}");
			Title[] ret;
			if (_client.DefaultRequestHeaders.Any(e => e.Key == "authorization" & e.Value.Any(f => !string.IsNullOrWhiteSpace(f))))
			{
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
			HttpResponseMessage message = await _client.PostAsync($"affiliation?datasource={datasource}", JsonContent.Create(characterIds));
			Affiliation[] ret;
			if (_client.DefaultRequestHeaders.Any(e => e.Key == "authorization" & e.Value.Any(f => !string.IsNullOrWhiteSpace(f))))
			{
				ret = _serializer.Deserialize<Affiliation[]>(new JsonTextReader(new StreamReader(await message.Content.ReadAsStreamAsync())));
			}
			else
			{
				throw new Exception("No Authorization Token, this endpoint will fail.");
			}
			return ret;
		}
	}
}