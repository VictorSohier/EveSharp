namespace EveSharp.Core.Models.Asset
{
    public struct Location
    {
        public long itemId;
        public Position position;
    }
	
    public struct SoALocation
    {
        public readonly long[] itemIds;
        public readonly Position[] positions;
		
		public SoALocation(params Location[] locations)
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