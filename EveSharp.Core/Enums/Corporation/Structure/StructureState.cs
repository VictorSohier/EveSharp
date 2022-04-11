using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace EveSharp.Core.Enums.Corporation.Structure
{
	[JsonConverter(typeof(StringEnumConverter))]
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