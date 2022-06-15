namespace EveSharp.Core.Models.PlanetaryInteraction
{
	public struct ExtractorHead
	{
		public int headId;
		public float latitude;
		public float longitude;
	}
	
	public struct SoAExtractorHead
	{
		public readonly int[] headIds;
		public readonly float[] latitudes;
		public readonly float[] longitudes;
		
		public SoAExtractorHead(params ExtractorHead[] extractorHeads)
		{
			int count = extractorHeads.Length;
			headIds = new int[count];
			latitudes = new float[count];
			longitudes = new float[count];
			
			for (int i = 0; i < count; i++)
			{
				headIds[i] = extractorHeads[i].headId;
				latitudes[i] = extractorHeads[i].latitude;
				longitudes[i] = extractorHeads[i].longitude;
			}
		}
	}
}