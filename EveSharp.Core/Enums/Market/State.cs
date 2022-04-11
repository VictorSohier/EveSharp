using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace EveSharp.Core.Enums.Market
{
	[JsonConverter(typeof(StringEnumConverter))]
	public enum State
	{
		Cancelled,
		Expired
	}
}