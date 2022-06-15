using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

namespace EveSharp.Core.Enums.Sovereignty
{
	[JsonConverter(typeof(StringEnumConverter), typeof(SnakeCaseNamingStrategy))]

	public enum EventType
	{
		TcuDefense,
		IhubDefense,
		StationDefense,
		StationFreeport
	}
}