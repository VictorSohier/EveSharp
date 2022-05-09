namespace EveSharp.Core.Models.Universe
{
	public struct SystemJump
	{
		public int shipJumps;
		public int systemId;
	}
	
	public struct SoASystemJump
	{
		public readonly int[] shipJumps;
		public readonly int[] systemIds;
		
		public SoASystemJump(params SystemJump[] systemJumps)
		{
			int count = systemJumps.Length;
			shipJumps = new int[count];
			systemIds = new int[count];
			
			for (int i = 0; i < count; i++)
			{
				shipJumps[i] = systemJumps[i].shipJumps;
				systemIds[i] = systemJumps[i].systemId;
			}
		}
	}
}