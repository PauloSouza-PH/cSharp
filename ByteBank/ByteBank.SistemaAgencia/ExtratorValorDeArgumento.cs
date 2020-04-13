using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank.SistemaAgencia
{
    public class ExtratorValorDeArgumento
    {
        private String _URL;
        public String URL
        {
            get
            {
                return _URL;
            }
            private set
            {
                if (String.IsNullOrEmpty(value))
                    throw new ArgumentException("Valor de argumento não informado " + nameof(URL));
            }
        }

        public ExtratorValorDeArgumento(String url)
        {
            URL = url.Substring(url.IndexOf("?"));
        }

        public List<String> GetQueryString() {
            List<String> argumentos = new List<string>();
            
            
            
            return null;
        }


    }
}
