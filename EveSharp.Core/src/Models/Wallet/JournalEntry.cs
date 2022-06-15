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
	
	public struct SoAJournalEntry
	{
		public readonly double[] amounts;
		public readonly double[] balances;
		public readonly long?[] contextIds;
		public readonly Context[] contextIdTypes;
		public readonly DateTime[] dates;
		public readonly string[] descriptions;
		public readonly int?[] firstPartyIds;
		public readonly long[] ids;
		public readonly string[] reasons;
		public readonly RefType[] refTypes;
		public readonly int?[] secondPartyIds;
		public readonly double?[] taxs;
		public readonly int?[] taxReceiverIds;
		
		public SoAJournalEntry(params JournalEntry[] journalEntries)
		{
			int count = journalEntries.Length;
			amounts = new double[count];
			balances = new double[count];
			contextIds = new long?[count];
			contextIdTypes = new Context[count];
			dates = new DateTime[count];
			descriptions = new string[count];
			firstPartyIds = new int?[count];
			ids = new long[count];
			reasons = new string[count];
			refTypes = new RefType[count];
			secondPartyIds = new int?[count];
			taxs = new double?[count];
			taxReceiverIds = new int?[count];
			
			for (int i = 0; i < count; i++)
			{
				amounts[i] = journalEntries[i].amount;
				balances[i] = journalEntries[i].balance;
				contextIds[i] = journalEntries[i].contextId;
				contextIdTypes[i] = journalEntries[i].contextIdType;
				dates[i] = journalEntries[i].date;
				descriptions[i] = journalEntries[i].description;
				firstPartyIds[i] = journalEntries[i].firstPartyId;
				ids[i] = journalEntries[i].id;
				reasons[i] = journalEntries[i].reason;
				refTypes[i] = journalEntries[i].refType;
				secondPartyIds[i] = journalEntries[i].secondPartyId;
				taxs[i] = journalEntries[i].tax;
				taxReceiverIds[i] = journalEntries[i].taxReceiverId;
			}
		}
	}
}