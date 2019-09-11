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

        public Game()
        {
            InitializeComponent();
            CargarTableros();
        }

        private async void CargarTableros()
        {
            CargarTableroA();
            CargarTableroB();
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

                    // add to Form's Controls so that they show up
                    Controls.Add(newPanel);

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
                    // add to Form's Controls so that they show up
                    Controls.Add(newPanel);

                    // add to our 2d array of panels for future use
                    tableroB[n, m] = newPanel;
                }
            }
        }

        private async void BtnUbicarBarcos_Click(object sender, EventArgs e)
        {
            await Task.Run(()=> UbicarBarcos(tableroA));
            await Task.Run(() => UbicarBarcos(tableroB));
            btnIniciarBatalla.Enabled = true;
            btnLimpiarBarcos.Enabled = true;
        }

        private async void UbicarBarcos(Panel[,] jugador)
        {
            Random random = new Random();
            int cantBarcos = 5;

            for (int i = 0; i < cantBarcos; i++)
            {
                int X1 = random.Next(0, 49);
                int Y1 = random.Next(0, 49);
                int direccion1 = random.Next(1, 4);
                int X2 = random.Next(0, 49);
                int Y2 = random.Next(0, 49);
                int direccion2 = random.Next(1, 4);
                switch (i)
                {
                    //Portaaviones 6 casilleros
                    case 0:
                        ColocarBarco(X1, Y1, 6, direccion1, jugador);
                        ColocarBarco(X2, Y2, 6, direccion2, jugador);
                        break;
                    //Fragatas 5 casilleros
                    case 1:
                        ColocarBarco(X1, Y1, 5, direccion1, jugador);
                        ColocarBarco(X2, Y2, 5, direccion2, jugador);
                        break;
                    //Submarinos 4 casilleros
                    case 2:
                        ColocarBarco(X1, Y1, 4, direccion1, jugador);
                        ColocarBarco(X2, Y2, 4, direccion2, jugador);
                        break;
                    //Corbetas 3 casilleros
                    case 3:
                        ColocarBarco(X1, Y1, 3, direccion1, jugador);
                        ColocarBarco(X2, Y2, 3, direccion2, jugador);
                        break;
                    //Destructores 2 casilleros
                    case 4:
                        ColocarBarco(X1, Y1, 2, direccion1, jugador);
                        ColocarBarco(X2, Y2, 2, direccion2, jugador);
                        break;
                    default:
                        break;
                }
            }           
        }

        private void ColocarBarco(int XInicial, int YInicial, int casilleros, int direccion, Panel[,] jugador)
        {
            var X = XInicial;
            var Y = YInicial;
            var tablero = jugador;
            switch (direccion)
            {
                //Arriba
                case 1:
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
            CargarTableros();

            btnLimpiarBarcos.Enabled = false;
            btnUbicarBarcos.Enabled = true;
        }

        private void BtnIniciarBatalla_Click(object sender, EventArgs e)
        {
            btnUbicarBarcos.Enabled = false;
            this.Cursor = Cursors.WaitCursor;
            AtaquesA();
            AtaquesB();
            this.Cursor = Cursors.Arrow;
        }

        private void AtaquesA()
        {
            Estrategia estrategiaA = new Estrategia(tableroB, Color.Green);
            Task.Run(() => estrategiaA.Caza() );
            lblAciertosA.Text = estrategiaA.aciertos.ToString();
            lblCantTirosA.Text = estrategiaA.cantTiros.ToString();
        }

        private async void AtaquesB()
        {
            Estrategia estrategiaB = new Estrategia(tableroA, Color.Blue);
            await Task.Run(() => estrategiaB.Random() );
            lblAciertosB.Text = estrategiaB.aciertos.ToString();
            lblCantTirosB.Text = estrategiaB.cantTiros.ToString();
        }
    }
}
