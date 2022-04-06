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
}