namespace EveSharp.Core.Models.Universe
{
	public struct Stargate
	{
		public StargateDestination destination;
		public string name;
		public Position position;
		public int stargateId;
		public int systemId;
		public int typeId;
	}
	
	public struct SoAStargate
	{
		public readonly SoAStargateDestination destinations;
		public readonly string[] names;
		public readonly SoAPosition positions;
		public readonly int[] stargateIds;
		public readonly int[] systemIds;
		public readonly int[] typeIds;
		
		public SoAStargate(params Stargate[] stargates)
		{
			int count = stargates.Length;
			destinations = new SoAStargateDestination(count);
			names = new string[count];
			positions = new SoAPosition(count);
			stargateIds = new int[count];
			systemIds = new int[count];
			typeIds = new int[count];
			
			for (int i = 0; i < count; i++)
			{
				destinations.stargateIds[i] = stargates[i].destination.stargateId;
				destinations.systemIds[i] = stargates[i].destination.systemId;
				names[i] = stargates[i].name;
				positions.xs[i] = stargates[i].position.x;
				positions.ys[i] = stargates[i].position.y;
				positions.zs[i] = stargates[i].position.z;
				stargateIds[i] = stargates[i].stargateId;
				systemIds[i] = stargates[i].systemId;
				typeIds[i] = stargates[i].typeId;
			}
		}
	}
}