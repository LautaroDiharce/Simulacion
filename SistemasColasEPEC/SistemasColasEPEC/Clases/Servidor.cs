using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemasColasEPEC.Clases
{
    public class Servidor:IServiciable
    {//servidor estandar que tiene asociado una cola, un evento y una forma de calcular la proxima atencion
        IColeable cola;
        ICalculable calculable;
        double proxFAT;
        int estado;
        string nombre;
        String eventoFat;
        bool ultimo;
        bool primero;

        //Instanciacion del servidor con una cola, una forma de calcular el proximo fin de atencion, el evento de fin de atencion, el nombre del servidor, si es primer servidor del sistema, si es ultimo servidor del sistema
        public Servidor(IColeable _cola, ICalculable _calculable, string _eventoFat, string _nombre, bool _ultimo, bool _primero)
        {
            estado = 0;
            cola = _cola;
            eventoFat = _eventoFat;
            calculable = _calculable;
            nombre = _nombre;
            proxFAT = -1;
            ultimo = _ultimo;
            primero = _primero;
        }
        public bool sosPrimero()
        {
            return primero;
        }
        public bool sosUltimo()
        {
            return ultimo;
        }
        public string darNombre()
        {
            return nombre;
        }
        public string darEventoFat()
        {
            return eventoFat;
        }
        public double calcularProximaFAT()
        {

            return calculable.calcularTiempo();
        }
        public string darEstado()
        {
            return estado.ToString(); 
        }
        public void setCola(IColeable _cola)
        {
            cola = _cola;
        }
        public void setCalculadora(ICalculable _calculable)
        {
            calculable = _calculable;
        }
        public double darProxFAT()
        {
            return proxFAT;
        }
        //realizacion del metodo de la interfaz, el servidor se comporta segun el evento y el servicio que se calculo
        public void hacerAlgo(string evento, double reloj, int _servicio)
        {
            //Si el evento es la llegada de un cliente y esta libre y loa atiende
            if (cola.esTuEventoLlegada(evento, _servicio))
            {
                if (estado == 0)
                {
                    if (!cola.estaAtendido())
                    {
                        cola.quitarElemento();
                        cola.setAtencion(true);
                        proxFAT = calcularProximaFAT() + reloj;
                        estado = 1;
                    }

                }

            }
            //si el evento es un fin de atencion y hay clientes en la cola entonces calcula el proximo fin de atencion y quita un cliente de la cola
            if (evento == eventoFat)
            {

                if (cola.tenesAlgo())
                {
                    cola.quitarElemento();
                    proxFAT = calcularProximaFAT() + reloj;

                }
                else
                {
                    proxFAT = -1;
                    estado = 0;
                }
            }



        }

        public string darEvento()
        {
            return eventoFat;
        }

        public string darEventoFAT()
        {
            return eventoFat;
        }
    }
}
