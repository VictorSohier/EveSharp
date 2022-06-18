using EveSharp.Core.Enums.Contacts;
using Newtonsoft.Json;

namespace EveSharp.Core.Models.Contacts
{
	public struct Contact
	{
		public int contactId;
		public ContactType contactType;
		public long[] labelIds = new long[0];
		public float standing;
		public bool? isBlocked;
		public bool? isWatched;
		
		public Contact()
		{
			contactId = 0;
			contactType = ContactType.other;
			labelIds = new long[0];
			standing = 0;
			isBlocked = false;
			isWatched = false;
		}
		
		[JsonConstructor]
		public Contact(
			int contactId,
			ContactType contactType,
			long[] labelIds,
			float standing,
			bool? isBlocked,
			bool? isWatched
		)
		{
			this.contactId = contactId;
			this.contactType = contactType;
			this.labelIds = labelIds ?? new long[0];
			this.standing = standing;
			this.isBlocked = isBlocked;
			this.isWatched = isWatched;
		}
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
				Array.Copy(contacts[i].labelIds, labelIds[i], labelIdsLength);
			}
		}
	}
}