using EveSharp.Core.Enums;

namespace EveSharp.Core.Models.Corporation
{
	public struct CharacterRolesHistory
	{
		public DateTime ChangedAt;
		public int CharacterId;
		public int IssuerId;
		public Role[] NewRoles;
		public Role[] OldRoles;
		public RoleType RoleType;
	}
}