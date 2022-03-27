namespace EveSharp.Core.Models.FactionWarfare.Statistics
{
	public struct Record
	{
		public int? CurrentRank;
		public DateTime EnlistedOn;
		public int? FactionId;
		public int? HighestRank;
		public RollingRecord Kills;
		public int? Pilots;
		public RollingRecord VictoryPoints;
	}
}