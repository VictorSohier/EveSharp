namespace EveSharp.Core.Models.PlanetaryInteraction
{
	public struct Colony
	{
		public Link[] links;
		public Pin[] pins;
		public Route[] routes;
	}
	
	public struct SoAColony
	{
		public readonly SoALink[] links;
		public readonly SoAPin[] pins;
		public readonly SoARoute[] routes;
		
		public SoAColony(params Colony[] colonies)
		{
			int count = colonies.Length;
			links = new SoALink[count];
			pins = new SoAPin[count];
			routes = new SoARoute[count];
			
			for (int i = 0; i < count; i++)
			{
				links[i] = new(colonies[i].links);
				pins[i] = new(colonies[i].pins);
				routes[i] = new(colonies[i].routes);
			}
		}
	}
}