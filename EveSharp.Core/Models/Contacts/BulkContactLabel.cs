namespace EveSharp.Core.Models.Contacts
{
	public struct BulkContactLabelAssociations
	{
		public long[] labelIds;
		public int[] contactIds;
		
		public BulkContactLabelAssociations(params ContactLabelAssociation[] data)
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
	
	public struct ContactLabelAssociation
	{
		public long labelId;
		public int contactId;
	}
}