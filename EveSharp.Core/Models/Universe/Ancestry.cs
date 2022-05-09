namespace EveSharp.Core.Models.Universe
{
	public struct Ancestry
	{
		public int bloodlineId;
		public string description;
		public int iconId;
		public int id;
		public string name;
		public string shortDescription;
	}
	
	public struct SoAAncestry
	{
		public readonly int[] bloodlineIds;
		public readonly string[] descriptions;
		public readonly int[] iconIds;
		public readonly int[] ids;
		public readonly string[] names;
		public readonly string[] shortDescriptions;
		
		public SoAAncestry(params Ancestry[] ancestries)
		{
			int count = ancestries.Length;
			bloodlineIds = new int[count];
			descriptions = new string[count];
			iconIds = new int[count];
			ids = new int[count];
			names = new string[count];
			shortDescriptions = new string[count];
			
			for (int i = 0; i < count; i++)
			{
				bloodlineIds[i] = ancestries[i].bloodlineId;
				descriptions[i] = ancestries[i].description;
				iconIds[i] = ancestries[i].iconId;
				ids[i] = ancestries[i].id;
				names[i] = ancestries[i].name;
				shortDescriptions[i] = ancestries[i].shortDescription;
			}
		}
	}
}