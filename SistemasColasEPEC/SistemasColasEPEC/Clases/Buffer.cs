using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemasColasEPEC.Clases
{
    public class Buffer:IColeable
    {
        List<IServiciable> servidores;
        int miembros;
        string nombre;
        bool atendido;
        int servicio;
        List<string> eventosLlegada;
        public Buffer(string _nombre, List<IServiciable> _servidores, int _servicio)
        {
            servidores = _servidores;
            eventosLlegada = new List<string>();
            nombre = _nombre;
            atendido = false;
            miembros = 0;
            servicio = _servicio;
        }
        public string darNombre()
        {
            return nombre;
        }
        public void agregarElemento()
        {
            miembros += 1;
        }


        public double calcularProximaLlegada()
        {
            return -1;
        }

        public double darProximaLlegada()
        {
            return -1;
        }
        public bool esTuEventoLlegada(string evento, int _servicio)
        {
            bool eve = false;
            if (servicio != _servicio)
            {
                return false;
            }
            for (int i = 0; i < servidores.Count; i++)
            {
                if (evento == servidores[i].darEventoFAT())
                {
                    eve = true;
                    break;
                }
            }
            return eve;
        }
        public void hacerAlgo(string evento, double reloj, int _servicio)
        {
            bool fat = false;
            if (servicio == _servicio)
            {
                for (int i = 0; i < servidores.Count; i++)
                {
                    if (servidores[i].darEventoFAT() == evento)
                    {
                        fat = true;
                        break;
                    }
                }
            }
            if (fat)
            {
                atendido = false;
                agregarElemento();
            }
        }

        public void quitarElemento()
        {
            miembros -= 1;
        }

        public bool tenesAlgo()
        {
            return miembros > 0;
        }

        public string darElementosString()
        {
            return miembros.ToString();
        }
        public bool estaAtendido()
        {
            return atendido;
        }
        public void setAtencion(bool _atencion)
        {
            atendido = _atencion;
        }
        public string darEvento()
        {
            return "";
        }

        public bool entradaSistema()
        {
            return false;
        }
    }
}
