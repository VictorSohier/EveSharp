namespace EveSharp.Core.Models.Wallet
{
	public struct Transaction
	{
		public int clientId;
		public DateTime date;
		public bool isBuy;
		public bool? isPersonal;
		public long journalRefId;
		public long locationId;
		public int quantity;
		public long transactionId;
		public int typeId;
		public double unitPrice;
	}
}