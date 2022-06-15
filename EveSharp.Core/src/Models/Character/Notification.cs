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
	
	public struct SoANotification
	{
		public readonly bool?[] isReads;
		public readonly long[] notificationIds;
		public readonly int[] senderIds;
		public readonly ContactType[] senderTypes;
		public readonly string[] texts;
		public readonly DateTime[] timestamps;
		public readonly NotificationType[] types;
		
		public SoANotification(params Notification[] notifications)
		{
			int count = notifications.Length;
			isReads = new bool?[count];
			notificationIds = new long[count];
			senderIds = new int[count];
			senderTypes = new ContactType[count];
			texts = new string[count];
			timestamps = new DateTime[count];
			types = new NotificationType[count];
			
			for (int i = 0; i < count; i++)
			{
				isReads[i] = notifications[i].isRead;
				notificationIds[i] = notifications[i].notificationId;
				senderIds[i] = notifications[i].senderId;
				senderTypes[i] = notifications[i].senderType;
				texts[i] = notifications[i].text;
				timestamps[i] = notifications[i].timestamp;
				types[i] = notifications[i].type;
			}
		}
	}
}