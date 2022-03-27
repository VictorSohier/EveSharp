using EveSharp.Core.Enums;

namespace EveSharp.Core.Models.Corporation
{
	public struct CorporationRole
	{
		public int CharacterId;
		public Role[] GrantableRoles;
		public Role[] GrantableRolesAtBase;
		public Role[] GrantableRolesAtHQ;
		public Role[] GrantableRolesAtOther;
		public Role[] Roles;
		public Role[] RolesAtBase;
		public Role[] RolesAtHq;
		public Role[] RolesAtOther;
	}
}