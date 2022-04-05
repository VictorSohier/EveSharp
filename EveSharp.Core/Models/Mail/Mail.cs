namespace EveSharp.Core.Models.Mail
{
	public struct Mail
	{
		public long? approvedCost;
		public string body;
		public Recipient[] recipients;
		public string subject;
	}
}