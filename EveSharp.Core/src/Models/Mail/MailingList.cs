namespace EveSharp.Core.Models.Mail
{
	public struct MailingList
	{
		public int mailingListId;
		public string name;
	}
	
	public struct SoAMailingList
	{
		public readonly int[] mailingListIds;
		public readonly string[] names;
		
		public SoAMailingList(params MailingList[] mailingLists)
		{
			int count = mailingLists.Length;
			mailingListIds = new int[count];
			names = new string[count];
			
			for (int i = 0; i < count; i++)
			{
				mailingListIds[i] = mailingLists[i].mailingListId;
				names[i] = mailingLists[i].name;
			}
		}
	}
}