using EveSharp.Core.Enums.Contracts;

namespace EveSharp.Core.Models.Contracts
{
	public struct PublicContract
	{
		public double Buyout;
		public double Collateral;
		public int ContractId;
		public DateTime DateAccepted;
		public DateTime DateCompleted;
		public DateTime DateExpired;
		public DateTime DateIssued;
		public int DaysToComplete;
		public long EndLocationId;
		public bool ForCorporation;
		public int IssuerCorporationId;
		public int IssuerId;
		public double Price;
		public double Reward;
		public long StartLocationId;
		public ContractStatus Status;
		public string Title;
		public ContractType Type;
		public double Volume;
	}
}