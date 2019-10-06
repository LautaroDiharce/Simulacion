using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BatallaNaval
{
    public partial class ModoAuto : Form
    {
        private Panel[,] tableroA;
        private Panel[,] tableroB;

        Random random = new Random();

        private int cantGanados1 = 0;
        private int cantGanados2 = 0;
        public ModoAuto()
        {
            InitializeComponent();
        }

        private void ModoAuto_Load(object sender, EventArgs e)
        {

        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnSimular_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            while (cantGanados1 + cantGanados2 < 1000)
            {
                CargarTableroA();
                CargarTableroB();
                UbicarBarcos(tableroA);
                UbicarBarcos(tableroB);
                Jugar();
            }
            this.Cursor = Cursors.Arrow;

            lblJuegosGanadosJ1.Visible = true;
            lblJuegosGanadosJ2.Visible = true;
            lblJuegosGanadosJ1.Text = cantGanados1.ToString();
            lblJuegosGanadosJ2.Text = cantGanados2.ToString();

            lblPorcentajeJ1.Visible = true;
            lblPorcentajeJ2.Visible = true;
            double porcentaje1 = (double)(cantGanados1 * 100) / 1000;
            double porcentaje2 = (double)(cantGanados2 * 100) / 1000;
            porcentaje1 = Math.Round(porcentaje1, 2);
            porcentaje2 = Math.Round(porcentaje2, 2);
            lblPorcentajeJ1.Text = porcentaje1.ToString() + "%";
            lblPorcentajeJ2.Text = porcentaje2.ToString() + "%";
        }

        private void CargarTableroA()
        {
            const int tileSize = 5;
            const int gridSize = 70;
            var clr1 = Color.DarkGray;
            var clr2 = Color.White;
            var ubicacionInicialX = 200;
            var ubicacionInicialY = 200;

            tableroA = new Panel[gridSize, gridSize];

            // double for loop to handle all rows and columns
            for (var n = 0; n < gridSize; n++)
            {
                for (var m = 0; m < gridSize; m++)
                {
                    var newPanel = new Panel
                    {
                        Size = new Size(tileSize, tileSize),
                        Location = new Point((tileSize * n) + ubicacionInicialX, (tileSize * m) + ubicacionInicialY)
                    };

                    // add to our 2d array of panels for future use
                    tableroA[n, m] = newPanel;

                    // color the backgrounds
                    if (n % 2 == 0)
                        newPanel.BackColor = m % 2 != 0 ? clr1 : clr2;
                    else
                        newPanel.BackColor = m % 2 != 0 ? clr2 : clr1;
                }
            }
        }

        private void CargarTableroB()
        {
            const int tileSize = 5;
            const int gridSize = 70;
            var clr1 = Color.DarkGray;
            var clr2 = Color.White;
            var ubicacionInicialX = 900;
            var ubicacionInicialY = 200;

            tableroB = new Panel[gridSize, gridSize];

            // double for loop to handle all rows and columns
            for (var n = 0; n < gridSize; n++)
            {
                for (var m = 0; m < gridSize; m++)
                {
                    var newPanel = new Panel
                    {
                        Size = new Size(tileSize, tileSize),
                        Location = new Point((tileSize * n) + ubicacionInicialX, (tileSize * m) + ubicacionInicialY)
                    };

                    // color the backgrounds
                    if (n % 2 == 0)
                        newPanel.BackColor = m % 2 != 0 ? clr1 : clr2;
                    else
                        newPanel.BackColor = m % 2 != 0 ? clr2 : clr1;

                    // add to our 2d array of panels for future use
                    tableroB[n, m] = newPanel;
                }
            }
        }

        private void UbicarBarcos(Panel[,] jugador)
        {
            int cantBarcos = 0;
            int portaaviones = 0;
            int fragatas = 0;
            int submarinos = 0;
            int corbetas = 0;
            int destructores = 0;

            while (cantBarcos < 10)
            {
                int X1 = random.Next(0, 70);
                int Y1 = random.Next(0, 70);
                int direccion1 = random.Next(1, 4);

                if (portaaviones < 2 && ValidarUbicacion(X1, Y1, 6, direccion1, jugador))
                {
                    ColocarBarco(X1, Y1, 6, direccion1, jugador);
                    portaaviones++;
                    cantBarcos++;
                    continue;
                }

                if (fragatas < 2 && ValidarUbicacion(X1, Y1, 5, direccion1, jugador))
                {
                    ColocarBarco(X1, Y1, 5, direccion1, jugador);
                    fragatas++;
                    cantBarcos++;
                    continue;
                }

                if (submarinos < 2 && ValidarUbicacion(X1, Y1, 4, direccion1, jugador))
                {
                    ColocarBarco(X1, Y1, 4, direccion1, jugador);
                    submarinos++;
                    cantBarcos++;
                    continue;
                }

                if (corbetas < 2 && ValidarUbicacion(X1, Y1, 3, direccion1, jugador))
                {
                    ColocarBarco(X1, Y1, 3, direccion1, jugador);
                    corbetas++;
                    cantBarcos++;
                    continue;
                }

                if (destructores < 2 && ValidarUbicacion(X1, Y1, 2, direccion1, jugador))
                {
                    ColocarBarco(X1, Y1, 2, direccion1, jugador);
                    destructores++;
                    cantBarcos++;
                    continue;
                }
            }
        }

        private bool ValidarUbicacion(int X, int Y, int cantPosiciones, int direccion, Panel[,] tablero)
        {
            int XFinal = X;
            int YFinal = Y;
            switch (direccion)
            {
                //Arriba
                case 1:
                    if ((Y + cantPosiciones) >= 70)
                    {
                        return false;
                    }
                    else
                    {
                        for (int i = 0; i < cantPosiciones; i++)
                        {
                            if (YFinal < 70)
                            {
                                if (tablero[XFinal, YFinal].BackColor == Color.Red)
                                {
                                    return false;
                                }
                            }
                            else
                            {
                                return false;
                            }
                            YFinal++;
                        }
                    }
                    break;
                //Derecha
                case 2:
                    if ((X + cantPosiciones) >= 70)
                    {
                        return false;
                    }
                    else
                    {
                        for (int i = 0; i < cantPosiciones; i++)
                        {
                            if (XFinal < 70)
                            {
                                if (tablero[XFinal, YFinal].BackColor == Color.Red)
                                {
                                    return false;
                                }
                            }
                            else
                            {
                                return false;
                            }
                            XFinal++;
                        }
                    }
                    break;
                //Abajo
                case 3:
                    if ((Y - cantPosiciones) < 0)
                    {
                        return false;
                    }
                    else
                    {
                        for (int i = 0; i < cantPosiciones; i++)
                        {
                            if (YFinal >= 0)
                            {
                                if (tablero[XFinal, YFinal].BackColor == Color.Red)
                                {
                                    return false;
                                }
                            }
                            else
                            {
                                return false;
                            }
                            YFinal--;
                        }
                    }
                    break;
                //Izquierda
                case 4:
                    if ((X - cantPosiciones) < 0)
                    {
                        return false;
                    }
                    else
                    {
                        for (int i = 0; i < cantPosiciones; i++)
                        {
                            if (XFinal >= 0)
                            {
                                if (tablero[XFinal, YFinal].BackColor == Color.Red)
                                {
                                    return false;
                                }
                            }
                            else
                            {
                                return false;
                            }
                            XFinal--;
                        }
                    }
                    break;
            }
            return true;
        }

        private void ColocarBarco(int XInicial, int YInicial, int casilleros, int direccion, Panel[,] jugador)
        {
            var X = XInicial;
            var Y = YInicial;
            //int XFinal;
            //int YFinal;
            var tablero = jugador;
            switch (direccion)
            {
                //Arriba
                case 1:
                    for (int i = 0; i < casilleros; i++)
                    {
                        tablero[X, Y].BackColor = Color.Red;
                        Y++;
                    }
                    break;
                //Derecha
                case 2:
                    for (int i = 0; i < casilleros; i++)
                    {
                        tablero[X, Y].BackColor = Color.Red;
                        X++;
                    }
                    break;
                //Abajo
                case 3:
                    for (int i = 0; i < casilleros; i++)
                    {
                        tablero[X, Y].BackColor = Color.Red;
                        Y--;
                    }
                    break;
                //Izquierda
                case 4:
                    for (int i = 0; i < casilleros; i++)
                    {
                        tablero[X, Y].BackColor = Color.Red;
                        X--;
                    }
                    break;
                default:
                    break;
            }
        }
        private void Jugar()
        {
            Estrategia juego = new Estrategia(tableroA, tableroB);
            while (juego.aciertosJugador1 < 40 && juego.aciertosJugador2 < 40)
            {
                juego.TiroRandom();

                juego.TiroCaza();

                if (juego.aciertosJugador1 == 40)
                {
                    cantGanados1++;
                }
                else if (juego.aciertosJugador2 == 40)
                {
                    cantGanados2++;
                }
            }
        }
    }
}
