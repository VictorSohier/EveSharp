using EveSharp.Core.Enums;

namespace EveSharp.Core.Models.Corporation
{
	public struct CorporationRole
	{
		public int characterId;
		public Role[] grantableRoles;
		public Role[] grantableRolesAtBase;
		public Role[] grantableRolesAtHQ;
		public Role[] grantableRolesAtOther;
		public Role[] roles;
		public Role[] rolesAtBase;
		public Role[] rolesAtHq;
		public Role[] rolesAtOther;
	}
}