namespace EveSharp.Core.Models.Character
{
	public struct CorpHistoryEntry
	{
		public int corporationId;
		public bool? isDeleted;
		public int recordId;
		public DateTime startDate;
	}
	
	public struct SoACorpHistoryEntry
	{
		public readonly int[] corporationIds;
		public readonly bool?[] isDeleteds;
		public readonly int[] recordIds;
		public readonly DateTime[] startDates;
		
		public SoACorpHistoryEntry(params CorpHistoryEntry[] corpHistoryEntries)
		{
			int count = corpHistoryEntries.Length;
			corporationIds = new int[count];
			isDeleteds = new bool?[count];
			recordIds = new int[count];
			startDates = new DateTime[count];
			
			for (int i = 0; i < count; i++)
			{
				corporationIds[i] = corpHistoryEntries[i].corporationId;
				isDeleteds[i] = corpHistoryEntries[i].isDeleted;
				recordIds[i] = corpHistoryEntries[i].recordId;
				startDates[i] = corpHistoryEntries[i].startDate;
			}
		}
	}
}