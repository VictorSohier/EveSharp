using EveSharp.Core.Models;
using EveSharp.Core.Models.Character;
using EveSharp.Core.Models.Character.Clone;
using EveSharp.Core.Models.Character.Skills;
using EveSharp.Infrastructure.Enums;
using EveSharp.Infrastructure.Models;
using EveSharp.Infrastructure.Models.Wrappers;

namespace EveSharp.Test
{
	internal class CharacterWrapperTests
	{
		private OAuth2Token _token;
		private JsonWebKeySet _jwks;
		private readonly int _characterId;
		private readonly CharacterWrapper _wrapper = new();
		
		internal CharacterWrapperTests(ref OAuth2Token token, ref JsonWebKeySet jwks)
		{
			_token = token;
			_jwks = jwks;
			_characterId = int.Parse(jwks.sub.Split(":")[2]);
		}
		
		internal async Task<(int, int, int)> Run()
		{
			int totalTests = 0;
			int passedTests = 0;
			totalTests++;
			bool publicCharacterInformation = await PublicCharacterInformation();
			totalTests++;
			bool characterResearchAgents = await CharacterAgentResearch();
			totalTests++;
			bool characterBlueprints = await CharacterBlueprints();
			totalTests++;
			bool characterCorporationHistory = await CharacterCorporationHistory();
			totalTests++;
			bool CPSA = await CharacterCPSA();
			totalTests++;
			bool characterNotifications = await CharacterNotifications();
			totalTests++;
			bool characterContactNotifications = await CharacterContactNotifications();
			totalTests++;
			bool characterPortrait = await CharacterPortrait();
			totalTests++;
			bool characterStandings = await CharacterStandings();
			totalTests++;
			bool characterAffiliations = await CharacterAffiliations();
			totalTests++;
			bool clones = await Clones();
			totalTests++;
			bool skillQueue = await SkillQueue();
			totalTests++;
			bool skills = await Skills();
			if (publicCharacterInformation) passedTests++;
			if (characterResearchAgents) passedTests++;
			if (characterBlueprints) passedTests++;
			if (characterCorporationHistory) passedTests++;
			if (CPSA) passedTests++;
			if (characterNotifications) passedTests++;
			if (characterContactNotifications) passedTests++;
			if (characterPortrait) passedTests++;
			if (characterStandings) passedTests++;
			if (characterAffiliations) passedTests++;
			if (clones) passedTests++;
			if (skillQueue) passedTests++;
			if (skills) passedTests++;
			Console.WriteLine($"Character public data: {publicCharacterInformation}");
			Console.WriteLine($"Character research agents: {characterResearchAgents}");
			Console.WriteLine($"Character blueprints: {characterBlueprints}");
			Console.WriteLine($"Character corporation history: {characterCorporationHistory}");
			Console.WriteLine($"CPSA: {CPSA}");
			Console.WriteLine($"Character notifications: {characterNotifications}");
			Console.WriteLine($"Character contact notifications: {characterContactNotifications}");
			Console.WriteLine($"Character portrait: {characterPortrait}");
			Console.WriteLine($"Character standings: {characterStandings}");
			Console.WriteLine($"Character affiliations: {characterAffiliations}");
			Console.WriteLine($"Character clones: {clones}");
			Console.WriteLine($"Character skill queue: {skillQueue}");
			Console.WriteLine($"Character skills: {skills}");
			return (totalTests, passedTests, totalTests - passedTests);
		}
		
		private async Task<bool> PublicCharacterInformation()
		{
			Character character = await _wrapper.GetCharacterAsync(_characterId);
			bool ret = character.name == "Fomanko Berodald";
			return ret;
		}
		
		private async Task<bool> CharacterAgentResearch()
		{
			if (_jwks.exp > DateTimeOffset.Now.ToUnixTimeSeconds() + 5)
			{
				_token = await OAuth2Wrapper._instance.NativeTokenRefresh(_token.refreshToken);
				(_jwks, _) = await OAuth2Wrapper._instance.VerifyToken(_token);
			}
			AgentsResearch[] agents = await _wrapper.GetAgentsAsync(_token, _characterId);
			bool ret = agents.Length > 0;
			return ret;
		}
		
		private async Task<bool> CharacterBlueprints()
		{
			if (_jwks.exp > DateTimeOffset.Now.ToUnixTimeSeconds() + 5)
			{
				_token = await OAuth2Wrapper._instance.NativeTokenRefresh(_token.refreshToken);
				(_jwks, _) = await OAuth2Wrapper._instance.VerifyToken(_token);
			}
			Blueprint[] blueprints = await _wrapper.GetBlueprintsAsync(_token, _characterId);
			bool ret = blueprints.Length > 0;
			return ret;
		}
		
		private async Task<bool> CharacterCorporationHistory()
		{
			CorpHistoryEntry[] CorporationHistory = await _wrapper.GetCorporationHistoryAsync(_characterId);
			bool ret = CorporationHistory.Length > 0;
			return ret;
		}
		
		private async Task<bool> CharacterCPSA()
		{
			if (_jwks.exp > DateTimeOffset.Now.ToUnixTimeSeconds() + 5)
			{
				_token = await OAuth2Wrapper._instance.NativeTokenRefresh(_token.refreshToken);
				(_jwks, _) = await OAuth2Wrapper._instance.VerifyToken(_token);
			}
			float? CPSA = await _wrapper.GetCPSAAsync(_token, _characterId, DataSources.tranquility, _characterId);
			bool ret = CPSA != null;
			return ret;
		}
		
		private async Task<bool> CharacterNotifications()
		{
			if (_jwks.exp > DateTimeOffset.Now.ToUnixTimeSeconds() + 5)
			{
				_token = await OAuth2Wrapper._instance.NativeTokenRefresh(_token.refreshToken);
				(_jwks, _) = await OAuth2Wrapper._instance.VerifyToken(_token);
			}
			Notification[] notifications = await _wrapper.GetNotificationsAsync(_token, _characterId, DataSources.tranquility);
			bool ret = notifications.Length > 0;
			return ret;
		}
		
		private async Task<bool> CharacterContactNotifications()
		{
			if (_jwks.exp > DateTimeOffset.Now.ToUnixTimeSeconds() + 5)
			{
				_token = await OAuth2Wrapper._instance.NativeTokenRefresh(_token.refreshToken);
				(_jwks, _) = await OAuth2Wrapper._instance.VerifyToken(_token);
			}
			NotificationContact[] notifications = await _wrapper.GetContactNotificationsAsync(_token, _characterId);
			bool ret = notifications.Length > 0;
			return ret;
		}
		
		private async Task<bool> CharacterPortrait()
		{
			Icon protrait = await _wrapper.GetPortraitAsync(_characterId);
			bool ret =
				!string.IsNullOrEmpty(protrait.px64x64) |
				!string.IsNullOrEmpty(protrait.px128x128) |
				!string.IsNullOrEmpty(protrait.px256x256) |
				!string.IsNullOrEmpty(protrait.px512x512);
			return ret;
		}
		
		private async Task<bool> CharacterStandings()
		{
			if (_jwks.exp > DateTimeOffset.Now.ToUnixTimeSeconds() + 5)
			{
				_token = await OAuth2Wrapper._instance.NativeTokenRefresh(_token.refreshToken);
				(_jwks, _) = await OAuth2Wrapper._instance.VerifyToken(_token);
			}
			StandingEntry[] standings = await _wrapper.GetStandingsAsync(_token, _characterId);
			bool ret = standings.Length > 0;
			return ret;
		}
		
		private async Task<bool> CharacterAffiliations()
		{
			SoAAffiliation affiliations = new(await _wrapper.BulkAffiliationLookupAsync(DataSources.tranquility, _characterId));
			bool ret = affiliations.characterIds.Contains(_characterId);
			return ret;
		}
		
		private async Task<bool> Clones()
		{
			if (_jwks.exp > DateTimeOffset.Now.ToUnixTimeSeconds() + 5)
			{
				_token = await OAuth2Wrapper._instance.NativeTokenRefresh(_token.refreshToken);
				(_jwks, _) = await OAuth2Wrapper._instance.VerifyToken(_token);
			}
			Clones cloneDetails = await _wrapper.GetClonesAsync(_token, _characterId);
			bool ret = cloneDetails.jumpClones.Length > 0;
			return ret;
		}
		
		private async Task<bool> SkillQueue()
		{
			if (_jwks.exp > DateTimeOffset.Now.ToUnixTimeSeconds() + 5)
			{
				_token = await OAuth2Wrapper._instance.NativeTokenRefresh(_token.refreshToken);
				(_jwks, _) = await OAuth2Wrapper._instance.VerifyToken(_token);
			}
			QueuedSkill[] queuedSkills = await _wrapper.GetSkillQueueAsync(_token, _characterId);
			bool ret = queuedSkills.Length > 0;
			return ret;
		}
		
		private async Task<bool> Skills()
		{
			if (_jwks.exp > DateTimeOffset.Now.ToUnixTimeSeconds() + 5)
			{
				_token = await OAuth2Wrapper._instance.NativeTokenRefresh(_token.refreshToken);
				(_jwks, _) = await OAuth2Wrapper._instance.VerifyToken(_token);
			}
			Skills skills = await _wrapper.GetSkillsAsync(_token, _characterId);
			bool ret = skills.skills.Length > 0;
			ret &= skills.totalSp > 0;
			return ret;
		}
	}
}