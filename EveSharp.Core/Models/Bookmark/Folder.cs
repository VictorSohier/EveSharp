namespace EveSharp.Core.Models.Bookmark
{
    public struct Folder
    {
        public int? creatorId;
        public int folderId;
        public string name;
    }
	
    public struct SoAFolder
    {
        public readonly int?[] creatorIds;
        public readonly int[] folderIds;
        public readonly string[] names;
		
		public SoAFolder(params Folder[] folders)
		{
			int count = folders.Length;
			creatorIds = new int?[count];
			folderIds = new int[count];
			names = new string[count];
			
			for (int i = 0; i < count; i++)
			{
				creatorIds[i] = folders[i].creatorId;
				folderIds[i] = folders[i].folderId;
				names[i] = folders[i].name;
			}
		}
    }
}