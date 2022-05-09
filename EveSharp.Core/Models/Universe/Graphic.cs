namespace EveSharp.Core.Models.Universe
{
	public struct Graphic
	{
		public string collisionFile;
		public string graphicFile;
		public int graphicId;
		public string iconFolder;
		public string sofDna;
		public string sofFationName;
		public string sofHullName;
		public string sofRaceName;
	}
	
	public struct SoAGraphic
	{
		public readonly string[] collisionFiles;
		public readonly string[] graphicFiles;
		public readonly int[] graphicIds;
		public readonly string[] iconFolders;
		public readonly string[] sofDnas;
		public readonly string[] sofFationNames;
		public readonly string[] sofHullNames;
		public readonly string[] sofRaceNames;
		
		public SoAGraphic(params Graphic[] graphics)
		{
			int count = graphics.Length;
			collisionFiles = new string[count];
			graphicFiles = new string[count];
			graphicIds = new int[count];
			iconFolders = new string[count];
			sofDnas = new string[count];
			sofFationNames = new string[count];
			sofHullNames = new string[count];
			sofRaceNames = new string[count];
			
			for (int i = 0; i < count; i++)
			{
				collisionFiles[i] = graphics[i].collisionFile;
				graphicFiles[i] = graphics[i].graphicFile;
				graphicIds[i] = graphics[i].graphicId;
				iconFolders[i] = graphics[i].iconFolder;
				sofDnas[i] = graphics[i].sofDna;
				sofFationNames[i] = graphics[i].sofFationName;
				sofHullNames[i] = graphics[i].sofHullName;
				sofRaceNames[i] = graphics[i].sofRaceName;
			}
		}
	}
}