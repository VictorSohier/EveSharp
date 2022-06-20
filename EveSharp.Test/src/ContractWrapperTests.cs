using EveSharp.Core.Enums.Contracts;
using EveSharp.Core.Models.Contracts;
using EveSharp.Infrastructure.Models;
using EveSharp.Infrastructure.Models.Wrappers;

namespace EveSharp.Test
{
	internal class ContractWrapperTests
	{
		private OAuth2Token _token;
		private JsonWebKeySet _jwks;
		private readonly int _characterId;
		private readonly ContractWrapper _wrapper = new();
		private const int TEST_REGION_ID = 10000002; // The Forge
		private const int TEST_CORPORATION_ID = 0;
		
		internal ContractWrapperTests(ref OAuth2Token token, ref JsonWebKeySet jwks)
		{
			_token = token;
			_jwks = jwks;
			_characterId = int.Parse(jwks.sub.Split(":")[2]);
		}
		
		internal async Task<(int, int, int)> Run()
		{
			int totalTests = 0;
			int passedTests = 0;
			bool characterContractBids = false;
			bool characterContractItems = false;
			bool publicContractBids = false;
			bool publicContractItems = false;
			bool corporationContractItems = false;
			bool corporationContractBids = false;
			totalTests++;
			(bool characterContracts, int characterContractId) = await CharacterContracts();
			Console.WriteLine($"Character contracts: {characterContracts}");
			if (characterContracts)
			{
				passedTests++;
				totalTests++;
				characterContractBids = await CharacterContractBids(characterContractId);
				Console.WriteLine($"Character contract bids: {characterContractBids}");
				totalTests++;
				characterContractItems = await CharacterContractItems(characterContractId);
				Console.WriteLine($"Character contract items: {characterContractItems}");
			}
			(bool publicContracts, int publicContractId) = await PublicContracts();
			Console.WriteLine($"Public contracts: {publicContracts}");
			if (publicContracts)
			{
				passedTests++;
				totalTests++;
				publicContractBids = await PublicContractBids(publicContractId);
				Console.WriteLine($"Public contract bids: {publicContractBids}");
				totalTests++;
				publicContractItems = await PublicContractItems(publicContractId);
				Console.WriteLine($"Public contract items: {publicContractItems}");
			}
			// TODO: need to get a corp to meaningfully test this
			// (bool corporationContracts, int corporationContractId) = await CorporationContracts();
			// Console.WriteLine($"Corporation contracts: {corporationContracts}");
			// if (characterContracts)
			// {
			// 	passedTests++;
			// 	totalTests++;
			// 	corporationContractBids = await CorporationContractBids(publicContractId);
			// 	Console.WriteLine($"Corporation contract bids: {corporationContractBids}");
			// 	totalTests++;
			// 	corporationContractItems = await CorporationContractItems(publicContractId);
			// 	Console.WriteLine($"Corporation contract items: {corporationContractItems}");
			// }
			if (characterContractBids) passedTests++;
			if (characterContractItems) passedTests++;
			if (publicContractBids) passedTests++;
			if (publicContractItems) passedTests++;
			if (corporationContractBids) passedTests++;
			if (corporationContractItems) passedTests++;
			return (totalTests, passedTests, totalTests - passedTests);
		}
		
		private async Task<(bool, int)> CharacterContracts()
		{
			if (_jwks.exp > DateTimeOffset.Now.ToUnixTimeSeconds() + 5)
			{
				_token = await OAuth2Wrapper._instance.NativeTokenRefresh(_token.refreshToken);
				(_jwks, _) = await OAuth2Wrapper._instance.VerifyToken(_token);
			}
			Contract[] contracts = await _wrapper.GetCharacterContractsAsync(_token, _characterId);
			bool ret = contracts.Any(e => e.type == ContractType.Auction);
			if (ret)
				return (ret, contracts.First(e => e.type == ContractType.Auction).contractId);
			return (ret, 0);
		}
		
		private async Task<bool> CharacterContractBids(int contractId)
		{
			if (_jwks.exp > DateTimeOffset.Now.ToUnixTimeSeconds() + 5)
			{
				_token = await OAuth2Wrapper._instance.NativeTokenRefresh(_token.refreshToken);
				(_jwks, _) = await OAuth2Wrapper._instance.VerifyToken(_token);
			}
			Bid[] bids = await _wrapper.GetCharacterContractBidsAsync(_token, _characterId, contractId);
			bool ret = bids.Length > 0;
			return ret;
		}
		
		private async Task<bool> CharacterContractItems(int contractId)
		{
			if (_jwks.exp > DateTimeOffset.Now.ToUnixTimeSeconds() + 5)
			{
				_token = await OAuth2Wrapper._instance.NativeTokenRefresh(_token.refreshToken);
				(_jwks, _) = await OAuth2Wrapper._instance.VerifyToken(_token);
			}
			Item[] items = await _wrapper.GetCharacterContractItemsAsync(_token, _characterId, contractId);
			int itemIndex = items.ToList().FindIndex(e => e.typeId == 17470);
			bool ret = itemIndex > -1;
			if (!ret) return ret;
			ret &= items[itemIndex].quantity != 0;
			return ret;
		}
		
		private async Task<(bool, int)> PublicContracts()
		{
			Contract[] contracts = await _wrapper.GetPublicContractsAsync(TEST_REGION_ID);
			bool ret = contracts.Length > 0;
			contracts = new Contract[0];
			bool stop = false;
			int page = 1;
			int lastArrayCount = 0;
			while (!stop && !contracts.Any(e => e.type == ContractType.Auction))
			{
				try
				{
					Contract[] tmp = await _wrapper.GetPublicContractsAsync(TEST_REGION_ID, page);
					Array.Resize(ref contracts, contracts.Length + tmp.Length);
					Array.Copy(tmp, 0, contracts, contracts.Length - tmp.Length, tmp.Length);
					if (tmp.Length < lastArrayCount) stop = true;
					lastArrayCount = tmp.Length;
				}
				catch (Exception e)
				{
					break;
				}
				page++;
			}
			return (ret, contracts.First(e => e.type == ContractType.Auction).contractId);
		}
		
		private async Task<bool> PublicContractBids(int contractId)
		{
			Bid[] bids = await _wrapper.GetPublicContractBidsAsync(contractId);
			bool ret = bids.Length > 0;
			return ret;
		}
		
		private async Task<bool> PublicContractItems(int contractId)
		{
			Item[] items = await _wrapper.GetPublicContractItemsAsync(contractId);
			bool ret = items.Length > 0;
			return ret;
		}
		
		private async Task<(bool, int)> CorporationContracts()
		{
			if (_jwks.exp > DateTimeOffset.Now.ToUnixTimeSeconds() + 5)
			{
				_token = await OAuth2Wrapper._instance.NativeTokenRefresh(_token.refreshToken);
				(_jwks, _) = await OAuth2Wrapper._instance.VerifyToken(_token);
			}
			Contract[] contracts = await _wrapper.GetCorporationContractsAsync(_token, TEST_CORPORATION_ID);
			bool ret = contracts.Length > 0;
			return (ret, contracts.First(e => e.type == ContractType.Auction).contractId);
		}
		
		private async Task<bool> CorporationContractBids(int contractId)
		{
			if (_jwks.exp > DateTimeOffset.Now.ToUnixTimeSeconds() + 5)
			{
				_token = await OAuth2Wrapper._instance.NativeTokenRefresh(_token.refreshToken);
				(_jwks, _) = await OAuth2Wrapper._instance.VerifyToken(_token);
			}
			Bid[] bids = await _wrapper.GetCorporationContractBidsAsync(_token, TEST_CORPORATION_ID, contractId);
			bool ret = bids.Length > 0;
			return ret;
		}
		
		private async Task<bool> CorporationContractItems(int contractId)
		{
			if (_jwks.exp > DateTimeOffset.Now.ToUnixTimeSeconds() + 5)
			{
				_token = await OAuth2Wrapper._instance.NativeTokenRefresh(_token.refreshToken);
				(_jwks, _) = await OAuth2Wrapper._instance.VerifyToken(_token);
			}
			Item[] items = await _wrapper.GetCorporationContractItemsAsync(_token, TEST_CORPORATION_ID, contractId);
			bool ret = items.Length > 0;
			return ret;
		}
	}
}