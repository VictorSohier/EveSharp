using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace EveSharp.Core.Enums.Incursions
{
	[JsonConverter(typeof(StringEnumConverter))]
	public enum State
	{
		Withdrawing,
		Mobilizing,
		Established
	}
}