using EveSharp.Core.Enums.Corporation.Structure;

namespace EveSharp.Core.Models.Corporation.Structure
{
	public struct StarbaseDetails
	{
		public bool allowAllianceMembers;
		public bool allowCorporationMembers;
		public StarbaseRole anchor;
		public bool attackIfAtWar;
		public bool attackIfSecurityStatusDropping;
		public float? attackSecurityStatusThreshold;
		public float? attackStandingThreshold;
		public StarbaseRole fuelBayTake;
		public StarbaseRole fuelBayView;
		public Item[] fuels;
		public StarbaseRole offline;
		public StarbaseRole online;
		public StarbaseRole unanchor;
		public bool useAllianceStandings;
	}
}