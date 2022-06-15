namespace EveSharp.Core.Models.Contacts
{
	public struct ContactLabelAssociation
	{
		public long labelId;
		public int contactId;
	}
	
	public struct SoAContactLabelAssociation
	{
		public long[] labelIds;
		public int[] contactIds;
		
		public SoAContactLabelAssociation(params ContactLabelAssociation[] data)
		{
			labelIds = new long[data.Length];
			contactIds = new int[data.Length];
			
			for (int i = 0; i < data.Length; i++)
			{
				labelIds[i] = data[i].labelId;
				contactIds[i] = data[i].contactId;
			}
		}
	}
}