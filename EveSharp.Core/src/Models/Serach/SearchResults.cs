namespace EveSharp.Core.Models.Search
{
	public struct SearchResults
	{
		public int[] agent;
		public int[] alliance;
		public int[] character;
		public int[] constellation;
		public int[] corporation;
		public int[] faction;
		public int[] inventoryType;
		public int[] region;
		public int[] solarSystem;
		public int[] station;
	}
	
	public struct SoASearchResults
	{
		public readonly int[][] agents;
		public readonly int[][] alliances;
		public readonly int[][] characters;
		public readonly int[][] constellations;
		public readonly int[][] corporations;
		public readonly int[][] factions;
		public readonly int[][] inventoryTypes;
		public readonly int[][] regions;
		public readonly int[][] solarSystems;
		public readonly int[][] stations;
		
		public SoASearchResults(params SearchResults[] searchResults)
		{
			int count = searchResults.Length;
			agents = new int[count][];
			alliances = new int[count][];
			characters = new int[count][];
			constellations = new int[count][];
			corporations = new int[count][];
			factions = new int[count][];
			inventoryTypes = new int[count][];
			regions = new int[count][];
			solarSystems = new int[count][];
			stations = new int[count][];
			
			for (int i = 0; i < count; i++)
			{
				int agentsLength = searchResults[i].agent.Length;
				int alliancesLength = searchResults[i].alliance.Length;
				int charactersLength = searchResults[i].character.Length;
				int constellationsLength = searchResults[i].constellation.Length;
				int corporationsLength = searchResults[i].corporation.Length;
				int factionsLength = searchResults[i].faction.Length;
				int inventoryTypesLength = searchResults[i].inventoryType.Length;
				int regionsLength = searchResults[i].region.Length;
				int solarSystemsLength = searchResults[i].solarSystem.Length;
				int stationsLength = searchResults[i].station.Length;
				agents[i] = new int[agentsLength];
				alliances[i] = new int[alliancesLength];
				characters[i] = new int[charactersLength];
				constellations[i] = new int[constellationsLength];
				corporations[i] = new int[corporationsLength];
				factions[i] = new int[factionsLength];
				inventoryTypes[i] = new int[inventoryTypesLength];
				regions[i] = new int[regionsLength];
				solarSystems[i] = new int[solarSystemsLength];
				stations[i] = new int[stationsLength];
				Array.Copy(searchResults[i].agent, agents[i], agentsLength);
				Array.Copy(searchResults[i].alliance, alliances[i], alliancesLength);
				Array.Copy(searchResults[i].character, characters[i], charactersLength);
				Array.Copy(searchResults[i].constellation, constellations[i], constellationsLength);
				Array.Copy(searchResults[i].corporation, corporations[i], corporationsLength);
				Array.Copy(searchResults[i].faction, factions[i], factionsLength);
				Array.Copy(searchResults[i].inventoryType, inventoryTypes[i], inventoryTypesLength);
				Array.Copy(searchResults[i].region, regions[i], regionsLength);
				Array.Copy(searchResults[i].solarSystem, solarSystems[i], solarSystemsLength);
				Array.Copy(searchResults[i].station, stations[i], stationsLength);
			}
		}
	}
}