using EveSharp.Infrastructure.Enums;
using EveSharp.Infrastructure.Models;
using EveSharp.Infrastructure.Models.Wrappers;

namespace EveSharp.Test
{
	public class Program
	{
		public static void Main(string[] args) => MainAsync(args).GetAwaiter().GetResult();
		
		public static async Task MainAsync(string[] args)
		{
			OAuth2Wrapper._instance.SetClientId("5f6a42f6bd1b476dab1a1a0eae4967b5");
			
			if (args.Length > 0)
			{
				if (await OAuth2Wrapper
					._instance
					.PipeToOriginalClient("eveauth-test", args[0])
				)
					return;
			}
			
			OAuth2Token token;
			JsonWebKeySet jwks;
			OAuth2Token? tmp = await OAuth2Wrapper._instance.NativeProtocol(
				"eveauth-test://localhost:7777",
				Permissions.List.ToArray()
			);
			
			if (tmp == null)
				return;
			else
				token = tmp.Value;
			(jwks, bool isValid) = await OAuth2Wrapper._instance.VerifyToken(token);
			AssetWrapperTests assetWrapperTests = new(token, jwks);
			
			await assetWrapperTests.Run();
		}
	}
}