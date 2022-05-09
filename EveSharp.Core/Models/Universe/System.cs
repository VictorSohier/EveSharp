using System.Reflection.Metadata.Ecma335;

namespace EveSharp.Core.Models.Universe
{
	public struct System
	{
		public int constellationId;
		public string name;
		public Planet[] planets;
		public Position position;
		public string securityClass;
		public float securityStatus;
		public int starId;
		public int[] stargates;
		public int[] stations;
		public int systemId;
	}
	
	public struct SoASystem
	{
		public readonly int[] constellationIds;
		public readonly string[] names;
		public readonly SoAPlanet[] planets;
		public readonly SoAPosition positions;
		public readonly string[] securityClasses;
		public readonly float[] securityStatus;
		public readonly int[] starIds;
		public readonly int[][] stargates;
		public readonly int[][] stations;
		public readonly int[] systemIds;
		
		public SoASystem(params System[] systems)
		{
			int count = systems.Length;
			constellationIds = new int[count];
			names = new string[count];
			planets = new SoAPlanet[count];
			positions = new SoAPosition(count);
			securityClasses = new string[count];
			securityStatus = new float[count];
			starIds = new int[count];
			stargates = new int[count][];
			stations = new int[count][];
			systemIds = new int[count];
			
			for (int i = 0; i < count; i++)
			{
				constellationIds[i] = systems[i].constellationId;
				names[i] = systems[i].name;
				planets[i] = new (systems[i].planets);
				positions.xs[i] = systems[i].position.x;
				positions.ys[i] = systems[i].position.y;
				positions.zs[i] = systems[i].position.z;
				securityClasses[i] = systems[i].securityClass;
				securityStatus[i] = systems[i].securityStatus;
				starIds[i] = systems[i].starId;
				stargates[i] = systems[i].stargates;
				stations[i] = systems[i].stations;
				systemIds[i] = systems[i].systemId;
			}
		}
	}
}