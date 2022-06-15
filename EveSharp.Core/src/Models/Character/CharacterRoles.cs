using EveSharp.Core.Enums;

namespace EveSharp.Core.Models.Character
{
	public struct CharacterRoles
	{
		public Role[] roles;
		public Role[] rolesAtBase;
		public Role[] rolesAtHQ;
		public Role[] rolesAtOther;
	}
	
	public struct SoACharacterRoles
	{
		public readonly Role[][] roles;
		public readonly Role[][] rolesAtBase;
		public readonly Role[][] rolesAtHQ;
		public readonly Role[][] rolesAtOther;
		
		public SoACharacterRoles(params CharacterRoles[] characterRoles)
		{
			int count = characterRoles.Length;
			roles = new Role[count][];
			rolesAtBase = new Role[count][];
			rolesAtHQ = new Role[count][];
			rolesAtOther = new Role[count][];
			
			for (int i = 0; i < count; i++)
			{
				int rolesCount = characterRoles[i].roles.Length;
				int rolesAtBaseCount = characterRoles[i].rolesAtBase.Length;
				int rolesAtHQCount = characterRoles[i].rolesAtHQ.Length;
				int rolesAtOtherCount = characterRoles[i].rolesAtOther.Length;
				roles[i] = new Role[rolesCount];
				rolesAtBase[i] = new Role[rolesAtBaseCount];
				rolesAtHQ[i] = new Role[rolesAtHQCount];
				rolesAtOther[i] = new Role[rolesAtOtherCount];
				Array.Copy(characterRoles[i].roles, roles[i], rolesCount);
				Array.Copy(characterRoles[i].rolesAtBase, rolesAtBase[i], rolesAtBaseCount);
				Array.Copy(characterRoles[i].rolesAtHQ, rolesAtHQ[i], rolesAtHQCount);
				Array.Copy(characterRoles[i].rolesAtOther, rolesAtOther[i], rolesAtOtherCount);
			}
		}
	}
}