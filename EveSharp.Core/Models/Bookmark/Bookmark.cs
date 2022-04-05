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
}