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
		
		public CharacterWrapper()
		{
			_client = new();
			_client.BaseAddress = new($"{WrapperConfig._instance.DOMAIN}");
			_serializer = WrapperConfig._instance.SERIALIZER;
		}
		
		public async Task<Character> GetCharacterAsync(int characterId, DataSources datasource = DataSources.tranquility)
		{
			HttpResponseMessage message = await _client.GetAsync($"/{WrapperConfig._instance.API_VERSION}/characters/{characterId}?datasource={Enum.GetName(datasource)?.ToLower()}");
			Character ret;
			if (WrapperConfig._instance.SUCCESS.Contains(message.StatusCode))
			{
				ret = _serializer.Deserialize<Character>(new JsonTextReader(new StreamReader(await message.Content.ReadAsStreamAsync())));
				return ret;
			}
			throw new Exception(_serializer.Deserialize<Error>(new JsonTextReader(new StreamReader(await message.Content.ReadAsStreamAsync()))).error);
		}
		
		public async Task<AgentsResearch[]> GetAgentsAsync(OAuth2Token token, int characterId, DataSources datasource = DataSources.tranquility)
		{
			_client.DefaultRequestHeaders.Remove("Authorization");
			_client.DefaultRequestHeaders.Add("Authorization", $"{token.tokenType} {token.accessToken}");
			AgentsResearch[] ret;
			HttpResponseMessage message = await _client.GetAsync($"/{WrapperConfig._instance.API_VERSION}/characters/{characterId}/agents_research?datasource={Enum.GetName(datasource)?.ToLower()}");
			if (WrapperConfig._instance.SUCCESS.Contains(message.StatusCode))
			{	
				ret = _serializer.Deserialize<AgentsResearch[]>(new JsonTextReader(new StreamReader(await message.Content.ReadAsStreamAsync())));
				return ret;
			}
			throw new Exception(_serializer.Deserialize<Error>(new JsonTextReader(new StreamReader(await message.Content.ReadAsStreamAsync()))).error);
		}
		
		public async Task<Blueprint[]> GetBlueprintsAsync(OAuth2Token token, int characterId, int page = 1, DataSources datasource = DataSources.tranquility)
		{
			_client.DefaultRequestHeaders.Remove("Authorization");
			_client.DefaultRequestHeaders.Add("Authorization", $"{token.tokenType} {token.accessToken}");
			Blueprint[] ret;
			HttpResponseMessage message = await _client.GetAsync($"/{WrapperConfig._instance.API_VERSION}/characters/{characterId}/blueprints?datasource={Enum.GetName(datasource)?.ToLower()}&page={page}");
			if (WrapperConfig._instance.SUCCESS.Contains(message.StatusCode))
			{	
				ret = _serializer.Deserialize<Blueprint[]>(new JsonTextReader(new StreamReader(await message.Content.ReadAsStreamAsync())));
				return ret;
			}
			throw new Exception(_serializer.Deserialize<Error>(new JsonTextReader(new StreamReader(await message.Content.ReadAsStreamAsync()))).error);
		}
		
		public async Task<CorpHistoryEntry[]> GetCorporationHistoryAsync(int characterId, DataSources datasource = DataSources.tranquility)
		{
			HttpResponseMessage message = await _client.GetAsync($"/{WrapperConfig._instance.API_VERSION}/characters/{characterId}/corporationhistory?datasource={Enum.GetName(datasource)?.ToLower()}");
			CorpHistoryEntry[] ret = _serializer.Deserialize<CorpHistoryEntry[]>(new JsonTextReader(new StreamReader(await message.Content.ReadAsStreamAsync())));
			return ret;
		}
		
		public async Task<float> GetCPSAAsync(OAuth2Token token, int characterId, DataSources datasource = DataSources.tranquility, params int[] recipientIds)
		{
			_client.DefaultRequestHeaders.Remove("Authorization");
			_client.DefaultRequestHeaders.Add("Authorization", $"{token.tokenType} {token.accessToken}");
			float ret;
			HttpResponseMessage message = await _client.PostAsync($"/{WrapperConfig._instance.API_VERSION}/characters/{characterId}/cspa?datasource={Enum.GetName(datasource)?.ToLower()}", JsonContent.Create(recipientIds));
			if (WrapperConfig._instance.SUCCESS.Contains(message.StatusCode))
			{	
				ret = _serializer.Deserialize<float>(new JsonTextReader(new StreamReader(await message.Content.ReadAsStreamAsync())));
				return ret;
			}
			throw new Exception(_serializer.Deserialize<Error>(new JsonTextReader(new StreamReader(await message.Content.ReadAsStreamAsync()))).error);
		}
		
		public async Task<JumpFatigue> GetJumpFatigueAsync(OAuth2Token token, int characterId, DataSources datasource = DataSources.tranquility)
		{
			_client.DefaultRequestHeaders.Remove("Authorization");
			_client.DefaultRequestHeaders.Add("Authorization", $"{token.tokenType} {token.accessToken}");
			JumpFatigue ret;
			HttpResponseMessage message = await _client.GetAsync($"/{WrapperConfig._instance.API_VERSION}/characters/{characterId}/fatigue?datasource={Enum.GetName(datasource)?.ToLower()}");
				if (WrapperConfig._instance.SUCCESS.Contains(message.StatusCode))
					throw new Exception(_serializer.Deserialize<Error>(new JsonTextReader(new StreamReader(await message.Content.ReadAsStreamAsync()))).error);
				ret = _serializer.Deserialize<JumpFatigue>(new JsonTextReader(new StreamReader(await message.Content.ReadAsStreamAsync())));
			return ret;
		}
		
		public async Task<Medal[]> GetMedalsAsync(OAuth2Token token, int characterId, DataSources datasource = DataSources.tranquility)
		{
			_client.DefaultRequestHeaders.Remove("Authorization");
			_client.DefaultRequestHeaders.Add("Authorization", $"{token.tokenType} {token.accessToken}");
			Medal[] ret;
			HttpResponseMessage message = await _client.GetAsync($"/{WrapperConfig._instance.API_VERSION}/characters/{characterId}/medals?datasource={Enum.GetName(datasource)?.ToLower()}");
			if (WrapperConfig._instance.SUCCESS.Contains(message.StatusCode))
			{	
				ret = _serializer.Deserialize<Medal[]>(new JsonTextReader(new StreamReader(await message.Content.ReadAsStreamAsync())));
				return ret;
			}
			throw new Exception(_serializer.Deserialize<Error>(new JsonTextReader(new StreamReader(await message.Content.ReadAsStreamAsync()))).error);
		}
		
		public async Task<Notification[]> GetNotificationsAsync(OAuth2Token token, int characterId, DataSources datasource = DataSources.tranquility)
		{
			_client.DefaultRequestHeaders.Remove("Authorization");
			_client.DefaultRequestHeaders.Add("Authorization", $"{token.tokenType} {token.accessToken}");
			Notification[] ret;
			HttpResponseMessage message = await _client.GetAsync($"/{WrapperConfig._instance.API_VERSION}/characters/{characterId}/notifications?datasource={Enum.GetName(datasource)?.ToLower()}");
			if (WrapperConfig._instance.SUCCESS.Contains(message.StatusCode))
			{	
				ret = _serializer.Deserialize<Notification[]>(new JsonTextReader(new StreamReader(await message.Content.ReadAsStreamAsync())));
				return ret;
			}
			throw new Exception(_serializer.Deserialize<Error>(new JsonTextReader(new StreamReader(await message.Content.ReadAsStreamAsync()))).error);
		}
		
		public async Task<NotificationContact[]> GetContactNotificationsAsync(OAuth2Token token, int characterId, DataSources datasource = DataSources.tranquility)
		{
			_client.DefaultRequestHeaders.Remove("Authorization");
			_client.DefaultRequestHeaders.Add("Authorization", $"{token.tokenType} {token.accessToken}");
			NotificationContact[] ret;
			HttpResponseMessage message = await _client.GetAsync($"/{WrapperConfig._instance.API_VERSION}/characters/{characterId}/notifications/contacts?datasource={Enum.GetName(datasource)?.ToLower()}");
			if (WrapperConfig._instance.SUCCESS.Contains(message.StatusCode))
			{
				ret = _serializer.Deserialize<NotificationContact[]>(new JsonTextReader(new StreamReader(await message.Content.ReadAsStreamAsync())));
				return ret;
			}
			throw new Exception(_serializer.Deserialize<Error>(new JsonTextReader(new StreamReader(await message.Content.ReadAsStreamAsync()))).error);
		}
		
		public async Task<Icon> GetPortraitAsync(int characterId, DataSources datasource = DataSources.tranquility)
		{
			HttpResponseMessage message = await _client.GetAsync($"/{WrapperConfig._instance.API_VERSION}/characters/{characterId}/portrait?datasource={Enum.GetName(datasource)?.ToLower()}");
			Icon ret;
			if (WrapperConfig._instance.SUCCESS.Contains(message.StatusCode))
			{
				ret = _serializer.Deserialize<Icon>(new JsonTextReader(new StreamReader(await message.Content.ReadAsStreamAsync())));
				return ret;
			}
			throw new Exception(_serializer.Deserialize<Error>(new JsonTextReader(new StreamReader(await message.Content.ReadAsStreamAsync()))).error);
		}
		
		public async Task<CharacterRoles> GetRolesAsync(OAuth2Token token, int characterId, DataSources datasource = DataSources.tranquility)
		{
			_client.DefaultRequestHeaders.Remove("Authorization");
			_client.DefaultRequestHeaders.Add("Authorization", $"{token.tokenType} {token.accessToken}");
			CharacterRoles ret;
			HttpResponseMessage message = await _client.GetAsync($"/{WrapperConfig._instance.API_VERSION}/characters/{characterId}/roles?datasource={Enum.GetName(datasource)?.ToLower()}");
			if (WrapperConfig._instance.SUCCESS.Contains(message.StatusCode))
			{	
				ret = _serializer.Deserialize<CharacterRoles>(new JsonTextReader(new StreamReader(await message.Content.ReadAsStreamAsync())));
				return ret;
			}
			throw new Exception(_serializer.Deserialize<Error>(new JsonTextReader(new StreamReader(await message.Content.ReadAsStreamAsync()))).error);
		}
		
		public async Task<StandingEntry[]> GetStandingsAsync(OAuth2Token token, int characterId, DataSources datasource = DataSources.tranquility)
		{
			_client.DefaultRequestHeaders.Remove("Authorization");
			_client.DefaultRequestHeaders.Add("Authorization", $"{token.tokenType} {token.accessToken}");
			StandingEntry[] ret;
			HttpResponseMessage message = await _client.GetAsync($"/{WrapperConfig._instance.API_VERSION}/characters/{characterId}/standings?datasource={Enum.GetName(datasource)?.ToLower()}");
			if (WrapperConfig._instance.SUCCESS.Contains(message.StatusCode))
			{	
				ret = _serializer.Deserialize<StandingEntry[]>(new JsonTextReader(new StreamReader(await message.Content.ReadAsStreamAsync())));
				return ret;
			}
			throw new Exception(_serializer.Deserialize<Error>(new JsonTextReader(new StreamReader(await message.Content.ReadAsStreamAsync()))).error);
		}
		
		public async Task<Title[]> GetTitlesAsync(OAuth2Token token, int characterId, DataSources datasource = DataSources.tranquility)
		{
			_client.DefaultRequestHeaders.Remove("Authorization");
			_client.DefaultRequestHeaders.Add("Authorization", $"{token.tokenType} {token.accessToken}");
			Title[] ret;
			HttpResponseMessage message = await _client.GetAsync($"/{WrapperConfig._instance.API_VERSION}/characters/{characterId}/titles?datasource={Enum.GetName(datasource)?.ToLower()}");
			if (WrapperConfig._instance.SUCCESS.Contains(message.StatusCode))
			{	
				ret = _serializer.Deserialize<Title[]>(new JsonTextReader(new StreamReader(await message.Content.ReadAsStreamAsync())));
				return ret;
			}
			throw new Exception(_serializer.Deserialize<Error>(new JsonTextReader(new StreamReader(await message.Content.ReadAsStreamAsync()))).error);
		}
		
		public async Task<Affiliation[]> BulkAffiliationLookupAsync(DataSources datasource = DataSources.tranquility, params int[] characterIds)
		{
			Affiliation[] ret;
			HttpResponseMessage message = await _client.PostAsync($"/{WrapperConfig._instance.API_VERSION}/characters/affiliation?datasource={Enum.GetName(datasource)?.ToLower()}", JsonContent.Create(characterIds));
			if (WrapperConfig._instance.SUCCESS.Contains(message.StatusCode))
			{	
				ret = _serializer.Deserialize<Affiliation[]>(new JsonTextReader(new StreamReader(await message.Content.ReadAsStreamAsync())));
				return ret;
			}
			throw new Exception(_serializer.Deserialize<Error>(new JsonTextReader(new StreamReader(await message.Content.ReadAsStreamAsync()))).error);
		}
		
		public async Task<Clones> GetClonesAsync(OAuth2Token token, int characterId, DataSources datasource = DataSources.tranquility)
		{
			_client.DefaultRequestHeaders.Remove("Authorization");
			_client.DefaultRequestHeaders.Add("Authorization", $"{token.tokenType} {token.accessToken}");
			Clones ret;
			HttpResponseMessage message = await _client.GetAsync($"/{WrapperConfig._instance.API_VERSION}/characters/{characterId}/clones?datasource={Enum.GetName(datasource)?.ToLower()}");
			if (WrapperConfig._instance.SUCCESS.Contains(message.StatusCode))
			{	
				ret = _serializer.Deserialize<Clones>(new JsonTextReader(new StreamReader(await message.Content.ReadAsStreamAsync())));
				return ret;
			}
			throw new Exception(_serializer.Deserialize<Error>(new JsonTextReader(new StreamReader(await message.Content.ReadAsStreamAsync()))).error);
		}
		
		public async Task<int[]> GetCurrentCloneImplantsAsync(OAuth2Token token, int characterId, DataSources datasource = DataSources.tranquility)
		{
			_client.DefaultRequestHeaders.Remove("Authorization");
			_client.DefaultRequestHeaders.Add("Authorization", $"{token.tokenType} {token.accessToken}");
			int[] ret;
			HttpResponseMessage message = await _client.GetAsync($"/{WrapperConfig._instance.API_VERSION}/characters/{characterId}/implants?datasource={Enum.GetName(datasource)?.ToLower()}");
			if (WrapperConfig._instance.SUCCESS.Contains(message.StatusCode))
			{	
				ret = _serializer.Deserialize<int[]>(new JsonTextReader(new StreamReader(await message.Content.ReadAsStreamAsync())));
				return ret;
			}
			throw new Exception(_serializer.Deserialize<Error>(new JsonTextReader(new StreamReader(await message.Content.ReadAsStreamAsync()))).error);
		}
		
		public async Task<Attributes> GetCurrentCloneAttributesAsync(OAuth2Token token, int characterId, DataSources datasource = DataSources.tranquility)
		{
			_client.DefaultRequestHeaders.Remove("Authorization");
			_client.DefaultRequestHeaders.Add("Authorization", $"{token.tokenType} {token.accessToken}");
			Attributes ret;
			HttpResponseMessage message = await _client.GetAsync($"/{WrapperConfig._instance.API_VERSION}/characters/{characterId}/attributes?datasource={Enum.GetName(datasource)?.ToLower()}");
			if (WrapperConfig._instance.SUCCESS.Contains(message.StatusCode))
			{	
				ret = _serializer.Deserialize<Attributes>(new JsonTextReader(new StreamReader(await message.Content.ReadAsStreamAsync())));
				return ret;
			}
			throw new Exception(_serializer.Deserialize<Error>(new JsonTextReader(new StreamReader(await message.Content.ReadAsStreamAsync()))).error);
		}
		
		public async Task<QueuedSkill[]> GetSkillQueueAsync(OAuth2Token token, int characterId, DataSources datasource = DataSources.tranquility)
		{
			_client.DefaultRequestHeaders.Remove("Authorization");
			_client.DefaultRequestHeaders.Add("Authorization", $"{token.tokenType} {token.accessToken}");
			QueuedSkill[] ret;
			HttpResponseMessage message = await _client.GetAsync($"/{WrapperConfig._instance.API_VERSION}/characters/{characterId}/skillqueue?datasource={Enum.GetName(datasource)?.ToLower()}");
			if (WrapperConfig._instance.SUCCESS.Contains(message.StatusCode))
			{	
				ret = _serializer.Deserialize<QueuedSkill[]>(new JsonTextReader(new StreamReader(await message.Content.ReadAsStreamAsync())));
				return ret;
			}
			throw new Exception(_serializer.Deserialize<Error>(new JsonTextReader(new StreamReader(await message.Content.ReadAsStreamAsync()))).error);
		}
		
		public async Task<Skills> GetSkillsAsync(OAuth2Token token, int characterId, DataSources datasource = DataSources.tranquility)
		{
			_client.DefaultRequestHeaders.Remove("Authorization");
			_client.DefaultRequestHeaders.Add("Authorization", $"{token.tokenType} {token.accessToken}");
			Skills ret;
			HttpResponseMessage message = await _client.GetAsync($"/{WrapperConfig._instance.API_VERSION}/characters/{characterId}/skills?datasource={Enum.GetName(datasource)?.ToLower()}");
			if (WrapperConfig._instance.SUCCESS.Contains(message.StatusCode))
			{	
				ret = _serializer.Deserialize<Skills>(new JsonTextReader(new StreamReader(await message.Content.ReadAsStreamAsync())));
				return ret;
			}
			throw new Exception(_serializer.Deserialize<Error>(new JsonTextReader(new StreamReader(await message.Content.ReadAsStreamAsync()))).error);
		}
	}
}