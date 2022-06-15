using System.Text;
using EveSharp.Core.Models.Fleets;
using EveSharp.Infrastructure.Enums;
using EveSharp.Infrastructure.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace EveSharp.Infrastructure.Models.Wrappers
{
	public class FleetWrapper
	{
		private readonly HttpClient _client;
		private readonly JsonSerializer _serializer;
		
		public FleetWrapper()
		{
			_client = new();
			_client.BaseAddress = new($"{WrapperConfig._instance.DOMAIN}/{WrapperConfig._instance.API_VERSION}");
			_serializer = WrapperConfig._instance.SERIALIZER;
		}
		
		public async Task<Fleet> GetCurrentFleetAsync(OAuth2Token token, int characterId, DataSources datasource = DataSources.tranquility)
		{
			_client.DefaultRequestHeaders.Remove("Authorization");
			_client.DefaultRequestHeaders.Add("Authorization", $"{token.tokenType} {token.accessToken}");
			HttpResponseMessage message = await _client.GetAsync($"characters/{characterId}/fleet?datasource={Enum.GetName(datasource)?.ToLower()}");
			Fleet ret;
			if (WrapperConfig._instance.SUCCESS.Contains(message.StatusCode))
			{
				ret = _serializer.Deserialize<Fleet>(new JsonTextReader(new StreamReader(await message.Content.ReadAsStreamAsync())));
				return ret;
			}
			throw new Exception(_serializer.Deserialize<Error>(new JsonTextReader(new StreamReader(await message.Content.ReadAsStreamAsync()))).error);
		}
		
		public async Task<FleetDetails> GetFleetAsync(OAuth2Token token, long fleetId, DataSources datasource = DataSources.tranquility)
		{
			_client.DefaultRequestHeaders.Remove("Authorization");
			_client.DefaultRequestHeaders.Add("Authorization", $"{token.tokenType} {token.accessToken}");
			HttpResponseMessage message = await _client.GetAsync($"fleets/{fleetId}?datasource={Enum.GetName(datasource)?.ToLower()}");
			FleetDetails ret;
			if (WrapperConfig._instance.SUCCESS.Contains(message.StatusCode))
			{
				ret = _serializer.Deserialize<FleetDetails>(new JsonTextReader(new StreamReader(await message.Content.ReadAsStreamAsync())));
				return ret;
			}
			throw new Exception(_serializer.Deserialize<Error>(new JsonTextReader(new StreamReader(await message.Content.ReadAsStreamAsync()))).error);
		}
		
		public async Task PutFleetUpdateAsync(OAuth2Token token, long fleetId, FleetUpdate fleetSettings, DataSources datasource = DataSources.tranquility)
		{
			_client.DefaultRequestHeaders.Remove("Authorization");
			_client.DefaultRequestHeaders.Add("Authorization", $"{token.tokenType} {token.accessToken}");
			StringWriter sw = new();
			_serializer.Serialize(sw, fleetSettings);
			await _client.PutAsync($"/fleets/{fleetId}?datasource={Enum.GetName(datasource)?.ToLower()}", new StringContent(sw.ToString(), Encoding.UTF8, "application/json"));
		}
		
		public async Task<FleetMember[]> GetFleetMembersAsync(OAuth2Token token, long fleetId, DataSources datasource = DataSources.tranquility)
		{
			_client.DefaultRequestHeaders.Remove("Authorization");
			_client.DefaultRequestHeaders.Add("Authorization", $"{token.tokenType} {token.accessToken}");
			HttpResponseMessage message = await _client.GetAsync($"fleets/{fleetId}/members?datasource={Enum.GetName(datasource)?.ToLower()}");
			FleetMember[] ret;
			if (WrapperConfig._instance.SUCCESS.Contains(message.StatusCode))
			{
				ret = _serializer.Deserialize<FleetMember[]>(new JsonTextReader(new StreamReader(await message.Content.ReadAsStreamAsync())));
				return ret;
			}
			throw new Exception(_serializer.Deserialize<Error>(new JsonTextReader(new StreamReader(await message.Content.ReadAsStreamAsync()))).error);
		}
		
		public async Task RemoveFleetMemberAsync(OAuth2Token token, long fleetId, int characterId, DataSources datasource = DataSources.tranquility)
		{
			_client.DefaultRequestHeaders.Remove("Authorization");
			_client.DefaultRequestHeaders.Add("Authorization", $"{token.tokenType} {token.accessToken}");
			await _client.DeleteAsync($"/fleets/{fleetId}/members/{characterId}?datasource={Enum.GetName(datasource)?.ToLower()}");
		}
		
		public async Task MoveFleetMemberAsync(OAuth2Token token, long fleetId, int characterId, FleetMemberUpdate fleetMemberUpdate, DataSources datasource = DataSources.tranquility)
		{
			_client.DefaultRequestHeaders.Remove("Authorization");
			_client.DefaultRequestHeaders.Add("Authorization", $"{token.tokenType} {token.accessToken}");
			StringWriter sw = new();
			_serializer.Serialize(sw, fleetMemberUpdate);
			await _client.PutAsync($"/fleets/{fleetId}/members/{characterId}?datasource={Enum.GetName(datasource)?.ToLower()}", new StringContent(sw.ToString(), Encoding.UTF8, "application/json"));
		}
		
		public async Task RemoveSquadAsync(OAuth2Token token, long fleetId, long squadId, DataSources datasource = DataSources.tranquility)
		{
			_client.DefaultRequestHeaders.Remove("Authorization");
			_client.DefaultRequestHeaders.Add("Authorization", $"{token.tokenType} {token.accessToken}");
			await _client.DeleteAsync($"/fleets/{fleetId}/squads/{squadId}?datasource={Enum.GetName(datasource)?.ToLower()}");
		}
		
		public async Task UpdateSquadAsync(OAuth2Token token, long fleetId, long squadId, string name, DataSources datasource = DataSources.tranquility)
		{
			_client.DefaultRequestHeaders.Remove("Authorization");
			_client.DefaultRequestHeaders.Add("Authorization", $"{token.tokenType} {token.accessToken}");
			await _client.PutAsync($"/fleets/{fleetId}/squads/{squadId}?datasource={Enum.GetName(datasource)?.ToLower()}", new StringContent($"{{ name: {name} }}", Encoding.UTF8, "application/json"));
		}
		
		public async Task<Wing[]> GetWingsAsync(OAuth2Token token, long fleetId, DataSources datasource = DataSources.tranquility)
		{
			_client.DefaultRequestHeaders.Remove("Authorization");
			_client.DefaultRequestHeaders.Add("Authorization", $"{token.tokenType} {token.accessToken}");
			HttpResponseMessage message = await _client.GetAsync($"fleets/{fleetId}/wings?datasource={Enum.GetName(datasource)?.ToLower()}");
			Wing[] ret;
			if (WrapperConfig._instance.SUCCESS.Contains(message.StatusCode))
			{
				ret = _serializer.Deserialize<Wing[]>(new JsonTextReader(new StreamReader(await message.Content.ReadAsStreamAsync())));
				return ret;
			}
			throw new Exception(_serializer.Deserialize<Error>(new JsonTextReader(new StreamReader(await message.Content.ReadAsStreamAsync()))).error);
		}
		
		public async Task<long> CreateNewWingAsync(OAuth2Token token, long fleetId, DataSources datasource = DataSources.tranquility)
		{
			_client.DefaultRequestHeaders.Remove("Authorization");
			_client.DefaultRequestHeaders.Add("Authorization", $"{token.tokenType} {token.accessToken}");
			HttpResponseMessage message = await _client.PostAsync($"fleets/{fleetId}/wings?datasource={Enum.GetName(datasource)?.ToLower()}", null);
			long ret;
			if (WrapperConfig._instance.SUCCESS.Contains(message.StatusCode))
				throw new Exception(_serializer.Deserialize<Error>(new JsonTextReader(new StreamReader(await message.Content.ReadAsStreamAsync()))).error);
			ret = JToken.Parse(await message.Content.ReadAsStringAsync())["wing_id"].Value<long>();
			return ret;
		}
		
		public async Task RemoveWingAsync(OAuth2Token token, long fleetId, long wingId, DataSources datasource = DataSources.tranquility)
		{
			_client.DefaultRequestHeaders.Remove("Authorization");
			_client.DefaultRequestHeaders.Add("Authorization", $"{token.tokenType} {token.accessToken}");
			await _client.DeleteAsync($"/fleets/{fleetId}/wings/{wingId}?datasource={Enum.GetName(datasource)?.ToLower()}");
		}
		
		public async Task UpdateWingAsync(OAuth2Token token, long fleetId, long wingId, string name, DataSources datasource = DataSources.tranquility)
		{
			_client.DefaultRequestHeaders.Remove("Authorization");
			_client.DefaultRequestHeaders.Add("Authorization", $"{token.tokenType} {token.accessToken}");
			await _client.PutAsync($"/fleets/{fleetId}/wings/{wingId}?datasource={Enum.GetName(datasource)?.ToLower()}", new StringContent($"{{ name: {name} }}", Encoding.UTF8, "application/json"));
		}
		
		public async Task<long> CreateNewSquadAsync(OAuth2Token token, long fleetId, long wingId, DataSources datasource = DataSources.tranquility)
		{
			_client.DefaultRequestHeaders.Remove("Authorization");
			_client.DefaultRequestHeaders.Add("Authorization", $"{token.tokenType} {token.accessToken}");
			HttpResponseMessage message = await _client.PostAsync($"fleets/{fleetId}/wings/{wingId}/squads?datasource={Enum.GetName(datasource)?.ToLower()}", null);
			long ret;
			if (WrapperConfig._instance.SUCCESS.Contains(message.StatusCode))
				throw new Exception(_serializer.Deserialize<Error>(new JsonTextReader(new StreamReader(await message.Content.ReadAsStreamAsync()))).error);
			ret = JToken.Parse(await message.Content.ReadAsStringAsync())["squad_id"].Value<long>();
			return ret;
		}
	}
}