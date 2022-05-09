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
	
	public struct SoAIncursion
	{
		public readonly int[] constellationIds;
		public readonly int[] factionIds;
		public readonly bool[] hasBosss;
		public readonly int[][] infestedSolarSystems;
		public readonly float[] influences;
		public readonly int[] stagingSolarSystemIds;
		public readonly State[] states;
		public readonly string[] types;
		
		public SoAIncursion(params Incursion[] incursions)
		{
			int count = incursions.Length;
			constellationIds = new int[count];
			factionIds = new int[count];
			hasBosss = new bool[count];
			infestedSolarSystems = new int[count][];
			influences = new float[count];
			stagingSolarSystemIds = new int[count];
			states = new State[count];
			types = new string[count];
			
			for (int i = 0; i < count; i++)
			{
				int infestedSolarSystemsLength = incursions[i].infestedSolarSystems.Length;
				constellationIds[i] = incursions[i].constellationId;
				factionIds[i] = incursions[i].factionId;
				hasBosss[i] = incursions[i].hasBoss;
				infestedSolarSystems[i] = new int[infestedSolarSystemsLength];
				influences[i] = incursions[i].influence;
				stagingSolarSystemIds[i] = incursions[i].stagingSolarSystemId;
				states[i] = incursions[i].state;
				types[i] = incursions[i].type;
				Array.Copy(incursions[i].infestedSolarSystems, infestedSolarSystems[i], infestedSolarSystemsLength);
			}
		}
	}
}