using EveSharp.Core.Enums;

namespace EveSharp.Core.Models.Asset
{
    public struct Asset
    {
        public bool? IsBlueprintCopy;
        public bool IsSingleton;
        public long ItemId;
        public LocationFlag LocationFlag;
        public long LocationId;
        public Enums.Asset.LocationType LocationType;
        public int Quantity;
        public int TypeId;
    }
}