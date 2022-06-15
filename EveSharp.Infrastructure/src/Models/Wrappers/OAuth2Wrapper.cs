using System.Diagnostics;
using System.IO.Pipes;
using System.Security.Cryptography;
using System.Text;
using EveSharp.Infrastructure.Enums;
using Newtonsoft.Json;

namespace EveSharp.Infrastructure.Models.Wrappers
{
	public class OAuth2Wrapper
	{
		public readonly static OAuth2Wrapper _instance = new();
		private readonly HttpClient HTTP_CLIENT = new()
		{
			BaseAddress = new($"https://{WrapperConfig._instance.OAUTH2_DOMAIN}")
		};
		private string CLIENT_ID;
		private readonly string state = Guid.NewGuid().ToString();
		
		private OAuth2Wrapper()
		{
			HTTP_CLIENT.DefaultRequestHeaders.Add("Host", "login.eveonline.com");
			HTTP_CLIENT.DefaultRequestHeaders.Add("Accepts", "application/json");
		}
		
		private async Task<OAuth2Token> OAuthRequest(
			HttpContent content
		)
		{
			HttpResponseMessage response = await HTTP_CLIENT
				.PostAsync("/v2/oauth/token", content);
			JsonTextReader json = new (
				new StringReader(
					await response
						.Content
						.ReadAsStringAsync()
					)
				);
			OAuth2Token ret = WrapperConfig
				._instance
				.SERIALIZER
				.Deserialize<OAuth2Token>(
					json
				);
			return ret;
		}
		
		public void SetClientId(string clientId) => CLIENT_ID = clientId;
		
		public async Task<bool> PipeToOriginalClient(string schema, string uri)
		{
			if (uri != null)
			{
				if (uri.StartsWith(schema))
				{
					string state = uri
						.Split("?")[1]
						.Split("&")
						.First(e =>
							e
								.StartsWith("state")
							)
						.Split("=")[1];
					string code = uri
						.Split("?")[1]
						.Split("&")
						.First(e =>
							e
								.StartsWith("code")
							)
						.Split("=")[1];
					NamedPipeClientStream pipeClient = new(".",
						state, PipeDirection.Out, PipeOptions.None);
					byte[] writeBuffer = Encoding.UTF8.GetBytes(code);
					await pipeClient.ConnectAsync();
					await pipeClient.WriteAsync(writeBuffer);
					await pipeClient.FlushAsync();
					pipeClient.Close();
					return true;
				}
			}
			return false;
		}
		
		public async Task<OAuth2Token?> NativeProtocol (
			string callbackUri,
			params Permissions[] permissions
		) => await NativeProtocol(
				callbackUri,
				new PermissionsSOA(permissions));
		
		public async Task<OAuth2Token?> NativeProtocol (
			string callbackUri,
			PermissionsSOA permissions
		)
		{
			OAuth2Token token;
			byte[] random = new byte[32];
			string code;
			WrapperConfig
				._instance
				.RANDOM
				.NextBytes(random);
			string verifier = Convert
				.ToBase64String(random)
				.Replace("+", "-")
				.Replace("/", "_");
			
			{
				string challenge = Convert
					.ToBase64String(WrapperConfig
						._instance
						.SHA256
						.ComputeHash(Encoding
							.ASCII
							.GetBytes(verifier)
						)
					)
					.Replace("+", "-")
					.Replace("/", "_")
					.Replace("=", "");
				string path = $"/v2/oauth/authorize?response_type=code&redirect_uri={callbackUri}&client_id={CLIENT_ID}&state={state}&code_challenge={challenge}&code_challenge_method=S256&scope={string.Join("%20", permissions.values)}";
				Process browser = Process.Start("xdg-open", $"https://{WrapperConfig._instance.OAUTH2_DOMAIN}{path}");
				CancellationTokenSource cts = new();
				browser.Disposed += (object sender, EventArgs e) => cts.Cancel(false);
				byte[] bytes = new byte[4096];
				NamedPipeServerStream pipeServer = new(state);
				int bytesRead;
				string response = "";
				await pipeServer.WaitForConnectionAsync(cts.Token);
				if (cts.Token.IsCancellationRequested)
					return null;
				do
				{
					bytesRead = await pipeServer.ReadAsync(bytes, 0, bytes.Length);
					response += Encoding.UTF8.GetString(bytes);
					bytes = new byte[4096];
				}
				while (bytesRead == bytes.Length);
				code = response.Split("?")[1].Split("&").First(e => e.StartsWith("code")).Split("=")[1];
				pipeServer.Close();
				browser.Close();
			}
			
			{
				HttpContent content = new FormUrlEncodedContent(
					new Dictionary<string, string>()
					{
						{ "grant_type", "authorization_code" },
						{ "code", code },
						{ "client_id", CLIENT_ID },
						{ "code_verifier", verifier }
					}
				);
				token = await OAuthRequest(content);
			}
			
			return  token;
		}
		
		public async Task<OAuth2Token> NativeTokenRefresh (
			string refreshToken
		)
		{
			OAuth2Token token;
			HttpContent content = new FormUrlEncodedContent(
				new Dictionary<string, string>()
				{
					{ "grant_type", "refresh_token" },
					{ "refresh_token", refreshToken },
					{ "client_id", CLIENT_ID }
				}
			);
			token = await OAuthRequest(content);
			return token;
		}
		
		public string GetWebRedirect (
			string state,
			string callbackUri,
			params Permissions[] permissions
		) => GetWebRedirect (
			state,
			callbackUri,
			new PermissionsSOA(permissions)
		);
		
		public string GetWebRedirect (
			string state,
			string callbackUri,
			PermissionsSOA permissions
		) => $"https://{WrapperConfig._instance.OAUTH2_DOMAIN}/v2/oauth/authorize?response_type=code&redirect_uri={callbackUri}&client_id={CLIENT_ID}&state={state}&scope={string.Join(" ", permissions.values)}";
		
		public async Task<OAuth2Token> CompleteWebOAuth2Request (
			string secretKey,
			string code
		)
		{
			OAuth2Token token;
			HttpContent content = new FormUrlEncodedContent(
				new Dictionary<string, string>()
				{
					{ "grant_type", "authorization_code" },
					{ "code", code }
				}
			);
			HTTP_CLIENT
				.DefaultRequestHeaders
				.Authorization = new("Basic", Convert
					.ToBase64String(Encoding
						.ASCII
						.GetBytes($"{CLIENT_ID}:{secretKey}")));
			token = await OAuthRequest(content);
			HTTP_CLIENT
				.DefaultRequestHeaders
				.Authorization = null;
			return token;
		}
		
		public async Task<OAuth2Token> WebTokenRefresh (
			string refreshToken,
			string secretKey
		)
		{
			OAuth2Token token;
			HttpContent content = new FormUrlEncodedContent(
				new Dictionary<string, string>()
				{
					{ "grant_type", "refresh_token" },
					{ "refresh_token", refreshToken }
				}
			);
			HTTP_CLIENT
				.DefaultRequestHeaders
				.Authorization = new("Basic", Convert
					.ToBase64String(Encoding
						.ASCII
						.GetBytes($"{CLIENT_ID}:{secretKey}")));
			token = await OAuthRequest(content);
			HTTP_CLIENT
				.DefaultRequestHeaders
				.Authorization = null;
			return token;
		}
		
		public async Task<(JsonWebKeySet, bool)> VerifyToken(OAuth2Token token)
		{
			string[] tokenComponents = token.accessToken.Split(".");
			string headerB64 = tokenComponents[0].Replace("-", "+").Replace("_", "/") + new string('=', 4 - (tokenComponents[0].Length % 4));
			string contentB64 = tokenComponents[1].Replace("-", "+").Replace("_", "/") + new string('=', 4 - (tokenComponents[1].Length % 4));
			string headerString = Encoding.UTF8.GetString(Convert.FromBase64String(headerB64));
			string content = Encoding.UTF8.GetString(Convert.FromBase64String(contentB64));
			string payload = $"{tokenComponents[0]}.{tokenComponents[1]}";
			JsonTextReader json = new (
				new StringReader(
					content
				)
			);
			JsonWebKeySet ret = WrapperConfig
				._instance
				.SERIALIZER
				.Deserialize<JsonWebKeySet>(
					json
				);
			json = new JsonTextReader(
				new StringReader(
					headerString
				)
			);
			JsonWebTokenHeader header = WrapperConfig
				._instance
				.SERIALIZER
				.Deserialize<JsonWebTokenHeader>(
					json
				);
			HttpResponseMessage response = await HTTP_CLIENT.GetAsync("/oauth/jwks");
			json = new JsonTextReader(
				new StringReader(
					await response.Content.ReadAsStringAsync()
				)
			);
			OAuthSignatureVerificationKeys keys = WrapperConfig
				._instance
				.SERIALIZER
				.Deserialize<OAuthSignatureVerificationKeys>(
					json
				);
			bool isValid = true;
			switch (header.alg)
			{
				case "RS256":
				{
					Key key = keys.keys.First(e => e.alg == "RS256");
					byte[] exponent = Convert.FromBase64String(key.e);
					byte[] modulus = Convert.FromBase64String(key.n.Replace("-", "+").Replace("_", "/") + "==");
					RSA RSA = RSA.Create();
					RSA.ImportParameters(new ()
						{
							Modulus = modulus,
							Exponent = exponent
						}
					);
					RSAPKCS1SignatureDeformatter RSASHA256 =
						new();
					RSASHA256.SetHashAlgorithm("sha256");
					RSASHA256.SetKey(RSA);
					isValid &= RSASHA256.VerifySignature(WrapperConfig
						._instance
						.SHA256
						.ComputeHash(Encoding.ASCII.GetBytes(payload)),
						Convert
							.FromBase64String(tokenComponents[2]
								.Replace("-", "+")
								.Replace("_", "/") + "==")
					);
					break;
				}
				case "ES256":
				{
					Key key = keys.keys.First(e => e.alg == "ES256");
					ECDsa ECDsa = ECDsa.Create(new ECParameters()
						{
							Curve = ECCurve.CreateFromFriendlyName("P-256"),
							Q = new ()
							{
								X = Convert.FromBase64String(key.x.Replace("-", "+").Replace("_", "/")),
								Y = Convert.FromBase64String(key.y.Replace("-", "+").Replace("_", "/"))
							}
						}
					);
					DSASignatureDeformatter ES256 = new();
					ES256.SetHashAlgorithm("sha256");
					ES256.SetKey(ECDsa);
					isValid &= ES256.VerifySignature(WrapperConfig
						._instance
						.SHA256
						.ComputeHash(Encoding.ASCII.GetBytes(payload)),
						Convert
							.FromBase64String(
								tokenComponents[2]
									.Replace("-", "+")
									.Replace("_", "/") + "==")
					);
					break;
				}
			}
			isValid &= ret.iss == WrapperConfig._instance.OAUTH2_DOMAIN;
			isValid &= ret.aud.Contains("EVE Online");
			return (ret, isValid);
		}
	}
}