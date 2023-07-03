using System;
using System.Xml.Serialization;

namespace Dominio.Entities.Qr
{
    public class ResponseXml
    {
        // using System.Xml.Serialization;
        // XmlSerializer serializer = new XmlSerializer(typeof(Signature));
        // using (StringReader reader = new StringReader(xml))
        // {
        //    var test = (Signature)serializer.Deserialize(reader);
        // }

        [XmlRoot(ElementName = "CanonicalizationMethod", Namespace = "")]
        public class CanonicalizationMethod
        {

            [XmlAttribute(AttributeName = "Algorithm", Namespace = "")]
            public string Algorithm;
        }

        [XmlRoot(ElementName = "SignatureMethod", Namespace = "http://www.w3.org/2000/09/xmldsig#")]
        public class SignatureMethod
        {

            [XmlAttribute(AttributeName = "Algorithm", Namespace = "")]
            public string Algorithm;
        }

        [XmlRoot(ElementName = "Transform", Namespace = "http://www.w3.org/2000/09/xmldsig#")]
        public class Transform
        {

            [XmlAttribute(AttributeName = "Algorithm", Namespace = "")]
            public string Algorithm;
        }

        [XmlRoot(ElementName = "Transforms", Namespace = "http://www.w3.org/2000/09/xmldsig#")]
        public class Transforms
        {

            [XmlElement(ElementName = "Transform", Namespace = "http://www.w3.org/2000/09/xmldsig#")]
            public Transform Transform;
        }

        [XmlRoot(ElementName = "DigestMethod", Namespace = "http://www.w3.org/2000/09/xmldsig#")]
        public class DigestMethod
        {

            [XmlAttribute(AttributeName = "Algorithm", Namespace = "")]
            public string Algorithm;
        }

        [XmlRoot(ElementName = "Reference", Namespace = "http://www.w3.org/2000/09/xmldsig#")]
        public class Reference
        {

            [XmlElement(ElementName = "Transforms", Namespace = "http://www.w3.org/2000/09/xmldsig#")]
            public Transforms Transforms;

            [XmlElement(ElementName = "DigestMethod", Namespace = "http://www.w3.org/2000/09/xmldsig#")]
            public DigestMethod DigestMethod;

            [XmlElement(ElementName = "DigestValue", Namespace = "http://www.w3.org/2000/09/xmldsig#")]
            public string DigestValue;

            [XmlAttribute(AttributeName = "URI", Namespace = "")]
            public string URI;

            [XmlText]
            public string Text;
        }

        [XmlRoot(ElementName = "SignedInfo", Namespace = "http://www.w3.org/2000/09/xmldsig#")]
        public class SignedInfo
        {

            [XmlElement(ElementName = "CanonicalizationMethod", Namespace = "http://www.w3.org/2000/09/xmldsig#")]
            public CanonicalizationMethod CanonicalizationMethod;

            [XmlElement(ElementName = "SignatureMethod", Namespace = "http://www.w3.org/2000/09/xmldsig#")]
            public SignatureMethod SignatureMethod;

            [XmlElement(ElementName = "Reference", Namespace = "http://www.w3.org/2000/09/xmldsig#")]
            public Reference Reference;
        }

        [XmlRoot(ElementName = "X509Data", Namespace = "http://www.w3.org/2000/09/xmldsig#")]
        public class X509Data
        {

            [XmlElement(ElementName = "X509Certificate", Namespace = "http://www.w3.org/2000/09/xmldsig#")]
            public string X509Certificate;
        }

        [XmlRoot(ElementName = "KeyInfo", Namespace = "http://www.w3.org/2000/09/xmldsig#")]
        public class KeyInfo
        {

            [XmlElement(ElementName = "X509Data", Namespace = "http://www.w3.org/2000/09/xmldsig#")]
            public X509Data X509Data;

            [XmlElement(ElementName = "KeyName", Namespace = "http://www.w3.org/2000/09/xmldsig#")]
            public string KeyName;
        }

        [XmlRoot(ElementName = "ResponseHeader", Namespace = "")]
        public class ResponseHeader
        {

            [XmlElement(ElementName = "ResultCode", Namespace = "")]
            public string ResultCode;

            [XmlElement(ElementName = "Message", Namespace = "")]
            public string Message;
            [XmlIgnore]
            public DateTime Expiration;
        }

        [XmlRoot(ElementName = "ResponseData", Namespace = "")]
        public class ResponseData
        {

            [XmlElement(ElementName = "IdQr", Namespace = "")]
            public string IdQr;

            [XmlElement(ElementName = "DataQR", Namespace = "")]
            public string DataQR;
        }

        [XmlRoot(ElementName = "Response", Namespace = "")]
        public class Response
        {

            [XmlElement(ElementName = "ResponseHeader", Namespace = "")]
            public ResponseHeader ResponseHeader;

            [XmlElement(ElementName = "ResponseData", Namespace = "")]
            public ResponseData ResponseData;

            [XmlAttribute(AttributeName = "xmlns", Namespace = "")]
            public string Xmlns;

            [XmlText]
            public string Text;
        }

        [XmlRoot(ElementName = "Object", Namespace = "http://www.w3.org/2000/09/xmldsig#")]
        public class Object
        {

            [XmlElement(ElementName = "Response", Namespace = "")]
            public Response Response;

            [XmlAttribute(AttributeName = "Id", Namespace = "")]
            public string Id;

            [XmlText]
            public string Text;
        }

        [XmlRoot(ElementName = "Signature", Namespace = "http://www.w3.org/2000/09/xmldsig#")]
        public class Signature
        {

            [XmlElement(ElementName = "SignedInfo", Namespace = "http://www.w3.org/2000/09/xmldsig#")]
            public SignedInfo SignedInfo;

            [XmlElement(ElementName = "SignatureValue", Namespace = "http://www.w3.org/2000/09/xmldsig#")]
            public string SignatureValue;

            [XmlElement(ElementName = "KeyInfo", Namespace = "http://www.w3.org/2000/09/xmldsig#")]
            public KeyInfo KeyInfo;

            [XmlElement(ElementName = "Object", Namespace = "http://www.w3.org/2000/09/xmldsig#")]
            public Object Object;

            [XmlAttribute(AttributeName = "xmlns", Namespace = "")]
            public string Xmlns;

            [XmlText]
            public string Text;
        }
    }

}
