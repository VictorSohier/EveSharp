namespace EveSharp.Core.Models.Universe
{
	public struct Constellation
	{
		public int constellationId;
		public Position position;
		public int regionId;
		public int[] systems;
	}
	
	public struct SoAConstellation
	{
		public readonly int[] constellationIds;
		public readonly SoAPosition positions;
		public readonly int[] regionIds;
		public readonly int[][] systems;
		
		public SoAConstellation(params Constellation[] constellations)
		{
			int count = constellations.Length;
			constellationIds = new int[count];
			positions = new SoAPosition(count);
			regionIds = new int[count];
			systems = new int[count][];
			
			for (int i = 0; i < count; i++)
			{
				int systemsLength = constellations[i].systems.Length;
				constellationIds[i] = constellations[i].constellationId;
				positions.xs[i] = constellations[i].position.x;
				positions.ys[i] = constellations[i].position.y;
				positions.zs[i] = constellations[i].position.z;
				regionIds[i] = constellations[i].regionId;
				systems[i] = new int[systemsLength];
				Array.Copy(constellations[i].systems, systems[i], systemsLength);
			}
		}
	}
}