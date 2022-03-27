using EveSharp.Core.Enums.FactionWarfare;

namespace EveSharp.Core.Models.FactionWarfare
{
	public struct System
	{
		public Status Contested;
		public int OccupierFactionId;
		public int OwnerFactionId;
		public int SolarSystemId;
		public int VictoryPoints;
		public int VictoryPointsThreshold;
	}
}