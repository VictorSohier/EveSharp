namespace EveSharp.Core.Models.War
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
	
	public struct SoAWar
	{
		public readonly SoABelligerent aggressors;
		public readonly SoAAlly[] allies;
		public readonly DateTime[] declareds;
		public readonly SoABelligerent defenders;
		public readonly DateTime[] finisheds;
		public readonly int[] ids;
		public readonly bool[] mutuals;
		public readonly bool[] openForAllies;
		public readonly DateTime[] retracteds;
		public readonly DateTime[] starteds;
		
		public SoAWar(params War[] wars)
		{
			int count = wars.Length;
			aggressors = new SoABelligerent(count);
			allies = new SoAAlly[count];
			declareds = new DateTime[count];
			defenders = new SoABelligerent(count);
			finisheds = new DateTime[count];
			ids = new int[count];
			mutuals = new bool[count];
			openForAllies = new bool[count];
			retracteds = new DateTime[count];
			starteds = new DateTime[count];
			
			for (int i = 0; i < count; i++)
			{
				aggressors.allianceIds[i] = wars[i].aggressor.allianceId;
				aggressors.corporationIds[i] = wars[i].aggressor.corporationId;
				aggressors.iskDestroyeds[i] = wars[i].aggressor.iskDestroyed;
				aggressors.shipsKilleds[i] = wars[i].aggressor.shipsKilled;
				allies[i] = new(wars[i].allies);
				declareds[i] = wars[i].declared;
				defenders.allianceIds[i] = wars[i].defender.allianceId;
				defenders.corporationIds[i] = wars[i].defender.corporationId;
				defenders.iskDestroyeds[i] = wars[i].defender.iskDestroyed;
				defenders.shipsKilleds[i] = wars[i].defender.shipsKilled;
				finisheds[i] = wars[i].finished;
				ids[i] = wars[i].id;
				mutuals[i] = wars[i].mutual;
				openForAllies[i] = wars[i].openForAllies;
				retracteds[i] = wars[i].retracted;
				starteds[i] = wars[i].started;
			}
		}
	}
}