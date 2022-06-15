using System.Net.Http.Json;
using EveSharp.Core.Models.Contacts;
using EveSharp.Infrastructure.Enums;
using Newtonsoft.Json;

namespace EveSharp.Infrastructure.Models.Wrappers
{
	public class ContactWrapper
	{
		private readonly HttpClient _client;
		private readonly JsonSerializer _serializer;
		
		public ContactWrapper()
		{
			_client = new();
			_client.BaseAddress = new($"{WrapperConfig._instance.DOMAIN}");
			_serializer = WrapperConfig._instance.SERIALIZER;
		}
		
		public async Task<Contact[]> GetAllianceContactsAsync(OAuth2Token token, int allianceId, int page = 1, DataSources datasource = DataSources.tranquility)
		{
			_client.DefaultRequestHeaders.Remove("Authorization");
			_client.DefaultRequestHeaders.Add("Authorization", $"{token.tokenType} {token.accessToken}");
			HttpResponseMessage message = await _client.GetAsync($"/{WrapperConfig._instance.API_VERSION}/alliances/{allianceId}/contacts?datasource={Enum.GetName(datasource)?.ToLower()}&page={page}");
			Contact[] ret;
			if (WrapperConfig._instance.SUCCESS.Contains(message.StatusCode))
			{
				ret = _serializer.Deserialize<Contact[]>(new JsonTextReader(new StreamReader(await message.Content.ReadAsStreamAsync())));
				return ret;
			}
			throw new Exception(_serializer.Deserialize<Error>(new JsonTextReader(new StreamReader(await message.Content.ReadAsStreamAsync()))).error);
		}
		
		public async Task<ContactLabel[]> GetAllianceContactLabelsAsync(OAuth2Token token, int allianceId, DataSources datasource = DataSources.tranquility)
		{
			_client.DefaultRequestHeaders.Remove("Authorization");
			_client.DefaultRequestHeaders.Add("Authorization", $"{token.tokenType} {token.accessToken}");
			HttpResponseMessage message = await _client.GetAsync($"/{WrapperConfig._instance.API_VERSION}/alliances/{allianceId}/contacts/labels?datasource={Enum.GetName(datasource)?.ToLower()}");
			ContactLabel[] ret;
			if (WrapperConfig._instance.SUCCESS.Contains(message.StatusCode))
			{
				ret = _serializer.Deserialize<ContactLabel[]>(new JsonTextReader(new StreamReader(await message.Content.ReadAsStreamAsync())));
				return ret;
			}
			throw new Exception(_serializer.Deserialize<Error>(new JsonTextReader(new StreamReader(await message.Content.ReadAsStreamAsync()))).error);
		}
		
		public async Task GetCharacterContactsAsync(OAuth2Token token, int characterId, DataSources datasource = DataSources.tranquility, params int[] contactIds)
		{
			_client.DefaultRequestHeaders.Remove("Authorization");
			_client.DefaultRequestHeaders.Add("Authorization", $"{token.tokenType} {token.accessToken}");
			string payload = string.Join(",", contactIds);
			await _client.DeleteAsync($"/{WrapperConfig._instance.API_VERSION}/characters/{characterId}/contacts?datasource={Enum.GetName(datasource)?.ToLower()}&contact_ids={payload}");
		}
		
		public async Task<Contact[]> GetCharacterContactsAsync(OAuth2Token token, int characterId, int page = 1, DataSources datasource = DataSources.tranquility)
		{
			_client.DefaultRequestHeaders.Remove("Authorization");
			_client.DefaultRequestHeaders.Add("Authorization", $"{token.tokenType} {token.accessToken}");
			HttpResponseMessage message = await _client.GetAsync($"/{WrapperConfig._instance.API_VERSION}/characters/{characterId}/contacts?datasource={Enum.GetName(datasource)?.ToLower()}&page={page}");
			Contact[] ret;
			if (WrapperConfig._instance.SUCCESS.Contains(message.StatusCode))
			{
				ret = _serializer.Deserialize<Contact[]>(new JsonTextReader(new StreamReader(await message.Content.ReadAsStreamAsync())));
				return ret;
			}
			throw new Exception(_serializer.Deserialize<Error>(new JsonTextReader(new StreamReader(await message.Content.ReadAsStreamAsync()))).error);
		}
		
		public async Task<int[]> BulkSetCharacterContacts(OAuth2Token token, int characterId, float standing, DataSources datasource = DataSources.tranquility, params int[] newContactIds)
		{
			_client.DefaultRequestHeaders.Remove("Authorization");
			_client.DefaultRequestHeaders.Add("Authorization", $"{token.tokenType} {token.accessToken}");
			HttpResponseMessage message = await _client.PostAsync($"characters/{characterId}/contacts?datasource={Enum.GetName(datasource)?.ToLower()}&standing={standing}", JsonContent.Create(newContactIds));
			int[] ret;
			if (WrapperConfig._instance.SUCCESS.Contains(message.StatusCode))
			{
				ret = _serializer.Deserialize<int[]>(new JsonTextReader(new StreamReader(await message.Content.ReadAsStreamAsync())));
				return ret;
			}
			throw new Exception(_serializer.Deserialize<Error>(new JsonTextReader(new StreamReader(await message.Content.ReadAsStreamAsync()))).error);
		}
		
		public async Task<int[]> BulkSetCharacterContacts(OAuth2Token token, int characterId, float standing, SoAContactLabelAssociation newContacts, bool watched = false, DataSources datasource = DataSources.tranquility)
		{
			_client.DefaultRequestHeaders.Remove("Authorization");
			_client.DefaultRequestHeaders.Add("Authorization", $"{token.tokenType} {token.accessToken}");
			string payload = string.Join(",", newContacts.labelIds);
			HttpResponseMessage message = await _client.PostAsync($"characters/{characterId}/contacts?datasource={Enum.GetName(datasource)?.ToLower()}&standing={standing}$label_ids={payload}&watched={watched}", JsonContent.Create(newContacts.contactIds));
			int[] ret;
			if (WrapperConfig._instance.SUCCESS.Contains(message.StatusCode))
			{
				ret = _serializer.Deserialize<int[]>(new JsonTextReader(new StreamReader(await message.Content.ReadAsStreamAsync())));
				return ret;
			}
			throw new Exception(_serializer.Deserialize<Error>(new JsonTextReader(new StreamReader(await message.Content.ReadAsStreamAsync()))).error);
		}
		
		public async Task<int[]> BulkUpdateCharacterContacts(OAuth2Token token, int characterId, float standing, DataSources datasource = DataSources.tranquility, params int[] newContactIds)
		{
			_client.DefaultRequestHeaders.Remove("Authorization");
			_client.DefaultRequestHeaders.Add("Authorization", $"{token.tokenType} {token.accessToken}");
			HttpResponseMessage message = await _client.PutAsync($"characters/{characterId}/contacts?datasource={Enum.GetName(datasource)?.ToLower()}&standing={standing}", JsonContent.Create(newContactIds));
			int[] ret;
			if (WrapperConfig._instance.SUCCESS.Contains(message.StatusCode))
			{
				ret = _serializer.Deserialize<int[]>(new JsonTextReader(new StreamReader(await message.Content.ReadAsStreamAsync())));
				return ret;
			}
			throw new Exception(_serializer.Deserialize<Error>(new JsonTextReader(new StreamReader(await message.Content.ReadAsStreamAsync()))).error);
		}
		
		public async Task<int[]> BulkUpdateCharacterContacts(OAuth2Token token, int characterId, float standing, SoAContactLabelAssociation newContacts, bool watched = false, DataSources datasource = DataSources.tranquility)
		{
			_client.DefaultRequestHeaders.Remove("Authorization");
			_client.DefaultRequestHeaders.Add("Authorization", $"{token.tokenType} {token.accessToken}");
			string payload = string.Join(",", newContacts.labelIds);
			HttpResponseMessage message = await _client.PutAsync($"characters/{characterId}/contacts?datasource={Enum.GetName(datasource)?.ToLower()}&standing={standing}$label_ids={payload}&watched={watched}", JsonContent.Create(newContacts.contactIds));
			int[] ret;
			if (WrapperConfig._instance.SUCCESS.Contains(message.StatusCode))
			{
				ret = _serializer.Deserialize<int[]>(new JsonTextReader(new StreamReader(await message.Content.ReadAsStreamAsync())));
				return ret;
			}
			throw new Exception(_serializer.Deserialize<Error>(new JsonTextReader(new StreamReader(await message.Content.ReadAsStreamAsync()))).error);
		}
		
		public async Task<ContactLabel[]> GetCharacterContactLabelsAsync(OAuth2Token token, int characterId, DataSources datasource = DataSources.tranquility)
		{
			_client.DefaultRequestHeaders.Remove("Authorization");
			_client.DefaultRequestHeaders.Add("Authorization", $"{token.tokenType} {token.accessToken}");
			HttpResponseMessage message = await _client.GetAsync($"/{WrapperConfig._instance.API_VERSION}/characters/{characterId}/contacts/labels?datasource={Enum.GetName(datasource)?.ToLower()}");
			ContactLabel[] ret;
			if (WrapperConfig._instance.SUCCESS.Contains(message.StatusCode))
			{
				ret = _serializer.Deserialize<ContactLabel[]>(new JsonTextReader(new StreamReader(await message.Content.ReadAsStreamAsync())));
				return ret;
			}
			throw new Exception(_serializer.Deserialize<Error>(new JsonTextReader(new StreamReader(await message.Content.ReadAsStreamAsync()))).error);
		}
		
		public async Task<Contact[]> GetCorporationContactsAsync(OAuth2Token token, int corporationId, int page = 1, DataSources datasource = DataSources.tranquility)
		{
			_client.DefaultRequestHeaders.Remove("Authorization");
			_client.DefaultRequestHeaders.Add("Authorization", $"{token.tokenType} {token.accessToken}");
			HttpResponseMessage message = await _client.GetAsync($"/{WrapperConfig._instance.API_VERSION}/corporations/{corporationId}/contacts?datasource={Enum.GetName(datasource)?.ToLower()}&page={page}");
			Contact[] ret;
			if (WrapperConfig._instance.SUCCESS.Contains(message.StatusCode))
			{
				ret = _serializer.Deserialize<Contact[]>(new JsonTextReader(new StreamReader(await message.Content.ReadAsStreamAsync())));
				return ret;
			}
			throw new Exception(_serializer.Deserialize<Error>(new JsonTextReader(new StreamReader(await message.Content.ReadAsStreamAsync()))).error);
		}
		
		public async Task<ContactLabel[]> GetCorporationContactLabelsAsync(OAuth2Token token, int corporationId, DataSources datasource = DataSources.tranquility)
		{
			_client.DefaultRequestHeaders.Remove("Authorization");
			_client.DefaultRequestHeaders.Add("Authorization", $"{token.tokenType} {token.accessToken}");
			HttpResponseMessage message = await _client.GetAsync($"/{WrapperConfig._instance.API_VERSION}/corporations/{corporationId}/contacts/labels?datasource={Enum.GetName(datasource)?.ToLower()}");
			ContactLabel[] ret;
			if (WrapperConfig._instance.SUCCESS.Contains(message.StatusCode))
			{
				ret = _serializer.Deserialize<ContactLabel[]>(new JsonTextReader(new StreamReader(await message.Content.ReadAsStreamAsync())));
				return ret;
			}
			throw new Exception(_serializer.Deserialize<Error>(new JsonTextReader(new StreamReader(await message.Content.ReadAsStreamAsync()))).error);
		}
	}
}