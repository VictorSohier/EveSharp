using EveSharp.Core.Enums.Mail;

namespace EveSharp.Core.Models.Mail
{
	public struct Recipient
	{
		public int recipientId;
		public RecipientType recipientType;
	}
	
	public struct SoARecipient
	{
		public readonly int[] recipientIds;
		public readonly RecipientType[] recipientTypes;
		
		public SoARecipient(params Recipient[] recipients)
		{
			int count = recipients.Length;
			recipientIds = new int[count];
			recipientTypes = new RecipientType[count];
			
			for (int i = 0; i < count; i++)
			{
				recipientIds[i] = recipients[i].recipientId;
				recipientTypes[i] = recipients[i].recipientType;
			}
		}
	}
}