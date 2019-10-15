using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemasColasEPEC.Clases
{
    //Servidor que tiene la salvedad de interrumpirse bajo alguna condicion
    public class ServidorInterrupcion : IServiciable
    {
        IColeable cola;
        ICalculable calculable;
        ICalculable calculableInterrupcion;
        double proxFAT;
        int estado;
        string eventoFinInterrupcion;
        bool interrumpido;
        int cantLimite;
        int atendidos;
        string nombre;
        String eventoFat;
        bool ultimo;
        bool primero;
        //inicializa al servidor con lo mismo que un servidor estandar y con la condicion de interrupcion junto con su calculo
        public ServidorInterrupcion(IColeable _cola,ICalculable _calculableInterrupcion, ICalculable _calculable, string _eventoFat, string _nombre,string _eventoFinInterrupcion, int _cantLimite,bool _ultimo, bool _primero)
        {
            estado = 0;
            cola = _cola;
            eventoFat = _eventoFat;
            calculable = _calculable;
            nombre = _nombre;
            proxFAT = -1;
            eventoFinInterrupcion = _eventoFinInterrupcion;
            cantLimite = _cantLimite;
            interrumpido = false;
            atendidos = 0;
            calculableInterrupcion = _calculableInterrupcion;
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
        public string darEstado()
        {
            return estado.ToString();
        }
        public string darEvento()
        {
            if (interrumpido)
            {
                return eventoFinInterrupcion;
            }
            return eventoFat;
        }

        public string darEventoFAT()
        {
            if (interrumpido)
            {
                return eventoFinInterrupcion;
            }
            return eventoFat;
        }

        public string darNombre()
        {
            return nombre;
        }

        public double darProxFAT()
        {
            return proxFAT;
        }
        private double calcularFinInterrupcion()
        {
            return calculableInterrupcion.calcularTiempo();
        }
        public double calcularProximaFAT()
        {

            return calculable.calcularTiempo();
        }
        public void hacerAlgo(string evento, double reloj, int _servicio)
        {
            //evalua si el servidor esta interrupido
            if (interrumpido)
            {
                //si esta interrumpido y el evento es fin de interrupcion entonces se liber el servidor
                if (evento == eventoFinInterrupcion)
                {
                    estado = 0;
                    interrumpido = false;
                    atendidos = 0;
                    proxFAT = -1;
                    //verifica si la cola tiene algo en ese caso atiende un cliente
                    if (cola.tenesAlgo())
                    {

                        cola.quitarElemento();
                        
                        proxFAT = calcularProximaFAT() + reloj;
                        estado = 1;
                        atendidos += 1;

                    }
                    else
                    {
                        proxFAT = -1;
                        estado = 0;
                    }
                }
            }
            else
            {
                //verifica ante un evento si la cola esta libre  y la atiende
                if (estado == 0 && cola.tenesAlgo())
                {
                    if (!cola.estaAtendido())
                    {
                        cola.quitarElemento();
                        proxFAT = calcularProximaFAT() + reloj;
                        estado = 1;
                        atendidos += 1;
                    }

                }
                //verifica si el evento y el servicio pertenece a la cola en caso de estar libre lo atiende
                if (cola.esTuEventoLlegada(evento, _servicio))
                {
                    if (estado == 0 && cola.tenesAlgo())
                    {
                        if (!cola.estaAtendido())
                        {
                            cola.quitarElemento();
                            cola.setAtencion(true);
                            proxFAT = calcularProximaFAT() + reloj;
                            estado = 1;
                            atendidos += 1;
                        }

                    }

                }
                // en caso de el evento sea un fin de atencion y lo cola tiene clientes, atiende a uno sino se libera
                if (evento == eventoFat)
                {
                    if (cola.tenesAlgo())
                    {

                        cola.quitarElemento();

                        proxFAT = calcularProximaFAT() + reloj;
                        atendidos += 1;

                    }
                    else
                    {
                        proxFAT = -1;
                        estado = 0;
                    }
                }
            }
            if (cantLimite == atendidos && !interrumpido)
            {
                interrumpido = true;
                proxFAT = calcularProximaFAT() + reloj;
                estado = 2;
            }
        }
    }
}
