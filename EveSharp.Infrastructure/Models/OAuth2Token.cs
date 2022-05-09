namespace EveSharp.Infrastructure.Models
{
	public struct OAuth2Token
	{
		public string accessToken;
		public int expiresIn;
		public string tokenType;
		public string refreshToken;
	}
}