namespace EveSharp.Core.Models.Character
{
	public struct NotificationContact
	{
		public string message;
		public int notificationId;
		public DateTime sendDate;
		public int senderCharacterId;
		public float standingLevel;
	}
	
	public struct SoANotificationContact
	{
		public readonly string[] messages;
		public readonly int[] notificationIds;
		public readonly DateTime[] sendDates;
		public readonly int[] senderCharacterIds;
		public readonly float[] standingLevels;
		
		public SoANotificationContact(params NotificationContact[] notificationContacts)
		{
			int count = notificationContacts.Length;
			messages = new string[count];
			notificationIds = new int[count];
			sendDates = new DateTime[count];
			senderCharacterIds = new int[count];
			standingLevels = new float[count];
			
			for (int i = 0; i < count; i++)
			{
				messages[i] = notificationContacts[i].message;
				notificationIds[i] = notificationContacts[i].notificationId;
				sendDates[i] = notificationContacts[i].sendDate;
				senderCharacterIds[i] = notificationContacts[i].senderCharacterId;
				standingLevels[i] = notificationContacts[i].standingLevel;
			}
		}
	}
}