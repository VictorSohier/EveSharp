using System.Text;
using EveSharp.Core.Enums.Calendar;
using EveSharp.Core.Models.Calendar;
using EveSharp.Infrastructure.Enums;
using Newtonsoft.Json;

namespace EveSharp.Infrastructure.Models.Wrappers
{
	public class CalendarWrapper
	{
		private readonly HttpClient _client;
		private readonly JsonSerializer _serializer;
		
		public CalendarWrapper(string authToken)
		{
			_client = new();
			_client.BaseAddress = new($"{WrapperConfig._instance.DOMAIN}/{WrapperConfig._instance.API_VERSION}/characters");
			_client.DefaultRequestHeaders.Add("authorization", authToken);
			_serializer = WrapperConfig._instance.SERIALIZER;
		}
		
		public async Task<Event[]> GetEventsAsync(int characterId, DataSources datasource = DataSources.TRANQUILITY)
		{
			HttpResponseMessage message = await _client.GetAsync($"{characterId}/calendar?datasource={Enum.GetName<DataSources>(datasource)?.ToLower()}");
			Event[] ret;
			if (WrapperConfig._instance.SUCCESS.Contains(message.StatusCode))
				throw new Exception(_serializer.Deserialize<Error>(new JsonTextReader(new StreamReader(await message.Content.ReadAsStreamAsync()))).error);
			ret = _serializer.Deserialize<Event[]>(new JsonTextReader(new StreamReader(await message.Content.ReadAsStreamAsync())));
			return ret;
		}
		
		public async Task<EventDetails> GetEventDetailsAsync(int characterId, int eventId, DataSources datasource = DataSources.TRANQUILITY)
		{
			HttpResponseMessage message = await _client.GetAsync($"{characterId}/calendar/{eventId}?datasource={Enum.GetName<DataSources>(datasource)?.ToLower()}");
			EventDetails ret;
			if (WrapperConfig._instance.SUCCESS.Contains(message.StatusCode))
				throw new Exception(_serializer.Deserialize<Error>(new JsonTextReader(new StreamReader(await message.Content.ReadAsStreamAsync()))).error);
			ret = _serializer.Deserialize<EventDetails>(new JsonTextReader(new StreamReader(await message.Content.ReadAsStreamAsync())));
			return ret;
		}
		
		public async Task PutEventResponseAsync(int characterId, int eventId, Response response, DataSources datasource = DataSources.TRANQUILITY)
		{
			await _client
				.PutAsync(
					$"{characterId}/calendar/{eventId}?datasource={Enum.GetName<DataSources>(datasource)?.ToLower()}",
					new StringContent($"{{ \"response\": \"{Enum.GetName(response)?.ToLower()}\" }}",
						encoding: Encoding.UTF8,
						mediaType: "application/json")
				);
		}
		
		public async Task<AttendeeResponse[]> GetEventResponsesAsync(int characterId, int eventId, DataSources datasource = DataSources.TRANQUILITY)
		{
			HttpResponseMessage message = await _client.GetAsync($"{characterId}/calendar/{eventId}/attendees?datasource={Enum.GetName<DataSources>(datasource)?.ToLower()}");
			AttendeeResponse[] ret;
			if (WrapperConfig._instance.SUCCESS.Contains(message.StatusCode))
				throw new Exception(_serializer.Deserialize<Error>(new JsonTextReader(new StreamReader(await message.Content.ReadAsStreamAsync()))).error);
			ret = _serializer.Deserialize<AttendeeResponse[]>(new JsonTextReader(new StreamReader(await message.Content.ReadAsStreamAsync())));
			return ret;
		}
	}
}