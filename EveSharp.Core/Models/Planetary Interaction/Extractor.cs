namespace EveSharp.Core.Models.PlanetaryInteraction
{
	public struct Extractor
	{
		public int? cycleTime;
		public float? headRadius;
		public ExtractorHead[] heads;
		public int? productTypeId;
		public int? qtyPerCycle;
	}
	
	public struct SoAExtractor
	{
		public readonly int?[] cycleTimes;
		public readonly float?[] headRadiuss;
		public readonly SoAExtractorHead[] heads;
		public readonly int?[] productTypeIds;
		public readonly int?[] qtyPerCycles;
		
		public SoAExtractor(params Extractor[] extractors)
		{
			int count = extractors.Length;
			cycleTimes = new int?[count];
			headRadiuss = new float?[count];
			heads = new SoAExtractorHead[count];
			productTypeIds = new int?[count];
			qtyPerCycles = new int?[count];
			
			for (int i = 0; i < count; i++)
			{
				cycleTimes[i] = extractors[i].cycleTime;
				headRadiuss[i] = extractors[i].headRadius;
				heads[i] = new(extractors[i].heads);
				productTypeIds[i] = extractors[i].productTypeId;
				qtyPerCycles[i] = extractors[i].qtyPerCycle;
			}
		}
	}
}