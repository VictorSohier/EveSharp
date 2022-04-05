using EveSharp.Core.Enums.FactionWarfare;

namespace EveSharp.Core.Models.FactionWarfare
{
	public struct System
	{
		public Status contested;
		public int occupierFactionId;
		public int ownerFactionId;
		public int solarSystemId;
		public int victoryPoints;
		public int victoryPointsThreshold;
	}
}