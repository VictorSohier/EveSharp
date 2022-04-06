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
}