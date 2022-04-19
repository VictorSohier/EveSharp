namespace EveSharp.Infrastructure.Models
{
	public struct OAuth2Tokens
	{
		public string accessToken;
		public int expiresIn;
		public string tokenType;
		public string refreshToken;
	}
}