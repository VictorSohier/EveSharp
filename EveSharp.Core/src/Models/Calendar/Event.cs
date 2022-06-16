using EveSharp.Core.Enums.Calendar;

namespace EveSharp.Core.Models.Calendar
{
	public struct Event
	{
		public DateTime eventDate;
		public int eventId;
		public Response eventResponse;
		public int? importance;
		public string title;
	}
	
	public struct SoAEvent
	{
		public readonly DateTime[] eventDates;
		public readonly int[] eventIds;
		public readonly Response[] eventResponses;
		public readonly int?[] importances;
		public readonly string[] titles;
		
		public SoAEvent(params Event[] events)
		{
			int count = events.Length;
			eventDates = new DateTime[count];
			eventIds = new int[count];
			eventResponses = new Response[count];
			importances = new int?[count];
			titles = new string[count];
			
			for (int i = 0; i < count; i++)
			{
				eventDates[i] = events[i].eventDate;
				eventIds[i] = events[i].eventId;
				eventResponses[i] = events[i].eventResponse;
				importances[i] = events[i].importance;
				titles[i] = events[i].title;
			}
		}
	}
}