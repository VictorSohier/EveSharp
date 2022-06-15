namespace EveSharp.Core.Models.UserInterface
{
	public struct NewMail
	{
		public string body;
		public int[] recipients;
		public string subject;
		public int? toCorpOrAllianceId;
		public int? mailingListId;
	}
	
	public struct SoANewMail
	{
		public readonly string[] bodys;
		public readonly int[][] recipientss;
		public readonly string[] subjects;
		public readonly int?[] toCorpOrAllianceIds;
		public readonly int?[] mailingListIds;
		
		public SoANewMail(params NewMail[] newMail)
		{
			int count = newMail.Length;
			bodys = new string[count];
			recipientss = new int[count][];
			subjects = new string[count];
			toCorpOrAllianceIds = new int?[count];
			mailingListIds = new int?[count];
			
			for (int i = 0; i < count; i++)
			{
				bodys[i] = newMail[i].body;
				recipientss[i] = newMail[i].recipients;
				subjects[i] = newMail[i].subject;
				toCorpOrAllianceIds[i] = newMail[i].toCorpOrAllianceId;
				mailingListIds[i] = newMail[i].mailingListId;
			}
		}
	}
}