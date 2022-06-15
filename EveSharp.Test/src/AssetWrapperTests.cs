using EveSharp.Core.Models.Asset;
using EveSharp.Infrastructure.Models;
using EveSharp.Infrastructure.Models.Wrappers;

internal class AssetWrapperTests
{
	private OAuth2Token _token;
	private JsonWebKeySet _jwks;
	private readonly int _characterId;
	private readonly AssetWrapper _wrapper;
	
	internal AssetWrapperTests(OAuth2Token token, JsonWebKeySet jwks)
	{
		_token = token;
		_jwks = jwks;
		_characterId = int.Parse(jwks.sub.Split(":")[2]);
		_wrapper = new();
	}
	
	internal async Task<(int, int, int)> Run()
	{
		int totalTests = 0;
		int passedTests = 0;
		totalTests++;
		bool getCharacterAssets = await CharacterAssetsTest();
		if (getCharacterAssets) passedTests++;
		Console.WriteLine($"Get character assets: {getCharacterAssets}");
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
}