using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace EveSharp.Core.Enums.Corporation.Structure
{
	[JsonConverter(typeof(StringEnumConverter))]
	public enum StarbaseState
	{
		Offline,
		Online,
		Onlining,
		Reinforced,
		Unanchoring
	}
}