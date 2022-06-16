using EveSharp.Core.Models.Calendar;
using EveSharp.Infrastructure.Models;
using EveSharp.Infrastructure.Models.Wrappers;

namespace EveSharp.Test
{
	internal class CalendarWrapperTests
	{
		private OAuth2Token _token;
		private JsonWebKeySet _jwks;
		private readonly int _characterId;
		private readonly CalendarWrapper _wrapper = new();
		
		internal CalendarWrapperTests(ref OAuth2Token token, ref JsonWebKeySet jwks)
		{
			_token = token;
			_jwks = jwks;
			_characterId = int.Parse(jwks.sub.Split(":")[2]);
		}
		
		internal async Task<(int, int, int)> Run()
		{
			int totalTests = 0;
			int passedTests = 0;
			bool getCalendarEventSummaries;
			bool getCalendarEventDetails = false;
			bool getCalendarEventResponses = false;
			totalTests++;
			(getCalendarEventSummaries, Event[] events) = await GetCalendarEventSummaries();
			Console.WriteLine($"Get event summaries: {getCalendarEventSummaries}");
			if (getCalendarEventSummaries)
			{
				passedTests++;
				totalTests++;
				getCalendarEventDetails = await GetCalendarEventDetails(events[0].eventId);
				Console.WriteLine($"Get event details: {getCalendarEventDetails}");
				totalTests++;
				getCalendarEventResponses = await GetCalendarEventResponses(events[0].eventId);
				Console.WriteLine($"Get event responses: {getCalendarEventResponses}");
			}
			if (getCalendarEventDetails) passedTests++;
			if (getCalendarEventResponses) passedTests++;
			return (totalTests, passedTests, totalTests - passedTests);
		}
		
		private async Task<(bool, Event[])> GetCalendarEventSummaries()
		{
			if (_jwks.exp > DateTimeOffset.Now.ToUnixTimeSeconds() + 5)
			{
				_token = await OAuth2Wrapper._instance.NativeTokenRefresh(_token.refreshToken);
				(_jwks, _) = await OAuth2Wrapper._instance.VerifyToken(_token);
			}
			Event[] events = await _wrapper.GetEventsAsync(_token, _characterId);
			return (events.Length > 0, events);
		}
		
		private async Task<bool> GetCalendarEventDetails(int eventId)
		{
			if (_jwks.exp > DateTimeOffset.Now.ToUnixTimeSeconds() + 5)
			{
				_token = await OAuth2Wrapper._instance.NativeTokenRefresh(_token.refreshToken);
				(_jwks, _) = await OAuth2Wrapper._instance.VerifyToken(_token);
			}
			EventDetails eventDetails = await _wrapper.GetEventDetailsAsync(_token, _characterId, eventId);
			return eventDetails.eventId == eventId;
		}
		
		private async Task<bool> GetCalendarEventResponses(int eventId)
		{
			if (_jwks.exp > DateTimeOffset.Now.ToUnixTimeSeconds() + 5)
			{
				_token = await OAuth2Wrapper._instance.NativeTokenRefresh(_token.refreshToken);
				(_jwks, _) = await OAuth2Wrapper._instance.VerifyToken(_token);
			}
			SoAAttendeeResponse attendeeResponses = new(await _wrapper.GetEventResponsesAsync(_token, _characterId, eventId));
			return attendeeResponses.characterIds.Contains(_characterId);
		}
	}
}