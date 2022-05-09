namespace EveSharp.Core.Models.Industry
{
	public struct Facility
	{
		public long facilityId;
		public int ownerId;
		public int regionId;
		public int solarSystemId;
		public float? tax;
		public int typeId;
	}
	
	public struct SoAFacility
	{
		public readonly long[] facilityIds;
		public readonly int[] ownerIds;
		public readonly int[] regionIds;
		public readonly int[] solarSystemIds;
		public readonly float?[] taxes;
		public readonly int[] typeIds;
		
		public SoAFacility(params Facility[] facilities)
		{
			int count = facilities.Length;
			facilityIds = new long[count];
			ownerIds = new int[count];
			regionIds = new int[count];
			solarSystemIds = new int[count];
			taxes = new float?[count];
			typeIds = new int[count];
			
			for (int i = 0; i < count; i++)
			{
				facilityIds[i] = facilities[i].facilityId;
				ownerIds[i] = facilities[i].ownerId;
				regionIds[i] = facilities[i].regionId;
				solarSystemIds[i] = facilities[i].solarSystemId;
				taxes[i] = facilities[i].tax;
				typeIds[i] = facilities[i].typeId;
			}
		}
	}
}