using EveSharp.Core.Enums.PlanetaryInteraction;

namespace EveSharp.Core.Models.PlanetaryInteraction
{
	public struct Planet
	{
		public DateTime lastUpdate;
		public int numPins;
		public int ownerId;
		public int planetId;
		public PlanetType planetType;
		public int solarSystemId;
		public int upgradeLevel;
	}
	
	public struct SoAPlanet
	{
		public readonly DateTime[] lastUpdates;
		public readonly int[] numPinss;
		public readonly int[] ownerIds;
		public readonly int[] planetIds;
		public readonly PlanetType[] planetTypes;
		public readonly int[] solarSystemIds;
		public readonly int[] upgradeLevels;
		
		public SoAPlanet(params Planet[] planets)
		{
			int count = planets.Length;
			lastUpdates = new DateTime[count];
			numPinss = new int[count];
			ownerIds = new int[count];
			planetIds = new int[count];
			planetTypes = new PlanetType[count];
			solarSystemIds = new int[count];
			upgradeLevels = new int[count];
			
			for (int i = 0; i < count; i++)
			{
				lastUpdates[i] = planets[i].lastUpdate;
				numPinss[i] = planets[i].numPins;
				ownerIds[i] = planets[i].ownerId;
				planetIds[i] = planets[i].planetId;
				planetTypes[i] = planets[i].planetType;
				solarSystemIds[i] = planets[i].solarSystemId;
				upgradeLevels[i] = planets[i].upgradeLevel;
			}
		}
	}
}