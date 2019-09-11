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
        public int aciertos { get; set; }
        public int cantTiros { get; set; }
        public double proporcionAciertos { get; set; }

        Panel[,] adversario;
        Color colorJugador;
        DireccionDeCaza direccion;
        public Estrategia(Panel[,] _adversario, Color _colorJugador)
        {
            adversario = _adversario;
            colorJugador = _colorJugador;
        }

        public async void Caza()
        {
            Random random = new Random();
            aciertos = 0;
            cantTiros = 0;

            while (aciertos < 40)
            {
                var X = random.Next(0, 49);
                var Y = random.Next(0, 49);

                if (adversario[X, Y].BackColor == Color.Red)
                {
                    switch (IdentificarDireccion(X, Y))
                    {
                        case DireccionDeCaza.Arriba:
                            aciertos += CazarArriba(X, Y);
                            break;
                        case DireccionDeCaza.Abajo:
                            aciertos += CazarAbajo(X, Y);
                            break;
                        case DireccionDeCaza.Derecha:
                            aciertos += CazarDerecha(X, Y);
                            break;
                        case DireccionDeCaza.Izquierda:
                            aciertos += CazarIzquierda(X, Y);
                            break;
                        default:
                            break;
                    }
                }
                else
                {
                    cantTiros++;
                }
            }
        }

        private int CazarArriba(int X, int Y)
        {
            var YArriba = Y;
            int cantAciertos = 0;
            //Se hace para asegurarnos que no se haya salido del tablero
            bool estaDentroDelTablero = true;
            while(estaDentroDelTablero)
            {
                if (adversario[X, YArriba].BackColor == Color.Red)
                {
                    YArriba++;
                    cantAciertos++;
                    //Se verifica que el siguiente valor este dentro del rango
                    estaDentroDelTablero = YArriba < adversario.GetLength(0);
                }

                adversario[X, YArriba].BackColor = colorJugador;
                cantTiros++;
            }
            return cantAciertos;
        }

        private int CazarAbajo(int X, int Y)
        {
            var YAbajo = Y;
            int cantAciertos = 0;
            //Se hace para asegurarnos que no se haya salido del tablero
            bool estaDentroDelTablero = true;
            while (estaDentroDelTablero)
            {
                if (adversario[X, YAbajo].BackColor == Color.Red)
                {
                    YAbajo--;
                    cantAciertos++;
                    estaDentroDelTablero = YAbajo >= 0;
                }

                adversario[X, YAbajo].BackColor = colorJugador;
                cantTiros++;
            }
            return cantAciertos;
        }

        private int CazarIzquierda(int X, int Y)
        {
            var XIzq = X;
            int cantAciertos = 0;
            //Se hace para asegurarnos que no se haya salido del tablero
            bool estaDentroDelTablero = true;
            while (estaDentroDelTablero)
            {
                if (adversario[XIzq, Y].BackColor == Color.Red)
                {
                    XIzq--;
                    cantAciertos++;
                    estaDentroDelTablero = XIzq >= 0;
                }

                adversario[XIzq, Y].BackColor = colorJugador;
                cantTiros++;
            }
            return cantAciertos;
        }

        private int CazarDerecha(int X, int Y)
        {
            var XDer = X;
            int cantAciertos = 0;
            //Se hace para asegurarnos que no se haya salido del tablero
            bool estaDentroDelTablero = true;
            while (estaDentroDelTablero)
            {
                if (adversario[XDer, Y].BackColor == Color.Red)
                {
                    XDer++;
                    cantAciertos++;
                    estaDentroDelTablero = XDer < adversario.GetLength(1);
                }

                adversario[XDer, Y].BackColor = colorJugador;
                cantTiros++;
            }
            return cantAciertos;
        }

        private DireccionDeCaza? IdentificarDireccion(int XInicial, int YInicial)
        {
            var XDer = XInicial + 1;
            var XIzq = XInicial - 1;
            var YArr = YInicial + 1;
            var YAba = YInicial - 1;

            if (adversario[XDer, YInicial].BackColor == Color.Red)
            {
                return DireccionDeCaza.Derecha;
            }

            if (adversario[XIzq, YInicial].BackColor == Color.Red)
            {
                return DireccionDeCaza.Izquierda;
            }

            if (adversario[XInicial, YArr].BackColor == Color.Red)
            {
                return DireccionDeCaza.Arriba;
            }

            if (adversario[XInicial, YAba].BackColor == Color.Red)
            {
                return DireccionDeCaza.Abajo;
            }

            return null;
        }

        public async void Random()
        {
            Random random = new Random();
            aciertos = 0;
            cantTiros = 0;

            while (aciertos < 40)
            {
                var X = random.Next(0, 50);
                var Y = random.Next(0, 50);

                if (adversario[X, Y].BackColor == Color.Red)
                {
                    aciertos++;
                }

                adversario[X, Y].BackColor = colorJugador;
                cantTiros++;
            }
        }

        enum DireccionDeCaza
        {
            Arriba,
            Abajo,
            Izquierda,
            Derecha
        }
    }
}
