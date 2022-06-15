namespace EveSharp.Core.Models.Sovereignty
{
	public struct Structure
	{
		public int allianceId;
		public int solarSystemId;
		public long structureId;
		public int structureTypeId;
		public float? vulnerabilityOccupancyLevel;
		public DateTime vulnerableEndTime;
		public DateTime vulnerableStartTime;
	}
	
	public struct SoAStructure
	{
		public readonly int[] allianceIds;
		public readonly int[] solarSystemIds;
		public readonly long[] structureIds;
		public readonly int[] structureTypeIds;
		public readonly float?[] vulnerabilityOccupancyLevels;
		public readonly DateTime[] vulnerableEndTimes;
		public readonly DateTime[] vulnerableStartTimes;
		
		public SoAStructure(params Structure[] structures)
		{
			int count = structures.Length;
			allianceIds = new int[count];
			solarSystemIds = new int[count];
			structureIds = new long[count];
			structureTypeIds = new int[count];
			vulnerabilityOccupancyLevels = new float?[count];
			vulnerableEndTimes = new DateTime[count];
			vulnerableStartTimes = new DateTime[count];
			
			for (int i = 0; i < count; i++)
			{
				allianceIds[i] = structures[i].allianceId;
				solarSystemIds[i] = structures[i].solarSystemId;
				structureIds[i] = structures[i].structureId;
				structureTypeIds[i] = structures[i].structureTypeId;
				vulnerabilityOccupancyLevels[i] = structures[i].vulnerabilityOccupancyLevel;
				vulnerableEndTimes[i] = structures[i].vulnerableEndTime;
				vulnerableStartTimes[i] = structures[i].vulnerableStartTime;
			}
		}
	}
}