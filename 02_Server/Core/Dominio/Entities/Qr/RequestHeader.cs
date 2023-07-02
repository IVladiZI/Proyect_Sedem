using System.Xml.Serialization;
using System;

namespace Dominio.Entities.Qr
{
    //[XmlRoot(ElementName = "RequestHeader", Namespace = "")]
    public class RequestHeader
    {
        [XmlElement(ElementName = "Servicio")]
        public string Service { get; set; }
        [XmlElement(ElementName = "Usuario")]
        public string User { get; set; }
        [XmlElement(ElementName = "Password")]
        public string Password { get; set; }
        [XmlIgnore]
        private string _date { get; set; }
        [XmlIgnore]
        private string _time { get; set; }
        [XmlElement(ElementName = "Fecha")]
        public string Date
        {
            get
            {
                _date = DateTime.Now.ToString("dd/MM/yyyy");
                return this._date;
            }
            set
            {
                this._date = value;
            }
        }
        [XmlElement(ElementName = "Hora")]
        public string Time
        {
            get
            {
                _time = DateTime.Now.ToString("HH:mm:ss");
                return this._time;
            }
            set
            {
                this._time = value;
            }
        }
    }
}
