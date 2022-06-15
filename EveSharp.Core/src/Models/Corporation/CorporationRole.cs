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
	
	public struct SoACorporationRole
	{
		public readonly int[] characterIds;
		public readonly Role[][] grantableRoles;
		public readonly Role[][] grantableRolesAtBases;
		public readonly Role[][] grantableRolesAtHQs;
		public readonly Role[][] grantableRolesAtOthers;
		public readonly Role[][] roles;
		public readonly Role[][] rolesAtBases;
		public readonly Role[][] rolesAtHqs;
		public readonly Role[][] rolesAtOthers;
		
		public SoACorporationRole(params CorporationRole[] corporationRoles)
		{
			int count = corporationRoles.Length;
			characterIds = new int[count];
			grantableRoles = new Role[count][];
			grantableRolesAtBases = new Role[count][];
			grantableRolesAtHQs = new Role[count][];
			grantableRolesAtOthers = new Role[count][];
			roles = new Role[count][];
			rolesAtBases = new Role[count][];
			rolesAtHqs = new Role[count][];
			rolesAtOthers = new Role[count][];
			
			for (int i = 0; i < count; i++)
			{
				int grantableRolesLength = corporationRoles[i].grantableRoles.Length;
				int grantableRolesAtBasesLength = corporationRoles[i].grantableRolesAtBase.Length;
				int grantableRolesAtHQsLength = corporationRoles[i].grantableRolesAtHQ.Length;
				int grantableRolesAtOthersLength = corporationRoles[i].grantableRolesAtOther.Length;
				int rolesLength = corporationRoles[i].roles.Length;
				int rolesAtBasesLength = corporationRoles[i].rolesAtBase.Length;
				int rolesAtHqsLength = corporationRoles[i].rolesAtHq.Length;
				int rolesAtOthersLength = corporationRoles[i].rolesAtOther.Length;
				characterIds[i] = corporationRoles[i].characterId;
				grantableRoles[i] = new Role[grantableRolesLength];
				grantableRolesAtBases[i] = new Role[grantableRolesAtBasesLength];
				grantableRolesAtHQs[i] = new Role[grantableRolesAtHQsLength];
				grantableRolesAtOthers[i] = new Role[grantableRolesAtOthersLength];
				roles[i] = new Role[rolesLength];
				rolesAtBases[i] = new Role[rolesAtBasesLength];
				rolesAtHqs[i] = new Role[rolesAtHqsLength];
				rolesAtOthers[i] = new Role[rolesAtOthersLength];
				Array.Copy(corporationRoles[i].grantableRoles, grantableRoles[i], grantableRolesLength);
				Array.Copy(corporationRoles[i].grantableRolesAtBase, grantableRolesAtBases[i], grantableRolesAtBasesLength);
				Array.Copy(corporationRoles[i].grantableRolesAtHQ, grantableRolesAtHQs[i], grantableRolesAtHQsLength);
				Array.Copy(corporationRoles[i].grantableRolesAtOther, grantableRolesAtOthers[i], grantableRolesAtOthersLength);
				Array.Copy(corporationRoles[i].roles, roles[i], rolesLength);
				Array.Copy(corporationRoles[i].rolesAtBase, rolesAtBases[i], rolesAtBasesLength);
				Array.Copy(corporationRoles[i].rolesAtHq, rolesAtHqs[i], rolesAtHqsLength);
				Array.Copy(corporationRoles[i].rolesAtOther, rolesAtOthers[i], rolesAtOthersLength);
			}
		}
	}
}