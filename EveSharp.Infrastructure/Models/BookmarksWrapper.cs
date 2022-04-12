using EveSharp.Core.Models.Bookmark;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace EveSharp.Infrastructure.Models
{
	public class BookmarkWrapper
	{
		private readonly HttpClient _client;
		private readonly JsonSerializer _serializer;
		
		public BookmarkWrapper(string authToken)
		{
			_client = new();
			_client.BaseAddress = new($"https://esi.evetech.net/{WrapperConfig._instance.API_VERSION}");
			_client.DefaultRequestHeaders.Add("authorization", authToken);
			_serializer = JsonSerializer.Create(WrapperConfig._instance.settings);
		}
		
		public async Task<Bookmark[]> GetCharacterBookmarksAsync(int characterId, int page = 1, string datasource = "tranquility")
		{
			HttpResponseMessage message = await _client.GetAsync($"characters/{characterId}/bookmarks?datasource={datasource}&page={page}");
			Bookmark[] ret = _serializer.Deserialize<Bookmark[]>(new JsonTextReader(new StreamReader(await message.Content.ReadAsStreamAsync())));
			return ret;
		}
		
		public async Task<Folder[]> GetCharacterBookmarkFoldersAsync(int characterId, int page = 1, string datasource = "tranquility")
		{
			HttpResponseMessage message = await _client.GetAsync($"characters/{characterId}/bookmarks/folders?datasource={datasource}&page={page}");
			Folder[] ret = _serializer.Deserialize<Folder[]>(new JsonTextReader(new StreamReader(await message.Content.ReadAsStreamAsync())));
			return ret;
		}
		
		public async Task<Bookmark[]> GetCorporationBookmarksAsync(int corporationId, int page = 1, string datasource = "tranquility")
		{
			HttpResponseMessage message = await _client.GetAsync($"characters/{corporationId}/bookmarks?datasource={datasource}&page={page}");
			Bookmark[] ret = _serializer.Deserialize<Bookmark[]>(new JsonTextReader(new StreamReader(await message.Content.ReadAsStreamAsync())));
			return ret;
		}
		
		public async Task<Folder[]> GetCorporationBookmarkFoldersAsync(int corporationId, int page = 1, string datasource = "tranquility")
		{
			HttpResponseMessage message = await _client.GetAsync($"characters/{corporationId}/bookmarks/folders?datasource={datasource}&page={page}");
			Folder[] ret = _serializer.Deserialize<Folder[]>(new JsonTextReader(new StreamReader(await message.Content.ReadAsStreamAsync())));
			return ret;
		}
	}
}