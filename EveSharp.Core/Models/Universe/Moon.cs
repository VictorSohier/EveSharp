namespace EveSharp.Core.Models.Universe
{
	public struct Moon
	{
		public int moonId;
		public string name;
		public Position position;
		public int systemId;
	}
	
	public struct SoAMoon
	{
		public readonly int[] moonIds;
		public readonly string[] names;
		public readonly SoAPosition positions;
		public readonly int[] systemIds;
		
		public SoAMoon(params Moon[] moons)
		{
			int count = moons.Length;
			moonIds = new int[count];
			names = new string[count];
			positions = new SoAPosition(count);
			systemIds = new int[count];
			
			for (int i = 0; i < count; i++)
			{
				moonIds[i] = moons[i].moonId;
				names[i] = moons[i].name;
				positions.xs[i] = moons[i].position.x;
				positions.ys[i] = moons[i].position.y;
				positions.zs[i] = moons[i].position.z;
				systemIds[i] = moons[i].systemId;
			}
		}
	}
}