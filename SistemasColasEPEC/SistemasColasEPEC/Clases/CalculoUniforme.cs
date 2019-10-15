using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemasColasEPEC.Clases
{
    public class CalculoUniforme:ICalculable
    {
        double mayor;
        double menor;
        Random random;
        public CalculoUniforme(double _mayor, double _menor)
        {
            random = new Random();
            menor = _menor;
            mayor = _mayor;
        }
        public double calcularTiempo()
        {
            return menor + (mayor - menor) * random.NextDouble();
        }
    }
}
