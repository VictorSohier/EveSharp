using EveSharp.Core.Models.Incursions;

namespace EveSharp.Core.Models.Fleets
{
	public struct Incursion
	{
		public int ConstellationId;
		public int FactionId;
		public bool HasBoss;
		public int[] InfestedSolarSystems;
		public float Influence;
		public int StagingSolarSystemId;
		public State State;
		public string Type;
	}
}