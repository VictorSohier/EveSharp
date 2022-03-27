using EveSharp.Core.Enums.Calendar;

namespace EveSharp.Core.Models.Calendar
{
	public struct EventDetails
	{
		public DateTime Date;
		public int Duration;
		public int EventId;
		public int Importance;
		public int OwnerId;
		public string OwnerName;
		public EventOwnerType OwnerType;
		public string Response;
		public string Text;
		public string Title;
	}
}