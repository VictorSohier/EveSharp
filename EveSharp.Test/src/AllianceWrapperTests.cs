using EveSharp.Core.Models;
using EveSharp.Core.Models.Alliance;
using EveSharp.Infrastructure.Models.Wrappers;

namespace EveSharp.Test
{
	internal class AllianceWrapperTests
	{
		private readonly AllianceWrapper _wrapper = new();
		private const int TEST_ALLIANCE_ID = 1354830081; // GSF
		
		internal AllianceWrapperTests() { }
		
		internal async Task<(int, int, int)> Run()
		{
			int totalTests = 0;
			int passedTests = 0;
			totalTests++;
			bool getAllianceIds = await AllianceIdsTest();
			totalTests++;
			bool getAllianceDetails = await AllianceDetailsTest();
			totalTests++;
			bool getAllianceCorporations = await AllianceCorporationsTest();
			totalTests++;
			bool getAllianceIcons = await AllianceIconsTest();
			if (getAllianceIds) passedTests++;
			if (getAllianceDetails) passedTests++;
			if (getAllianceCorporations) passedTests++;
			if (getAllianceIcons) passedTests++;
			Console.WriteLine($"Get alliance ids: {getAllianceIds}");
			Console.WriteLine($"Get alliance details: {getAllianceDetails}");
			Console.WriteLine($"Get alliance member corporations: {getAllianceCorporations}");
			Console.WriteLine($"Get alliance icons: {getAllianceIcons}");
			return (totalTests, passedTests, totalTests - passedTests);
		}
		
		private async Task<bool> AllianceIdsTest()
		{
			int[] allianceIds = await _wrapper.GetAlliancesAsync();
			bool ret = allianceIds.Length > 0;
			return ret;
		}
		
		private async Task<bool> AllianceDetailsTest()
		{
			Alliance alliance = await _wrapper.GetAllianceAsync(TEST_ALLIANCE_ID);
			bool ret = alliance.name == "Goonswarm Federation";
			ret &= alliance.ticker == "CONDI";
			return ret;
		}
		
		private async Task<bool> AllianceCorporationsTest()
		{
			int[] allianceCorporationIds = await _wrapper.GetAllianceCorporationsAsync(TEST_ALLIANCE_ID);
			bool ret = allianceCorporationIds.Length > 0;
			return ret;
		}
		
		private async Task<bool> AllianceIconsTest()
		{
			Icon allianceIcons = await _wrapper.GetAllianceIconsAsync(TEST_ALLIANCE_ID);
			bool ret = 
				!string.IsNullOrEmpty(allianceIcons.px64x64) |
				!string.IsNullOrEmpty(allianceIcons.px128x128) |
				!string.IsNullOrEmpty(allianceIcons.px256x256) |
				!string.IsNullOrEmpty(allianceIcons.px512x512);
			return ret;
		}
	}
}