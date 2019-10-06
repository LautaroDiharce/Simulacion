using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BatallaNaval
{
    public class Estrategia
    {
        public int aciertosJugador1 { get; set; }
        public int aciertosJugador2 { get; set; }
        public int cantTirosJugador1 { get; set; }
        public int cantTirosJugador2 { get; set; }
        public double proporcionAciertos { get; set; }

        Panel[,] tableroJug1;
        Panel[,] tableroJug2;
        Color colorJugador;
        Random random = new Random();
        List<Pares> paresJugador1 = new List<Pares>();
        List<Pares> paresJugador2 = new List<Pares>();
        Pares parDeCaza = null;
        bool cazarArriba = false;
        bool cazarAbajo = false;
        bool cazarIzquierda = false;
        bool cazarDerecha = false;

        bool tiroArriba = false;
        bool tiroDerecha = false;
        bool tiroAbajo = false;
        bool tiroIzquierda = false;
        public Estrategia(Panel[,] _tableroJug1, Panel[,] _tableroJug2)
        {
            tableroJug1 = _tableroJug1;
            tableroJug2 = _tableroJug2;
            CargarPares();
        }

        private void CargarPares()
        {
            for (int i = 0; i < 70; i++)
            {
                for (int j = 0; j < 70; j++)
                {
                    Pares par = new Pares(i, j);
                    paresJugador1.Add(par);
                    paresJugador2.Add(par);
                }
            }
        }

        private void Jugar()
        {
            while (aciertosJugador1 < 40 && aciertosJugador2 < 40)
            {
                //Primero tira el jugador 1 
                TiroRandom();

                //Si no llego al total de aciertos necesarios, tira el jugador 2
                if (aciertosJugador1 < 40)
                {
                    TiroCaza();
                }
            }
        }

        //El jugador 2 le tira a los pares del jugador 1
        public void TiroCaza()
        {
            if (parDeCaza == null)
            {
                var rand = random.Next(0, paresJugador1.Count);

                var par = paresJugador1[rand];

                if (tableroJug1[par.X, par.Y].BackColor == Color.DarkGray || tableroJug1[par.X, par.Y].BackColor == Color.White)
                {
                    tableroJug1[par.X, par.Y].BackColor = Color.Blue;
                    cantTirosJugador2++;
                    paresJugador1.RemoveAt(rand);
                    return;
                }
                else if (tableroJug1[par.X, par.Y].BackColor == Color.Red)
                {
                    //Pintamos, contamos 1 tiro y almacenamos el par para tenerlo en cuenta en el tiro siguiente;
                    tableroJug1[par.X, par.Y].BackColor = Color.Orange;
                    parDeCaza = par;
                    cantTirosJugador2++;
                    aciertosJugador2++;
                    return;
                }
                else
                {
                    TiroCaza();
                }
            }
            else
            {
                //En esta logica se hace un tiro en cada direccion. Al hacer el tiro se determina si es correcta y se empieza la caza en esa direccion, de lo contrario se intenta con otra.
                if (!tiroArriba)
                {
                    TirarArriba();
                    return;
                }
                else if (cazarArriba)
                {
                    CazarHaciaArriba();
                    return;
                }

                if (!tiroDerecha)
                {
                    TirarDerecha();
                    return;
                }
                else if (cazarDerecha)
                {
                    CazarHaciaDerecha();
                    return;
                }

                if (!tiroAbajo)
                {
                    TirarAbajo();
                    return;
                }
                else if (cazarAbajo)
                {
                    CazarHaciaAbajo();
                    return;
                }

                if (!tiroIzquierda)
                {
                    TirarIzquierda();
                    return;
                }
                else if (cazarIzquierda)
                {
                    CazarHaciaIzquierda();
                    return;
                }

                parDeCaza = null;
                ResetearIndicadores();
                TiroCaza();
            }
        }

        private void ResetearIndicadores()
        {
            cazarArriba = false;
            cazarAbajo = false;
            cazarIzquierda = false;
            cazarDerecha = false;

            tiroArriba = false;
            tiroDerecha = false;
            tiroAbajo = false;
            tiroIzquierda = false;
        }

        private void TirarArriba()
        {
            Pares parDeArriba = new Pares(parDeCaza.X, parDeCaza.Y + 1);
            if (paresJugador1.Contains(parDeArriba))
            {
                if (tableroJug1[parDeArriba.X, parDeArriba.Y].BackColor == Color.DarkGray || tableroJug1[parDeArriba.X, parDeArriba.Y].BackColor == Color.White)
                {
                    tableroJug1[parDeArriba.X, parDeArriba.Y].BackColor = Color.Blue;
                    paresJugador1.Remove(parDeArriba);
                    tiroArriba = true;
                    cantTirosJugador2++;
                }
                else if (tableroJug1[parDeArriba.X, parDeArriba.Y].BackColor == Color.Red)
                {
                    tableroJug1[parDeArriba.X, parDeArriba.Y].BackColor = Color.Orange;
                    aciertosJugador2++;
                    //Eliminamos el par de caza porque ya determinamos que vamos a ir hacia arriba
                    paresJugador1.Remove(parDeCaza);
                    parDeCaza = parDeArriba;
                    cazarArriba = true;
                    tiroArriba = true;
                    cantTirosJugador2++;
                }
                else
                {
                    //No se cuenta este tiro porque ya fue marcado
                    tiroArriba = true;
                    TiroCaza();
                }
            }
            else
            {
                //No se cuenta este tiro porque esta fuera del tablero
                tiroArriba = true;
                TiroCaza();
            }
        }

        private void CazarHaciaArriba()
        {
            Pares parDeArriba = new Pares(parDeCaza.X, parDeCaza.Y + 1);
            if (paresJugador1.Contains(parDeArriba))
            {
                if (tableroJug1[parDeArriba.X, parDeArriba.Y].BackColor == Color.DarkGray || tableroJug1[parDeArriba.X, parDeArriba.Y].BackColor == Color.White)
                {
                    //Este escenario implica que se completo el barco
                    tableroJug1[parDeArriba.X, parDeArriba.Y].BackColor = Color.Blue;
                    paresJugador1.Remove(parDeArriba);
                    paresJugador1.Remove(parDeCaza);
                    //parDeCaza se setea null para que vuelva a tiar random
                    parDeCaza = null;
                    //Se resetean los indicadores de la caza
                    ResetearIndicadores();
                    cantTirosJugador2++;
                }
                else if (tableroJug1[parDeArriba.X, parDeArriba.Y].BackColor == Color.Red)
                {
                    tableroJug1[parDeArriba.X, parDeArriba.Y].BackColor = Color.Orange;
                    aciertosJugador2++;
                    //Eliminamos el par de caza y lo cambiamos por el nuevo par que marcamos
                    paresJugador1.Remove(parDeCaza);
                    parDeCaza = parDeArriba;
                    cantTirosJugador2++;
                }
                else
                {
                    //En esta instancia estaba cazando y el limite del barco estaba en el limite del tablero, se concluye la caza
                    paresJugador1.Remove(parDeCaza);
                    //parDeCaza se setea null para que vuelva a tiar random
                    parDeCaza = null;
                    //Se resetean los indicadores de la caza
                    ResetearIndicadores();
                    TiroCaza();
                }
            }
            else
            {
                //En esta instancia estaba cazando y el limite del barco estaba en el limite del tablero, se concluye la caza
                paresJugador1.Remove(parDeCaza);
                //parDeCaza se setea null para que vuelva a tiar random
                parDeCaza = null;
                //Se resetean los indicadores de la caza
                ResetearIndicadores();
                TiroCaza();
            }
        }

        private void TirarDerecha()
        {
            Pares parDerecho = new Pares(parDeCaza.X + 1, parDeCaza.Y);
            if (paresJugador1.Contains(parDerecho))
            {
                if (tableroJug1[parDerecho.X, parDerecho.Y].BackColor == Color.DarkGray || tableroJug1[parDerecho.X, parDerecho.Y].BackColor == Color.White)
                {
                    tableroJug1[parDerecho.X, parDerecho.Y].BackColor = Color.Blue;
                    paresJugador1.Remove(parDerecho);
                    tiroDerecha = true;
                    cantTirosJugador2++;
                }
                else if (tableroJug1[parDerecho.X, parDerecho.Y].BackColor == Color.Red)
                {
                    tableroJug1[parDerecho.X, parDerecho.Y].BackColor = Color.Orange;
                    aciertosJugador2++;
                    //Eliminamos el par de caza porque ya determinamos que vamos a ir hacia la derecha
                    paresJugador1.Remove(parDeCaza);
                    parDeCaza = parDerecho;
                    cazarDerecha = true;
                    tiroDerecha = true;
                    cantTirosJugador2++;
                }
                else
                {
                    tiroDerecha = true;
                    TiroCaza();
                }
            }
            else
            {
                tiroDerecha = true;
                TiroCaza();
            }
        }

        private void CazarHaciaDerecha()
        {
            Pares parDerecho = new Pares(parDeCaza.X + 1, parDeCaza.Y);
            if (paresJugador1.Contains(parDerecho))
            {
                if (tableroJug1[parDerecho.X, parDerecho.Y].BackColor == Color.DarkGray || tableroJug1[parDerecho.X, parDerecho.Y].BackColor == Color.White)
                {
                    //Este escenario implica que se completo el barco
                    tableroJug1[parDerecho.X, parDerecho.Y].BackColor = Color.Blue;
                    paresJugador1.Remove(parDerecho);
                    paresJugador1.Remove(parDeCaza);
                    //parDeCaza se setea null para que vuelva a tiar random
                    parDeCaza = null;
                    //Se resetean los indicadores de la caza
                    ResetearIndicadores();
                    cantTirosJugador2++;
                }
                else if (tableroJug1[parDerecho.X, parDerecho.Y].BackColor == Color.Red)
                {
                    tableroJug1[parDerecho.X, parDerecho.Y].BackColor = Color.Orange;
                    aciertosJugador2++;
                    //Eliminamos el par de caza y lo cambiamos por el nuevo par que marcamos
                    paresJugador1.Remove(parDeCaza);
                    parDeCaza = parDerecho;
                    cantTirosJugador2++;
                }
                else
                {
                    paresJugador1.Remove(parDeCaza);
                    //parDeCaza se setea null para que vuelva a tiar random
                    parDeCaza = null;
                    //Se resetean los indicadores de la caza
                    ResetearIndicadores();
                    TiroCaza();
                }
            }
            else
            {
                paresJugador1.Remove(parDeCaza);
                //parDeCaza se setea null para que vuelva a tiar random
                parDeCaza = null;
                //Se resetean los indicadores de la caza
                ResetearIndicadores();
                TiroCaza();
            }
        }

        private void TirarAbajo()
        {
            Pares parAbajo = new Pares(parDeCaza.X, parDeCaza.Y - 1);
            if (paresJugador1.Contains(parAbajo))
            {
                if (tableroJug1[parAbajo.X, parAbajo.Y].BackColor == Color.DarkGray || tableroJug1[parAbajo.X, parAbajo.Y].BackColor == Color.White)
                {
                    tableroJug1[parAbajo.X, parAbajo.Y].BackColor = Color.Blue;
                    paresJugador1.Remove(parAbajo);
                    tiroAbajo = true;
                    cantTirosJugador2++;
                }
                else if (tableroJug1[parAbajo.X, parAbajo.Y].BackColor == Color.Red)
                {
                    tableroJug1[parAbajo.X, parAbajo.Y].BackColor = Color.Orange;
                    aciertosJugador2++;
                    //Eliminamos el par de caza porque ya determinamos que vamos a ir hacia abajo
                    paresJugador1.Remove(parDeCaza);
                    parDeCaza = parAbajo;
                    cazarAbajo = true;
                    tiroAbajo = true;
                    cantTirosJugador2++;
                }
                else
                {
                    tiroAbajo = true;
                    TiroCaza();
                }
            }
            else
            {
                tiroAbajo = true;
                TiroCaza();
            }
        }

        private void CazarHaciaAbajo()
        {
            Pares parAbajo = new Pares(parDeCaza.X, parDeCaza.Y -1);
            if (paresJugador1.Contains(parAbajo))
            {
                if (tableroJug1[parAbajo.X, parAbajo.Y].BackColor == Color.DarkGray || tableroJug1[parAbajo.X, parAbajo.Y].BackColor == Color.White)
                {
                    //Este escenario implica que se completo el barco
                    tableroJug1[parAbajo.X, parAbajo.Y].BackColor = Color.Blue;
                    paresJugador1.Remove(parAbajo);
                    paresJugador1.Remove(parDeCaza);
                    //parDeCaza se setea null para que vuelva a tiar random
                    parDeCaza = null;
                    //Se resetean los indicadores de la caza
                    ResetearIndicadores();
                    cantTirosJugador2++;
                }
                else if (tableroJug1[parAbajo.X, parAbajo.Y].BackColor == Color.Red)
                {
                    tableroJug1[parAbajo.X, parAbajo.Y].BackColor = Color.Orange;
                    aciertosJugador2++;
                    //Eliminamos el par de caza y lo cambiamos por el nuevo par que marcamos
                    paresJugador1.Remove(parDeCaza);
                    parDeCaza = parAbajo;
                    cantTirosJugador2++;
                }
                else
                {
                    paresJugador1.Remove(parDeCaza);
                    //parDeCaza se setea null para que vuelva a tiar random
                    parDeCaza = null;
                    //Se resetean los indicadores de la caza
                    ResetearIndicadores();
                    TiroCaza();
                }
            }
            else
            {
                paresJugador1.Remove(parDeCaza);
                //parDeCaza se setea null para que vuelva a tiar random
                parDeCaza = null;
                //Se resetean los indicadores de la caza
                ResetearIndicadores();
                TiroCaza();
            }
        }

        private void TirarIzquierda()
        {
            Pares parIzquierda = new Pares(parDeCaza.X - 1, parDeCaza.Y);
            if (paresJugador1.Contains(parIzquierda))
            {
                if (tableroJug1[parIzquierda.X, parIzquierda.Y].BackColor == Color.DarkGray || tableroJug1[parIzquierda.X, parIzquierda.Y].BackColor == Color.White)
                {
                    tableroJug1[parIzquierda.X, parIzquierda.Y].BackColor = Color.Blue;
                    paresJugador1.Remove(parIzquierda);
                    tiroIzquierda = true;
                    cantTirosJugador2++;
                }
                else if (tableroJug1[parIzquierda.X, parIzquierda.Y].BackColor == Color.Red)
                {
                    tableroJug1[parIzquierda.X, parIzquierda.Y].BackColor = Color.Orange;
                    aciertosJugador2++;
                    //Eliminamos el par de caza porque ya determinamos que vamos a ir hacia la izquierda
                    paresJugador1.Remove(parDeCaza);
                    parDeCaza = parIzquierda;
                    cazarIzquierda = true;
                    tiroIzquierda = true;
                    cantTirosJugador2++;
                }
                else
                {
                    tiroIzquierda = true;
                    TiroCaza();
                }
            }
            else
            {
                tiroIzquierda = true;
                TiroCaza();
            }
        }

        private void CazarHaciaIzquierda()
        {
            Pares parIzquierda = new Pares(parDeCaza.X - 1, parDeCaza.Y);
            if (paresJugador1.Contains(parIzquierda))
            {
                if (tableroJug1[parIzquierda.X, parIzquierda.Y].BackColor == Color.DarkGray || tableroJug1[parIzquierda.X, parIzquierda.Y].BackColor == Color.White)
                {
                    //Este escenario implica que se completo el barco
                    tableroJug1[parIzquierda.X, parIzquierda.Y].BackColor = Color.Blue;
                    paresJugador1.Remove(parIzquierda);
                    paresJugador1.Remove(parDeCaza);
                    //parDeCaza se setea null para que vuelva a tiar random
                    parDeCaza = null;
                    //Se resetean los indicadores de la caza
                    ResetearIndicadores();
                    cantTirosJugador2++;
                }
                else if (tableroJug1[parIzquierda.X, parIzquierda.Y].BackColor == Color.Red)
                {
                    tableroJug1[parIzquierda.X, parIzquierda.Y].BackColor = Color.Orange;
                    aciertosJugador2++;
                    //Eliminamos el par de caza y lo cambiamos por el nuevo par que marcamos
                    paresJugador1.Remove(parDeCaza);
                    parDeCaza = parIzquierda;
                    cantTirosJugador2++;
                }
                else
                {
                    paresJugador1.Remove(parDeCaza);
                    //parDeCaza se setea null para que vuelva a tiar random
                    parDeCaza = null;
                    //Se resetean los indicadores de la caza
                    ResetearIndicadores();
                    TiroCaza();
                }
            }
            else
            {
                paresJugador1.Remove(parDeCaza);
                //parDeCaza se setea null para que vuelva a tiar random
                parDeCaza = null;
                //Se resetean los indicadores de la caza
                ResetearIndicadores();
                TiroCaza();
            }
        }

        //El jugador 1 le tira a los pares del jugador 2
        public void TiroRandom()
        {
            var rand = random.Next(0, paresJugador2.Count);

            var par = paresJugador2[rand];
            paresJugador2.RemoveAt(rand);            

            if (tableroJug2[par.X, par.Y].BackColor == Color.DarkGray || tableroJug2[par.X, par.Y].BackColor == Color.White)
            {
                tableroJug2[par.X, par.Y].BackColor = Color.Green;
                cantTirosJugador1++;
            }
            else if (tableroJug2[par.X, par.Y].BackColor == Color.Red)
            {
                tableroJug2[par.X, par.Y].BackColor = Color.Orange;
                aciertosJugador1++;
                cantTirosJugador1++;
            }
        }

    }
}
