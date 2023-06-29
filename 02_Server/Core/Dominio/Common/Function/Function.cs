using System;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace Dominio.Common.Function
{
    public class Function
    {
        public string SerializeToString<T>(T value)
        {
            var emptyNamespaces = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });
            var serializer = new XmlSerializer(value.GetType());
            var settings = new XmlWriterSettings();
            settings.Indent = true;
            settings.OmitXmlDeclaration = true;

            using (var stream = new StringWriter())
            using (var writer = XmlWriter.Create(stream, settings))
            {
                serializer.Serialize(writer, value, emptyNamespaces);
                return stream.ToString();
            }
        }
        public T ConvertXmlToObject<T>(string xml)
        {
            try
            {
                T obj;
                using (StringReader reader = new StringReader(xml))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(T));
                    obj = (T)serializer.Deserialize(reader);
                }
                return obj;
            }
            catch (Exception e)
            {
                throw e;
            }
            
        }
    }
}
