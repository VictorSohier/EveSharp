using EveSharp.Core.Enums.Calendar;

namespace EveSharp.Core.Models.Calendar
{
	public struct CalendarEventDetails
	{
		public DateTime Date;
		public int Duration;
		public int EventId;
		public int Importance;
		public int OwnerId;
		public string OwnerName;
		public CalendarEventOwnerType OwnerType;
		public string Response;
		public string Text;
		public string Title;
	}
}