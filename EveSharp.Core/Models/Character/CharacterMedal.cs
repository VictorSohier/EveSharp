using EveSharp.Core.Enums;

namespace EveSharp.Core.Models.Character
{
	public struct CharacterMedal
	{
		public int CorporationId;
		public DateTime Date;
		public string Description;
		public int IssuerId;
		public int MedalId;
		public string Reason;
		public string Title;
		public GraphicComponent[] Graphics;
		public Status Status;
	}
}