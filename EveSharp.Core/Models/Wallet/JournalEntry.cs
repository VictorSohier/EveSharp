using EveSharp.Core.Enums.Wallet;

namespace EveSharp.Core.Models.Wallet
{
	public struct JournalEntry
	{
		public double amount;
		public double balance;
		public long? contextId;
		public Context contextIdType;
		public DateTime date;
		public string description;
		public int? firstPartyId;
		public long id;
		public string reason;
		public RefType refType;
		public int? secondPartyId;
		public double? tax;
		public int? taxReceiverId;
	}
}