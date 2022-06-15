namespace EveSharp.Core.Models.Asset
{
    public struct AssetLocation
    {
        public long itemId;
        public Position position;
    }
	
    public struct SoAAssetLocation
    {
        public readonly long[] itemIds;
        public readonly Position[] positions;
		
		public SoAAssetLocation(params AssetLocation[] locations)
		{
			int count = locations.Length;
			itemIds = new long[count];
			positions = new Position[count];
			
			for (int i = 0; i < count; i++)
			{
				itemIds[i] = locations[i].itemId;
				positions[i] = locations[i].position;
			}
		}
    }
}