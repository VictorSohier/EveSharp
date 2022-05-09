namespace EveSharp.Core.Models
{
    public struct Position
    {
        public double x;
        public double y;
        public double z;
    }
	
    public struct SoAPosition
    {
        public double[] xs;
        public double[] ys;
        public double[] zs;
		
		public SoAPosition(int count)
		{
			xs = new double[count];
			ys = new double[count];
			zs = new double[count];
		}
		
		public SoAPosition(params Position[] positions)
		{
			int count = positions.Length;
			xs = new double[count];
			ys = new double[count];
			zs = new double[count];
			
			for (int i = 0; i < count; i++)
			{
				xs[i] = positions[i].x;
				ys[i] = positions[i].y;
				zs[i] = positions[i].z;
			}
		}
    }
}