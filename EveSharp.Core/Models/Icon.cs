using System.ComponentModel.Design;

namespace EveSharp.Core.Models
{
	public struct Icon
	{
		public string px512x512;
		public string px256x256;
		public string px128x128;
		public string px64x64;
	}
	
	public struct SoAIcon
	{
		public string[] px512x512s;
		public string[] px256x256s;
		public string[] px128x128s;
		public string[] px64x64s;
		
		public SoAIcon(params Icon[] icons)
		{
			int count = icons.Length;
			px512x512s = new string[count];
			px256x256s = new string[count];
			px128x128s = new string[count];
			px64x64s = new string[count];
			
			for (int i = 0; i < count; i++)
			{
				px512x512s[i] = icons[i].px512x512;
				px256x256s[i] = icons[i].px256x256;
				px128x128s[i] = icons[i].px128x128;
				px64x64s[i] = icons[i].px64x64;
			}
		}
	}
}