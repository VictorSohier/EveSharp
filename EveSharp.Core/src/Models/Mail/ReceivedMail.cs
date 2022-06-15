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
	
	public struct SoAReceivedMail
	{
		public readonly string[] bodys;
		public readonly int?[] froms;
		public readonly int[][] labels;
		public readonly bool[] reads;
		public readonly SoARecipient[] recipients;
		public readonly string[] subjects;
		public readonly DateTime[] timestamps;
		
		public SoAReceivedMail(params ReceivedMail[] receivedMail)
		{
			int count = receivedMail.Length;
			bodys = new string[count];
			froms = new int?[count];
			labels = new int[count][];
			reads = new bool[count];
			recipients = new SoARecipient[count];
			subjects = new string[count];
			timestamps = new DateTime[count];
			
			for (int i = 0; i < count; i++)
			{
				int labelsLength = receivedMail[i].labels.Length;
				bodys[i] = receivedMail[i].body;
				froms[i] = receivedMail[i].from;
				labels[i] = new int[labelsLength];
				reads[i] = receivedMail[i].read;
				recipients[i] = new(receivedMail[i].recipients);
				subjects[i] = receivedMail[i].subject;
				timestamps[i] = receivedMail[i].timestamp;
				Array.Copy(receivedMail[i].labels, labels[i], labelsLength);
			}
		}
	}
}