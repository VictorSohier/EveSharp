namespace EveSharp.Core.Models.Mail
{
	public struct Mail
	{
		public long? ApprovedCost;
		public string Body;
		public Recipient[] Recipients;
		public string Subject;
	}
}