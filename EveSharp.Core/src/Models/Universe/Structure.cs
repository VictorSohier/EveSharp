namespace EveSharp.Core.Models.Universe
{
	public struct Structure
	{
		public string name;
		public int ownerId;
		public Position position;
		public int solarSystemId;
		public int? typeId;
	}
	
	public struct SoAStructure
	{
		public readonly string[] names;
		public readonly int[] ownerIds;
		public readonly SoAPosition positions;
		public readonly int[] solarSystemIds;
		public readonly int?[] typeIds;
		
		public SoAStructure(params Structure[] structures)
		{
			int count = structures.Length;
			names = new string[count];
			ownerIds = new int[count];
			positions = new SoAPosition(count);
			solarSystemIds = new int[count];
			typeIds = new int?[count];
			
			for (int i = 0; i < count; i++)
			{
				names[i] = structures[i].name;
				ownerIds[i] = structures[i].ownerId;
				positions.xs[i] = structures[i].position.x;
				positions.ys[i] = structures[i].position.y;
				positions.zs[i] = structures[i].position.z;
				solarSystemIds[i] = structures[i].solarSystemId;
				typeIds[i] = structures[i].typeId;
			}
		}
	}
}