using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace EveSharp.Core.Enums.Calendar
{
	[JsonConverter(typeof(StringEnumConverter))]
	public enum Response
	{
		Declined,
		NotResponded,
		Accepted,
		Tentative
	}
}