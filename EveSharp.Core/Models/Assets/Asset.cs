using EveSharp.Core.Enums.Assets;

namespace EveSharp.Core.Models.Assets
{
    public struct Asset
    {
        public bool IsBlueprintCopy;
        public bool IsSingleton;
        public long ItemId;
        public AssetLocationFlag LocationFlag;
        public long LocationId;
        public AssetLocationType LocationType;
        public int Quantity;
        public int TypeId;
    }
}