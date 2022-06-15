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
	
	public struct SoATitle
	{
		public readonly Role[][] grantableRoles;
		public readonly Role[][] grantableRolesAtBases;
		public readonly Role[][] grantableRolesAtHQs;
		public readonly Role[][] grantableRolesAtOthers;
		public readonly string[] names;
		public readonly Role[][] roles;
		public readonly Role[][] rolesAtBases;
		public readonly Role[][] rolesAtHQs;
		public readonly Role[][] rolesAtOthers;
		public readonly int[] titleIds;
		
		public SoATitle(params Title[] titles)
		{
			int count = titles.Length;
			grantableRoles = new Role[count][];
			grantableRolesAtBases = new Role[count][];
			grantableRolesAtHQs = new Role[count][];
			grantableRolesAtOthers = new Role[count][];
			names = new string[count];
			roles = new Role[count][];
			rolesAtBases = new Role[count][];
			rolesAtHQs = new Role[count][];
			rolesAtOthers = new Role[count][];
			titleIds = new int[count];
			
			for (int i = 0; i < count; i++)
			{
				int grantableRolesLength = titles[i].grantableRoles.Length;
				int grantableRolesAtBasesLength = titles[i].grantableRolesAtBase.Length;
				int grantableRolesAtHQsLength = titles[i].grantableRolesAtHQ.Length;
				int grantableRolesAtOthersLength = titles[i].grantableRolesAtOther.Length;
				int rolesLength = titles[i].roles.Length;
				int rolesAtBasesLength = titles[i].rolesAtBase.Length;
				int rolesAtHQsLength = titles[i].rolesAtHQ.Length;
				int rolesAtOthersLength = titles[i].rolesAtOther.Length;
				grantableRoles[i] = new Role[grantableRolesLength];
				grantableRolesAtBases[i] = new Role[grantableRolesAtBasesLength];
				grantableRolesAtHQs[i] = new Role[grantableRolesAtHQsLength];
				grantableRolesAtOthers[i] = new Role[grantableRolesAtOthersLength];
				names[i] = titles[i].name;
				roles[i] = new Role[rolesLength];
				rolesAtBases[i] = new Role[rolesAtBasesLength];
				rolesAtHQs[i] = new Role[rolesAtHQsLength];
				rolesAtOthers[i] = new Role[rolesAtOthersLength];
				titleIds[i] = titles[i].titleId;
				Array.Copy(titles[i].grantableRoles, grantableRoles[i], grantableRolesLength);
				Array.Copy(titles[i].grantableRolesAtBase, grantableRolesAtBases[i], grantableRolesAtBasesLength);
				Array.Copy(titles[i].grantableRolesAtHQ, grantableRolesAtHQs[i], grantableRolesAtHQsLength);
				Array.Copy(titles[i].grantableRolesAtOther, grantableRolesAtOthers[i], grantableRolesAtOthersLength);
				Array.Copy(titles[i].roles, roles[i], rolesLength);
				Array.Copy(titles[i].rolesAtBase, rolesAtBases[i], rolesAtBasesLength);
				Array.Copy(titles[i].rolesAtHQ, rolesAtHQs[i], rolesAtHQsLength);
				Array.Copy(titles[i].rolesAtOther, rolesAtOthers[i], rolesAtOthersLength);
			}
		}
	}
}