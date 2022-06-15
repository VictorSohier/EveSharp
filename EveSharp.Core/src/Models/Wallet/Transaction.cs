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
	
	public struct SoATransaction
	{
		public readonly int[] clientIds;
		public readonly DateTime[] dates;
		public readonly bool[] isBuys;
		public readonly bool?[] isPersonals;
		public readonly long[] journalRefIds;
		public readonly long[] locationIds;
		public readonly int[] quantitys;
		public readonly long[] transactionIds;
		public readonly int[] typeIds;
		public readonly double[] unitPrices;
		
		public SoATransaction(params Transaction[] transactions)
		{
			int count = transactions.Length;
			clientIds = new int[count];
			dates = new DateTime[count];
			isBuys = new bool[count];
			isPersonals = new bool?[count];
			journalRefIds = new long[count];
			locationIds = new long[count];
			quantitys = new int[count];
			transactionIds = new long[count];
			typeIds = new int[count];
			unitPrices = new double[count];
			
			for (int i = 0; i < count; i++)
			{
				clientIds[i] = transactions[i].clientId;
				dates[i] = transactions[i].date;
				isBuys[i] = transactions[i].isBuy;
				isPersonals[i] = transactions[i].isPersonal;
				journalRefIds[i] = transactions[i].journalRefId;
				locationIds[i] = transactions[i].locationId;
				quantitys[i] = transactions[i].quantity;
				transactionIds[i] = transactions[i].transactionId;
				typeIds[i] = transactions[i].typeId;
				unitPrices[i] = transactions[i].unitPrice;
			}
		}
	}
}