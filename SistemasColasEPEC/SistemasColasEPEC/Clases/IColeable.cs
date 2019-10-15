using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemasColasEPEC.Clases
{
    public interface IColeable
    {
        //true=> cola>0, false cola=0
        bool tenesAlgo();
        // devuelve la cantidad de clientes que hay en la cola
        string darElementosString();
        // devuelve el nombre de la cola
        string darNombre();
        // devuelve el evento de llegada al que esta asociada
        string darEvento();
        //agrega un nuevo cliente
        void agregarElemento();
        //eliminar un cliente
        void quitarElemento();
        // devuelve la proxima llegada de un cliente a la cola
        double darProximaLlegada();
        // devuelve si la llegada de un cliente fue atendida o no
        bool estaAtendido();
        // determina si la llegada de un cliente y determina si fue atendida
        void setAtencion(bool _atencion);
        // devuelve si la cola esta asociada a ese evento y al servicio prestado por el servidor
        bool esTuEventoLlegada(string evento, int _servicio);
        // metodo polimorfico para flexibilizar el comportamiento de la cola segun sea la hora, el evento y el servicio
        void hacerAlgo(string evento, double reloj, int _servicio);
        // determina si el sistema comienza con esta cola 
        bool entradaSistema();
    }
}
