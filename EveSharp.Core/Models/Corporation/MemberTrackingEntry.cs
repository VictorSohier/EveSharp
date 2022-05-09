namespace EveSharp.Core.Models.Corporation
{
	public struct MemberTrackingEntry
	{
		public int? baseId;
		public int characterId;
		public long? locationId;
		public DateTime logoffDate;
		public DateTime logonDate;
		public int? shipTypeId;
		public DateTime startDate;
	}
	
	public struct SoAMemberTrackingEntry
	{
		public readonly int?[] baseIds;
		public readonly int[] characterIds;
		public readonly long?[] locationIds;
		public readonly DateTime[] logoffDates;
		public readonly DateTime[] logonDates;
		public readonly int?[] shipTypeIds;
		public readonly DateTime[] startDates;
		
		public SoAMemberTrackingEntry(params MemberTrackingEntry[] memberTrackingEntries)
		{
			int count = memberTrackingEntries.Length;
			baseIds = new int?[count];
			characterIds = new int[count];
			locationIds = new long?[count];
			logoffDates = new DateTime[count];
			logonDates = new DateTime[count];
			shipTypeIds = new int?[count];
			startDates = new DateTime[count];
			
			for (int i = 0; i < count; i++)
			{
				baseIds[i] = memberTrackingEntries[i].baseId;
				characterIds[i] = memberTrackingEntries[i].characterId;
				locationIds[i] = memberTrackingEntries[i].locationId;
				logoffDates[i] = memberTrackingEntries[i].logoffDate;
				logonDates[i] = memberTrackingEntries[i].logonDate;
				shipTypeIds[i] = memberTrackingEntries[i].shipTypeId;
				startDates[i] = memberTrackingEntries[i].startDate;
			}
		}
	}
}