namespace EveSharp.Core.Models.Mail
{
	public struct ReceivedMail
	{
		public string Body;
		public int? From;
		public int[] Labels;
		public bool Read;
		public Recipient[] Recipients;
		public string Subject;
		public DateTime Timestamp;
	}
}