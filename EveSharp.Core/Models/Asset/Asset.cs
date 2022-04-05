using EveSharp.Core.Enums;

namespace EveSharp.Core.Models.Asset
{
    public struct Asset
    {
        public bool? isBlueprintCopy;
        public bool isSingleton;
        public long itemId;
        public LocationFlag locationFlag;
        public long locationId;
        public Enums.Asset.LocationType LocationType;
        public int quantity;
        public int typeId;
    }
}