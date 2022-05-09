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
	
	public struct SoASystem
	{
		public readonly Status[] contesteds;
		public readonly int[] occupierFactionIds;
		public readonly int[] ownerFactionIds;
		public readonly int[] solarSystemIds;
		public readonly int[] victoryPoints;
		public readonly int[] victoryPointsThresholds;
		
		public SoASystem(params System[] systems)
		{
			int count = systems.Length;
			contesteds = new Status[count];
			occupierFactionIds = new int[count];
			ownerFactionIds = new int[count];
			solarSystemIds = new int[count];
			victoryPoints = new int[count];
			victoryPointsThresholds = new int[count];
			
			for (int i = 0; i < count; i++)
			{
				contesteds[i] = systems[i].contested;
				occupierFactionIds[i] = systems[i].occupierFactionId;
				ownerFactionIds[i] = systems[i].ownerFactionId;
				solarSystemIds[i] = systems[i].solarSystemId;
				victoryPoints[i] = systems[i].victoryPoints;
				victoryPointsThresholds[i] = systems[i].victoryPointsThreshold;
			}
		}
	}
}