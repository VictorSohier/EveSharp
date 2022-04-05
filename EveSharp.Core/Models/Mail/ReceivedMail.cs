namespace EveSharp.Core.Models.Mail
{
	public struct ReceivedMail
	{
		public string body;
		public int? from;
		public int[] labels;
		public bool read;
		public Recipient[] recipients;
		public string subject;
		public DateTime timestamp;
	}
}