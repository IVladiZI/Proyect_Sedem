using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;

namespace ServiceUniQr
{
    public class Manager
    {
        public static void conexion()
        {
            ServicePointManager.SecurityProtocol |= SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
            ServicePointManager.ServerCertificateValidationCallback = delegate (object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors) { return true; };

            //QRServiceClient reference = new QRServiceClient();


        }
    }
}