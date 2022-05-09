namespace EveSharp.Core.Models.FactionWarfare.Statistics
{
	public struct Record
	{
		public int? currentRank;
		public DateTime enlistedOn;
		public int? factionId;
		public int? highestRank;
		public RollingRecord kills;
		public int? pilots;
		public RollingRecord victoryPoints;
	}
	
	public struct SoARecord
	{
		public readonly int?[] currentRanks;
		public readonly DateTime[] enlistedOns;
		public readonly int?[] factionIds;
		public readonly int?[] highestRanks;
		public readonly SoARollingRecord kills;
		public readonly int?[] pilots;
		public readonly SoARollingRecord victoryPoints;
		
		public SoARecord(params Record[] records)
		{
			int count = records.Length;
			currentRanks = new int?[count];
			enlistedOns = new DateTime[count];
			factionIds = new int?[count];
			highestRanks = new int?[count];
			kills = new SoARollingRecord(count);
			pilots = new int?[count];
			victoryPoints = new SoARollingRecord(count);
			
			for (int i = 0; i < count; i++)
			{
				currentRanks[i] = records[i].currentRank;
				enlistedOns[i] = records[i].enlistedOn;
				factionIds[i] = records[i].factionId;
				highestRanks[i] = records[i].highestRank;
				kills.lastWeeks[i] = records[i].kills.lastWeek;
				kills.totals[i] = records[i].kills.total;
				kills.yesterdays[i] = records[i].kills.yesterday;
				pilots[i] = records[i].pilots;
				victoryPoints.lastWeeks[i] = records[i].victoryPoints.lastWeek;
				victoryPoints.totals[i] = records[i].victoryPoints.total;
				victoryPoints.yesterdays[i] = records[i].victoryPoints.yesterday;
			}
		}
	}
}