using Dominio.Entities.Qr;
using Microsoft.Extensions.Configuration;
using System;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Security.Cryptography.Xml;
using System.Xml;
namespace ServiceUniQr
{
    public class Manager
    {
        private string User;
        private string Password;
        public string _time;
        public string XmlSigned;
        private DateTime DateTime = DateTime.Now;
        private readonly IConfiguration _configuration;
        public Manager()
        {
            _time = DateTime.ToString("dd/MM/yyyy HH:mm:ss");
        }
        public string Conection(string path)
        {
            try
            {
                using QRServiceClient reference = new(QRServiceClient.EndpointConfiguration.BasicHttpBinding_IQRService);
                XmlDocument xmlDoc = new();
                xmlDoc.LoadXml(path);
                return reference.BunApi(xmlDoc.OuterXml);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public string KeyXml(string path)
        {
            try
            {
                try
                {
                    X509Certificate2 myCert = null;
                    var store = new X509Store(StoreLocation.CurrentUser); //StoreLocation.LocalMachine fails too
                    store.Open(OpenFlags.ReadOnly);
                    var certificates = store.Certificates;
                    foreach (var certificate in certificates)
                    {
                        if (certificate.Subject.Contains("CN=SedemCert"))
                        {
                            myCert = certificate;
                            break;
                        }
                    }

                    if (myCert != null)
                    {
                        RSA rsaKey = ((RSA)myCert.PrivateKey);
                        XmlSigned = SignXmlFile(path, rsaKey, myCert);
                    }
                    return XmlSigned;
                }
                catch (CryptographicException e)
                {
                    Console.WriteLine(e.Message);
                    throw e;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public string SignXmlFile(string path, RSA Key, X509Certificate2 myCert)
        {
            try
            {
                // Create a new XML document.
                XmlDocument doc = new XmlDocument();
                doc.LoadXml(path);
                // Create a SignedXml object.
                SignedXml signedXml = new SignedXml(doc);
                // Add the key to the SignedXml document. 
                signedXml.SigningKey = Key;

                // Create a data object to hold the data to sign.
                DataObject dataObject = new DataObject();
                dataObject.Data = doc.ChildNodes;
                dataObject.Id = _time;

                // Add the data object to the signature.
                signedXml.AddObject(dataObject);

                // Create a reference to be signed.
                Reference reference = new Reference();
                // Add an enveloped transformation to the reference.
                XmlDsigC14NTransform c14t = new XmlDsigC14NTransform();
                reference.AddTransform(c14t);
                // Format the document to ignore white spaces.
                doc.PreserveWhitespace = true;

                // Load the passed XML file using it's name.
                reference.Uri = $"#{_time}";
                reference.DigestMethod = SignedXml.XmlDsigSHA1Url;

                // Add the reference to the SignedXml object.
                signedXml.AddReference(reference);

                // Create a new KeyInfo object.
                KeyInfo keyInfo = new KeyInfo();

                // Load the certificate into a KeyInfoX509Data object
                // and add it to the KeyInfo object.
                keyInfo.AddClause(new KeyInfoX509Data(myCert));
                KeyInfoName keyName = new();
                keyName.Value = "oad913";
                keyInfo.AddClause(keyName);
                // Add the KeyInfo object to the SignedXml object.
                signedXml.KeyInfo = keyInfo;

                signedXml.SignedInfo.SignatureMethod = SignedXml.XmlDsigRSASHA1Url;

                // Compute the signature.
                signedXml.ComputeSignature();

                // Get the XML representation of the signature and save
                // it to an XmlElement object.
                XmlElement xmlDigitalSignature = signedXml.GetXml();
                XmlDocument docSigned = new();

                //(1) the xml declaration is recommended, but not mandatory
                XmlDeclaration xmlDeclaration = docSigned.CreateXmlDeclaration("1.0", "UTF-8", null);
                XmlElement root = docSigned.DocumentElement;
                docSigned.InsertBefore(xmlDeclaration, root);
                // Append the element to the XML document.
                docSigned.AppendChild(docSigned.ImportNode(xmlDigitalSignature, true));

                if (docSigned.FirstChild is XmlDeclaration)
                {
                    docSigned.RemoveChild(docSigned.FirstChild);
                }

                return docSigned.OuterXml;
            }
            catch (Exception e)
            {
                throw e;
            }

        }
        public string RequestHeader(RequestHeader requestHeader)
        {
            try
            {
                XmlDocument xmlDoc = new();

                XmlNode data = xmlDoc.CreateElement("Data");
                XmlAttribute attribute = xmlDoc.CreateAttribute("xmlns");
                attribute.Value = "";
                data.Attributes.Append(attribute);
                xmlDoc.AppendChild(data);

                XmlNode requestHeaderNode = xmlDoc.CreateElement("RequestHeader");
                data.AppendChild(requestHeaderNode);

                XmlNode service = xmlDoc.CreateElement("Servicio");
                service.InnerText = requestHeader.Service;
                requestHeaderNode.AppendChild(service);

                XmlNode user = xmlDoc.CreateElement("Usuario");
                user.InnerText = requestHeader.User;
                requestHeaderNode.AppendChild(user);

                XmlNode password = xmlDoc.CreateElement("Password");
                password.InnerText = requestHeader.Password;
                requestHeaderNode.AppendChild(password);

                XmlNode fecha = xmlDoc.CreateElement("Fecha");
                fecha.InnerText = DateTime.ToString("dd/MM/yyyy");
                requestHeaderNode.AppendChild(fecha);

                XmlNode hora = xmlDoc.CreateElement("Hora");
                hora.InnerText = DateTime.ToString("HH:mm:ss");
                requestHeaderNode.AppendChild(hora);
                return xmlDoc.OuterXml;
            }
            catch (Exception e)
            {

                throw e;
            }
        }
        public string RequestDataGetQr(string path, RequestGetQr requestGetQr)
        {
            try
            {
                XmlDocument xmlDoc = new();
                xmlDoc.LoadXml(path);

                XmlNode data = xmlDoc.DocumentElement;

                XmlNode requestData = xmlDoc.CreateElement("RequestData");
                data.AppendChild(requestData);

                XmlNode account = xmlDoc.CreateElement("Cuenta");
                account.InnerText = requestGetQr.Account;
                requestData.AppendChild(account);

                XmlNode amount = xmlDoc.CreateElement("Importe");
                amount.InnerText = requestGetQr.Amount;
                requestData.AppendChild(amount);

                XmlNode currency = xmlDoc.CreateElement("Moneda");
                currency.InnerText = requestGetQr.Currency;
                requestData.AppendChild(currency);

                XmlNode reference = xmlDoc.CreateElement("Referencia");
                reference.InnerText = requestGetQr.Reference;
                requestData.AppendChild(reference);

                XmlNode valid = xmlDoc.CreateElement("Validez");
                valid.InnerText = requestGetQr.Valid;
                requestData.AppendChild(valid);

                XmlNode formatQr = xmlDoc.CreateElement("FormatoQR");
                formatQr.InnerText = requestGetQr.FormatQr;
                requestData.AppendChild(formatQr);

                XmlNode items = xmlDoc.CreateElement("Items");
                requestData.AppendChild(items);

                XmlNode item = xmlDoc.CreateElement("Item");
                items.AppendChild(item);

                /*XmlNode itemDescription = xmlDoc.CreateElement("ItemDescripcion");
                itemDescription.InnerText = requestGetQr.ItemDescription;
                item.AppendChild(itemDescription);

                XmlNode itemValue = xmlDoc.CreateElement("ItemValor");
                itemValue.InnerText = requestGetQr.ItemValue;
                item.AppendChild(itemValue);*/

                return xmlDoc.OuterXml;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}