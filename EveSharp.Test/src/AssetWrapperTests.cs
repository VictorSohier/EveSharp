using EveSharp.Core.Models.Asset;
using EveSharp.Infrastructure.Models;
using EveSharp.Infrastructure.Models.Wrappers;
using EveSharp.Infrastructure.Enums;

namespace EveSharp.Test
{
	internal class AssetWrapperTests
	{
		private OAuth2Token _token;
		private JsonWebKeySet _jwks;
		private readonly int _characterId;
		private readonly AssetWrapper _wrapper = new();
		
		internal AssetWrapperTests(ref OAuth2Token token, ref JsonWebKeySet jwks)
		{
			_token = token;
			_jwks = jwks;
			_characterId = int.Parse(jwks.sub.Split(":")[2]);
		}
		
		internal async Task<(int, int, int)> Run()
		{
			int totalTests = 0;
			int passedTests = 0;
			totalTests++;
			bool getCharacterAssets = await CharacterAssetsTest();
			totalTests++;
			bool getCharacterAssetLocations = await CharacterAssetLocationsTest();
			totalTests++;
			bool getCharacterAssetNames = await CharacterAssetNamesTest();
			if (getCharacterAssets) passedTests++;
			if (getCharacterAssetLocations) passedTests++;
			if (getCharacterAssetNames) passedTests++;
			Console.WriteLine($"Get character assets: {getCharacterAssets}");
			Console.WriteLine($"Get character asset locations: {getCharacterAssetLocations}");
			Console.WriteLine($"Get character asset names: {getCharacterAssetNames}");
			return (totalTests, passedTests, totalTests - passedTests);
		}
		
		private async Task<bool> CharacterAssetsTest()
		{
			if (_jwks.exp > DateTimeOffset.Now.ToUnixTimeSeconds() + 5)
			{
				_token = await OAuth2Wrapper._instance.NativeTokenRefresh(_token.refreshToken);
				(_jwks, _) = await OAuth2Wrapper._instance.VerifyToken(_token);
			}
			Asset[] assets = await _wrapper.GetCharacterAssetsAsync(_token, _characterId);
			bool ret = assets.Length > 0;
			return ret;
		}
		
		private async Task<bool> CharacterAssetLocationsTest()
		{
			if (_jwks.exp > DateTimeOffset.Now.ToUnixTimeSeconds() + 5)
			{
				_token = await OAuth2Wrapper._instance.NativeTokenRefresh(_token.refreshToken);
				(_jwks, _) = await OAuth2Wrapper._instance.VerifyToken(_token);
			}
			AssetLocation[] assetLocations = await _wrapper.GetCharacterAssetLocationsAsync(_token, _characterId, DataSources.tranquility, (await _wrapper.GetCharacterAssetsAsync(_token, _characterId)).Select(e => e.itemId).ToArray());
			bool ret = assetLocations.Length > 0;
			return ret;
		}
		
		private async Task<bool> CharacterAssetNamesTest()
		{
			if (_jwks.exp > DateTimeOffset.Now.ToUnixTimeSeconds() + 5)
			{
				_token = await OAuth2Wrapper._instance.NativeTokenRefresh(_token.refreshToken);
				(_jwks, _) = await OAuth2Wrapper._instance.VerifyToken(_token);
			}
			AssetName[] assetNames = await _wrapper.GetCharacterAssetNamesAsync(_token, _characterId, DataSources.tranquility, (await _wrapper.GetCharacterAssetsAsync(_token, _characterId)).Select(e => e.itemId).ToArray());
			bool ret = assetNames.Length > 0;
			return ret;
		}
	}
}