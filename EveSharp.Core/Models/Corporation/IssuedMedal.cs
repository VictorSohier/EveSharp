using EveSharp.Core.Enums;

namespace EveSharp.Core.Models.Corporation
{
	public struct IssuedMedal
	{
		public int CharacterId;
		public DateTime IssuedAt;
		public int IssuerId;
		public int MedalId;
		public string Reason;
		public Status Status;
	}
}