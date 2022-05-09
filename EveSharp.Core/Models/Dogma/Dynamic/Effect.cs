namespace EveSharp.Core.Models.Dogma.Dynamic
{
	public struct Effect
	{
		public int effectId;
		public bool isDefault;
	}
	
	public struct SoAEffect
	{
		public readonly int[] effectIds;
		public readonly bool[] isDefaults;
		
		public SoAEffect(params Effect[] effects)
		{
			int count = effects.Length;
			effectIds = new int[count];
			isDefaults = new bool[count];
			
			for (int i = 0; i < count; i++)
			{
				effectIds[i] = effects[i].effectId;
				isDefaults[i] = effects[i].isDefault;
			}
		}
	}
}