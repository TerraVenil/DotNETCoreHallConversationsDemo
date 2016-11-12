using System;
using Microsoft.IdentityModel.Protocols.WSTrust;
using Microsoft.IdentityModel.Protocols.WSTrust.Bindings;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Demo1
{
    class Program
    {
        public static JArray SamlTokens { get; set; }

        static void Main(string[] args)
        {
            var samlToken = GetSamlToken();

            JToken jObject = JToken.Parse(
                JsonConvert.SerializeObject(new object())
            );

            var count = SamlTokens.Count;

            Console.WriteLine(samlToken);
        }

        /// <summary>
        /// https://msdn.microsoft.com/en-us/library/ee517268.aspx
        /// </summary>
        /// <returns></returns>
        public static string GetSamlToken()
        {
            WSTrustChannelFactory wsTrustChannelFactory = new WSTrustChannelFactory(new WindowsWSTrustBinding());

            RequestSecurityToken requestSecurityToken =
                    new RequestSecurityToken(WSTrust13Constants.RequestTypes.Issue, WSTrust13Constants.KeyTypes.Bearer);

            requestSecurityToken.TokenType = Microsoft.IdentityModel.Tokens.SecurityTokenTypes.Saml2TokenProfile11;

            var channel = (WSTrustChannel)wsTrustChannelFactory.CreateChannel();

            return string.Empty;
        }
    }
}
