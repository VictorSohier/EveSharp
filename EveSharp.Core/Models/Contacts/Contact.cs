using EveSharp.Core.Enums.Contacts;

namespace EveSharp.Core.Models.Contacts
{
	public struct Contact
	{
		public int contactId;
		public ContactType contactType;
		public long[] labelIds;
		public float standing;
		public bool? isBlocked;
		public bool? isWatched;
	}
	
	public struct SoAContact
	{
		public readonly int[] contactIds;
		public readonly ContactType[] contactTypes;
		public readonly long[][] labelIds;
		public readonly float[] standings;
		public readonly bool?[] isBlockeds;
		public readonly bool?[] isWatcheds;
		
		public SoAContact(params Contact[] contacts)
		{
			int count = contacts.Length;
			contactIds = new int[count];
			contactTypes = new ContactType[count];
			labelIds = new long[count][];
			standings = new float[count];
			isBlockeds = new bool?[count];
			isWatcheds = new bool?[count];
			
			for (int i = 0; i < count; i++)
			{
				int labelIdsLength = contacts[i].labelIds.Length;
				contactIds[i] = contacts[i].contactId;
				contactTypes[i] = contacts[i].contactType;
				labelIds[i] = new long[labelIdsLength];
				standings[i] = contacts[i].standing;
				isBlockeds[i] = contacts[i].isBlocked;
				isWatcheds[i] = contacts[i].isWatched;
				Array.Copy(contacts[i].labelIds, labelIds, labelIdsLength);
			}
		}
	}
}