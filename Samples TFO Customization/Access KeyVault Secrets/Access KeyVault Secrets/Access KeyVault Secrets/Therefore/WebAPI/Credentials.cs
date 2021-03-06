using System.Text;

namespace Therefore.WebAPI
{
    /// <summary>
    /// stores the user name and token, token is used for the automatic login
    /// </summary>
    public class TokenBasedCredentials : BaseCredentials
    {
        public static readonly string UseTokenHttpHeaderName = "UseToken";
        public static readonly string UseTokenHttpHeaderValue = "1";

        public TokenBasedCredentials(string userName, string token)
            : base(userName)
        {
            this.Token = token;
        }

        public override void ResetCredentials()
        {
            base.ResetCredentials();
            ResetKey();
        }

        public override void ResetKey()
        {
            Token = null;
        }


        public string Token { get; private set; }


        /// <summary>
        /// Serialize this token into a string that can be deserialized.
        /// </summary>
        /// <returns>A <c>string</c> representing the <see cref="TokenBasedCredentials"/> instance.</returns>
        /// <seealso cref="Deserialize"/>
        public string Serialize()
        {
            var sb = new StringBuilder();
            sb.Append(UserName);
            sb.Append(":");
            sb.Append(Token);
            return sb.ToString();
        }

        /// <summary>
        /// Restores a token from its serialized string representation.
        /// </summary>
        /// <param name='serializedString'>The serialized account generated by <see cref="Serialize"/>.</param>
        /// <returns>An <see cref="TokenBasedCredentials"/> instance represented by <paramref name="serializedString"/>.</returns>
        /// <seealso cref="Serialize"/>
        public static TokenBasedCredentials Deserialize(string serializedString)
        {
            string[] parts = serializedString.Split(':');
            if (parts.Length == 2)
                return new TokenBasedCredentials(parts[0], parts[1]);
            else
                throw new System.Exception("Could not deserialize token credential.");
        }

        public override bool IsValid()
        {
            return !string.IsNullOrEmpty(UserName) && !string.IsNullOrEmpty(Token);
        }
    }
}
