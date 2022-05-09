using System.Security.Cryptography.X509Certificates;

namespace EveSharp.Core.Models.Contacts
{
	public struct ContactLabel
	{
		public long labelId;
		public string labelName;
	}
	
	public struct SoAContactLabel
	{
		public long[] labelIds;
		public string[] labelNames;
		
		public SoAContactLabel(params ContactLabel[] contactLabels)
		{
			int count = contactLabels.Length;
			labelIds = new long[count];
			labelNames = new string[count];
			
			for(int i = 0; i < count; i++)
			{
				labelIds[i] = contactLabels[i].labelId;
				labelNames[i] = contactLabels[i].labelName;
			}
		}
	}
}