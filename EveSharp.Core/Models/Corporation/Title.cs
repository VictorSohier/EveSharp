using EveSharp.Core.Enums;

namespace EveSharp.Core.Models.Corporation
{
	public struct Title
	{
		public Role[] GrantableRoles;
		public Role[] GrantableRolesAtBase;
		public Role[] GrantableRolesAtHQ;
		public Role[] GrantableRolesAtOther;
		public string Name;
		public Role[] Roles;
		public Role[] RolesAtBase;
		public Role[] RolesAtHQ;
		public Role[] RolesAtOther;
		public int TitleId;
	}
}