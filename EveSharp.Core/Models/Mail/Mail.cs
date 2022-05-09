namespace EveSharp.Core.Models.Mail
{
	public struct Mail
	{
		public long? approvedCost;
		public string body;
		public Recipient[] recipients;
		public string subject;
	}
	
	public struct SoAMail
	{
		public readonly long?[] approvedCosts;
		public readonly string[] bodys;
		public readonly SoARecipient[] recipients;
		public readonly string[] subjects;
		
		public SoAMail(params Mail[] mail)
		{
			int count = mail.Length;
			approvedCosts = new long?[count];
			bodys = new string[count];
			recipients = new SoARecipient[count];
			subjects = new string[count];
			
			for (int i = 0; i < count; i++)
			{
				approvedCosts[i] = mail[i].approvedCost;
				bodys[i] = mail[i].body;
				recipients[i] = new(mail[i].recipients);
				subjects[i] = mail[i].subject;
			}
		}
	}
}