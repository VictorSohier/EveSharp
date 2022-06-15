namespace EveSharp.Core.Models.Universe
{
	public struct Race
	{
		public int allianceId;
		public string description;
		public string name;
		public int raceId;
	}
	
	public struct SoARace
	{
		public readonly int[] allianceIds;
		public readonly string[] descriptions;
		public readonly string[] names;
		public readonly int[] raceIds;
		
		public SoARace(params Race[] races)
		{
			int count = races.Length;
			allianceIds = new int[count];
			descriptions = new string[count];
			names = new string[count];
			raceIds = new int[count];
			
			for (int i = 0; i < count; i++)
			{
				allianceIds[i] = races[i].allianceId;
				descriptions[i] = races[i].description;
				names[i] = races[i].name;
				raceIds[i] = races[i].raceId;
			}
		}
	}
}