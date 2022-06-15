namespace EveSharp.Core.Models.Market
{
	public struct Group
	{
		public string description;
		public int marketGroupId;
		public string name;
		public int? parentGroupId;
		public int[] types;
	}
	
	public struct SoAGroup
	{
		public readonly string[] descriptions;
		public readonly int[] marketGroupIds;
		public readonly string[] names;
		public readonly int?[] parentGroupIds;
		public readonly int[][] types;
		
		public SoAGroup(params Group[] groups)
		{
			int count = groups.Length;
			descriptions = new string[count];
			marketGroupIds = new int[count];
			names = new string[count];
			parentGroupIds = new int?[count];
			types = new int[count][];
			
			for (int i = 0; i < count; i++)
			{
				descriptions[i] = groups[i].description;
				marketGroupIds[i] = groups[i].marketGroupId;
				names[i] = groups[i].name;
				parentGroupIds[i] = groups[i].parentGroupId;
				types[i] = groups[i].types;
			}
		}
	}
}