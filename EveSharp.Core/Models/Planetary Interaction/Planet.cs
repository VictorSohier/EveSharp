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
}