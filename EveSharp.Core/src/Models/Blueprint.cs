using EveSharp.Core.Enums;

namespace EveSharp.Core.Models
{
	public struct Blueprint
	{
		public long itemId;
		public LocationFlag locationFlag;
		public long locationId;
		public int materialEfficiency;
		public int quantity;
		public int runs;
		public int timeEfficiency;
		public int typeId;
	}
	
	public struct SoABlueprint
	{
		public readonly long[] itemIds;
		public readonly LocationFlag[] locationFlags;
		public readonly long[] locationIds;
		public readonly int[] materialEfficiencys;
		public readonly int[] quantitys;
		public readonly int[] runs;
		public readonly int[] timeEfficiencys;
		public readonly int[] typeIds;
		
		public SoABlueprint(params Blueprint[] blueprints)
		{
			int count = blueprints.Length;
			itemIds = new long[count];
			locationFlags = new LocationFlag[count];
			locationIds = new long[count];
			materialEfficiencys = new int[count];
			quantitys = new int[count];
			runs = new int[count];
			timeEfficiencys = new int[count];
			typeIds = new int[count];
			
			for (int i = 0; i < count; i++)
			{
				itemIds[i] = blueprints[i].itemId;
				locationFlags[i] = blueprints[i].locationFlag;
				locationIds[i] = blueprints[i].locationId;
				materialEfficiencys[i] = blueprints[i].materialEfficiency;
				quantitys[i] = blueprints[i].quantity;
				runs[i] = blueprints[i].runs;
				timeEfficiencys[i] = blueprints[i].timeEfficiency;
				typeIds[i] = blueprints[i].typeId;
			}
		}
	}
}