using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemasColasEPEC.Clases
{
    public class Multiplexor
    {
        List<string> eventos;
        List<List<int>> servicios;
        List<List<double>> probabilidades;
        public Multiplexor()
        {
            eventos = new List<string>();
            servicios = new List<List<int>>();
            probabilidades = new List<List<double>>();
        }
        //agregar el evento de un servidor con las probabilidades que ocurra con un servicio
        public void agregarEvento(string _evento, List<int> _servicio, List<double> _probabilidad)
        {
            eventos.Add(_evento);
            servicios.Add(_servicio);
            probabilidades.Add(_probabilidad);
        }
        //metodo para calcular el servicio del servidor si es el evento adecuado
        public int hacerAlgo(string _evento)
        {
            int cant = eventos.Count;
            for (int i = 0; i < cant; i++)
            {
                if (eventos[i] == _evento)
                {
                    Random random = new Random();
                    double rnd = random.NextDouble();
                    double acumulado = probabilidades[i][0];
                    int j = 0;
                    while (rnd > acumulado || j == probabilidades[i].Count)
                    {
                        acumulado += probabilidades[i][j + 1];
                        j += 1;
                    }
                    return servicios[i][j];
                }
            }
            return 0;
        }
        public void Clear()
        {
            eventos.Clear();
            servicios.Clear();
            probabilidades.Clear();
        }
    }
}
