using EveSharp.Core.Enums.Character;
using EveSharp.Core.Enums.Contacts;

namespace EveSharp.Core.Models.Character
{
	public struct Notification
	{
		public bool? IsRead;
		public long NotificationId;
		public int SenderId;
		public ContactType SenderType;
		public string Text;
		public DateTime Timestamp;
		public NotificationType Type;
	}
}