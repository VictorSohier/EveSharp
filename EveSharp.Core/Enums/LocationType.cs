using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace EveSharp.Core.Enums
{
	[JsonConverter(typeof(StringEnumConverter))]
	public enum LocationType
	{
		Station,
		Structure
	}
}