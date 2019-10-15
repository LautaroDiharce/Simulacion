using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemasColasEPEC.Clases
{
    public class Cola:IColeable
    {
        int miembros;
        double proxLlegada;
        string eventoLlegada;
        string nombre;
        bool atendido;
        int servicio;
        ICalculable calculable;

        public Cola(ICalculable _calculable, string _eventoLlegada, string _nombre, int _servicio)
        {
            nombre = _nombre;
            calculable = _calculable;
            eventoLlegada = _eventoLlegada;
            miembros = 0;
            servicio = _servicio;
        }

        public string darNombre()
        {
            return nombre;
        }
        public double calcularProximaLlegada()
        {
            return calculable.calcularTiempo();
        }
        public bool tenesAlgo()
        {
            bool si = miembros > 0;
            return si;
        }
        public bool esTuEventoLlegada(string evento, int _servicio)
        {
            return evento == eventoLlegada;
        }
        public string darEventoLlegada()
        {
            return eventoLlegada;
        }
        public void setCalculable(ICalculable _calculable)
        {
            calculable = _calculable;
        }
        public int darMiembros()
        {
            return miembros;
        }
        public void agregarElemento()
        {
            miembros += 1;
        }
        public void quitarElemento()
        {
            miembros -= 1;
        }
        public void hacerAlgo(string evento, double reloj, int _servicio)
        {
            if(evento == "Inicio")
            {
                proxLlegada = calcularProximaLlegada() + reloj;
            }
            if (evento == eventoLlegada)
            {
                atendido = false;
                agregarElemento();
                proxLlegada = calcularProximaLlegada() + reloj;
            }
        }
        public double darProximaLlegada()
        {
            return proxLlegada;
        }
        public bool estaAtendido()
        {
            return atendido;
        }
        public void setAtencion(bool _atencion)
        {
            atendido = _atencion;
        }
        public string darElementosString()
        {
            return miembros.ToString();
        }

        public string darEvento()
        {
            return eventoLlegada;
        }

        public void agregarServidore(List<IServiciable> _servidores)
        {

        }

        public bool entradaSistema()
        {
            return true; ;
        }
    }
}
