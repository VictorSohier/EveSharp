using EveSharp.Core.Models;
using EveSharp.Core.Models.Corporation;
using EveSharp.Core.Models.Corporation.Structure;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;

namespace EveSharp.Infrastructure.Models
{
	public class CorporationWrapper
	{
		private readonly HttpClient _client;
		private readonly JsonSerializer _serializer;
		
		public CorporationWrapper(string authToken)
		{
			_client = new();
			_client.BaseAddress = new($"https://esi.evetech.net/{WrapperConfig._instance.API_VERSION}/corporations");
			_client.DefaultRequestHeaders.Add("authorization", authToken);
			_serializer = WrapperConfig._instance.SERIALIZER;
		}
		
		public CorporationWrapper()
		{
			_client = new();
			_client.BaseAddress = new($"https://esi.evetech.net/{WrapperConfig._instance.API_VERSION}/corporations");
			_serializer = WrapperConfig._instance.SERIALIZER;
		}
		
		public async Task<Corporation> GetCorporationAsync(int corporationId, string datasource = "tranquilty")
		{
			HttpResponseMessage message = await _client.GetAsync($"{corporationId}?datasource={datasource}");
			Corporation ret = _serializer.Deserialize<Corporation>(new JsonTextReader(new StreamReader(await message.Content.ReadAsStreamAsync())));
			return ret;
		}
		
		public async Task<AllianceHistoryEntry[]> GetAllianceHistoryAsync(int corporationId, string datasource = "tranquilty")
		{
			HttpResponseMessage message = await _client.GetAsync($"{corporationId}/alliancehistory?datasource={datasource}");
			AllianceHistoryEntry[] ret = _serializer.Deserialize<AllianceHistoryEntry[]>(new JsonTextReader(new StreamReader(await message.Content.ReadAsStreamAsync())));
			return ret;
		}
		
		public async Task<Blueprint[]> GetBlueprintsAsync(int corporationId, int page = 1, string datasource = "tranquilty")
		{
			Blueprint[] ret;
			if (_client.DefaultRequestHeaders.Any(e => e.Key == "authorization" & e.Value.Any(f => !string.IsNullOrWhiteSpace(f))))
			{
				HttpResponseMessage message = await _client.GetAsync($"corporations/{corporationId}/blueprints?datasource={datasource}&page={page}");
				ret = _serializer.Deserialize<Blueprint[]>(new JsonTextReader(new StreamReader(await message.Content.ReadAsStreamAsync())));
			}
			else
			{
				throw new Exception("No Authorization Token, this endpoint will fail.");
			}
			return ret;
		}
		
		public async Task<ContainerLogEntry[]> GetContainerLogsAsync(int corporationId, int page = 1, string datasource = "tranquilty")
		{
			ContainerLogEntry[] ret;
			if (_client.DefaultRequestHeaders.Any(e => e.Key == "authorization" & e.Value.Any(f => !string.IsNullOrWhiteSpace(f))))
			{
				HttpResponseMessage message = await _client.GetAsync($"corporations/{corporationId}/containers/logs?datasource={datasource}&page={page}");
				ret = _serializer.Deserialize<ContainerLogEntry[]>(new JsonTextReader(new StreamReader(await message.Content.ReadAsStreamAsync())));
			}
			else
			{
				throw new Exception("No Authorization Token, this endpoint will fail.");
			}
			return ret;
		}
		
		/// <summary>
		/// Gets the hangar and wallet divisions of a corporation
		/// </summary>
		/// <param name="corporationId">The id of the corporation to get the divisions of</param>
		/// <param name="datasource">The EVE Online shard to probe</param>
		/// <returns>(Hangar Divisions, Wallet Divisions)</returns>
		public async Task<(CorporationDivision[], CorporationDivision[])> GetDivisionsAsync(int corporationId, string datasource = "tranquilty")
		{
			(CorporationDivision[], CorporationDivision[]) ret;
			if (_client.DefaultRequestHeaders.Any(e => e.Key == "authorization" & e.Value.Any(f => !string.IsNullOrWhiteSpace(f))))
			{
				HttpResponseMessage message = await _client.GetAsync($"corporations/{corporationId}/containers/logs?datasource={datasource}");
				JObject obj = JObject.Parse(await message.Content.ReadAsStringAsync());
				ret = (
					obj.SelectToken("hangar")?.Value<CorporationDivision[]>(),
					obj.SelectToken("wallet")?.Value<CorporationDivision[]>()
					);
			}
			else
			{
				throw new Exception("No Authorization Token, this endpoint will fail.");
			}
			return ret;
		}
		
		public async Task<Facility[]> GetFacilitiesAsync(int corporationId, string datasource = "tranquilty")
		{
			Facility[] ret;
			if (_client.DefaultRequestHeaders.Any(e => e.Key == "authorization" & e.Value.Any(f => !string.IsNullOrWhiteSpace(f))))
			{
				HttpResponseMessage message = await _client.GetAsync($"corporations/{corporationId}/facilities?datasource={datasource}");
				ret = _serializer.Deserialize<Facility[]>(new JsonTextReader(new StreamReader(await message.Content.ReadAsStreamAsync())));
			}
			else
			{
				throw new Exception("No Authorization Token, this endpoint will fail.");
			}
			return ret;
		}
		
		public async Task<Icon> GetIconsAsync(int corporationId, string datasource = "tranquilty")
		{
			HttpResponseMessage message = await _client.GetAsync($"{corporationId}/icons?datasource={datasource}");
			Icon ret = _serializer.Deserialize<Icon>(new JsonTextReader(new StreamReader(await message.Content.ReadAsStreamAsync())));
			return ret;
		}
		
		public async Task<Medal[]> GetMedalsAsync(int corporationId, int page = 1, string datasource = "tranquilty")
		{
			Medal[] ret;
			if (_client.DefaultRequestHeaders.Any(e => e.Key == "authorization" & e.Value.Any(f => !string.IsNullOrWhiteSpace(f))))
			{
				HttpResponseMessage message = await _client.GetAsync($"corporations/{corporationId}/medals?datasource={datasource}&page={page}");
				ret = _serializer.Deserialize<Medal[]>(new JsonTextReader(new StreamReader(await message.Content.ReadAsStreamAsync())));
			}
			else
			{
				throw new Exception("No Authorization Token, this endpoint will fail.");
			}
			return ret;
		}
		
		public async Task<IssuedMedal[]> GetIssuedMedalsAsync(int corporationId, int page = 1, string datasource = "tranquilty")
		{
			IssuedMedal[] ret;
			if (_client.DefaultRequestHeaders.Any(e => e.Key == "authorization" & e.Value.Any(f => !string.IsNullOrWhiteSpace(f))))
			{
				HttpResponseMessage message = await _client.GetAsync($"corporations/{corporationId}/medals/issued?datasource={datasource}&page={page}");
				ret = _serializer.Deserialize<IssuedMedal[]>(new JsonTextReader(new StreamReader(await message.Content.ReadAsStreamAsync())));
			}
			else
			{
				throw new Exception("No Authorization Token, this endpoint will fail.");
			}
			return ret;
		}
		
		public async Task<int[]> GetMembersAsync(int corporationId, string datasource = "tranquilty")
		{
			int[] ret;
			if (_client.DefaultRequestHeaders.Any(e => e.Key == "authorization" & e.Value.Any(f => !string.IsNullOrWhiteSpace(f))))
			{
				HttpResponseMessage message = await _client.GetAsync($"corporations/{corporationId}/members?datasource={datasource}");
				ret = _serializer.Deserialize<int[]>(new JsonTextReader(new StreamReader(await message.Content.ReadAsStreamAsync())));
			}
			else
			{
				throw new Exception("No Authorization Token, this endpoint will fail.");
			}
			return ret;
		}
		
		public async Task<int> GetMemberLimitAsync(int corporationId, string datasource = "tranquilty")
		{
			int ret;
			if (_client.DefaultRequestHeaders.Any(e => e.Key == "authorization" & e.Value.Any(f => !string.IsNullOrWhiteSpace(f))))
			{
				HttpResponseMessage message = await _client.GetAsync($"corporations/{corporationId}/members/limit?datasource={datasource}");
				ret = _serializer.Deserialize<int>(new JsonTextReader(new StreamReader(await message.Content.ReadAsStreamAsync())));
			}
			else
			{
				throw new Exception("No Authorization Token, this endpoint will fail.");
			}
			return ret;
		}
		
		public async Task<IssuedTitle[]> GetIssuedTitlesAsync(int corporationId, string datasource = "tranquilty")
		{
			IssuedTitle[] ret;
			if (_client.DefaultRequestHeaders.Any(e => e.Key == "authorization" & e.Value.Any(f => !string.IsNullOrWhiteSpace(f))))
			{
				HttpResponseMessage message = await _client.GetAsync($"corporations/{corporationId}/members/titles?datasource={datasource}");
				ret = _serializer.Deserialize<IssuedTitle[]>(new JsonTextReader(new StreamReader(await message.Content.ReadAsStreamAsync())));
			}
			else
			{
				throw new Exception("No Authorization Token, this endpoint will fail.");
			}
			return ret;
		}
		
		public async Task<MemberTrackingEntry[]> GetLastKnownMemberStatesAsync(int corporationId, string datasource = "tranquilty")
		{
			MemberTrackingEntry[] ret;
			if (_client.DefaultRequestHeaders.Any(e => e.Key == "authorization" & e.Value.Any(f => !string.IsNullOrWhiteSpace(f))))
			{
				HttpResponseMessage message = await _client.GetAsync($"corporations/{corporationId}/memberstracking?datasource={datasource}");
				ret = _serializer.Deserialize<MemberTrackingEntry[]>(new JsonTextReader(new StreamReader(await message.Content.ReadAsStreamAsync())));
			}
			else
			{
				throw new Exception("No Authorization Token, this endpoint will fail.");
			}
			return ret;
		}
		
		public async Task<CorporationRole[]> GetIssuedRolesAsync(int corporationId, string datasource = "tranquilty")
		{
			CorporationRole[] ret;
			if (_client.DefaultRequestHeaders.Any(e => e.Key == "authorization" & e.Value.Any(f => !string.IsNullOrWhiteSpace(f))))
			{
				HttpResponseMessage message = await _client.GetAsync($"corporations/{corporationId}/roles?datasource={datasource}");
				ret = _serializer.Deserialize<CorporationRole[]>(new JsonTextReader(new StreamReader(await message.Content.ReadAsStreamAsync())));
			}
			else
			{
				throw new Exception("No Authorization Token, this endpoint will fail.");
			}
			return ret;
		}
		
		public async Task<CharacterRolesHistory[]> GetCorporationRoleHistoryAsync(int corporationId, int page = 1, string datasource = "tranquilty")
		{
			CharacterRolesHistory[] ret;
			if (_client.DefaultRequestHeaders.Any(e => e.Key == "authorization" & e.Value.Any(f => !string.IsNullOrWhiteSpace(f))))
			{
				HttpResponseMessage message = await _client.GetAsync($"corporations/{corporationId}/roles/history?datasource={datasource}&page={page}");
				ret = _serializer.Deserialize<CharacterRolesHistory[]>(new JsonTextReader(new StreamReader(await message.Content.ReadAsStreamAsync())));
			}
			else
			{
				throw new Exception("No Authorization Token, this endpoint will fail.");
			}
			return ret;
		}
		
		public async Task<Shareholder[]> GetShareholdersAsync(int corporationId, int page = 1, string datasource = "tranquilty")
		{
			Shareholder[] ret;
			if (_client.DefaultRequestHeaders.Any(e => e.Key == "authorization" & e.Value.Any(f => !string.IsNullOrWhiteSpace(f))))
			{
				HttpResponseMessage message = await _client.GetAsync($"corporations/{corporationId}/shareholders?datasource={datasource}&page={page}");
				ret = _serializer.Deserialize<Shareholder[]>(new JsonTextReader(new StreamReader(await message.Content.ReadAsStreamAsync())));
			}
			else
			{
				throw new Exception("No Authorization Token, this endpoint will fail.");
			}
			return ret;
		}
		
		public async Task<StandingEntry[]> GetStandingsAsync(int corporationId, int page = 1, string datasource = "tranquilty")
		{
			StandingEntry[] ret;
			if (_client.DefaultRequestHeaders.Any(e => e.Key == "authorization" & e.Value.Any(f => !string.IsNullOrWhiteSpace(f))))
			{
				HttpResponseMessage message = await _client.GetAsync($"corporations/{corporationId}/standings?datasource={datasource}&page={page}");
				ret = _serializer.Deserialize<StandingEntry[]>(new JsonTextReader(new StreamReader(await message.Content.ReadAsStreamAsync())));
			}
			else
			{
				throw new Exception("No Authorization Token, this endpoint will fail.");
			}
			return ret;
		}
		
		public async Task<Starbase[]> GetStarbasesAsync(int corporationId, int page = 1, string datasource = "tranquilty")
		{
			Starbase[] ret;
			if (_client.DefaultRequestHeaders.Any(e => e.Key == "authorization" & e.Value.Any(f => !string.IsNullOrWhiteSpace(f))))
			{
				HttpResponseMessage message = await _client.GetAsync($"corporations/{corporationId}/starbases?datasource={datasource}&page={page}");
				ret = _serializer.Deserialize<Starbase[]>(new JsonTextReader(new StreamReader(await message.Content.ReadAsStreamAsync())));
			}
			else
			{
				throw new Exception("No Authorization Token, this endpoint will fail.");
			}
			return ret;
		}
		
		public async Task<StarbaseDetails> GetStarbaseDetailsAsync(int corporationId, int starbaseId, string datasource = "tranquilty")
		{
			StarbaseDetails ret;
			if (_client.DefaultRequestHeaders.Any(e => e.Key == "authorization" & e.Value.Any(f => !string.IsNullOrWhiteSpace(f))))
			{
				HttpResponseMessage message = await _client.GetAsync($"corporations/{corporationId}/starbases/{starbaseId}?datasource={datasource}");
				ret = _serializer.Deserialize<StarbaseDetails>(new JsonTextReader(new StreamReader(await message.Content.ReadAsStreamAsync())));
			}
			else
			{
				throw new Exception("No Authorization Token, this endpoint will fail.");
			}
			return ret;
		}
		
		public async Task<Structure[]> GetStructuresAsync(int corporationId, int page = 1, string datasource = "tranquilty")
		{
			Structure[] ret;
			if (_client.DefaultRequestHeaders.Any(e => e.Key == "authorization" & e.Value.Any(f => !string.IsNullOrWhiteSpace(f))))
			{
				HttpResponseMessage message = await _client.GetAsync($"corporations/{corporationId}/structures?datasource={datasource}&page={page}");
				ret = _serializer.Deserialize<Structure[]>(new JsonTextReader(new StreamReader(await message.Content.ReadAsStreamAsync())));
			}
			else
			{
				throw new Exception("No Authorization Token, this endpoint will fail.");
			}
			return ret;
		}
		
		public async Task<Title[]> GetTitlesAsync(int corporationId, int page = 1, string datasource = "tranquilty")
		{
			Title[] ret;
			if (_client.DefaultRequestHeaders.Any(e => e.Key == "authorization" & e.Value.Any(f => !string.IsNullOrWhiteSpace(f))))
			{
				HttpResponseMessage message = await _client.GetAsync($"corporations/{corporationId}/titles?datasource={datasource}&page={page}");
				ret = _serializer.Deserialize<Title[]>(new JsonTextReader(new StreamReader(await message.Content.ReadAsStreamAsync())));
			}
			else
			{
				throw new Exception("No Authorization Token, this endpoint will fail.");
			}
			return ret;
		}
		
		public async Task<int[]> GetNPCCorpsAsync(string datasource = "tranquilty")
		{
			HttpResponseMessage message = await _client.GetAsync($"npccorps?datasource={datasource}");
			int[] ret = _serializer.Deserialize<int[]>(new JsonTextReader(new StreamReader(await message.Content.ReadAsStreamAsync())));
			return ret;
		}
	}
}