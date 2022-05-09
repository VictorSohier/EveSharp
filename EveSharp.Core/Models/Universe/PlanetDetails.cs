namespace EveSharp.Core.Models.Universe
{
	public struct PlanetDetails
	{
		public string name;
		public int planetId;
		public Position position;
		public int systemId;
		public int typeId;
	}
	
	public struct SoAPlanetDetails
	{
		public readonly string[] names;
		public readonly int[] planetIds;
		public readonly SoAPosition positions;
		public readonly int[] systemIds;
		public readonly int[] typeIds;
		
		public SoAPlanetDetails(params PlanetDetails[] planetDetails)
		{
			int count = planetDetails.Length;
			names = new string[count];
			planetIds = new int[count];
			positions = new SoAPosition(count);
			systemIds = new int[count];
			typeIds = new int[count];
			
			for (int i = 0; i < count; i++)
			{
				names[i] = planetDetails[i].name;
				planetIds[i] = planetDetails[i].planetId;
				positions.xs[i] = planetDetails[i].position.x;
				positions.ys[i] = planetDetails[i].position.y;
				positions.zs[i] = planetDetails[i].position.z;
				systemIds[i] = planetDetails[i].systemId;
				typeIds[i] = planetDetails[i].typeId;
			}
		}
	}
}