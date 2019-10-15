using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemasColasEPEC.Clases
{
    public class Tester
    {
        List<string> valores;
        public Tester()
        {
            valores = new List<string>();
        }
        public void agregarValor(string valor)
        {
            valores.Add(valor);
        }
        public List<string> darValores()
        {
            return valores;
        }
    }
}
