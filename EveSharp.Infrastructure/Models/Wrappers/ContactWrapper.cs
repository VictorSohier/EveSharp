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
		
		public ContactWrapper(string authToken)
		{
			_client = new();
			_client.BaseAddress = new($"https://esi.evetech.net/{WrapperConfig._instance.API_VERSION}");
			_client.DefaultRequestHeaders.Add("authorization", authToken);
			_serializer = WrapperConfig._instance.SERIALIZER;
		}
		
		public async Task<Contact[]> GetAllianceContactsAsync(int allianceId, int page = 1, DataSources datasource = DataSources.TRANQUILITY)
		{
			HttpResponseMessage message = await _client.GetAsync($"alliances/{allianceId}/contacts?datasource={Enum.GetName<DataSources>(datasource)?.ToLower()}&page={page}");
			Contact[] ret;
			if (WrapperConfig._instance.SUCCESS.Contains(message.StatusCode))
				throw new Exception(_serializer.Deserialize<Error>(new JsonTextReader(new StreamReader(await message.Content.ReadAsStreamAsync()))).error);
			ret = _serializer.Deserialize<Contact[]>(new JsonTextReader(new StreamReader(await message.Content.ReadAsStreamAsync())));
			return ret;
		}
		
		public async Task<ContactLabel[]> GetAllianceContactLabelsAsync(int allianceId, DataSources datasource = DataSources.TRANQUILITY)
		{
			HttpResponseMessage message = await _client.GetAsync($"alliances/{allianceId}/contacts/labels?datasource={Enum.GetName<DataSources>(datasource)?.ToLower()}");
			ContactLabel[] ret;
			if (WrapperConfig._instance.SUCCESS.Contains(message.StatusCode))
				throw new Exception(_serializer.Deserialize<Error>(new JsonTextReader(new StreamReader(await message.Content.ReadAsStreamAsync()))).error);
			ret = _serializer.Deserialize<ContactLabel[]>(new JsonTextReader(new StreamReader(await message.Content.ReadAsStreamAsync())));
			return ret;
		}
		
		public async Task GetCharacterContactsAsync(int characterId, DataSources datasource = DataSources.TRANQUILITY, params int[] contactIds)
		{
			string payload = string.Join(",", contactIds);
			await _client.DeleteAsync($"characters/{characterId}/contacts?datasource={Enum.GetName<DataSources>(datasource)?.ToLower()}&contact_ids={payload}");
		}
		
		public async Task<Contact[]> GetCharacterContactsAsync(int characterId, int page = 1, DataSources datasource = DataSources.TRANQUILITY)
		{
			HttpResponseMessage message = await _client.GetAsync($"characters/{characterId}/contacts?datasource={Enum.GetName<DataSources>(datasource)?.ToLower()}&page={page}");
			Contact[] ret;
			if (WrapperConfig._instance.SUCCESS.Contains(message.StatusCode))
				throw new Exception(_serializer.Deserialize<Error>(new JsonTextReader(new StreamReader(await message.Content.ReadAsStreamAsync()))).error);
			ret = _serializer.Deserialize<Contact[]>(new JsonTextReader(new StreamReader(await message.Content.ReadAsStreamAsync())));
			return ret;
		}
		
		public async Task<int[]> BulkSetCharacterContacts(int characterId, float standing, DataSources datasource = DataSources.TRANQUILITY, params int[] newContactIds)
		{
			HttpResponseMessage message = await _client.PostAsync($"characters/{characterId}/contacts?datasource={Enum.GetName<DataSources>(datasource)?.ToLower()}&standing={standing}", JsonContent.Create(newContactIds));
			int[] ret;
			if (WrapperConfig._instance.SUCCESS.Contains(message.StatusCode))
				throw new Exception(_serializer.Deserialize<Error>(new JsonTextReader(new StreamReader(await message.Content.ReadAsStreamAsync()))).error);
			ret = _serializer.Deserialize<int[]>(new JsonTextReader(new StreamReader(await message.Content.ReadAsStreamAsync())));
			return ret;
		}
		
		public async Task<int[]> BulkSetCharacterContacts(int characterId, float standing, BulkContactLabelAssociations newContacts, bool watched = false, DataSources datasource = DataSources.TRANQUILITY)
		{
			string payload = string.Join(",", newContacts.labelIds);
			HttpResponseMessage message = await _client.PostAsync($"characters/{characterId}/contacts?datasource={Enum.GetName<DataSources>(datasource)?.ToLower()}&standing={standing}$label_ids={payload}&watched={watched}", JsonContent.Create(newContacts.contactIds));
			int[] ret;
			if (WrapperConfig._instance.SUCCESS.Contains(message.StatusCode))
				throw new Exception(_serializer.Deserialize<Error>(new JsonTextReader(new StreamReader(await message.Content.ReadAsStreamAsync()))).error);
			ret = _serializer.Deserialize<int[]>(new JsonTextReader(new StreamReader(await message.Content.ReadAsStreamAsync())));
			return ret;
		}
		
		public async Task<int[]> BulkUpdateCharacterContacts(int characterId, float standing, DataSources datasource = DataSources.TRANQUILITY, params int[] newContactIds)
		{
			HttpResponseMessage message = await _client.PutAsync($"characters/{characterId}/contacts?datasource={Enum.GetName<DataSources>(datasource)?.ToLower()}&standing={standing}", JsonContent.Create(newContactIds));
			int[] ret;
			if (WrapperConfig._instance.SUCCESS.Contains(message.StatusCode))
				throw new Exception(_serializer.Deserialize<Error>(new JsonTextReader(new StreamReader(await message.Content.ReadAsStreamAsync()))).error);
			ret = _serializer.Deserialize<int[]>(new JsonTextReader(new StreamReader(await message.Content.ReadAsStreamAsync())));
			return ret;
		}
		
		public async Task<int[]> BulkUpdateCharacterContacts(int characterId, float standing, BulkContactLabelAssociations newContacts, bool watched = false, DataSources datasource = DataSources.TRANQUILITY)
		{
			string payload = string.Join(",", newContacts.labelIds);
			HttpResponseMessage message = await _client.PutAsync($"characters/{characterId}/contacts?datasource={Enum.GetName<DataSources>(datasource)?.ToLower()}&standing={standing}$label_ids={payload}&watched={watched}", JsonContent.Create(newContacts.contactIds));
			int[] ret;
			if (WrapperConfig._instance.SUCCESS.Contains(message.StatusCode))
				throw new Exception(_serializer.Deserialize<Error>(new JsonTextReader(new StreamReader(await message.Content.ReadAsStreamAsync()))).error);
			ret = _serializer.Deserialize<int[]>(new JsonTextReader(new StreamReader(await message.Content.ReadAsStreamAsync())));
			return ret;
		}
		
		public async Task<ContactLabel[]> GetCharacterContactLabelsAsync(int characterId, DataSources datasource = DataSources.TRANQUILITY)
		{
			HttpResponseMessage message = await _client.GetAsync($"characters/{characterId}/contacts/labels?datasource={Enum.GetName<DataSources>(datasource)?.ToLower()}");
			ContactLabel[] ret;
			if (WrapperConfig._instance.SUCCESS.Contains(message.StatusCode))
				throw new Exception(_serializer.Deserialize<Error>(new JsonTextReader(new StreamReader(await message.Content.ReadAsStreamAsync()))).error);
			ret = _serializer.Deserialize<ContactLabel[]>(new JsonTextReader(new StreamReader(await message.Content.ReadAsStreamAsync())));
			return ret;
		}
		
		public async Task<Contact[]> GetCorporationContactsAsync(int corporationId, int page = 1, DataSources datasource = DataSources.TRANQUILITY)
		{
			HttpResponseMessage message = await _client.GetAsync($"corporations/{corporationId}/contacts?datasource={Enum.GetName<DataSources>(datasource)?.ToLower()}&page={page}");
			Contact[] ret;
			if (WrapperConfig._instance.SUCCESS.Contains(message.StatusCode))
				throw new Exception(_serializer.Deserialize<Error>(new JsonTextReader(new StreamReader(await message.Content.ReadAsStreamAsync()))).error);
			ret = _serializer.Deserialize<Contact[]>(new JsonTextReader(new StreamReader(await message.Content.ReadAsStreamAsync())));
			return ret;
		}
		
		public async Task<ContactLabel[]> GetCorporationContactLabelsAsync(int corporationId, DataSources datasource = DataSources.TRANQUILITY)
		{
			HttpResponseMessage message = await _client.GetAsync($"corporations/{corporationId}/contacts/labels?datasource={Enum.GetName<DataSources>(datasource)?.ToLower()}");
			ContactLabel[] ret;
			if (WrapperConfig._instance.SUCCESS.Contains(message.StatusCode))
				throw new Exception(_serializer.Deserialize<Error>(new JsonTextReader(new StreamReader(await message.Content.ReadAsStreamAsync()))).error);
			ret = _serializer.Deserialize<ContactLabel[]>(new JsonTextReader(new StreamReader(await message.Content.ReadAsStreamAsync())));
			return ret;
		}
	}
}