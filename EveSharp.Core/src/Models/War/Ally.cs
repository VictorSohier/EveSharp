namespace EveSharp.Core.Models.War
{
	public struct Ally
	{
		public int? allianceId;
		public int? corporationId;
	}
	
	public struct SoAAlly
	{
		public readonly int?[] allianceIds;
		public readonly int?[] corporationIds;
		
		public SoAAlly(params Ally[] allies)
		{
			int count = allies.Length;
			allianceIds = new int?[count];
			corporationIds = new int?[count];
			
			for (int i = 0; i < count; i++)
			{
				allianceIds[i] = allies[i].allianceId;
				corporationIds[i] = allies[i].corporationId;
			}
		}
	}
}