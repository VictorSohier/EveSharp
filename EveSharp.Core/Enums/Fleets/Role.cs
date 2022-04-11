using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace EveSharp.Core.Enums.Fleets
{
	[JsonConverter(typeof(StringEnumConverter))]
	public enum Role
	{
		FleetCommander,
		SquadCommander,
		SquadMember,
		WingCommander
	}
}