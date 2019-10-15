using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemasColasEPEC.Clases
{
    public class CalculoExponencialNegativa:ICalculable
    {
        double lambda;
        Random random;
        public CalculoExponencialNegativa(double _lambda)
        {
            lambda = _lambda;
            random = new Random();
        }
        public double calcularTiempo()
        {
            return (-1 * lambda) * Math.Log(1 - random.NextDouble());
        }
    }
}
