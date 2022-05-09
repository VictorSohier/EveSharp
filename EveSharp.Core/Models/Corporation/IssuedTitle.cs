namespace EveSharp.Core.Models.Corporation
{
	public struct IssuedTitle
	{
		public int characterId;
		public int[] titles;
	}
	
	public struct SoAIssuedTitle
	{
		public readonly int[] characterIds;
		public readonly int[][] titles;
		
		public SoAIssuedTitle(params IssuedTitle[] issuedTitles)
		{
			int count = issuedTitles.Length;
			characterIds = new int[count];
			titles = new int[count][];
			
			for (int i = 0; i < count; i++)
			{
				int issuedTitlesLength = issuedTitles[i].titles.Length;
				characterIds[i] = issuedTitles[i].characterId;
				titles[i] = new int[issuedTitlesLength];
				Array.Copy(issuedTitles[i].titles, titles[i], issuedTitlesLength);
			}
		}
	}
}