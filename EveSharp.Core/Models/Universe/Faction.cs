namespace EveSharp.Core.Models.Universe
{
	public struct Faction
	{
		public int? corporationId;
		public string description;
		public int factionId;
		public bool isUnique;
		public int? militiaCorporationId;
		public string name;
		public float sizeFactor;
		public int? solarSystemId;
		public int stationCount;
		public int stationSystemCount;
	}
	
	public struct SoAFaction
	{
		public readonly int?[] corporationIds;
		public readonly string[] descriptions;
		public readonly int[] factionIds;
		public readonly bool[] isUniques;
		public readonly int?[] militiaCorporationIds;
		public readonly string[] names;
		public readonly float[] sizeFactors;
		public readonly int?[] solarSystemIds;
		public readonly int[] stationCounts;
		public readonly int[] stationSystemCounts;
		
		public SoAFaction(params Faction[] factions)
		{
			int count = factions.Length;
			corporationIds = new int?[count];
			descriptions = new string[count];
			factionIds = new int[count];
			isUniques = new bool[count];
			militiaCorporationIds = new int?[count];
			names = new string[count];
			sizeFactors = new float[count];
			solarSystemIds = new int?[count];
			stationCounts = new int[count];
			stationSystemCounts = new int[count];
			
			for (int i = 0; i < count; i++)
			{
				corporationIds[i] = factions[i].corporationId;
				descriptions[i] = factions[i].description;
				factionIds[i] = factions[i].factionId;
				isUniques[i] = factions[i].isUnique;
				militiaCorporationIds[i] = factions[i].militiaCorporationId;
				names[i] = factions[i].name;
				sizeFactors[i] = factions[i].sizeFactor;
				solarSystemIds[i] = factions[i].solarSystemId;
				stationCounts[i] = factions[i].stationCount;
				stationSystemCounts[i] = factions[i].stationSystemCount;
			}
		}
	}
}