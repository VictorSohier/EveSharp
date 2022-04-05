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
}