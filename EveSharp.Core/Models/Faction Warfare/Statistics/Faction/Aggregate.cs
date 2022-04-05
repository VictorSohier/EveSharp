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
}