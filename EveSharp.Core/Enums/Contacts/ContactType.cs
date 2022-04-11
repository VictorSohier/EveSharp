using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace EveSharp.Core.Enums.Contacts
{
	[JsonConverter(typeof(StringEnumConverter))]
	public enum ContactType
	{
		character,
		corporation,
		alliance,
		faction,
		other
	}
}