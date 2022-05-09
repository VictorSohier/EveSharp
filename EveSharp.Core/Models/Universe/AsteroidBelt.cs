namespace EveSharp.Core.Models.Universe
{
	public struct AsteroidBelt
	{
		public string name;
		public Position position;
		public int systemId;
	}
	
	public struct SoAAsteroidBelt
	{
		public readonly string[] names;
		public readonly SoAPosition positions;
		public readonly int[] systemIds;
		
		public SoAAsteroidBelt(params AsteroidBelt[] asteroidBelts)
		{
			int count = asteroidBelts.Length;
			names = new string[count];
			positions = new SoAPosition(count);
			systemIds = new int[count];
			
			for (int i = 0; i < count; i++)
			{
				names[i] = asteroidBelts[i].name;
				positions.xs[i] = asteroidBelts[i].position.x;
				positions.ys[i] = asteroidBelts[i].position.y;
				positions.zs[i] = asteroidBelts[i].position.z;
				systemIds[i] = asteroidBelts[i].systemId;
			}
		}
	}
}