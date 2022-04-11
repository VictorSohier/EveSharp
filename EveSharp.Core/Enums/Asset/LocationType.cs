using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace EveSharp.Core.Enums.Asset
{
	[JsonConverter(typeof(StringEnumConverter))]
    public enum LocationType
    {
        Station,
        SolarSystem,
        Item,
        Other
    }
}