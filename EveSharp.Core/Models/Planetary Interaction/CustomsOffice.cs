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
	
	public struct SoACustomsOffice
	{
		public readonly float?[] allianceTaxRates;
		public readonly bool[] allowAccessWithStandingss;
		public readonly bool[] allowAllianceAccesss;
		public readonly float?[] badStandingTaxRates;
		public readonly float?[] corporationTaxRates;
		public readonly float?[] excellentStandingTaxRates;
		public readonly float?[] goodStandingTaxRates;
		public readonly float?[] neutralStandingTaxRates;
		public readonly long[] officeIds;
		public readonly int[] reinforceExitEnds;
		public readonly int[] reinforceExitStarts;
		public readonly Standing[] standingLevels;
		public readonly int[] systemIds;
		public readonly float?[] terribleTaxRates;
		
		public SoACustomsOffice(params CustomsOffice[] customsOffices)
		{
			int count = customsOffices.Length;
			allianceTaxRates = new float?[count];
			allowAccessWithStandingss = new bool[count];
			allowAllianceAccesss = new bool[count];
			badStandingTaxRates = new float?[count];
			corporationTaxRates = new float?[count];
			excellentStandingTaxRates = new float?[count];
			goodStandingTaxRates = new float?[count];
			neutralStandingTaxRates = new float?[count];
			officeIds = new long[count];
			reinforceExitEnds = new int[count];
			reinforceExitStarts = new int[count];
			standingLevels = new Standing[count];
			systemIds = new int[count];
			terribleTaxRates = new float?[count];
			
			for (int i = 0; i < count; i++)
			{
				allianceTaxRates[i] = customsOffices[i].allianceTaxRate;
				allowAccessWithStandingss[i] = customsOffices[i].allowAccessWithStandings;
				allowAllianceAccesss[i] = customsOffices[i].allowAllianceAccess;
				badStandingTaxRates[i] = customsOffices[i].badStandingTaxRate;
				corporationTaxRates[i] = customsOffices[i].corporationTaxRate;
				excellentStandingTaxRates[i] = customsOffices[i].excellentStandingTaxRate;
				goodStandingTaxRates[i] = customsOffices[i].goodStandingTaxRate;
				neutralStandingTaxRates[i] = customsOffices[i].neutralStandingTaxRate;
				officeIds[i] = customsOffices[i].officeId;
				reinforceExitEnds[i] = customsOffices[i].reinforceExitEnd;
				reinforceExitStarts[i] = customsOffices[i].reinforceExitStart;
				standingLevels[i] = customsOffices[i].standingLevel;
				systemIds[i] = customsOffices[i].systemId;
				terribleTaxRates[i] = customsOffices[i].terribleTaxRate;
			}
		}
	}
}