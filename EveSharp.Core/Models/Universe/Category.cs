namespace EveSharp.Core.Models.Universe
{
	public struct Category
	{
		public int categoryId;
		public int[] groups;
		public string name;
		public bool published;
	}
	
	public struct SoACategory
	{
		public readonly int[] categoryIds;
		public readonly int[][] groups;
		public readonly string[] names;
		public readonly bool[] publisheds;
		
		public SoACategory(params Category[] categories)
		{
			int count = categories.Length;
			categoryIds = new int[count];
			groups = new int[count][];
			names = new string[count];
			publisheds = new bool[count];
			
			for (int i = 0; i < count; i++)
			{
				int groupsLength = categories[i].groups.Length;
				categoryIds[i] = categories[i].categoryId;
				groups[i] = new int[i];
				names[i] = categories[i].name;
				publisheds[i] = categories[i].published;
				Array.Copy(categories[i].groups, groups[i], groupsLength);
			}
		}
	}
}