namespace EveSharp.Core.Models.Mail
{
	public struct MailUpdate
	{
		public int[] labels;
		public bool read;
	}
	
	public struct SoAMailUpdate
	{
		public readonly int[][] labels;
		public readonly bool[] reads;
		
		public SoAMailUpdate(params MailUpdate[] mailUpdates)
		{
			int count = mailUpdates.Length;
			labels = new int[count][];
			reads = new bool[count];
			
			for (int i = 0; i < count; i++)
			{
				int labelsLength = mailUpdates[i].labels.Length;
				labels[i] = new int[labelsLength];
				reads[i] = mailUpdates[i].read;
				Array.Copy(mailUpdates[i].labels, labels[i], labelsLength);
			}
		}
	}
}