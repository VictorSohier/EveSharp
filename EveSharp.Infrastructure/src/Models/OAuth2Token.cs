namespace EveSharp.Infrastructure.Models
{
	public struct OAuth2Token
	{
		public string accessToken;
		public int expiresIn;
		public string tokenType;
		public string refreshToken;
	}
	
	public struct JsonWebKeySet
	{
		public string[] scp;
		public string jti;
		public string kid;
		public string sub;
		public string azp;
		public string tenant;
		public string tier;
		public string region;
		public string aud;
		public string name;
		public string owner;
		public int exp;
		public int iat;
		public string iss;
	}
	
	public struct JsonWebTokenHeader
	{
		public string alg;
		public string kid;
		public string typ;
	}
	
	public struct OAuthSignatureVerificationKeys
	{
		public Key[] keys;
		public bool SkipUnresolvedJsonWebKeys;
	}
	
	public struct Key
	{
		public string alg;
		public string kid;
		public string kty;
		public string use;
		public string e;
		public string n;
		public string crv;
		public string x;
		public string y;
	}
}