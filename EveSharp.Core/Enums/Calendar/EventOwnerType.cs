using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace EveSharp.Core.Enums.Calendar
{
	[JsonConverter(typeof(StringEnumConverter))]
	public enum EventOwnerType
	{
		EveServer,
		Corporation,
		Faction,
		Character,
		Alliance
	}
}