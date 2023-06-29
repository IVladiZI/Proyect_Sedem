using System.Xml.Serialization;
using System;

namespace Dominio.Entities.Qr
{
    //[XmlRoot(ElementName = "RequestData", Namespace = "")]
    public class RequestGetQr
    {
        [XmlElement(ElementName = "Cuenta")]
        public string Account { get; set; }
        [XmlElement(ElementName = "Importe")]
        public string Amount { get; set; }
        [XmlElement(ElementName = "Moneda")]
        public string Currency { get; set; }
        [XmlElement(ElementName = "Referencia")]
        public string Reference { get; set; }
        [XmlElement(ElementName = "Validez")]
        public string Valid { get; set; }
        [XmlElement(ElementName = "FormatoQR")]
        public string FormatQr { get; set; }
        [XmlElement(ElementName = "Items")]
        public Items Items { get; set; }
    }

    public class Items
    {
        [XmlElement(ElementName = "Item")]
        public Item Item { get; set; }
    }
    public class Item
    {
        [XmlElement(ElementName = "ItemDescripcion")]
        public string ItemDescription { get; set; }
        [XmlElement(ElementName = "ItemValor")]
        public string ItemValue { get; set; }
    }
}
