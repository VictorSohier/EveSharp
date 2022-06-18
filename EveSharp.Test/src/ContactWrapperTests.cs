using EveSharp.Core.Models.Contacts;
using EveSharp.Infrastructure.Enums;
using EveSharp.Infrastructure.Models;
using EveSharp.Infrastructure.Models.Wrappers;

namespace EveSharp.Test
{
	internal class ContactWrapperTests
	{
		private OAuth2Token _token;
		private JsonWebKeySet _jwks;
		private readonly int _characterId;
		private readonly ContactWrapper _wrapper = new();
		private const int TEST_CONTACT_ID = 2114410380; // Mokaam Racor's ID
		
		// This class needs more tests regarding labels, corporations and alliances
		internal ContactWrapperTests(ref OAuth2Token token, ref JsonWebKeySet jwks)
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
			bool addContacts = await AddCharacterContacts();
			totalTests++;
			bool getContacts = await GetCharacterContacts();
			totalTests++;
			bool updateContacts = await UpdateCharacterContacts();
			totalTests++;
			bool removeContacts = await DeleteCharacterContacts();
			if (addContacts) passedTests++;
			if (getContacts) passedTests++;
			if (updateContacts) passedTests++;
			if (removeContacts) passedTests++;
			Console.WriteLine($"Create Contacts: {addContacts}");
			Console.WriteLine($"Read Contacts: {getContacts}");
			Console.WriteLine($"Update Contacts: {updateContacts}");
			Console.WriteLine($"Delete Contacts: {removeContacts}");
			return (totalTests, passedTests, totalTests - passedTests);
		}
		
		// This test probably fails due to the caching of the read endpoint
		private async Task<bool> AddCharacterContacts()
		{
			if (_jwks.exp > DateTimeOffset.Now.ToUnixTimeSeconds() + 5)
			{
				_token = await OAuth2Wrapper._instance.NativeTokenRefresh(_token.refreshToken);
				(_jwks, _) = await OAuth2Wrapper._instance.VerifyToken(_token);
			}
			int[] newContacts = await _wrapper.BulkSetCharacterContacts(_token, _characterId, 10, DataSources.tranquility, TEST_CONTACT_ID);
			Contact[] contacts = await _wrapper.GetCharacterContactsAsync(_token, _characterId);
			bool ret = newContacts.Length > 0;
			ret &= contacts.First(e => e.contactId == TEST_CONTACT_ID).standing == 10;
			return ret;
		}
		
		// This test probably fails due to the caching of the read endpoint
		private async Task<bool> GetCharacterContacts()
		{
			if (_jwks.exp > DateTimeOffset.Now.ToUnixTimeSeconds() + 5)
			{
				_token = await OAuth2Wrapper._instance.NativeTokenRefresh(_token.refreshToken);
				(_jwks, _) = await OAuth2Wrapper._instance.VerifyToken(_token);
			}
			Contact[] contacts = await _wrapper.GetCharacterContactsAsync(_token, _characterId);
			bool ret = contacts.Length > 0;
			SoAContact soaContacts = new(contacts);
			ret &= soaContacts.contactIds.Contains(TEST_CONTACT_ID);
			if (!ret) return ret;
			Contact contact = contacts.First(e => e.contactId == TEST_CONTACT_ID);
			ret &= contact.standing == 10;
			return ret;
		}
		
		// This test probably fails due to the caching of the read endpoint
		private async Task<bool> UpdateCharacterContacts()
		{
			if (_jwks.exp > DateTimeOffset.Now.ToUnixTimeSeconds() + 5)
			{
				_token = await OAuth2Wrapper._instance.NativeTokenRefresh(_token.refreshToken);
				(_jwks, _) = await OAuth2Wrapper._instance.VerifyToken(_token);
			}
			await _wrapper.BulkUpdateCharacterContacts(_token, _characterId, -10, DataSources.tranquility, TEST_CONTACT_ID);
			Contact[] contacts = await _wrapper.GetCharacterContactsAsync(_token, _characterId);
			bool ret = contacts.First(e => e.contactId == TEST_CONTACT_ID).standing == -10;
			return ret;
		}
		
		// This test probably fails due to the caching of the read endpoint
		private async Task<bool> DeleteCharacterContacts()
		{
			if (_jwks.exp > DateTimeOffset.Now.ToUnixTimeSeconds() + 5)
			{
				_token = await OAuth2Wrapper._instance.NativeTokenRefresh(_token.refreshToken);
				(_jwks, _) = await OAuth2Wrapper._instance.VerifyToken(_token);
			}
			await _wrapper.RemoveCharacterContactsAsync(_token, _characterId, DataSources.tranquility, TEST_CONTACT_ID);
			SoAContact contacts = new(await _wrapper.GetCharacterContactsAsync(_token, _characterId));
			bool ret = !contacts.contactIds.Contains(TEST_CONTACT_ID);
			return ret;
		}
	}
}