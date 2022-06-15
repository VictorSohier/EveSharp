namespace EveSharp.Core.Models.Universe
{
	public struct StargateDestination
	{
		public int stargateId;
		public int systemId;
	}
	
	public struct SoAStargateDestination
	{
		public readonly int[] stargateIds;
		public readonly int[] systemIds;
		
		public SoAStargateDestination(params StargateDestination[] stargateDestinations)
		{
			int count = stargateDestinations.Length;
			stargateIds = new int[count];
			systemIds = new int[count];
			
			for (int i = 0; i < count; i++)
			{
				stargateIds[i] = stargateDestinations[i].stargateId;
				systemIds[i] = stargateDestinations[i].systemId;
			}
		}
		
		public SoAStargateDestination(int count)
		{
			stargateIds = new int[count];
			systemIds = new int[count];
		}
	}
}