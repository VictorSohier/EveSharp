using EveSharp.Core.Models.War;

namespace EveSharp.Core.Models.Wallet
{
	public struct War
	{
		public Belligerent aggressor;
		public Ally[] allies;
		public DateTime declared;
		public Belligerent defender;
		public DateTime finished;
		public int id;
		public bool mutual;
		public bool openForAllies;
		public DateTime retracted;
		public DateTime started;
	}
}