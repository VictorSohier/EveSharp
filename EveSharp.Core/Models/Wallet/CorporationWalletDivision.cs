namespace EveSharp.Core.Models.Wallet
{
	public struct CorporationWalletDivision
	{
		public double balance;
		public int division;
	}
	
	public struct SoACorporationWalletDivision
	{
		public readonly double[] balances;
		public readonly int[] divisions;
		
		public SoACorporationWalletDivision(params CorporationWalletDivision[] corporationWalletDivisions)
		{
			int count = corporationWalletDivisions.Length;
			balances = new double[count];
			divisions = new int[count];
			
			for (int i = 0; i < count; i++)
			{
				balances[i] = corporationWalletDivisions[i].balance;
				divisions[i] = corporationWalletDivisions[i].division;
			}
		}
	}
}