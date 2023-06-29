using System.Xml.Serialization;

namespace Dominio.Entities.Qr
{
    [XmlRoot(ElementName = "Data", Namespace = "")]
    public class RequestXml
    {
        [XmlAttribute(AttributeName = "xmlns", Namespace = "")]
        public string Xmlns;
        [XmlElement(ElementName = "RequestHeader")]
        public RequestHeader requestHeader;
        [XmlElement(ElementName = "RequestData")]
        public RequestGetQr requestGetQr;
    }
}
