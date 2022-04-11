using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace EveSharp.Core.Enums.Contracts
{
	[JsonConverter(typeof(StringEnumConverter))]
	public enum Status
	{
		Outstanding,
		InProgress,
		FinishedIssuer,
		FinishedContractor,
		Finished,
		Cancelled,
		Rejected,
		Failed,
		Deleted,
		Reversed
	}
}