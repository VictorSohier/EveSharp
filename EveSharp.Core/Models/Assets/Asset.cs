using EveSharp.Core.Enums;

namespace EveSharp.Core.Models.Assets
{
    public struct Asset
    {
        public bool IsBlueprintCopy;
        public bool IsSingleton;
        public long ItemId;
        public LocationFlag LocationFlag;
        public long LocationId;
        public Enums.Assets.LocationType LocationType;
        public int Quantity;
        public int TypeId;
    }
}