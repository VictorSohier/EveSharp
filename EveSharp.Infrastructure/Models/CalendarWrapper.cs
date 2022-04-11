using System.Text;
using EveSharp.Core.Enums.Calendar;
using EveSharp.Core.Models.Calendar;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace EveSharp.Infrastructure.Models
{
	public class CalendarWrapper
	{
		private readonly HttpClient _client;
		private readonly JsonSerializer _serializer;
		
		public CalendarWrapper(string authToken)
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
		
		public async Task<Event[]> GetEventsAsync(int characterId, string datasource = "tranquility")
		{
			HttpResponseMessage message = await _client.GetAsync($"{characterId}/calendar?datasource={datasource}");
			Event[] ret = _serializer.Deserialize<Event[]>(new JsonTextReader(new StreamReader(await message.Content.ReadAsStreamAsync())));
			return ret;
		}
		
		public async Task<EventDetails> GetEventDetailsAsync(int characterId, int eventId, string datasource = "tranquility")
		{
			HttpResponseMessage message = await _client.GetAsync($"{characterId}/calendar/{eventId}?datasource={datasource}");
			EventDetails ret = _serializer.Deserialize<EventDetails>(new JsonTextReader(new StreamReader(await message.Content.ReadAsStreamAsync())));
			return ret;
		}
		
		public async Task PutEventResponseAsync(int characterId, int eventId, Response response, string datasource = "tranquility")
		{
			await _client
				.PutAsync(
					$"{characterId}/calendar/{eventId}?datasource={datasource}",
					new StringContent($"{{ \"response\": \"{Enum.GetName(response)?.ToLower()}\" }}",
						encoding: Encoding.UTF8,
						mediaType: "application/json")
				);
		}
		
		public async Task<AttendeeResponse[]> GetEventResponsesAsync(int characterId, int eventId, string datasource = "tranquility")
		{
			HttpResponseMessage message = await _client.GetAsync($"{characterId}/calendar/{eventId}/attendees?datasource={datasource}");
			AttendeeResponse[] ret = _serializer.Deserialize<AttendeeResponse[]>(new JsonTextReader(new StreamReader(await message.Content.ReadAsStreamAsync())));
			return ret;
		}
	}
}