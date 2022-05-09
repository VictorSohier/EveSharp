namespace EveSharp.Core.Models.Bookmark
{
    public struct Bookmark
    {
        public int bookmarkId;
        public Position coordinates;
        public DateTime created;
        public int creatorId;
        public int? folderId;
        public string label;
        public int locationId;
        public string notes;
        public Item item;
    }
	
    public struct SoABookmark
    {
        public readonly int[] bookmarkIds;
        public readonly Position[] coordinates;
        public readonly DateTime[] createds;
        public readonly int[] creatorIds;
        public readonly int?[] folderIds;
        public readonly string[] labels;
        public readonly int[] locationIds;
        public readonly string[] notes;
        public readonly Item[] items;
		
		public SoABookmark(params Bookmark[] bookmarks)
		{
			int count = bookmarks.Length;
			bookmarkIds = new int[count];
			coordinates = new Position[count];
			createds = new DateTime[count];
			creatorIds = new int[count];
			folderIds = new int?[count];
			labels = new string[count];
			locationIds = new int[count];
			notes = new string[count];
			items = new Item[count];
			
			for (int i = 0; i < count; i++)
			{
				bookmarkIds[i] = bookmarks[i].bookmarkId;
				coordinates[i] = bookmarks[i].coordinates;
				createds[i] = bookmarks[i].created;
				creatorIds[i] = bookmarks[i].creatorId;
				folderIds[i] = bookmarks[i].folderId;
				labels[i] = bookmarks[i].label;
				locationIds[i] = bookmarks[i].locationId;
				notes[i] = bookmarks[i].notes;
				items[i] = bookmarks[i].item;
			}
		}
    }
}