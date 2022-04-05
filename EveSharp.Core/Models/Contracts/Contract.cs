using EveSharp.Core.Enums.Contracts;

namespace EveSharp.Core.Models.Contracts
{
	public struct Contract
	{
		public int? acceptorId;
		public int? assigneeId;
		public Availability availability;
		public double? buyout;
		public double? collateral;
		public int contractId;
		public DateTime dateAccepted;
		public DateTime dateCompleted;
		public DateTime dateExpired;
		public DateTime dateIssued;
		public int? daysToComplete;
		public long? endLocationId;
		public bool forCorporation;
		public int issuerCorporationId;
		public int issuerId;
		public double? price;
		public double? reward;
		public long? startLocationId;
		public Status status;
		public string title;
		public ContractType type;
		public double? volume;
	}
}