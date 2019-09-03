using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP3SIM
{
    public static class Generador
    {
        static Random random = new Random();
        public static List<double> Uniforme(float a, float b, int cantidad)
        {
            var numeros = new List<double>();
            for (int i = 0; i < cantidad; i++)
            {
                //Generar numero aleatorio entre 0 y 1
                var r = random.NextDouble();
                var valordeVariableAleatoria = a + r * (b - a);

                numeros.Add(Math.Round(valordeVariableAleatoria, 4));
            }

            return numeros;
        }

        public static List<double> Normal(float media, float desviacionEstandar, int cantidad)
        {
            var numeros = new List<double>();
            for (int i = 0; i < cantidad; i++)
            {
                //Generar numeros aleatorio entre 0 y 1
                var r1 = random.NextDouble();
                var r2 = random.NextDouble();

                var z = Math.Sqrt(-2 * Math.Log(r2)) * Math.Cos(2 * Math.PI * r1);

                var valordeVariableAleatoria = media + (z * desviacionEstandar);

                numeros.Add(Math.Round(valordeVariableAleatoria, 4));
            }

            return numeros;
        }

        public static List<double> ExponencialNegativa(float lambda, int cantidad)
        {
            var numeros = new List<double>();
            for (int i = 0; i < cantidad; i++)
            {
                //Generar numeros aleatorio entre 0 y 1
                var r = random.NextDouble();

                var valordeVariableAleatoria = -(1 / lambda) * Math.Log(1 - r);

                numeros.Add(Math.Round(valordeVariableAleatoria, 4));
            }

            return numeros;
        }

        /*public static List<double> Poisson(float lambda, int cantidad)
        {
            
        }*/
    }
}
