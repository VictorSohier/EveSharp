namespace EveSharp.Core.Models.Character.Clone
{
	public struct Clone
	{
		public DateTime lastCloneJumpDate;
		public DateTime lastStationChangeDate;
		public JumpClone[] jumpClones;
		public Location homeLocation;
	}
}