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
	
	public struct SoAStarbaseDetails
	{
		public readonly bool[] allowAllianceMembers;
		public readonly bool[] allowCorporationMembers;
		public readonly StarbaseRole[] anchors;
		public readonly bool[] attackIfAtWars;
		public readonly bool[] attackIfSecurityStatusDroppings;
		public readonly float?[] attackSecurityStatusThresholds;
		public readonly float?[] attackStandingThresholds;
		public readonly StarbaseRole[] fuelBayTakes;
		public readonly StarbaseRole[] fuelBayViews;
		public readonly SoAItem[] fuels;
		public readonly StarbaseRole[] offlines;
		public readonly StarbaseRole[] onlines;
		public readonly StarbaseRole[] unanchors;
		public readonly bool[] useAllianceStandings;
		
		public SoAStarbaseDetails(params StarbaseDetails[] starbaseDetails)
		{
			int count = starbaseDetails.Length;
			allowAllianceMembers = new bool[count];
			allowCorporationMembers = new bool[count];
			anchors = new StarbaseRole[count];
			attackIfAtWars = new bool[count];
			attackIfSecurityStatusDroppings = new bool[count];
			attackSecurityStatusThresholds = new float?[count];
			attackStandingThresholds = new float?[count];
			fuelBayTakes = new StarbaseRole[count];
			fuelBayViews = new StarbaseRole[count];
			fuels = new SoAItem[count];
			offlines = new StarbaseRole[count];
			onlines = new StarbaseRole[count];
			unanchors = new StarbaseRole[count];
			useAllianceStandings = new bool[count];
			
			for (int i = 0; i < count; i++)
			{
				allowAllianceMembers[i] = starbaseDetails[i].allowAllianceMembers;
				allowCorporationMembers[i] = starbaseDetails[i].allowCorporationMembers;
				anchors[i] = starbaseDetails[i].anchor;
				attackIfAtWars[i] = starbaseDetails[i].attackIfAtWar;
				attackIfSecurityStatusDroppings[i] = starbaseDetails[i].attackIfSecurityStatusDropping;
				attackSecurityStatusThresholds[i] = starbaseDetails[i].attackSecurityStatusThreshold;
				attackStandingThresholds[i] = starbaseDetails[i].attackStandingThreshold;
				fuelBayTakes[i] = starbaseDetails[i].fuelBayTake;
				fuelBayViews[i] = starbaseDetails[i].fuelBayView;
				fuels[i] = new SoAItem(starbaseDetails[i].fuels);
				offlines[i] = starbaseDetails[i].offline;
				onlines[i] = starbaseDetails[i].online;
				unanchors[i] = starbaseDetails[i].unanchor;
				useAllianceStandings[i] = starbaseDetails[i].useAllianceStandings;
			}
		}
	}
}