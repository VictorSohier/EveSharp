namespace EveSharp.Core.Models.Corporation
{
	public struct Facility
	{
		public long facilityId;
		public int systemId;
		public int typeId;
	}
	
	public struct SoAFacility
	{
		public readonly long[] facilityIds;
		public readonly int[] systemIds;
		public readonly int[] typeIds;
		
		public SoAFacility(params Facility[] facilities)
		{
			int count = facilities.Length;
			facilityIds = new long[count];
			systemIds = new int[count];
			typeIds = new int[count];
			
			for (int i = 0; i < count; i++)
			{
				facilityIds[i] = facilities[i].facilityId;
				systemIds[i] = facilities[i].systemId;
				typeIds[i] = facilities[i].typeId;
			}
		}
	}
}