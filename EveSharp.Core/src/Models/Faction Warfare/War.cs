namespace EveSharp.Core.Models.FactionWarfare
{
	public struct War
	{
		public int againstId;
		public int factionId;
	}
	
	public struct SoAWar
	{
		public readonly int[] againstIds;
		public readonly int[] factionIds;
		
		public SoAWar(params War[] wars)
		{
			int count = wars.Length;
			againstIds = new int[count];
			factionIds = new int[count];
			
			for (int i = 0; i < count; i++)
			{
				againstIds[i] = wars[i].againstId;
				factionIds[i] = wars[i].factionId;
			}
		}
	}
}