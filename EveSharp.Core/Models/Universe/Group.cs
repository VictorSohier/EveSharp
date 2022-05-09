namespace EveSharp.Core.Models.Universe
{
	public struct Group
	{
		public int categoryId;
		public int groupId;
		public string name;
		public bool published;
		public int[] types;
	}
	
	public struct SoAGroup
	{
		public readonly int[] categoryIds;
		public readonly int[] groupIds;
		public readonly string[] names;
		public readonly bool[] publisheds;
		public readonly int[][] types;
		
		public SoAGroup(params Group[] groups)
		{
			int count = groups.Length;
			categoryIds = new int[count];
			groupIds = new int[count];
			names = new string[count];
			publisheds = new bool[count];
			types = new int[count][];
			
			for (int i = 0; i < count; i++)
			{
				int typesLength = groups[i].types.Length;
				categoryIds[i] = groups[i].categoryId;
				groupIds[i] = groups[i].groupId;
				names[i] = groups[i].name;
				publisheds[i] = groups[i].published;
				types[i] = new int[typesLength];
				Array.Copy(groups[i].types, types[i], typesLength);
			}
		}
	}
}