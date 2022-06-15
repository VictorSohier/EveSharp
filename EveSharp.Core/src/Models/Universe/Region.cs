namespace EveSharp.Core.Models.Universe
{
	public struct Region
	{
		public int[] constellations;
		public string description;
		public string name;
		public int regionId;
	}
	
	public struct SoARegion
	{
		public readonly int[][] constellations;
		public readonly string[] descriptions;
		public readonly string[] names;
		public readonly int[] regionIds;
		
		public SoARegion(params Region[] regions)
		{
			int count = regions.Length;
			constellations = new int[count][];
			descriptions = new string[count];
			names = new string[count];
			regionIds = new int[count];
			
			for (int i = 0; i < count; i++)
			{
				int constellationsLength = regions[i].constellations.Length;
				constellations[i] = new int[constellationsLength];
				descriptions[i] = regions[i].description;
				names[i] = regions[i].name;
				regionIds[i] = regions[i].regionId;
				Array.Copy(regions[i].constellations, constellations[i], constellationsLength);
			}
		}
	}
}