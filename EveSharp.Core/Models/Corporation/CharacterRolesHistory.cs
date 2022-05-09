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
	
	public struct SoACharacterRolesHistory
	{
		public readonly DateTime[] changedAts;
		public readonly int[] characterIds;
		public readonly int[] issuerIds;
		public readonly Role[][] newRoles;
		public readonly Role[][] oldRoles;
		public readonly RoleType[] roleTypes;
		
		public SoACharacterRolesHistory(params CharacterRolesHistory[] characterRolesHistories)
		{
			int count = characterRolesHistories.Length;
			changedAts = new DateTime[count];
			characterIds = new int[count];
			issuerIds = new int[count];
			newRoles = new Role[count][];
			oldRoles = new Role[count][];
			roleTypes = new RoleType[count];
			
			for (int i = 0; i < count; i++)
			{
				int newRolesLength = characterRolesHistories[i].newRoles.Length;
				int oldRolesLength = characterRolesHistories[i].oldRoles.Length;
				changedAts[i] = characterRolesHistories[i].changedAt;
				characterIds[i] = characterRolesHistories[i].characterId;
				issuerIds[i] = characterRolesHistories[i].issuerId;
				newRoles[i] = new Role[newRolesLength];
				oldRoles[i] = new Role[oldRolesLength];
				roleTypes[i] = characterRolesHistories[i].roleType;
				Array.Copy(characterRolesHistories[i].newRoles, newRoles, newRolesLength);
				Array.Copy(characterRolesHistories[i].oldRoles, oldRoles, oldRolesLength);
			}
		}
	}
}