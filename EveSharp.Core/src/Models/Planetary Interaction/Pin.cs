namespace EveSharp.Core.Models.PlanetaryInteraction
{
	public struct Pin
	{
		public ItemStack[] contents;
		public DateTime expiryTime;
		public Extractor extractorDetails;
		public int[] factoryDetails;
		public DateTime installTime;
		public DateTime lastCycleStart;
		public float latitude;
		public float longitude;
		public long pinId;
		public int? schematicId;
		public int typeId;
	}
	
	public struct SoAPin
	{
		public readonly ItemStack[][] contents;
		public readonly DateTime[] expiryTimes;
		public readonly Extractor[] extractorDetails;
		public readonly int[][] factoryDetailss;
		public readonly DateTime[] installTimes;
		public readonly DateTime[] lastCycleStarts;
		public readonly float[] latitudes;
		public readonly float[] longitudes;
		public readonly long[] pinIds;
		public readonly int?[] schematicIds;
		public readonly int[] typeIds;
		
		public SoAPin(params Pin[] pins)
		{
			int count = pins.Length;
			contents = new ItemStack[count][];
			expiryTimes = new DateTime[count];
			extractorDetails = new Extractor[count];
			factoryDetailss = new int[count][];
			installTimes = new DateTime[count];
			lastCycleStarts = new DateTime[count];
			latitudes = new float[count];
			longitudes = new float[count];
			pinIds = new long[count];
			schematicIds = new int?[count];
			typeIds = new int[count];
			
			for (int i = 0; i < count; i++)
			{
				contents[i] = pins[i].contents;
				expiryTimes[i] = pins[i].expiryTime;
				extractorDetails[i] = pins[i].extractorDetails;
				factoryDetailss[i] = pins[i].factoryDetails;
				installTimes[i] = pins[i].installTime;
				lastCycleStarts[i] = pins[i].lastCycleStart;
				latitudes[i] = pins[i].latitude;
				longitudes[i] = pins[i].longitude;
				pinIds[i] = pins[i].pinId;
				schematicIds[i] = pins[i].schematicId;
				typeIds[i] = pins[i].typeId;
			}
		}
	}
}