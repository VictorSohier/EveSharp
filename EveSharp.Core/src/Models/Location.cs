using EveSharp.Core.Enums;

namespace EveSharp.Core.Models
{
	public struct Location
	{
		public long locationId;
		public LocationType locationType;
	}
	
	public struct SoALocation
	{
		public readonly long[] locationIds;
		public readonly LocationType[] locationTypes;
		
		public SoALocation(int count)
		{
			locationIds = new long[count];
			locationTypes = new LocationType[count];
		}
		
		public SoALocation(params Location[] locations)
		{
			int count = locations.Length;
			locationIds = new long[count];
			locationTypes = new LocationType[count];
			
			for (int i = 0; i < count; i++)
			{
				locationIds[i] = locations[i].locationId;
				locationTypes[i] = locations[i].locationType;
			}
		}
	}
}