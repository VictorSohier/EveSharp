using EveSharp.Core.Enums.Corporation.Structure;

namespace EveSharp.Core.Models.Corporation.Structure
{
	public struct StarbaseDetails
	{
		public bool AllowAllianceMembers;
		public bool AllowCorporationMembers;
		public StarbaseRole Anchor;
		public bool AttackIfAtWar;
		public bool AttackIfSecurityStatusDropping;
		public float? AttackSecurityStatusThreshold;
		public float? AttackStandingThreshold;
		public StarbaseRole FuelBayTake;
		public StarbaseRole FuelBayView;
		public Item[] Fuels;
		public StarbaseRole Offline;
		public StarbaseRole Online;
		public StarbaseRole Unanchor;
		public bool UseAllianceStandings;
	}
}