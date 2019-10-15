using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemasColasEPEC.Clases
{
    public class Reloj
    {// clase que guarda el valor del evento y el reloj del sistema para que los servidores y las colas sepan que hacer
        double hora;
        string evento;
        public Reloj()
        {
            hora = 0;
            evento = "Inicio";
        }
        public void setHora(double _hora)
        {
            hora = _hora;
        }
        public void setEvento(string _evento)
        {
            evento = _evento;
        }
        public string getEvento()
        {
            return evento;
        }
        public double getHora()
        {
            return hora;
        }
    }
}
