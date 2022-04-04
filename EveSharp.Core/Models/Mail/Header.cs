namespace EveSharp.Core.Models.Mail
{
	public struct Header
	{
		public int? From;
		public bool? IsRead;
		public int[] Labels;
		public int? MailId;
		public Recipient[] Recipients;
		public string Subject;
		public DateTime Timestamp;
	}
}