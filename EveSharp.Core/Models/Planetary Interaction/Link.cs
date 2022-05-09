namespace EveSharp.Core.Models.PlanetaryInteraction
{
	public struct Link
	{
		public long destinationPinId;
		public int linkLevel;
		public long sourcePinId;
	}
	
	public struct SoALink
	{
		public readonly long[] destinationPinIds;
		public readonly int[] linkLevels;
		public readonly long[] sourcePinIds;
		
		public SoALink(params Link[] links)
		{
			int count = links.Length;
			destinationPinIds = new long[count];
			linkLevels = new int[count];
			sourcePinIds = new long[count];
			
			for (int i = 0; i < count; i++)
			{
				destinationPinIds[i] = links[i].destinationPinId;
				linkLevels[i] = links[i].linkLevel;
				sourcePinIds[i] = links[i].sourcePinId;
			}
		}
	}
}