namespace EveSharp.Core.Models.Universe
{
	public struct Star
	{
		public long age;
		public float luminosity;
		public string name;
		public long radius;
		public int solarSystemId;
		public string spectralClass;
		public int temperature;
		public int typeId;
	}
	
	public struct SoAStar
	{
		public readonly long[] ages;
		public readonly float[] luminositys;
		public readonly string[] names;
		public readonly long[] radii;
		public readonly int[] solarSystemIds;
		public readonly string[] spectralClasses;
		public readonly int[] temperatures;
		public readonly int[] typeIds;
		
		public SoAStar(params Star[] stars)
		{
			int count = stars.Length;
			ages = new long[count];
			luminositys = new float[count];
			names = new string[count];
			radii = new long[count];
			solarSystemIds = new int[count];
			spectralClasses = new string[count];
			temperatures = new int[count];
			typeIds = new int[count];
			
			for (int i = 0; i < count; i++)
			{
				ages[i] = stars[i].age;
				luminositys[i] = stars[i].luminosity;
				names[i] = stars[i].name;
				radii[i] = stars[i].radius;
				solarSystemIds[i] = stars[i].solarSystemId;
				spectralClasses[i] = stars[i].spectralClass;
				temperatures[i] = stars[i].temperature;
				typeIds[i] = stars[i].typeId;
			}
		}
	}
}