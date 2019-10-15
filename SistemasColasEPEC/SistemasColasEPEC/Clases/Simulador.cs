using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemasColasEPEC.Clases
{
    public class Simulador
    {
        // clase encargada de gestionar la simulacion un sistema de colas
        List<IServiciable> servidores;
        Servidor servidor;
        Cola cola;
        List<IColeable> colas;
        List<Reloj> relojes;
        Reloj reloj;
        double tiempoEspera;
        List<Tester> testers;
        Multiplexor multiplexor;
        double clientesTotalSistema;
        int simulaciones;
        double promedioDeCamiones;
        double TiempoPromedioClientEnSistema;
        double clientesActual;
        public Simulador()
        {
            reloj = new Reloj();
            servidores = new List<IServiciable>();
            colas = new List<IColeable>();
            relojes = new List<Reloj>();
            testers = new List<Tester>();
            multiplexor = new Multiplexor();
            clientesTotalSistema = 0;
            TiempoPromedioClientEnSistema = 0;
            tiempoEspera = 0;
            clientesActual = 0;
            simulaciones = 0;
            promedioDeCamiones = 0;
        }

        public void agregarServidor(IServiciable servidor)
        {
            servidores.Add(servidor);
        }
        //metodo para testear al software
        public void crearServidor(Servidor serviciable)
        {
            servidor = serviciable;
        }
        //metodo para testerar al software
        public void crearCola(Cola _cola)
        {
            cola = _cola;
        }
        public void agregarCola(IColeable cola)
        {
            colas.Add(cola);
        }
        // agregar un servidor y asociarlo a la clase multiplexor que tiene la funcion de calcular el servicio de un servidor. Segun el tipo de servicio se agregar a una u otra colas.
        // En caso de EPEC es si el camion es propio u contratado
        public void agregarEventoMultiplexor(IServiciable servidor, List<int> servicios, List<double> probabilidades)
        {
            agregarServidor(servidor);
            multiplexor.agregarEvento(servidor.darEvento(), servicios, probabilidades);
        }
        public void simular(int cantidad)
        {
            // base de los siguientes metodos para simular, no se utiliza en realidad
            reloj = new Reloj();
            string _evento = reloj.getEvento();
            double _min = reloj.getHora();
            int servicio = 0;
            double clientesTotalSistemaAntes = clientesTotalSistema;
            for (int j = 0; j < cantidad; j++)
            {
                servicio = multiplexor.hacerAlgo(_evento);
                bool flagComenzo = false;
                for (int i = 0; i < colas.Count; i++)
                {
                    colas[i].hacerAlgo(reloj.getEvento(), reloj.getHora(), servicio);
                    if (!flagComenzo)
                    {
                        if (colas[i].darProximaLlegada() != -1)
                        {
                            _min = colas[i].darProximaLlegada();
                            _evento = colas[i].darEvento();
                            flagComenzo = true;
                        }
                    }
                    if (_min > colas[i].darProximaLlegada() && colas[i].darProximaLlegada() != -1)
                    {
                        _min = colas[i].darProximaLlegada();
                        _evento = colas[i].darEvento();
                    }

                }
                for (int i = 0; i < servidores.Count; i++)
                {
                    servidores[i].hacerAlgo(reloj.getEvento(), reloj.getHora(), servicio);
                    if (servidores[i].darProxFAT() != -1 && _min > servidores[i].darProxFAT())
                    {
                        _min = servidores[i].darProxFAT();
                        _evento = servidores[i].darEvento();
                    }
                }
                for(int i =0; i < servidores.Count; i++)
                {
                    if (_evento == servidores[i].darEvento())
                    {
                        if (servidores[i].sosUltimo())
                        {
                            clientesActual -= 1;
                        }
                    }
                }
                for(int i = 0; i < colas.Count; i++)
                {
                    if (_evento == colas[i].darEvento())
                    {
                        if (colas[i].entradaSistema())
                        {
                            clientesActual += 1;
                            clientesTotalSistema += 1;
                        }
                    }
                }
                TiempoPromedioClientEnSistema = (TiempoPromedioClientEnSistema * clientesTotalSistemaAntes + (_min-reloj.getHora()) * clientesActual) / clientesTotalSistema;
                Tester tester = crearTester(servicio);
                testers.Add(tester);
                reloj.setEvento(_evento);
                reloj.setHora(_min);
                clientesTotalSistemaAntes = clientesTotalSistema;
            }
            simulaciones = cantidad;
        }
        public void simularDia(double finDia,double comienzoDia)
        {
            // Se inicializa los valores de reloj y las banderas que controlan la simulacion del dia
            reloj = new Reloj();
            reloj.setHora(comienzoDia);
            string _evento = reloj.getEvento();
            double _min = reloj.getHora();
            int servicio = 0;
            bool colasVacias=false;
            bool finSimulacionDia = false;
            bool libres = false;
            double clientesTotalSistemaAntes = clientesTotalSistema;
            // Se termina de simular el dia cuando haya terminado
            while ( (!finSimulacionDia || !libres))
            {

                simulaciones += 1;
                // comprueba si las termino el dia y comprueba si todas las colas estan vacias
                if (finSimulacionDia)
                {
                    // comprueba si todas las colas estan vacias
                    for(int i = 0; i < colas.Count; i++)
                    {
                        if (colas[i].tenesAlgo())
                        {
                            colasVacias = false;
                            break;                        
                        }
                        else
                        {
                            colasVacias = true;
                        }
                    }
                    
                }
                // si estan todas las colas vacias comprueba si todos los servidores estan libres
                if (colasVacias)
                {
                    for(int i = 0; i < servidores.Count; i++)
                    {
                        if (servidores[i].darEstado() == "0" || servidores[i].darEstado()=="2")
                        {
                            libres = true;
                        }
                        else
                        {
                            libres = false;
                            break;
                        }
                    }
                }
                // si es el fin del dia, si no hay nadie en la colas y los servidores estan libres entonces que se corte la simulacion
                if (finSimulacionDia && libres)
                {
                    break;
                }
                // se recalculan los valores de cantidad de clientes en el sistema
                for (int i = 0; i < servidores.Count; i++)
                {
                    if (reloj.getEvento() == servidores[i].darEvento())
                    {
                        if (servidores[i].sosUltimo())
                        {
                            clientesActual -= 1;
                        }
                    }
                }
                // Agrega miembros a al sistema y al historico de clientes
                for (int i = 0; i < colas.Count; i++)
                {
                    if (reloj.getEvento() == colas[i].darEvento())
                    {
                        if (colas[i].entradaSistema())
                        {
                            clientesActual += 1;
                            clientesTotalSistema += 1;
                        }
                    }
                }
                // calcula el servicio segun el evento para agregarselo a una cola
                servicio = multiplexor.hacerAlgo(_evento);
                // flag comenzo permite inicializar la variable _min con algo distinto a -1
                bool flagComenzo = false;
                // el metodo hacerAlgo es polimorfico en las diferentes realizaciones y su comportamiento depende de la hora y el evento
                // agregar un elemento en las colas en caso de que sea el evento y el servicio sean los adecuados
                for (int i = 0; i < colas.Count; i++)
                {

                    colas[i].hacerAlgo(reloj.getEvento(), reloj.getHora(), servicio);
                    // se calcula el tiempo mas chico para comparar, siempre cuando la cola sea la primera y que no sea el fin de simulacion
                    if (!flagComenzo && !finSimulacionDia)
                    {
                            if (colas[i].darProximaLlegada() != -1 )
                            {
                                _min = colas[i].darProximaLlegada();
                                _evento = colas[i].darEvento();
                                flagComenzo = true;
                            }
                    }
                    // Se busca el tiempo mas chico y el evento asociaso a la cola
                    if (_min > colas[i].darProximaLlegada() && colas[i].darProximaLlegada() != -1 && !finSimulacionDia)
                    {
                            _min = colas[i].darProximaLlegada();
                            _evento = colas[i].darEvento();
                    }

                }               
                for (int i = 0; i < servidores.Count; i++)
                {
                    // se utiliza el evento polimorfico de los servidores
                    servidores[i].hacerAlgo(reloj.getEvento(), reloj.getHora(), servicio);
                    // se busca el tiempo mas chico y el evento asociado
                    if(!flagComenzo)
                    {
                        if (servidores[i].darProxFAT() != -1 )
                        {
                            _min = servidores[i].darProxFAT();
                            _evento = servidores[i].darEvento();
                            flagComenzo = true;
                        }
                    }
                    if (servidores[i].darProxFAT() != -1 && _min > servidores[i].darProxFAT())
                    {
                        _min = servidores[i].darProxFAT();
                        _evento = servidores[i].darEvento();
                    }
                }

                // se calcula el promedio de clientes en el sistema
                if (clientesTotalSistema != 0)
                {
                    TiempoPromedioClientEnSistema = (TiempoPromedioClientEnSistema * clientesTotalSistemaAntes + (_min - reloj.getHora()) * clientesActual) / clientesTotalSistema;
                }
                // los tester permiten guardar cualquier vector estado de cualquier simulacion
                Tester tester = crearTester(servicio);
                testers.Add(tester);
                reloj.setEvento(_evento);
                reloj.setHora(_min);
                clientesTotalSistemaAntes = clientesTotalSistema;
                //verifica si ocurrio el fin de dia y deja de llegar clientes
                if (reloj.getHora() >= finDia && !finSimulacionDia)
                {
                    finSimulacionDia = true; ;
                }
            }
        }
        public void simularMes(int dias,double finDia,double comienzoDia)
        {
            for(int i = 0; i < dias; i++)
            {
                simularDia(finDia, comienzoDia);
            }
            promedioDeCamiones = clientesTotalSistema / dias;
        }
        public double darPromediodeCamionesXdia()
        {
            return promedioDeCamiones;
        }
        //metodo para guardar el vector estado y mirarlo en el data grid view
        private Tester crearTester(int _servicio)
        {

            Tester tester = new Tester();
            tester.agregarValor("Serv: " + _servicio.ToString());
            tester.agregarValor("Reloj: " + Math.Round(reloj.getHora(), 3).ToString());
            tester.agregarValor("Evento: " + reloj.getEvento());
            for (int i = 0; i < colas.Count; i++)
            {
                tester.agregarValor("| Cola = " + colas[i].darNombre() + " : " + colas[i].darElementosString() + " time:" + Math.Round(colas[i].darProximaLlegada(), 2).ToString());
            }
            for (int i = 0; i < servidores.Count; i++)
            {
                tester.agregarValor("| Es:" + servidores[i].darEstado() +" Servidor = " + servidores[i].darNombre() + " : " + Math.Round(servidores[i].darProxFAT(), 2).ToString());
            }
            tester.agregarValor("| Clientes Totales:" + Math.Round(clientesTotalSistema,0).ToString() + "  Clientes Ahora:" + Math.Round(clientesActual,0).ToString()+"Clientes tiempo Promedio "+Math.Round(TiempoPromedioClientEnSistema,2).ToString());
            return tester;

        }
        public void Clear()
        {
            servidores.Clear();
            colas.Clear();
            multiplexor.Clear();
            clientesTotalSistema = 0;
            TiempoPromedioClientEnSistema = 0;
            tiempoEspera = 0;
            clientesActual = 0;
            simulaciones = 0;
            promedioDeCamiones = 0;
            

        }
        public double promedioEnSistema()
        {
            return TiempoPromedioClientEnSistema;
        }
        public int darSimulaciones()
        {
            return simulaciones;
        }
        public double darTotalCamines()
        {
            return clientesTotalSistema;
        }
        public List<Reloj> darRelojes()
        {
            return relojes;
        }
        public List<IColeable> darColas()
        {
            return colas;
        }
        public List<IServiciable> darServidores()
        {
            return servidores;
        }
        public double darTiempoEspera()
        {
            return tiempoEspera;
        }
        public List<Tester> darTesters()
        {
            return testers;
        }
    }
}
