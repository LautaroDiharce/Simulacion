using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemasColasEPEC.Clases
{
    public class CalculoNormal:ICalculable
    {
        double media;
        double varianza;
        Random random; 
        public CalculoNormal(double _media,double _varianza)
        {
            media = _media;
            varianza = _varianza;
            random = new Random();
        }

        public double calcularTiempo()
        {
             
            double rnd1 = random.NextDouble();
            double rnd2 = random.NextDouble();
            double z = Math.Sqrt(-2 * Math.Log(1 - rnd1)) * Math.Sin(2 * Math.PI*rnd2);
            double x = media + z * varianza;
            return x;
        }
    }
}
