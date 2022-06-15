namespace EveSharp.Core.Models.Universe
{
	public struct Planet
	{
		public int[] asteroidBelts;
		public int[] moons;
		public int planetId;
	}
	
	public struct SoAPlanet
	{
		public readonly int[][] asteroidBelts;
		public readonly int[][] moons;
		public readonly int[] planetIds;
		
		public SoAPlanet(params Planet[] planets)
		{
			int count = planets.Length;
			asteroidBelts = new int[count][];
			moons = new int[count][];
			planetIds = new int[count];
			
			for (int i = 0; i < count; i++)
			{
				int asteroidBeltsLength = planets[i].asteroidBelts.Length;
				int moonsLength = planets[i].moons.Length;
				asteroidBelts[i] = new int[asteroidBeltsLength];
				moons[i] = new int[moonsLength];
				planetIds[i] = planets[i].planetId;
				Array.Copy(planets[i].asteroidBelts, asteroidBelts[i], asteroidBeltsLength);
				Array.Copy(planets[i].moons, moons[i], moonsLength);
			}
		}
	}
}