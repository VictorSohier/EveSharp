using System.Net.Http.Json;
using EveSharp.Core.Models.Contacts;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace EveSharp.Infrastructure.Models
{
	public class ContactWrapper
	{
		private readonly HttpClient _client;
		private readonly JsonSerializer _serializer;
		
		public ContactWrapper(string authToken)
		{
			_client = new();
			_client.BaseAddress = new($"https://esi.evetech.net/{WrapperConfig._instance.API_VERSION}");
			_client.DefaultRequestHeaders.Add("authorization", authToken);
			_serializer = WrapperConfig._instance.SERIALIZER;
		}
		
		public async Task<Contact[]> GetAllianceContactsAsync(int allianceId, int page = 1, string datasource = "tranquilty")
		{
			HttpResponseMessage message = await _client.GetAsync($"alliances/{allianceId}/contacts?datasource={datasource}&page={page}");
			Contact[] ret = _serializer.Deserialize<Contact[]>(new JsonTextReader(new StreamReader(await message.Content.ReadAsStreamAsync())));
			return ret;
		}
		
		public async Task<ContactLabel[]> GetAllianceContactLabelsAsync(int allianceId, string datasource = "tranquilty")
		{
			HttpResponseMessage message = await _client.GetAsync($"alliances/{allianceId}/contacts/labels?datasource={datasource}");
			ContactLabel[] ret = _serializer.Deserialize<ContactLabel[]>(new JsonTextReader(new StreamReader(await message.Content.ReadAsStreamAsync())));
			return ret;
		}
		
		public async Task GetCharacterContactsAsync(int characterId, string datasource = "tranquilty", params int[] contactIds)
		{
			string payload = string.Join(",", contactIds);
			await _client.DeleteAsync($"characters/{characterId}/contacts?datasource={datasource}&contact_ids={payload}");
		}
		
		public async Task<Contact[]> GetCharacterContactsAsync(int characterId, int page = 1, string datasource = "tranquilty")
		{
			HttpResponseMessage message = await _client.GetAsync($"characters/{characterId}/contacts?datasource={datasource}&page={page}");
			Contact[] ret = _serializer.Deserialize<Contact[]>(new JsonTextReader(new StreamReader(await message.Content.ReadAsStreamAsync())));
			return ret;
		}
		
		public async Task<int[]> BulkSetCharacterContacts(int characterId, float standing, string datasource = "tranquility", params int[] newContactIds)
		{
			HttpResponseMessage message = await _client.PostAsync($"characters/{characterId}/contacts?datasource={datasource}&standing={standing}", JsonContent.Create(newContactIds));
			int[] ret = _serializer.Deserialize<int[]>(new JsonTextReader(new StreamReader(await message.Content.ReadAsStreamAsync())));
			return ret;
		}
		
		public async Task<int[]> BulkSetCharacterContacts(int characterId, float standing, BulkContactLabelAssociations newContacts, bool watched = false, string datasource = "tranquility")
		{
			string payload = string.Join(",", newContacts.labelIds);
			HttpResponseMessage message = await _client.PostAsync($"characters/{characterId}/contacts?datasource={datasource}&standing={standing}$label_ids={payload}&watched={watched}", JsonContent.Create(newContacts.contactIds));
			int[] ret = _serializer.Deserialize<int[]>(new JsonTextReader(new StreamReader(await message.Content.ReadAsStreamAsync())));
			return ret;
		}
		
		public async Task<int[]> BulkUpdateCharacterContacts(int characterId, float standing, string datasource = "tranquility", params int[] newContactIds)
		{
			HttpResponseMessage message = await _client.PutAsync($"characters/{characterId}/contacts?datasource={datasource}&standing={standing}", JsonContent.Create(newContactIds));
			int[] ret = _serializer.Deserialize<int[]>(new JsonTextReader(new StreamReader(await message.Content.ReadAsStreamAsync())));
			return ret;
		}
		
		public async Task<int[]> BulkUpdateCharacterContacts(int characterId, float standing, BulkContactLabelAssociations newContacts, bool watched = false, string datasource = "tranquility")
		{
			string payload = string.Join(",", newContacts.labelIds);
			HttpResponseMessage message = await _client.PutAsync($"characters/{characterId}/contacts?datasource={datasource}&standing={standing}$label_ids={payload}&watched={watched}", JsonContent.Create(newContacts.contactIds));
			int[] ret = _serializer.Deserialize<int[]>(new JsonTextReader(new StreamReader(await message.Content.ReadAsStreamAsync())));
			return ret;
		}
		
		public async Task<ContactLabel[]> GetCharacterContactLabelsAsync(int characterId, string datasource = "tranquilty")
		{
			HttpResponseMessage message = await _client.GetAsync($"characters/{characterId}/contacts/labels?datasource={datasource}");
			ContactLabel[] ret = _serializer.Deserialize<ContactLabel[]>(new JsonTextReader(new StreamReader(await message.Content.ReadAsStreamAsync())));
			return ret;
		}
		
		public async Task<Contact[]> GetCorporationContactsAsync(int corporationId, int page = 1, string datasource = "tranquilty")
		{
			HttpResponseMessage message = await _client.GetAsync($"corporations/{corporationId}/contacts?datasource={datasource}&page={page}");
			Contact[] ret = _serializer.Deserialize<Contact[]>(new JsonTextReader(new StreamReader(await message.Content.ReadAsStreamAsync())));
			return ret;
		}
		
		public async Task<ContactLabel[]> GetCorporationContactLabelsAsync(int corporationId, string datasource = "tranquilty")
		{
			HttpResponseMessage message = await _client.GetAsync($"corporations/{corporationId}/contacts/labels?datasource={datasource}");
			ContactLabel[] ret = _serializer.Deserialize<ContactLabel[]>(new JsonTextReader(new StreamReader(await message.Content.ReadAsStreamAsync())));
			return ret;
		}
	}
}