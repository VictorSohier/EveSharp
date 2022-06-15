using EveSharp.Core.Models.Bookmark;
using EveSharp.Core.Models.Character;
using EveSharp.Infrastructure.Models;
using EveSharp.Infrastructure.Models.Wrappers;

namespace EveSharp.Test
{
	internal class BookmarkWrapperTests
	{
		private OAuth2Token _token;
		private JsonWebKeySet _jwks;
		private readonly int _characterId;
		private readonly CharacterWrapper _characterWrapper = new();
		private readonly BookmarkWrapper _bookmarkWrapper = new();
		
		internal BookmarkWrapperTests(ref OAuth2Token token, ref JsonWebKeySet jwks)
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
			bool getCharacterBookmarks = await CharacterBookmarks();
			totalTests++;
			bool getCharacterBookmarkFolders = await CharacterBookmarkFolders();
			// totalTests++;
			// bool getCorporationBookmarks = await CorporationBookmarks();
			// totalTests++;
			// bool getCorporationBookmarkFolders = await CorporationBookmarkFolders();
			if (getCharacterBookmarks) passedTests++;
			if (getCharacterBookmarkFolders) passedTests++;
			// if (getCorporationBookmarks) passedTests++;
			// if (getCorporationBookmarkFolders) passedTests++;
			Console.WriteLine($"Get character bookmarks: {getCharacterBookmarks}");
			Console.WriteLine($"Get character bookmark folders: {getCharacterBookmarkFolders}");
			// Console.WriteLine($"Get corporation bookmarks: {getCorporationBookmarks}");
			// Console.WriteLine($"Get corporation bookmark folders: {getCorporationBookmarkFolders}");
			return (totalTests, passedTests, totalTests - passedTests);
		}
		
		private async Task<bool> CharacterBookmarks()
		{
			if (_jwks.exp > DateTimeOffset.Now.ToUnixTimeSeconds() + 5)
			{
				_token = await OAuth2Wrapper._instance.NativeTokenRefresh(_token.refreshToken);
				(_jwks, _) = await OAuth2Wrapper._instance.VerifyToken(_token);
			}
			Bookmark[] bookmarks = await _bookmarkWrapper.GetCharacterBookmarksAsync(_token, _characterId);
			bool ret = bookmarks.Length > 0;
			return ret;
		}
		
		private async Task<bool> CharacterBookmarkFolders()
		{
			if (_jwks.exp > DateTimeOffset.Now.ToUnixTimeSeconds() + 5)
			{
				_token = await OAuth2Wrapper._instance.NativeTokenRefresh(_token.refreshToken);
				(_jwks, _) = await OAuth2Wrapper._instance.VerifyToken(_token);
			}
			Folder[] folders = await _bookmarkWrapper.GetCharacterBookmarkFoldersAsync(_token, _characterId);
			bool ret = folders.Length > 0;
			return ret;
		}
		
		private async Task<bool> CorporationBookmarks()
		{
			if (_jwks.exp > DateTimeOffset.Now.ToUnixTimeSeconds() + 5)
			{
				_token = await OAuth2Wrapper._instance.NativeTokenRefresh(_token.refreshToken);
				(_jwks, _) = await OAuth2Wrapper._instance.VerifyToken(_token);
			}
			Character character = await _characterWrapper.GetCharacterAsync(_characterId);
			Bookmark[] bookmarks = await _bookmarkWrapper.GetCorporationBookmarksAsync(_token, character.corporationId);
			bool ret = bookmarks.Length > 0;
			return ret;
		}
		
		private async Task<bool> CorporationBookmarkFolders()
		{
			if (_jwks.exp > DateTimeOffset.Now.ToUnixTimeSeconds() + 5)
			{
				_token = await OAuth2Wrapper._instance.NativeTokenRefresh(_token.refreshToken);
				(_jwks, _) = await OAuth2Wrapper._instance.VerifyToken(_token);
			}
			Character character = await _characterWrapper.GetCharacterAsync(_characterId);
			Folder[] folders = await _bookmarkWrapper.GetCorporationBookmarkFoldersAsync(_token, character.corporationId);
			bool ret = folders.Length > 0;
			return ret;
		}
	}
}