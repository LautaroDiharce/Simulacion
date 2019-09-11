using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
        public static  float Factorial(float fact)
        {
            float numero, resultado = 1;

            numero = fact;

            for (int i = 1; i <= numero; i++)
            {
                resultado = resultado * i;
            }
            return resultado;
        }
        public static List<double> IntervalosPoisson(float lambda)
        {
            var euler = Math.E;
            double acum = 0;
            double valor;
            var poisson = new List<double>();
            for (int x = 0; acum < 0.999; x++)
            {

                valor = Math.Pow(lambda, x) * Math.Pow(euler, (-1) * lambda) / Factorial(x);
                acum = valor + acum;
                poisson.Add(Math.Round(acum, 3));
            }
            return poisson;
        }
        public static List<double> Poisson(float lambda, int cantidad)
        {
            var poisson = IntervalosPoisson(lambda);
            var numeros = new List<double>();
            for (int i = 0; i < cantidad; i++)
            {
                var num = 0;
                //Generar numeros aleatorio entre 0 y 1
                var r = random.NextDouble();
                for (int f = 0; f < poisson.Count(); f++)
                {
                    if (r > poisson[f])
                    {
                        num++;
                    }
                }
                numeros.Add(num);
            }
            return numeros;
        }
    }
}
