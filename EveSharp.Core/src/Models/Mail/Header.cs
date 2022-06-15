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
	
	public struct SoAHeader
	{
		public readonly int?[] froms;
		public readonly bool?[] isReads;
		public readonly int[][] labels;
		public readonly int?[] mailIds;
		public readonly SoARecipient[] recipients;
		public readonly string[] subjects;
		public readonly DateTime[] timestamps;
		
		public SoAHeader(params Header[] headers)
		{
			int count = headers.Length;
			froms = new int?[count];
			isReads = new bool?[count];
			labels = new int[count][];
			mailIds = new int?[count];
			recipients = new SoARecipient[count];
			subjects = new string[count];
			timestamps = new DateTime[count];
			
			for (int i = 0; i < count; i++)
			{
				int labelsLength = headers[i].labels.Length;
				froms[i] = headers[i].from;
				isReads[i] = headers[i].isRead;
				labels[i] = new int[labelsLength];
				mailIds[i] = headers[i].mailId;
				recipients[i] = new(headers[i].recipients);
				subjects[i] = headers[i].subject;
				timestamps[i] = headers[i].timestamp;
				Array.Copy(headers[i].labels, labels[i], labelsLength);
			}
		}
	}
}