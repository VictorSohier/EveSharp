using EveSharp.Core.Enums.Calendar;

namespace EveSharp.Core.Models.Calendar
{
	public struct CalendarEvent
	{
		public DateTime EventDate;
		public int EventId;
		public CalendarResponse EventResponse;
		public int Importance;
		public string Title;
	}
}