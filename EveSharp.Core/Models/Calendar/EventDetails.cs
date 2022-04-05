using EveSharp.Core.Enums.Calendar;

namespace EveSharp.Core.Models.Calendar
{
	public struct EventDetails
	{
		public DateTime date;
		public int duration;
		public int eventId;
		public int importance;
		public int ownerId;
		public string ownerName;
		public EventOwnerType ownerType;
		public string response;
		public string text;
		public string title;
	}
}