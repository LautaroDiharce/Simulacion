using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemasColasEPEC.Clases
{
    public interface IServiciable
    {
        // metodo polimorfico para flexibilizar el comportamiento del tipo de servidor segun el evento, reloj y servicio
        void hacerAlgo(string evento, double reloj, int _servicio);
        // devuelve la proxima atencion del servidor en caso de que haya elementos en la colas
        double darProxFAT();
        //devuelve el nombre del servidor
        string darNombre();
        //devuelve el evento asociado al fin de atencion del servidor
        string darEvento();
        //devuelve el evento asociado al fin de atencion del servidor
        string darEventoFAT();
        // devuleve el estado del servidor
        string darEstado();
        //devuelve si el sistema termina con ese servidor
        bool sosUltimo();
        //devuelve si el sistema empieza con ese servidor
        bool sosPrimero();
    }
}
