using EveSharp.Core.Enums;

namespace EveSharp.Core.Models.Corporation
{
	public struct CharacterRolesHistory
	{
		public DateTime changedAt;
		public int characterId;
		public int issuerId;
		public Role[] newRoles;
		public Role[] oldRoles;
		public RoleType roleType;
	}
}