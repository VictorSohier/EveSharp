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
}