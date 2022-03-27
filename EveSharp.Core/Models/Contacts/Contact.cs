using EveSharp.Core.Enums.Contacts;

namespace EveSharp.Core.Models.Contacts
{
	public struct Contact
	{
		public int ContactId;
		public ContactType ContactType;
		public long[] LabelIds;
		public float Standing;
		public bool IsBlocked;
		public bool IsWatched;
	}
}