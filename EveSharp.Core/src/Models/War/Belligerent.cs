namespace EveSharp.Core.Models.War
{
	public struct Belligerent
	{
		public int? allianceId;
		public int? corporationId;
		public float iskDestroyed;
		public int shipsKilled;
	}
	
	public struct SoABelligerent
	{
		public readonly int?[] allianceIds;
		public readonly int?[] corporationIds;
		public readonly float[] iskDestroyeds;
		public readonly int[] shipsKilleds;
		
		public SoABelligerent(params Belligerent[] belligerents)
		{
			int count = belligerents.Length;
			allianceIds = new int?[count];
			corporationIds = new int?[count];
			iskDestroyeds = new float[count];
			shipsKilleds = new int[count];
			
			for (int i = 0; i < count; i++)
			{
				allianceIds[i] = belligerents[i].allianceId;
				corporationIds[i] = belligerents[i].corporationId;
				iskDestroyeds[i] = belligerents[i].iskDestroyed;
				shipsKilleds[i] = belligerents[i].shipsKilled;
			}
		}
		
		public SoABelligerent(int count)
		{
			allianceIds = new int?[count];
			corporationIds = new int?[count];
			iskDestroyeds = new float[count];
			shipsKilleds = new int[count];
		}
	}
}