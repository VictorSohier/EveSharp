using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace EveSharp.Core.Enums.Sovereignty
{
	[JsonConverter(typeof(StringEnumConverter))]
	public enum EventType
	{
		TcuDefense,
		IhubDefense,
		StationDefense,
		StationFreeport
	}
}