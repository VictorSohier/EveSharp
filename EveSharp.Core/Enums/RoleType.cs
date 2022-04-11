using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace EveSharp.Core.Enums
{
	[JsonConverter(typeof(StringEnumConverter))]
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