using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TP3SIM
{
    public partial class Main : Form
    {
        enum Distribucion
        {
            Uniforme,
            Normal,
            ExponencialNegativa,
            Poisson
        }

        Distribucion dist;
        List<double> Valores = new List<double>();
        

        public Main()
        {
            InitializeComponent();
            rbDistUniforme.Checked = true;
            txtCantValores.MaxLength = 6;
            
        }

        private void RbDistUniforme_CheckedChanged(object sender, EventArgs e)
        {
            txtUniformeA.Enabled = true;
            txtUniformeB.Enabled = true;
            txtMedia.Enabled = false;
            txtDesvEstandar.Enabled = false;
            txtLambdaExp.Enabled = false;
            txtLambdaPoisson.Enabled = false;

            txtMedia.Text = string.Empty;
            txtDesvEstandar.Text = string.Empty;
            txtLambdaExp.Text = string.Empty;
            txtLambdaPoisson.Text = string.Empty;
            txtCantValores.Text = string.Empty;
            dist = Distribucion.Uniforme;
        }

        private void RbDistNormal_CheckedChanged(object sender, EventArgs e)
        {
            txtUniformeA.Enabled = false;
            txtUniformeB.Enabled = false;
            txtMedia.Enabled = true;
            txtDesvEstandar.Enabled = true;
            txtLambdaExp.Enabled = false;
            txtLambdaPoisson.Enabled = false;

            txtUniformeA.Text = string.Empty;
            txtUniformeB.Text = string.Empty;
            txtLambdaExp.Text = string.Empty;
            txtLambdaPoisson.Text = string.Empty;
            txtCantValores.Text = string.Empty;
            dist = Distribucion.Normal;
        }

        private void RbDistExp_CheckedChanged(object sender, EventArgs e)
        {
            txtUniformeA.Enabled = false;
            txtUniformeB.Enabled = false;
            txtMedia.Enabled = false;
            txtDesvEstandar.Enabled = false;
            txtLambdaExp.Enabled = true;
            txtLambdaPoisson.Enabled = false;

            txtMedia.Text = string.Empty;
            txtDesvEstandar.Text = string.Empty;
            txtUniformeA.Text = string.Empty;
            txtUniformeB.Text = string.Empty;
            txtLambdaPoisson.Text = string.Empty;
            txtCantValores.Text = string.Empty;
            dist = Distribucion.ExponencialNegativa;
        }

        private void RbPoisson_CheckedChanged(object sender, EventArgs e)
        {
            txtUniformeA.Enabled = false;
            txtUniformeB.Enabled = false;
            txtMedia.Enabled = false;
            txtDesvEstandar.Enabled = false;
            txtLambdaExp.Enabled = false;
            txtLambdaPoisson.Enabled = true;

            txtMedia.Text = string.Empty;
            txtDesvEstandar.Text = string.Empty;
            txtUniformeA.Text = string.Empty;
            txtUniformeB.Text = string.Empty;
            txtLambdaExp.Text = string.Empty;
            txtCantValores.Text = string.Empty;
            dist = Distribucion.Poisson;
        }

        private void BtnGenerarValores_Click(object sender, EventArgs e)
        {   int i;
            bool success = int.TryParse(txtCantValores.Text,out i);
            if (success is true && i>0)
            {


                lstValores.DataSource = null;
                switch (dist)
                {
                    case Distribucion.Uniforme:
                        double b,a;
                        bool checkA = double.TryParse(txtUniformeA.Text, out a);
                        bool checkB = double.TryParse(txtUniformeB.Text, out b);
                        if (a > b || checkA is false || checkB is false )
                        {
                            MessageBox.Show("El valor de A debe ser inferior a B, y ambos deben ser numeros", "advertencia");
                            txtUniformeA.Focus();
                            return;
                        }
                        else
                        {
                            GenerarUniforme();
                        }
                        break;
                    case Distribucion.Normal:
                        double m, ds;
                        bool checkM = double.TryParse(txtMedia.Text, out m);
                        bool checkDS = double.TryParse(txtDesvEstandar.Text, out ds);
                        if (ds < 0|| !checkM || !checkDS)
                        {
                            MessageBox.Show("La desviacion estandar debe ser positiva, y ambos valores ingresados debe ser numeros", "advertencia");
                            txtMedia.Focus();
                            return;
                        }
                        else
                        {
                            GenerarNormal();
                        }
                        break;
                    case Distribucion.ExponencialNegativa:
                        double l;
                        bool checkL = double.TryParse(txtLambdaExp.Text, out l);
                        if (l <= 0|| !checkL)
                        {
                            MessageBox.Show("El valor de lambda debe ser positivo y un numero", "advertencia");
                            txtLambdaExp.Focus();
                            return;
                        }
                        else
                        {
                            GenerarExponencialNegativa();
                        }
                        break;
                    case Distribucion.Poisson:
                        double lp;
                        bool checkLP = double.TryParse(txtLambdaPoisson.Text, out lp);
                        if (lp<= 0||!checkLP)
                        {
                            MessageBox.Show("El valor de lambda debe ser positivo y un numero", "advertencia");
                            txtLambdaPoisson.Focus();
                            return;
                        }
                        else
                        {
                            GenerarPoisson();
                        }
                        break;
                    default:
                        break;
                }
            }
            else
            {
                MessageBox.Show("Ingrese una cantidad valida de valores a generar", "Advertencia");
                return;
            }
        }

        private void GenerarUniforme()
        {
            float a;
            float b;
            int cantidad;
            
            if (string.IsNullOrEmpty(txtUniformeA.Text) || !float.TryParse(txtUniformeA.Text, out a))
            {
                MessageBox.Show("Debe cargar un valor valido para A para poder generar los valores de las variables", "Advertencia");
                return;
            }
            if (string.IsNullOrEmpty(txtUniformeB.Text) || !float.TryParse(txtUniformeB.Text, out b))
            {
                MessageBox.Show("Debe cargar un valor valido para B para poder generar los valores de las variables", "Advertencia");
                return;
            }
            if (string.IsNullOrEmpty(txtCantValores.Text) || !int.TryParse(txtCantValores.Text, out cantidad))
            {
                MessageBox.Show("Debe cargar un valor valido para la cantidad para poder generar los valores de las variables", "Advertencia");
                return;
            }

            Valores = Generador.Uniforme(a, b, cantidad);
            lstValores.DataSource = Valores;
            lblIntervalos.Text = "";
        }

        private void GenerarNormal()
        {
            float media;
            float desviacion;
            int cantidad;

            if (string.IsNullOrEmpty(txtMedia.Text) || !float.TryParse(txtMedia.Text, out media))
            {
                MessageBox.Show("Debe cargar un valor valido para la media para poder generar los valores de las variables", "Advertencia");
                return;
            }
            if (string.IsNullOrEmpty(txtDesvEstandar.Text) || !float.TryParse(txtDesvEstandar.Text, out desviacion))
            {
                MessageBox.Show("Debe cargar un valor valido para la desviacion estandar para poder generar los valores de las variables", "Advertencia");
                return;
            }
            if (string.IsNullOrEmpty(txtCantValores.Text) || !int.TryParse(txtCantValores.Text, out cantidad))
            {
                MessageBox.Show("Debe cargar un valor valido para la cantidad para poder generar los valores de las variables", "Advertencia");
                return;
            }

            Valores = Generador.Normal(media, desviacion, cantidad);
            lstValores.DataSource = Valores;
            lblIntervalos.Text = "";
        }

        private void GenerarExponencialNegativa()
        {
            float lambda;
            int cantidad;

            if (string.IsNullOrEmpty(txtLambdaExp.Text) || !float.TryParse(txtLambdaExp.Text, out lambda))
            {
                MessageBox.Show("Debe cargar un valor valido para 'lambda' para poder generar los valores de las variables", "Advertencia");
                return;
            }
            if (string.IsNullOrEmpty(txtCantValores.Text) || !int.TryParse(txtCantValores.Text, out cantidad))
            {
                MessageBox.Show("Debe cargar un valor valido para la cantidad para poder generar los valores de las variables", "Advertencia");
                return;
            }

            Valores = Generador.ExponencialNegativa(lambda, cantidad);
            lstValores.DataSource = Valores;
            lblIntervalos.Text = "";
        }

        private void GenerarPoisson()
        {
            float lambda;
            int cantidad;
            if (string.IsNullOrEmpty(txtLambdaPoisson.Text) || !float.TryParse(txtLambdaPoisson.Text, out lambda))
            {
                MessageBox.Show("Debe cargar un valor valido para 'lambda' para poder generar los valores de las variables", "Advertencia");
                return;
            }
            if (string.IsNullOrEmpty(txtCantValores.Text) || !int.TryParse(txtCantValores.Text, out cantidad))
            {
                MessageBox.Show("Debe cargar un valor valido para la cantidad para poder generar los valores de las variables", "Advertencia");
                return;
            }
            Valores = Generador.Poisson(lambda, cantidad);
            lstValores.DataSource = Valores;
            lblIntervalos.Text = Valores.Max().ToString();

        }

        private void BtnLimpiar_Click(object sender, EventArgs e)
        {
            lstValores.DataSource = null;
        }

        private void BtnExcel_Click(object sender, EventArgs e)
        {
            if (lstValores.DataSource == null)
            {
                MessageBox.Show("No hay valores para exportar", "Advertencia");
                return;
            }

            GenerarGrafico grafico = new GenerarGrafico(Valores);
            grafico.Show();
        }

        private void BtnBondad_Click(object sender, EventArgs e)
        {
            PruebaBondad bondad = null;
            if (lstValores.DataSource == null)
            {
                MessageBox.Show("No hay valores para generar la pruba de bondad", "Advertencia");
                return;
            }
            string d;
            var lista = new List<double>();
            foreach (var elemento in lstValores.Items)
            {
                var ele = double.Parse(elemento.ToString());
                lista.Add(ele);
            }

            switch (dist)
            {
                case Distribucion.Uniforme:
                    d= "Uniforme";
                    bondad = new PruebaBondad(d, lista);
                    break;
                case Distribucion.Normal:
                    d = "Normal";
                    bondad = new PruebaBondad(d, lista);
                    break;
                case Distribucion.ExponencialNegativa:
                    d = "ExponencialNegativa";
                    bondad = new PruebaBondad(d, lista, double.Parse(txtLambdaExp.Text));
                    break;
                case Distribucion.Poisson:
                    d = "Poisson";
                    bondad = new PruebaBondad(d, lista, double.Parse(txtLambdaPoisson.Text));
                    break;
                default:
                    break;
            }
            if (bondad != null)
            {
                bondad.ShowDialog();
            }
            
        }
    }
}
