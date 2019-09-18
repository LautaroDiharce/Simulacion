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
    public partial class Game : Form
    {

        private Panel[,] tableroA;
        private Panel[,] tableroB;

        Random random;
        public Game()
        {
            InitializeComponent();
            CargarPaneles();
            random = new Random();
        }

        private void CargarPaneles()
        {
            CargarTableroA();
            CargarTableroB();
            AgregarPaneles();
        }

        private void AgregarPaneles()
        {
            foreach (var panel in tableroA)
            {
                Controls.Add(panel);
            }

            foreach (var panel in tableroB)
            {
                Controls.Add(panel);
            }
        }

        private async void CargarTableroA()
        {
            const int tileSize = 10;
            const int gridSize = 50;
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

        private async void CargarTableroB()
        {
            const int tileSize = 10;
            const int gridSize = 50;
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

        private async void BtnUbicarBarcos_Click(object sender, EventArgs e)
        {
            UbicarBarcos(tableroA);
            UbicarBarcos(tableroB);
            btnIniciarBatalla.Enabled = true;
            btnLimpiarBarcos.Enabled = true;
            btnUbicarBarcos.Enabled = false;
        }

        private async void UbicarBarcos(Panel[,] jugador)
        {
            int cantBarcos = 0;
            int portaaviones = 0;
            int fragatas = 0;
            int submarinos = 0;
            int corbetas = 0;
            int destructores = 0;

            while (cantBarcos < 10)
            {
                int X1 = random.Next(0, 50);
                int Y1 = random.Next(0, 50);
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
                case 0:
                    for (int i = 0; i < cantPosiciones; i++)
                    {
                        if (YFinal < 50)
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
                    break;
                //Derecha
                case 1:
                    for (int i = 0; i < cantPosiciones; i++)
                    {
                        if (XFinal < 50)
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
                    break;
                //Abajo
                case 2:
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
                    break;
                //Izquierda
                case 3:
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
                    break;
            }
            return true;
        }

        private void ColocarBarco(int XInicial, int YInicial, int casilleros, int direccion, Panel[,] jugador)
        {
            var X = XInicial;
            var Y = YInicial;
            int XFinal;
            int YFinal;
            var tablero = jugador;
            switch (direccion)
            {
                //Arriba
                case 1:
                    YFinal = Y + casilleros - 1;
                    if (YFinal >= 50)
                    {
                        Y = 50 - casilleros;
                    }
                    for (int i = 0; i < casilleros; i++)
                    {
                        if (i > 0)
                        {
                            Y++;
                        }

                        if (Y < tablero.GetLength(0))
                        {
                            tablero[X, Y].BackColor = Color.Red;
                        }
                        else 
                        {
                            break;
                        }
                    }
                    break;
                //Derecha
                case 2:
                    XFinal = X + casilleros - 1;
                    if (XFinal >= 50)
                    {
                        X = 50 - casilleros;
                    }
                    for (int i = 0; i < casilleros; i++)
                    {
                        if (i > 0)
                        {
                            X ++;
                        }
                        if (X < tablero.GetLength(1))
                        {
                            tablero[X, Y].BackColor = Color.Red;
                        }
                        else
                        {
                            break;
                        }
                    }
                    break;
                //Abajo
                case 3:
                    YFinal = Y - casilleros - 1;
                    if (YFinal < 0)
                    {
                        Y = casilleros;
                    }
                    for (int i = 0; i < casilleros; i++)
                    {
                        if (i > 0)
                        {
                            Y --;
                        }
                        if (Y >= 0)
                        {
                            tablero[X, Y].BackColor = Color.Red;
                        }
                        else
                        {
                            break;
                        }
                    }
                    break;
                //Izquierda
                case 4:
                    XFinal = X - casilleros - 1;
                    if (XFinal < 0)
                    {
                        X = casilleros;
                    }
                    for (int i = 0; i < casilleros; i++)
                    {
                        if (i > 0)
                        {
                            X --;
                        }
                        if (X >= 0)
                        {
                            tablero[X, Y].BackColor = Color.Red;
                        }
                        else
                        {
                            break;
                        }
                    }
                    break;
                default:
                    break;
            }
        }

        private void BtnLimpiarBarcos_Click(object sender, EventArgs e)
        {
            var clr1 = Color.DarkGray;
            var clr2 = Color.White;

            for (var n = 0; n < 50; n++)
            {
                for (var m = 0; m < 50; m++)
                {
                    // color the backgrounds
                    if (n % 2 == 0)
                    {
                        tableroA[n, m].BackColor = m % 2 != 0 ? clr1 : clr2;
                        tableroB[n, m].BackColor = m % 2 != 0 ? clr1 : clr2;
                    }
                    else
                    {
                        tableroA[n, m].BackColor = m % 2 != 0 ? clr2 : clr1;
                        tableroB[n, m].BackColor = m % 2 != 0 ? clr2 : clr1;
                    }

                }
            }

            btnLimpiarBarcos.Enabled = false;
            btnUbicarBarcos.Enabled = true;
            btnIniciarBatalla.Enabled = false;

            lblGanadorA.Visible = false;
            lblGanadorB.Visible = false;
            lblCantTirosA.Text = "0";
            lblCantTirosB.Text = "0";
            lblAciertosA.Text = "0";
            lblAciertosB.Text = "0";
        }

        private void BtnIniciarBatalla_Click(object sender, EventArgs e)
        {
            btnUbicarBarcos.Enabled = false;
            Jugar();
        }

        private async void Jugar()
        {
            this.Cursor = Cursors.WaitCursor;
            btnLimpiarBarcos.Enabled = false;
            btnIniciarBatalla.Enabled = false;
            Estrategia juego = new Estrategia(tableroA, tableroB);
            while (juego.aciertosJugador1 < 40 && juego.aciertosJugador2 < 40)
            {
                await Task.Delay(2);
                juego.TiroRandom();
                lblAciertosA.Text = juego.aciertosJugador1.ToString();
                lblCantTirosA.Text = juego.cantTirosJugador1.ToString();

                juego.TiroCaza();
                lblAciertosB.Text = juego.aciertosJugador2.ToString();
                lblCantTirosB.Text = juego.cantTirosJugador2.ToString();

                if (juego.aciertosJugador1 == 40)
                {
                    lblGanadorA.Visible = true;
                }
                else if (juego.aciertosJugador2 == 40)
                {
                    lblGanadorB.Visible = true;
                }
            }
            btnLimpiarBarcos.Enabled = true;

            this.Cursor = Cursors.Arrow;
        }
    }
}
