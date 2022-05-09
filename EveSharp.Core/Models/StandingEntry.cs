using EveSharp.Core.Enums;

namespace EveSharp.Core.Models
{
	public struct StandingEntry
	{
		public int fromId;
		public float standing;
		public NPCType fromType;
	}
	
	public struct SoAStandingEntry
	{
		public readonly int[] fromIds;
		public readonly float[] standings;
		public readonly NPCType[] fromTypes;
		
		public SoAStandingEntry(params StandingEntry[] standingEntries)
		{
			int count = standingEntries.Length;
			fromIds = new int[count];
			standings = new float[count];
			fromTypes = new NPCType[count];
			
			for (int i = 0; i < count; i++)
			{
				fromIds[i] = standingEntries[i].fromId;
				standings[i] = standingEntries[i].standing;
				fromTypes[i] = standingEntries[i].fromType;
			}
		}
	}
}