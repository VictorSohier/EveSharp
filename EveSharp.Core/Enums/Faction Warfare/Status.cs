using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace EveSharp.Core.Enums.FactionWarfare
{
	[JsonConverter(typeof(StringEnumConverter))]
	public enum Status
	{
		Captured,
		Contested,
		Uncontested,
		Vulnerable
	}
}