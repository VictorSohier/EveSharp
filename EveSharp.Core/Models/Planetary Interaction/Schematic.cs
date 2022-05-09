namespace EveSharp.Core.Models.PlanetaryInteraction
{
	public struct Schematic
	{
		public int cycleTime;
		public string schematicName;
	}
	
	public struct SoASchematic
	{
		public readonly int[] cycleTimes;
		public readonly string[] schematicNames;
		
		public SoASchematic(params Schematic[] schematics)
		{
			int count = schematics.Length;
			cycleTimes = new int[count];
			schematicNames = new string[count];
			
			for (int i = 0; i < count; i++)
			{
				cycleTimes[i] = schematics[i].cycleTime;
				schematicNames[i] = schematics[i].schematicName;
			}
		}
	}
}