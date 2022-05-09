namespace EveSharp.Core.Models.FactionWarfare.Statistics.Faction
{
	public struct Aggregate
	{
		public int factionId;
		public RollingRecord kills;
		public int pilots;
		public int systemsControlled;
		public RollingRecord victoryPoints;
	}
	
	public struct SoAAggregate
	{
		public readonly int[] factionIds;
		public readonly SoARollingRecord kills;
		public readonly int[] pilots;
		public readonly int[] systemsControlleds;
		public readonly SoARollingRecord victoryPoints;
		
		public SoAAggregate(params Aggregate[] aggregates)
		{
			int count = aggregates.Length;
			factionIds = new int[count];
			kills = new SoARollingRecord(count);
			pilots = new int[count];
			systemsControlleds = new int[count];
			victoryPoints = new SoARollingRecord(count);
			
			for (int i = 0; i < count; i++)
			{
				factionIds[i] = aggregates[i].factionId;
				kills.lastWeeks[i] = aggregates[i].kills.lastWeek;
				kills.totals[i] = aggregates[i].kills.total;
				kills.yesterdays[i] = aggregates[i].kills.yesterday;
				pilots[i] = aggregates[i].pilots;
				systemsControlleds[i] = aggregates[i].systemsControlled;
				victoryPoints.lastWeeks[i] = aggregates[i].victoryPoints.lastWeek;
				victoryPoints.totals[i] = aggregates[i].victoryPoints.total;
				victoryPoints.yesterdays[i] = aggregates[i].victoryPoints.yesterday;
			}
		}
	}
}