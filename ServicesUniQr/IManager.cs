using System.Security.Cryptography.X509Certificates;
using System.Security.Cryptography;

namespace ServicesUniQr
{
    public interface IManager
    {
        public string Conection(string path);
        public string KeyXml(string path, string certificatePath, string keyNameValue);
        public string SignXmlFile(string path, RSA Key, X509Certificate2 myCert, string keyNameValue);
    }
}
