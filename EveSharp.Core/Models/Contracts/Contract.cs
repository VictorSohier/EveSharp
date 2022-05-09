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
	
	public struct SoAContract
	{
		public readonly int?[] acceptorIds;
		public readonly int?[] assigneeIds;
		public readonly Availability[] availabilitys;
		public readonly double?[] buyouts;
		public readonly double?[] collaterals;
		public readonly int[] contractIds;
		public readonly DateTime[] dateAccepteds;
		public readonly DateTime[] dateCompleteds;
		public readonly DateTime[] dateExpireds;
		public readonly DateTime[] dateIssueds;
		public readonly int?[] daysToCompletes;
		public readonly long?[] endLocationIds;
		public readonly bool[] forCorporations;
		public readonly int[] issuerCorporationIds;
		public readonly int[] issuerIds;
		public readonly double?[] prices;
		public readonly double?[] rewards;
		public readonly long?[] startLocationIds;
		public readonly Status[] statuss;
		public readonly string[] titles;
		public readonly ContractType[] types;
		public readonly double?[] volumes;
		
		public SoAContract(params Contract[] contracts)
		{
			int count = contracts.Length;
			acceptorIds = new int?[count];
			assigneeIds = new int?[count];
			availabilitys = new Availability[count];
			buyouts = new double?[count];
			collaterals = new double?[count];
			contractIds = new int[count];
			dateAccepteds = new DateTime[count];
			dateCompleteds = new DateTime[count];
			dateExpireds = new DateTime[count];
			dateIssueds = new DateTime[count];
			daysToCompletes = new int?[count];
			endLocationIds = new long?[count];
			forCorporations = new bool[count];
			issuerCorporationIds = new int[count];
			issuerIds = new int[count];
			prices = new double?[count];
			rewards = new double?[count];
			startLocationIds = new long?[count];
			statuss = new Status[count];
			titles = new string[count];
			types = new ContractType[count];
			volumes = new double?[count];
			
			for (int i = 0; i < count; i++)
			{
				acceptorIds[i] = contracts[i].acceptorId;
				assigneeIds[i] = contracts[i].assigneeId;
				availabilitys[i] = contracts[i].availability;
				buyouts[i] = contracts[i].buyout;
				collaterals[i] = contracts[i].collateral;
				contractIds[i] = contracts[i].contractId;
				dateAccepteds[i] = contracts[i].dateAccepted;
				dateCompleteds[i] = contracts[i].dateCompleted;
				dateExpireds[i] = contracts[i].dateExpired;
				dateIssueds[i] = contracts[i].dateIssued;
				daysToCompletes[i] = contracts[i].daysToComplete;
				endLocationIds[i] = contracts[i].endLocationId;
				forCorporations[i] = contracts[i].forCorporation;
				issuerCorporationIds[i] = contracts[i].issuerCorporationId;
				issuerIds[i] = contracts[i].issuerId;
				prices[i] = contracts[i].price;
				rewards[i] = contracts[i].reward;
				startLocationIds[i] = contracts[i].startLocationId;
				statuss[i] = contracts[i].status;
				titles[i] = contracts[i].title;
				types[i] = contracts[i].type;
				volumes[i] = contracts[i].volume;
			}
		}
	}
}