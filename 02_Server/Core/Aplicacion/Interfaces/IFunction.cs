using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion.Interfaces
{
    public interface IFunction
    {
        public string SerializeToString<T>(T value);
        public T ConvertXmlToObject<T>(string xml);
        public DateTime DateExpirationQr(string value);
    }
}
