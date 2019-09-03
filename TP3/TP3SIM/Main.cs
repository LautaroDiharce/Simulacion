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
        {
            lstValores.DataSource = null;
            switch (dist)
            {
                case Distribucion.Uniforme:
                    GenerarUniforme();
                    break;
                case Distribucion.Normal:
                    GenerarNormal();
                    break;
                case Distribucion.ExponencialNegativa:
                    GenerarExponencialNegativa();
                    break;
                case Distribucion.Poisson:
                    break;
                default:
                    break;
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
        }

        private void GenerarPoisson()
        {

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
    }
}
