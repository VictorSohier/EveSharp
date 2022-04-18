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
		
		public FleetWrapper(string authToken)
		{
			_client = new();
			_client.BaseAddress = new($"https://esi.evetech.net/{WrapperConfig._instance.API_VERSION}");
			_client.DefaultRequestHeaders.Add("authorization", authToken);
			_serializer = WrapperConfig._instance.SERIALIZER;
		}
		
		public async Task<Fleet> GetCurrentFleetAsync(int characterId, DataSources datasource = DataSources.TRANQUILITY)
		{
			HttpResponseMessage message = await _client.GetAsync($"characters/{characterId}/fleet?datasource={Enum.GetName<DataSources>(datasource)?.ToLower()}");
			Fleet ret;
			if (WrapperConfig._instance.SUCCESS.Contains(message.StatusCode))
				throw new Exception(_serializer.Deserialize<Error>(new JsonTextReader(new StreamReader(await message.Content.ReadAsStreamAsync()))).error);
			ret = _serializer.Deserialize<Fleet>(new JsonTextReader(new StreamReader(await message.Content.ReadAsStreamAsync())));
			return ret;
		}
		
		public async Task<FleetDetails> GetFleetAsync(long fleetId, DataSources datasource = DataSources.TRANQUILITY)
		{
			HttpResponseMessage message = await _client.GetAsync($"fleets/{fleetId}?datasource={Enum.GetName<DataSources>(datasource)?.ToLower()}");
			FleetDetails ret;
			if (WrapperConfig._instance.SUCCESS.Contains(message.StatusCode))
				throw new Exception(_serializer.Deserialize<Error>(new JsonTextReader(new StreamReader(await message.Content.ReadAsStreamAsync()))).error);
			ret = _serializer.Deserialize<FleetDetails>(new JsonTextReader(new StreamReader(await message.Content.ReadAsStreamAsync())));
			return ret;
		}
		
		public async Task PutFleetUpdateAsync(long fleetId, FleetUpdate fleetSettings, DataSources datasource = DataSources.TRANQUILITY)
		{
			StringWriter sw = new();
			_serializer.Serialize(sw, fleetSettings);
			await _client.PutAsync($"/fleets/{fleetId}?datasource={Enum.GetName<DataSources>(datasource)?.ToLower()}", new StringContent(sw.ToString(), Encoding.UTF8, "application/json"));
		}
		
		public async Task<FleetMember[]> GetFleetMembersAsync(long fleetId, DataSources datasource = DataSources.TRANQUILITY)
		{
			HttpResponseMessage message = await _client.GetAsync($"fleets/{fleetId}/members?datasource={Enum.GetName<DataSources>(datasource)?.ToLower()}");
			FleetMember[] ret;
			if (WrapperConfig._instance.SUCCESS.Contains(message.StatusCode))
				throw new Exception(_serializer.Deserialize<Error>(new JsonTextReader(new StreamReader(await message.Content.ReadAsStreamAsync()))).error);
			ret = _serializer.Deserialize<FleetMember[]>(new JsonTextReader(new StreamReader(await message.Content.ReadAsStreamAsync())));
			return ret;
		}
		
		public async Task RemoveFleetMemberAsync(long fleetId, int characterId, DataSources datasource = DataSources.TRANQUILITY)
		{
			await _client.DeleteAsync($"/fleets/{fleetId}/members/{characterId}?datasource={Enum.GetName<DataSources>(datasource)?.ToLower()}");
		}
		
		public async Task MoveFleetMemberAsync(long fleetId, int characterId, FleetMemberUpdate fleetMemberUpdate, DataSources datasource = DataSources.TRANQUILITY)
		{
			StringWriter sw = new();
			_serializer.Serialize(sw, fleetMemberUpdate);
			await _client.PutAsync($"/fleets/{fleetId}/members/{characterId}?datasource={Enum.GetName<DataSources>(datasource)?.ToLower()}", new StringContent(sw.ToString(), Encoding.UTF8, "application/json"));
		}
		
		public async Task RemoveSquadAsync(long fleetId, long squadId, DataSources datasource = DataSources.TRANQUILITY)
		{
			await _client.DeleteAsync($"/fleets/{fleetId}/squads/{squadId}?datasource={Enum.GetName<DataSources>(datasource)?.ToLower()}");
		}
		
		public async Task UpdateSquadAsync(long fleetId, long squadId, string name, DataSources datasource = DataSources.TRANQUILITY)
		{
			await _client.PutAsync($"/fleets/{fleetId}/squads/{squadId}?datasource={Enum.GetName<DataSources>(datasource)?.ToLower()}", new StringContent($"{{ name: {name} }}", Encoding.UTF8, "application/json"));
		}
		
		public async Task<Wing[]> GetWingsAsync(long fleetId, DataSources datasource = DataSources.TRANQUILITY)
		{
			HttpResponseMessage message = await _client.GetAsync($"fleets/{fleetId}/wings?datasource={Enum.GetName<DataSources>(datasource)?.ToLower()}");
			Wing[] ret;
			if (WrapperConfig._instance.SUCCESS.Contains(message.StatusCode))
				throw new Exception(_serializer.Deserialize<Error>(new JsonTextReader(new StreamReader(await message.Content.ReadAsStreamAsync()))).error);
			ret = _serializer.Deserialize<Wing[]>(new JsonTextReader(new StreamReader(await message.Content.ReadAsStreamAsync())));
			return ret;
		}
		
		public async Task<long> CreateNewWingAsync(long fleetId, DataSources datasource = DataSources.TRANQUILITY)
		{
			HttpResponseMessage message = await _client.PostAsync($"fleets/{fleetId}/wings?datasource={Enum.GetName<DataSources>(datasource)?.ToLower()}", null);
			long ret;
			if (WrapperConfig._instance.SUCCESS.Contains(message.StatusCode))
				throw new Exception(_serializer.Deserialize<Error>(new JsonTextReader(new StreamReader(await message.Content.ReadAsStreamAsync()))).error);
			ret = JToken.Parse(await message.Content.ReadAsStringAsync())["wing_id"].Value<long>();
			return ret;
		}
		
		public async Task RemoveWingAsync(long fleetId, long wingId, DataSources datasource = DataSources.TRANQUILITY)
		{
			await _client.DeleteAsync($"/fleets/{fleetId}/wings/{wingId}?datasource={Enum.GetName<DataSources>(datasource)?.ToLower()}");
		}
		
		public async Task UpdateWingAsync(long fleetId, long wingId, string name, DataSources datasource = DataSources.TRANQUILITY)
		{
			await _client.PutAsync($"/fleets/{fleetId}/wings/{wingId}?datasource={Enum.GetName<DataSources>(datasource)?.ToLower()}", new StringContent($"{{ name: {name} }}", Encoding.UTF8, "application/json"));
		}
		
		public async Task<long> CreateNewSquadAsync(long fleetId, long wingId, DataSources datasource = DataSources.TRANQUILITY)
		{
			HttpResponseMessage message = await _client.PostAsync($"fleets/{fleetId}/wings/{wingId}/squads?datasource={Enum.GetName<DataSources>(datasource)?.ToLower()}", null);
			long ret;
			if (WrapperConfig._instance.SUCCESS.Contains(message.StatusCode))
				throw new Exception(_serializer.Deserialize<Error>(new JsonTextReader(new StreamReader(await message.Content.ReadAsStreamAsync()))).error);
			ret = JToken.Parse(await message.Content.ReadAsStringAsync())["squad_id"].Value<long>();
			return ret;
		}
	}
}