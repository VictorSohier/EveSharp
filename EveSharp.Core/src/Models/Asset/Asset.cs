using EveSharp.Core.Enums;
using EveSharp.Core.Enums.Asset;

namespace EveSharp.Core.Models.Asset
{
    public struct Asset
    {
        public bool? isBlueprintCopy;
        public bool isSingleton;
        public long itemId;
        public LocationFlag locationFlag;
        public long locationId;
        public AssetLocationType locationType;
        public int quantity;
        public int typeId;
    }
	
    public struct SoAAsset
    {
        public readonly bool?[] isBlueprintCopys;
        public readonly bool[] isSingletons;
        public readonly long[] itemIds;
        public readonly LocationFlag[] locationFlags;
        public readonly long[] locationIds;
        public readonly AssetLocationType[] locationTypes;
        public readonly int[] quantitys;
        public readonly int[] typeIds;
		
		public SoAAsset(params Asset[] assets)
		{
			int count = assets.Length;
			isBlueprintCopys = new bool?[count];
			isSingletons = new bool[count];
			itemIds = new long[count];
			locationFlags = new LocationFlag[count];
			locationIds = new long[count];
			locationTypes = new AssetLocationType[count];
			quantitys = new int[count];
			typeIds = new int[count];
			
			for (int i = 0; i < count; i++)
			{
				isBlueprintCopys[i] = assets[i].isBlueprintCopy;
				isSingletons[i] = assets[i].isSingleton;
				itemIds[i] = assets[i].itemId;
				locationFlags[i] = assets[i].locationFlag;
				locationIds[i] = assets[i].locationId;
				locationTypes[i] = assets[i].locationType;
				quantitys[i] = assets[i].quantity;
				typeIds[i] = assets[i].typeId;
			}
		}
    }
}