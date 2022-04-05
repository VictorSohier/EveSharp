using EveSharp.Core.Enums;

namespace EveSharp.Core.Models.Corporation
{
	public struct Title
	{
		public Role[] grantableRoles;
		public Role[] grantableRolesAtBase;
		public Role[] grantableRolesAtHQ;
		public Role[] grantableRolesAtOther;
		public string name;
		public Role[] roles;
		public Role[] rolesAtBase;
		public Role[] rolesAtHQ;
		public Role[] rolesAtOther;
		public int titleId;
	}
}