using EveSharp.Core.Enums;
using EveSharp.Core.Enums.Character;

namespace EveSharp.Core.Models.Character
{
	public struct Notification
	{
		public bool IsRead;
		public long NotificationId;
		public int SenderId;
		public SenderType SenderType;
		public string Text;
		public DateTime Timestamp;
		public NotificationType Type;
	}
}