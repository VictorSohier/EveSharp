using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

namespace EveSharp.Core.Enums
{
	[JsonConverter(typeof(StringEnumConverter), typeof(SnakeCaseNamingStrategy))]

	public enum RoleType
	{
		GrantableRoles,
		GrantableRolesAtBase,
		GrantableRolesAtHq,
		GrantableRolesAtOther,
		Roles,
		RolesAtBase,
		RolesAtHq,
		RolesAtOther
	}
}