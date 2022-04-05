using EveSharp.Core.Enums;

namespace EveSharp.Core.Models.Character
{
	public struct Medal
	{
		public int corporationId;
		public DateTime date;
		public string description;
		public int issuerId;
		public int medalId;
		public string reason;
		public string title;
		public GraphicComponent[] graphics;
		public Status status;
	}
}