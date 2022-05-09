namespace EveSharp.Core.Models
{
	public struct GraphicComponent
	{
		public int color;
		public string graphic;
		public int layer;
		public int part;
	}
	
	public struct SoAGraphicComponent
	{
		public readonly int[] colors;
		public readonly string[] graphics;
		public readonly int[] layers;
		public readonly int[] parts;
		
		public SoAGraphicComponent(params GraphicComponent[] graphicComponents)
		{
			int count = graphicComponents.Length;
			colors = new int[count];
			graphics = new string[count];
			layers = new int[count];
			parts = new int[count];
			
			for (int i = 0; i < count; i++)
			{
				colors[i] = graphicComponents[i].color;
				graphics[i] = graphicComponents[i].graphic;
				layers[i] = graphicComponents[i].layer;
				parts[i] = graphicComponents[i].part;
			}
		}
	}
}