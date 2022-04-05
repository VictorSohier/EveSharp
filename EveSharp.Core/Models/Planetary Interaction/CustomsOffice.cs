using EveSharp.Core.Enums;

namespace EveSharp.Core.Models.PlanetaryInteraction
{
	public struct CustomsOffice
	{
		public float? allianceTaxRate;
		public bool allowAccessWithStandings;
		public bool allowAllianceAccess;
		public float? badStandingTaxRate;
		public float? corporationTaxRate;
		public float? excellentStandingTaxRate;
		public float? goodStandingTaxRate;
		public float? neutralStandingTaxRate;
		public long officeId;
		public int reinforceExitEnd;
		public int reinforceExitStart;
		public Standing standingLevel;
		public int systemId;
		public float? terribleTaxRate;
	}
}