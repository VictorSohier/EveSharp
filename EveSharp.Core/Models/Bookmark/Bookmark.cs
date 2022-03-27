namespace EveSharp.Core.Models.Bookmark
{
    public struct Bookmark
    {
        public int BookmarkId;
        public Position Coordinates;
        public DateTime Created;
        public int CreatorId;
        public int? FolderId;
        public string Label;
        public int LocationId;
        public string Notes;
        public Item Item;
    }
}