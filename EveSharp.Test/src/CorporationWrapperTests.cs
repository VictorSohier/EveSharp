using EveSharp.Core.Models;
using EveSharp.Core.Models.Corporation;
using EveSharp.Core.Models.Corporation.Structure;
using EveSharp.Infrastructure.Models;
using EveSharp.Infrastructure.Models.Wrappers;

namespace EveSharp.Test
{
	internal class CorporationWrapperTests
	{
		//TODO: Make a corporation to test this wrapper
		private OAuth2Token _token;
		private JsonWebKeySet _jwks;
		private readonly int _characterId;
		private readonly CorporationWrapper _wrapper = new();
		private const int TEST_CORPORATION_ID = 1344654522;
		
		internal CorporationWrapperTests(ref OAuth2Token token, ref JsonWebKeySet jwks)
		{
			_token = token;
			_jwks = jwks;
			_characterId = int.Parse(jwks.sub.Split(":")[2]);
		}
		
		internal async Task<(int, int, int)> Run()
		{
			int totalTests = 0;
			int passedTests = 0;
			bool publicCorporationData = false;
			bool allianceHistory = false;
			bool corporationBlueprints = false;
			bool containerLogs = false;
			bool corporationDivisions = false;
			bool industrialFacilities = false;
			bool corporationIcon = false;
			bool medals = false;
			bool issuedMedals = false;
			bool members = false;
			bool memberLimit = false;
			bool titles = false;
			bool issuedTitles = false;
			bool tracking = false;
			bool issuedRoles = false;
			bool roleHistory = false;
			bool shareholders = false;
			bool standings = false;
			bool poses = false;
			bool posDetails = false;
			bool structures = false;
			bool npcCorporations = false;
			totalTests++;
			publicCorporationData = await PublicCorporationData();
			totalTests++;
			allianceHistory = await AllianceHistory();
			totalTests++;
			// corporationBlueprints = await CorporationBlueprints();
			// totalTests++;
			// containerLogs = await ContainerLogs();
			// totalTests++;
			// corporationDivisions = await CorporationDivisions();
			// totalTests++;
			// industrialFacilities = await CorporationFacilities();
			totalTests++;
			corporationIcon = await CorporationIcon();
			// totalTests++;
			// medals = await Medals();
			// totalTests++;
			// issuedMedals = await IssuedMedals();
			// totalTests++;
			// members = await Members();
			// totalTests++;
			// memberLimit = await MemberLimit();
			// totalTests++;
			// titles = await Titles();
			// totalTests++;
			// issuedTitles = await IssuedTitles();
			// totalTests++;
			// tracking = await Tracking();
			// totalTests++;
			// issuedRoles = await IssuedRoles();
			// totalTests++;
			// roleHistory = await RoleHistory();
			// totalTests++;
			// shareholders = await Shareholders();
			// totalTests++;
			// standings = await Standings();
			// totalTests++;
			// (poses, long starbaseId) = await POSes();
			// if (poses)
			// {
			// 	totalTests++;
			// 	posDetails = await POSDetails(starbaseId);
			// }
			// totalTests++;
			// structures = await Structures();
			totalTests++;
			npcCorporations = await NPCCorporations();
			if (publicCorporationData) passedTests++;
			if (allianceHistory) passedTests++;
			if (corporationBlueprints) passedTests++;
			if (containerLogs) passedTests++;
			if (corporationDivisions) passedTests++;
			if (industrialFacilities) passedTests++;
			if (corporationIcon) passedTests++;
			if (medals) passedTests++;
			if (issuedMedals) passedTests++;
			if (members) passedTests++;
			if (memberLimit) passedTests++;
			if (titles) passedTests++;
			if (issuedTitles) passedTests++;
			if (tracking) passedTests++;
			if (issuedRoles) passedTests++;
			if (roleHistory) passedTests++;
			if (shareholders) passedTests++;
			if (standings) passedTests++;
			if (poses) passedTests++;
			if (posDetails) passedTests++;
			if (structures) passedTests++;
			if (npcCorporations) passedTests++;
			Console.WriteLine($"Public corporation data: {publicCorporationData}");
			Console.WriteLine($"Alliance history: {allianceHistory}");
			Console.WriteLine($"Corporation blueprints: {corporationBlueprints}");
			Console.WriteLine($"Container logs: {containerLogs}");
			Console.WriteLine($"Corporation Divisions: {corporationDivisions}");
			Console.WriteLine($"Industrial Facilities: {industrialFacilities}");
			Console.WriteLine($"Corporation icons: {corporationIcon}");
			Console.WriteLine($"Medals: {medals}");
			Console.WriteLine($"Issued Medals: {issuedMedals}");
			Console.WriteLine($"Memebrs: {members}");
			Console.WriteLine($"Member limit: {memberLimit}");
			Console.WriteLine($"Titles: {titles}");
			Console.WriteLine($"Issued titles: {issuedTitles}");
			Console.WriteLine($"Tracking: {tracking}");
			Console.WriteLine($"Issued roles: {issuedRoles}");
			Console.WriteLine($"Role history: {roleHistory}");
			Console.WriteLine($"Shareholders: {shareholders}");
			Console.WriteLine($"POSes: {poses}");
			Console.WriteLine($"POS details: {posDetails}");
			Console.WriteLine($"Structures: {structures}");
			Console.WriteLine($"NPC corporations: {npcCorporations}");
			return (totalTests, passedTests, totalTests - passedTests);
		}
		
		private async Task<bool> PublicCorporationData()
		{
			Corporation corporation = await _wrapper.GetCorporationAsync(TEST_CORPORATION_ID);
			bool ret = !string.IsNullOrEmpty(corporation.ticker);
			ret &= !string.IsNullOrEmpty(corporation.name);
			return ret;
		}
		
		private async Task<bool> AllianceHistory()
		{
			AllianceHistoryEntry[] allianceHistory = await _wrapper.GetAllianceHistoryAsync(TEST_CORPORATION_ID);
			bool ret = allianceHistory.Length > 0;
			return ret;
		}
		
		private async Task<bool> CorporationBlueprints()
		{
			if (_jwks.exp > DateTimeOffset.Now.ToUnixTimeSeconds() + 5)
			{
				_token = await OAuth2Wrapper._instance.NativeTokenRefresh(_token.refreshToken);
				(_jwks, _) = await OAuth2Wrapper._instance.VerifyToken(_token);
			}
			Blueprint[] allianceHistory = await _wrapper.GetBlueprintsAsync(_token, TEST_CORPORATION_ID);
			bool ret = allianceHistory.Length > 0;
			return ret;
		}
		
		private async Task<bool> ContainerLogs()
		{
			if (_jwks.exp > DateTimeOffset.Now.ToUnixTimeSeconds() + 5)
			{
				_token = await OAuth2Wrapper._instance.NativeTokenRefresh(_token.refreshToken);
				(_jwks, _) = await OAuth2Wrapper._instance.VerifyToken(_token);
			}
			ContainerLogEntry[] containerLogs = await _wrapper.GetContainerLogsAsync(_token, TEST_CORPORATION_ID);
			bool ret = containerLogs.Length > 0;
			return ret;
		}
		
		private async Task<bool> CorporationDivisions()
		{
			if (_jwks.exp > DateTimeOffset.Now.ToUnixTimeSeconds() + 5)
			{
				_token = await OAuth2Wrapper._instance.NativeTokenRefresh(_token.refreshToken);
				(_jwks, _) = await OAuth2Wrapper._instance.VerifyToken(_token);
			}
			(CorporationDivision[] hangarDivisions, CorporationDivision[] walletDivisions)  = await _wrapper.GetDivisionsAsync(_token, TEST_CORPORATION_ID);
			bool ret = hangarDivisions.Length > 0;
			ret &= walletDivisions.Length > 0;
			return ret;
		}
		
		// TODO: Pick up a structure.
		private async Task<bool> CorporationFacilities()
		{
			if (_jwks.exp > DateTimeOffset.Now.ToUnixTimeSeconds() + 5)
			{
				_token = await OAuth2Wrapper._instance.NativeTokenRefresh(_token.refreshToken);
				(_jwks, _) = await OAuth2Wrapper._instance.VerifyToken(_token);
			}
			Facility[] facilities = await _wrapper.GetFacilitiesAsync(_token, TEST_CORPORATION_ID);
			bool ret = facilities.Length > 0;
			return ret;
		}
		
		private async Task<bool> CorporationIcon()
		{
			Icon icons = await _wrapper.GetIconsAsync(TEST_CORPORATION_ID);
			bool ret = 
				!string.IsNullOrEmpty(icons.px64x64) |
				!string.IsNullOrEmpty(icons.px128x128) |
				!string.IsNullOrEmpty(icons.px256x256) |
				!string.IsNullOrEmpty(icons.px512x512);
			return ret;
		}
		
		private async Task<bool> Medals()
		{
			if (_jwks.exp > DateTimeOffset.Now.ToUnixTimeSeconds() + 5)
			{
				_token = await OAuth2Wrapper._instance.NativeTokenRefresh(_token.refreshToken);
				(_jwks, _) = await OAuth2Wrapper._instance.VerifyToken(_token);
			}
			Medal[] medals = await _wrapper.GetMedalsAsync(_token, TEST_CORPORATION_ID);
			bool ret = medals.Length > 0;
			return ret;
		}
		
		private async Task<bool> IssuedMedals()
		{
			if (_jwks.exp > DateTimeOffset.Now.ToUnixTimeSeconds() + 5)
			{
				_token = await OAuth2Wrapper._instance.NativeTokenRefresh(_token.refreshToken);
				(_jwks, _) = await OAuth2Wrapper._instance.VerifyToken(_token);
			}
			IssuedMedal[] medals = await _wrapper.GetIssuedMedalsAsync(_token, TEST_CORPORATION_ID);
			bool ret = medals.Length > 0;
			return ret;
		}
		
		private async Task<bool> Members()
		{
			if (_jwks.exp > DateTimeOffset.Now.ToUnixTimeSeconds() + 5)
			{
				_token = await OAuth2Wrapper._instance.NativeTokenRefresh(_token.refreshToken);
				(_jwks, _) = await OAuth2Wrapper._instance.VerifyToken(_token);
			}
			int[] members = await _wrapper.GetMembersAsync(_token, TEST_CORPORATION_ID);
			bool ret = members.Length > 0;
			return ret;
		}
		
		private async Task<bool> MemberLimit()
		{
			if (_jwks.exp > DateTimeOffset.Now.ToUnixTimeSeconds() + 5)
			{
				_token = await OAuth2Wrapper._instance.NativeTokenRefresh(_token.refreshToken);
				(_jwks, _) = await OAuth2Wrapper._instance.VerifyToken(_token);
			}
			int memberLimit = await _wrapper.GetMemberLimitAsync(_token, TEST_CORPORATION_ID);
			bool ret = memberLimit > 0;
			return ret;
		}
		
		private async Task<bool> Titles()
		{
			if (_jwks.exp > DateTimeOffset.Now.ToUnixTimeSeconds() + 5)
			{
				_token = await OAuth2Wrapper._instance.NativeTokenRefresh(_token.refreshToken);
				(_jwks, _) = await OAuth2Wrapper._instance.VerifyToken(_token);
			}
			Title[] titles = await _wrapper.GetTitlesAsync(_token, TEST_CORPORATION_ID);
			bool ret = titles.Length > 0;
			return ret;
		}
		
		private async Task<bool> IssuedTitles()
		{
			if (_jwks.exp > DateTimeOffset.Now.ToUnixTimeSeconds() + 5)
			{
				_token = await OAuth2Wrapper._instance.NativeTokenRefresh(_token.refreshToken);
				(_jwks, _) = await OAuth2Wrapper._instance.VerifyToken(_token);
			}
			IssuedTitle[] titles = await _wrapper.GetIssuedTitlesAsync(_token, TEST_CORPORATION_ID);
			bool ret = titles.Length > 0;
			return ret;
		}
		
		private async Task<bool> Tracking()
		{
			if (_jwks.exp > DateTimeOffset.Now.ToUnixTimeSeconds() + 5)
			{
				_token = await OAuth2Wrapper._instance.NativeTokenRefresh(_token.refreshToken);
				(_jwks, _) = await OAuth2Wrapper._instance.VerifyToken(_token);
			}
			MemberTrackingEntry[] lastKnownStates = await _wrapper.GetLastKnownMemberStatesAsync(_token, TEST_CORPORATION_ID);
			bool ret = lastKnownStates.Length > 0;
			return ret;
		}
		
		private async Task<bool> IssuedRoles()
		{
			if (_jwks.exp > DateTimeOffset.Now.ToUnixTimeSeconds() + 5)
			{
				_token = await OAuth2Wrapper._instance.NativeTokenRefresh(_token.refreshToken);
				(_jwks, _) = await OAuth2Wrapper._instance.VerifyToken(_token);
			}
			CorporationRole[] roles = await _wrapper.GetIssuedRolesAsync(_token, TEST_CORPORATION_ID);
			bool ret = roles.Length > 0;
			return ret;
		}
		
		private async Task<bool> RoleHistory()
		{
			if (_jwks.exp > DateTimeOffset.Now.ToUnixTimeSeconds() + 5)
			{
				_token = await OAuth2Wrapper._instance.NativeTokenRefresh(_token.refreshToken);
				(_jwks, _) = await OAuth2Wrapper._instance.VerifyToken(_token);
			}
			CharacterRolesHistory[] roles = await _wrapper.GetCorporationRoleHistoryAsync(_token, TEST_CORPORATION_ID);
			bool ret = roles.Length > 0;
			return ret;
		}
		
		private async Task<bool> Shareholders()
		{
			if (_jwks.exp > DateTimeOffset.Now.ToUnixTimeSeconds() + 5)
			{
				_token = await OAuth2Wrapper._instance.NativeTokenRefresh(_token.refreshToken);
				(_jwks, _) = await OAuth2Wrapper._instance.VerifyToken(_token);
			}
			Shareholder[] shareholders = await _wrapper.GetShareholdersAsync(_token, TEST_CORPORATION_ID);
			bool ret = shareholders.Length > 0;
			return ret;
		}
		
		private async Task<bool> Standings()
		{
			if (_jwks.exp > DateTimeOffset.Now.ToUnixTimeSeconds() + 5)
			{
				_token = await OAuth2Wrapper._instance.NativeTokenRefresh(_token.refreshToken);
				(_jwks, _) = await OAuth2Wrapper._instance.VerifyToken(_token);
			}
			StandingEntry[] standings = await _wrapper.GetStandingsAsync(_token, TEST_CORPORATION_ID);
			bool ret = standings.Length > 0;
			return ret;
		}
		
		// TODO: Pick up a POS
		private async Task<(bool, long)> POSes()
		{
			if (_jwks.exp > DateTimeOffset.Now.ToUnixTimeSeconds() + 5)
			{
				_token = await OAuth2Wrapper._instance.NativeTokenRefresh(_token.refreshToken);
				(_jwks, _) = await OAuth2Wrapper._instance.VerifyToken(_token);
			}
			Starbase[] starbases = await _wrapper.GetStarbasesAsync(_token, TEST_CORPORATION_ID);
			bool ret = starbases.Length > 0;
			return (ret, ret ? starbases[0].starbaseId : 0);
		}
		
		private async Task<bool> POSDetails(long posId)
		{
			if (_jwks.exp > DateTimeOffset.Now.ToUnixTimeSeconds() + 5)
			{
				_token = await OAuth2Wrapper._instance.NativeTokenRefresh(_token.refreshToken);
				(_jwks, _) = await OAuth2Wrapper._instance.VerifyToken(_token);
			}
			StarbaseDetails starbase = await _wrapper.GetStarbaseDetailsAsync(_token, TEST_CORPORATION_ID, posId);
			bool ret = starbase.useAllianceStandings;
			return ret;
		}
		
		// TODO: Pick up a structure
		private async Task<bool> Structures()
		{
			if (_jwks.exp > DateTimeOffset.Now.ToUnixTimeSeconds() + 5)
			{
				_token = await OAuth2Wrapper._instance.NativeTokenRefresh(_token.refreshToken);
				(_jwks, _) = await OAuth2Wrapper._instance.VerifyToken(_token);
			}
			Structure[] structures = await _wrapper.GetStructuresAsync(_token, TEST_CORPORATION_ID);
			bool ret = structures.Length > 0;
			return ret;
		}
		
		private async Task<bool> NPCCorporations()
		{
			int[] corporationIds = await _wrapper.GetNPCCorpsAsync();
			bool ret = corporationIds.Length > 0;
			return ret;
		}
	}
}