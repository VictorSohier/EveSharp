namespace EveSharp.Core.Models.Killmails
{
	public struct Killmail
	{
		public string killmailHash;
		public int killmailId;
	}
	
	public struct SoAKillmail
	{
		public readonly string[] killmailHashs;
		public readonly int[] killmailIds;
		
		public SoAKillmail(params Killmail[] killmails)
		{
			int count = killmails.Length;
			killmailHashs = new string[count];
			killmailIds = new int[count];
			
			for (int i = 0; i < count; i++)
			{
				killmailHashs[i] = killmails[i].killmailHash;
				killmailIds[i] = killmails[i].killmailId;
			}
		}
	}
}