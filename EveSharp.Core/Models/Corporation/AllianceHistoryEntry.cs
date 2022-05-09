namespace EveSharp.Core.Models.Corporation
{
	public struct AllianceHistoryEntry
	{
		public int? allianceId;
		public bool? isDeleted;
		public int recordId;
		public DateTime startDate;
	}
	
	public struct SoAAllianceHistoryEntry
	{
		public readonly int?[] allianceIds;
		public readonly bool?[] isDeleteds;
		public readonly int[] recordIds;
		public readonly DateTime[] startDates;
		
		public SoAAllianceHistoryEntry(params AllianceHistoryEntry[] allianceHistoryEntries)
		{
			int count = allianceHistoryEntries.Length;
			allianceIds = new int?[count];
			isDeleteds = new bool?[count];
			recordIds = new int[count];
			startDates = new DateTime[count];
			
			for (int i = 0; i < count; i++)
			{
				allianceIds[i] = allianceHistoryEntries[i].allianceId;
				isDeleteds[i] = allianceHistoryEntries[i].isDeleted;
				recordIds[i] = allianceHistoryEntries[i].recordId;
				startDates[i] = allianceHistoryEntries[i].startDate;
			}
		}
	}
}