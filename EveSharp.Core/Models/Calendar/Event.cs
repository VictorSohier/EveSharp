using EveSharp.Core.Enums.Calendar;

namespace EveSharp.Core.Models.Calendar
{
	public struct Event
	{
		public DateTime eventDate;
		public int? eventId;
		public Response eventResponse;
		public int? importance;
		public string title;
	}
}