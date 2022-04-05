using EveSharp.Core.Enums.Incursions;

namespace EveSharp.Core.Models.Incursions
{
	public struct Incursion
	{
		public int constellationId;
		public int factionId;
		public bool hasBoss;
		public int[] infestedSolarSystems;
		public float influence;
		public int stagingSolarSystemId;
		public State state;
		public string type;
	}
}