using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemasColasEPEC.Clases
{
    public class CalculoConstante:ICalculable
    {
        double constante;
        public CalculoConstante(double _constante)
        {
            constante = _constante;
        }
        public double calcularTiempo()
        {
            return constante;
        }
    }
}
