using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

namespace EveSharp.Core.Enums.Corporation.Structure
{
	[JsonConverter(typeof(StringEnumConverter), typeof(SnakeCaseNamingStrategy))]

	public enum StructureState
	{
		Anchorvulnerable,
		Anchoring,
		ArmorReinforce,
		ArmorVulnerable,
		DeployVulnerable,
		FittingInvulnerable,
		HullReinforce,
		HullVulnerable,
		OnlineDeprecated,
		OnliningVulnerable,
		ShieldVulnerable,
		Unanchored,
		Unknown
	}
}