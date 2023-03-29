using PayoutsSdk.Core;
using PayPalHttp;
using System.Collections.Generic;

namespace GamesPlatform
{
    public class PayPalClient
    {

        public static PayPalEnvironment environment()
        {
            return new SandboxEnvironment(System.Environment.GetEnvironmentVariable("PAYPAL_CLIENT_ID") != null ? System.Environment.GetEnvironmentVariable("PAYPAL_CLIENT_ID") : "AVj-IsYoEFbkHc82nnlQncM4R2c9yi47nhnFGLZta8b8ccR3zMiNr7a-fJqq6ZLeEuGhKHCYt_ZynDC8", System.Environment.GetEnvironmentVariable("PAYPAL_CLIENT_SECRET") != null ? System.Environment.GetEnvironmentVariable("PAYPAL_CLIENT_SECRET") : "EDvu4qdJPqGW6FNc6YpZqYBgv0BiaoKO06ZmtIC2kvrAyuDiP012j52aes3eZhP4XZMeMkPkSTwG6ajC");
        }
        public static PayPalHttp.HttpClient client()
        {
            return new PayPalHttpClient(environment());
        }
        public static PayPalHttp.HttpClient client(string refreshToken)
        {
            return new PayPalHttpClient(environment(), refreshToken);
        }
    }
}