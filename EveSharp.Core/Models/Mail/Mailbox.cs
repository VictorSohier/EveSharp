namespace EveSharp.Core.Models.Mail
{
	public struct Mailbox
	{
		public Label[] labels;
		public int? totalUnreadCount;
	}
	
	public struct SoAMailbox
	{
		public readonly SoALabel[] labels;
		public readonly int?[] totalUnreadCounts;
		
		public SoAMailbox(params Mailbox[] mailboxes)
		{
			int count = mailboxes.Length;
			labels = new SoALabel[count];
			totalUnreadCounts = new int?[count];
			
			for (int i = 0; i < count; i++)
			{
				labels[i] = new(mailboxes[i].labels);
				totalUnreadCounts[i] = mailboxes[i].totalUnreadCount;
			}
		}
	}
}