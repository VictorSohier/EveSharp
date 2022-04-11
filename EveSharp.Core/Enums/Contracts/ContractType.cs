using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace EveSharp.Core.Enums.Contracts
{
	[JsonConverter(typeof(StringEnumConverter))]
	public enum ContractType
	{
		Unknown,
		ItemExchange,
		Auction,
		Courier,
		Loan
	}
}