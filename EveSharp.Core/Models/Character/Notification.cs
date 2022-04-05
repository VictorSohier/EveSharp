using EveSharp.Core.Enums.Character;
using EveSharp.Core.Enums.Contacts;

namespace EveSharp.Core.Models.Character
{
	public struct Notification
	{
		public bool? isRead;
		public long notificationId;
		public int senderId;
		public ContactType senderType;
		public string text;
		public DateTime timestamp;
		public NotificationType type;
	}
}