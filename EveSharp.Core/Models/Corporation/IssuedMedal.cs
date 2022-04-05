using EveSharp.Core.Enums;

namespace EveSharp.Core.Models.Corporation
{
	public struct IssuedMedal
	{
		public int characterId;
		public DateTime issuedAt;
		public int issuerId;
		public int medalId;
		public string reason;
		public Status status;
	}
}