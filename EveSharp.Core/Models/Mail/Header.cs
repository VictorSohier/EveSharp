namespace EveSharp.Core.Models.Mail
{
	public struct Header
	{
		public int? from;
		public bool? isRead;
		public int[] labels;
		public int? mailId;
		public Recipient[] recipients;
		public string subject;
		public DateTime timestamp;
	}
}