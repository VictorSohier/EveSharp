using System.Security.Cryptography.X509Certificates;

namespace EveSharp.Core.Models.Locations
{
	public struct CharacterLocation
	{
		public int solarSystemId;
		public int? stationId;
		public long? structureId;
	}
	
	public struct SoACharacterLocation
	{
		public readonly int[] solarSystemIds;
		public readonly int?[] stationIds;
		public readonly long?[] structureIds;
		
		public SoACharacterLocation(params CharacterLocation[] characterLocations)
		{
			int count = characterLocations.Length;
			solarSystemIds = new int[count];
			stationIds = new int?[count];
			structureIds = new long?[count];
			
			for (int i = 0; i < count; i++)
			{
				solarSystemIds[i] = characterLocations[i].solarSystemId;
				stationIds[i] = characterLocations[i].stationId;
				structureIds[i] = characterLocations[i].structureId;
			}
		}
	}
}