namespace EveSharp.Core.Models.Asset
{
    public struct AssetName
    {
        public long itemId;
        public string name;
    }
	
	public struct SoAAssetName
	{
		public readonly long[] itemIds;
		public readonly string[] names;
		
		public SoAAssetName(params AssetName[] assetNames)
		{
			int count = assetNames.Length;
			itemIds = new long[count];
			names = new string[count];
			
			for (int i = 0; i < count; i++)
			{
				itemIds[i] = assetNames[i].itemId;
				names[i] = assetNames[i].name;
			}
		}
	}
}