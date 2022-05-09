using EveSharp.Core.Models.FactionWarfare.Leaderboard;

namespace EveSharp.Core.Models.Dogma.Dynamic
{
	public struct Attribute
	{
		public int attributeId;
		public float value;
	}
	
	public struct SoAAttribute
	{
		public readonly int[] attributeIds;
		public readonly float[] values;
		
		public SoAAttribute(params Attribute[] attributes)
		{
			int count = attributes.Length;
			attributeIds = new int[count];
			values = new float[count];
			
			for (int i = 0; i < count; i++)
			{
				attributeIds[i] = attributes[i].attributeId;
				values[i] = attributes[i].value;
			}
		}
	}
}