namespace EveSharp.Core.Models.Bookmarks
{
    public struct Bookmark
    {
        public int BookmarkId;
        public EvePosition Coordinates;
        public DateTime Created;
        public int CreatorId;
        public int FolderId;
        public string Label;
        public int LocationId;
        public string Notes;
        public Item Item;
    }
}