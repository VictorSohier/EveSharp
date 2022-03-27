namespace EveSharp.Core.Models.FactionWarfare.Statistics.Faction
{
	public struct Aggregate
	{
		public int FactionId;
		public RollingRecord Kills;
		public int Pilots;
		public int SystemsControlled;
		public RollingRecord VictoryPoints;
	}
}