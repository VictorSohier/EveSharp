using System.Text;
using EveSharp.Infrastructure.Enums;
using Newtonsoft.Json;

namespace EveSharp.Infrastructure.Models.Wrappers
{
	public class OAuth2Wrapper
	{
		private readonly string CALLBACK_URL;
		private readonly string CLIENT_ID;
		private readonly HttpClient HTTP_CLIENT = new()
		{
			BaseAddress = new($"https://{WrapperConfig._instance.OAUTH2_DOMAIN}/v2/oauth/token")
		};
		private string stateString;
		
		public OAuth2Wrapper(string callbackUrl, string clientId)
		{
			CALLBACK_URL = callbackUrl;
			CLIENT_ID = clientId;
			HTTP_CLIENT.DefaultRequestHeaders.Add("Content-Type", "application/x-www-form-urlencoded");
			HTTP_CLIENT.DefaultRequestHeaders.Add("Host", "login.eveonline.com");
		}
		
		/// <summary>
		/// Returns the url to redirect the user to for web applications
		/// </summary>
		/// <param name="responseType">The type of token to request</param>
		/// <param name="permissions">The permissions to be requested</param>
		/// <returns>(url, state token)</returns>
		public (string, string) GetSSOURL(ResponseTypes responseType, Permissions[] permissions, string stateString = "")
		{
			PermissionsSOA perms = new(permissions);
			if (string.IsNullOrWhiteSpace(stateString))
			{
				byte[] state = new byte[32];
				WrapperConfig._instance.RANDOM.NextBytes(state);
				this.stateString = Encoding.UTF8.GetString(state);
			}
			else
			{
				this.stateString = stateString;
			}
			string url = $"https://{WrapperConfig._instance.OAUTH2_DOMAIN}/v2/oauth/authorize?response_type={Enum.GetName(responseType)}&redirect_uri={CALLBACK_URL}&client_id={CLIENT_ID}&scope={string.Join(" ", perms.values)}&state={stateString}";
			return (url, stateString);
		}
		
		/// <summary>
		/// Returns the url to open in a browser for desktop applications
		/// </summary>
		/// <param name="responseType">The type of token to request</param>
		/// <param name="permissions">The permissions to be requested</param>
		/// <returns>(url, state token)</returns>
		public async Task<(string, string)> GetDesktopSSOURL(ResponseTypes responseType, Permissions[] permissions, string stateString = "")
		{
			byte[] challenge = new byte[32];
			WrapperConfig._instance.RANDOM.NextBytes(challenge);
			MemoryStream ms = new(challenge);
			challenge = await WrapperConfig._instance.SHA256.ComputeHashAsync(ms);
			(string url, string state) = GetSSOURL(responseType, permissions, stateString);
			return ($"{url}&code_challenge={Convert.ToBase64String(challenge).TrimEnd('=')}&code_challenge_method=S256", state);
		}
		
		public async Task<OAuth2Token> GetOAuth2Tokens(string code, string stateString)
		{
			OAuth2Token token;
			if (this.stateString == stateString)
			{
				HttpResponseMessage message = await HTTP_CLIENT
					.PostAsync("", null);
				token = WrapperConfig
					._instance
					.SERIALIZER
					.Deserialize<OAuth2Token>(
						new JsonTextReader(
							new StreamReader(
								await message
									.Content
									.ReadAsStreamAsync())));
			}
			else
			{
				throw new Exception("The request was rejected due to the state not matching with what was stored earlier");
			}
			return token;
		}
	}
}