using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace EveSharp.Core.Enums.Industry
{
	[JsonConverter(typeof(StringEnumConverter))]
	public enum Status
	{
		Active,
		Cancelled,
		Delivered,
		Paused,
		Ready,
		Reverted
	}
}