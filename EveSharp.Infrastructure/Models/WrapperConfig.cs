namespace EveSharp.Infrastructure.Models
{
	public class WrapperConfig
	{
		public readonly static WrapperConfig _instance = new();
		
		public readonly string API_VERSION = "latest";
		
		private WrapperConfig()
		{
			
		}
	}
}