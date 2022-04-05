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
}