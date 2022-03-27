using EveSharp.Core.Enums.Calendar;

namespace EveSharp.Core.Models.Calendar
{
	public struct Event
	{
		public DateTime EventDate;
		public int? EventId;
		public Response EventResponse;
		public int? Importance;
		public string Title;
	}
}