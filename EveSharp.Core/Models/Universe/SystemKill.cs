namespace EveSharp.Core.Models.Universe
{
	public struct SystemKill
	{
		public int npcKills;
		public int podKills;
		public int shipKills;
		public int systemId;
	}
	
	public struct SoASystemKill
	{
		public readonly int[] npcKills;
		public readonly int[] podKills;
		public readonly int[] shipKills;
		public readonly int[] systemIds;
		
		public SoASystemKill(params SystemKill[] systemKills)
		{
			int count = systemKills.Length;
			npcKills = new int[count];
			podKills = new int[count];
			shipKills = new int[count];
			systemIds = new int[count];
			
			for (int i = 0; i < count; i++)
			{
				npcKills[i] = systemKills[i].npcKills;
				podKills[i] = systemKills[i].podKills;
				shipKills[i] = systemKills[i].shipKills;
				systemIds[i] = systemKills[i].systemId;
			}
		}
	}
}