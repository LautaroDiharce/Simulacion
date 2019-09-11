using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MathNet.Numerics.Statistics;


namespace TP3SIM
{
    public partial class PruebaBondad : Form
    {
        List<double> Valores;
        double _lambda;
        double alpha = 0.95;
        public PruebaBondad(string dist, List<double> lista)
        {
            InitializeComponent();
            lblDist.Text = dist;
            Valores = lista;
        }
        public PruebaBondad(string dist, List<double> lista, double lambda)
        {
            InitializeComponent();
            lblDist.Text = dist;
            Valores = lista;
            _lambda = lambda;
        }
        public List<int> Seccionar()
        { 
            var intervalos = int.Parse(txtInter.Text);
            var lista = new List<int>();
            var valorMinimo = Valores.Min();
            var valorMaximo = Valores.Max();
            var paso = (valorMaximo - valorMinimo) / intervalos;

            for (double i = valorMinimo; i <valorMaximo; i += paso)
            {
                var valoresEnRango = Valores.Where(x => x >= i && x < (i + paso)).ToList();
                lista.Add(valoresEnRango.Count());
            }
            return lista;
        }
        public List<int> SeccionarPoi()
        {
            var intervalos = int.Parse(txtInter.Text);
            var lista = new List<int>();
            var valorMinimo =Convert.ToInt32( Valores.Min());
            var valorMaximo = Convert.ToInt32(Valores.Max());
            var paso = Convert.ToInt32((valorMaximo - valorMinimo) / intervalos);

            for (int i = 0; i <= valorMaximo; i += paso)
            {
                var valoresEnRango = Valores.Where(x => x >= i && x < (i + paso)).ToList();
                lista.Add(valoresEnRango.Count());
            }
            return lista;
        }

        private void GenerarUni()
        {
            var observados = Seccionar();
            var frecAbs = new List<int>();
            var intervalos = int.Parse(txtInter.Text);
            int esperado =(Valores.Count() / intervalos);
            frecAbs.Add(esperado);
            for (int i = 1; i < intervalos; i++)
            {
                frecAbs.Add(esperado);
            }
            double acumulador = 0;
            for (int i = 0; i < intervalos-1; i++)
            {
                acumulador = acumulador + Math.Pow((observados[i] - frecAbs[i]),2)/ frecAbs[i];
            }
            txtAcum.Text = acumulador.ToString();
            var gl = intervalos-1-2;
            var chi = MathNet.Numerics.Distributions.ChiSquared.InvCDF(gl,alpha);
            txtTabulado.Text = chi.ToString();       
        }
        private void GenerarNorm()
        {
            var observados = Seccionar();
            double acumulador = 0;
            var frecAbs = new List<double>();
            var intervalos = int.Parse(txtInter.Text);
            var min = Valores.Min();
            var max = Valores.Max();
            var paso = (max - min) / intervalos;
            var mean = ArrayStatistics.Mean(Valores.ToArray());
            var desEst=ArrayStatistics.StandardDeviation(Valores.ToArray());
            for (double i =min; i <= max; i+=paso)
            {
                var sup = MathNet.Numerics.Distributions.Normal.CDF(mean, desEst, i + paso);
                var inf= MathNet.Numerics.Distributions.Normal.CDF(mean, desEst, i);
                double esperado = Valores.Count()*(sup -inf);
                frecAbs.Add(esperado);
            }
            for (int i = 0; i < intervalos-1; i++)
            {
                acumulador = acumulador + Math.Pow(observados[i] - frecAbs[i], 2) / frecAbs[i];
            }
            txtAcum.Text = acumulador.ToString();
            var gl = intervalos - 1 - 2;
            var chi = MathNet.Numerics.Distributions.ChiSquared.InvCDF(gl, alpha);
            txtTabulado.Text = chi.ToString();
        }
        private void GenerarEN()
        {
            var observados = Seccionar();

            double acumulador = 0;
            var frecAbs = new List<double>();
            var intervalos = int.Parse(txtInter.Text);
            var min = Valores.Min();
            var max = Valores.Max();
            var paso = (max - min) / intervalos;
            var lambda =_lambda;
            for (double i = min; i <= max; i += paso)
            {
                double esperado = (MathNet.Numerics.Distributions.Exponential.CDF(lambda, i + paso) - MathNet.Numerics.Distributions.Exponential.CDF(lambda, i))*Valores.Count();
                frecAbs.Add(esperado);
            }
            for (int i = 0; i < intervalos; i++)
            {
                acumulador = acumulador + Math.Pow((observados[i] - frecAbs[i]), 2) / frecAbs[i];
            }
            txtAcum.Text = acumulador.ToString();
            var gl = intervalos - 1 - 1;
            var chi = MathNet.Numerics.Distributions.ChiSquared.InvCDF(gl, alpha);
            txtTabulado.Text = chi.ToString();
        }
        private void GenerarPoi()
        {
            var observados = SeccionarPoi();
            double acumulador = 0;
            var frecEsp = new List<double>();
            var intervalos = int.Parse(txtInter.Text);
            var lambda = _lambda;
            for (int i = 0; i < intervalos; i++)
            {
                var mass = MathNet.Numerics.Distributions.Poisson.PMF(lambda, i);
                double esperado = Valores.Count() * mass;

                frecEsp.Add(esperado);
            }
            for (int i = 0; i < intervalos; i++)
            {
                var resta = observados[i] - frecEsp[i];
                acumulador = acumulador + Math.Pow(resta, 2) / frecEsp[i];
            }
            txtAcum.Text = acumulador.ToString();
            var gl = intervalos - 1 - 1;
            var chi = MathNet.Numerics.Distributions.ChiSquared.InvCDF(gl, alpha);
            txtTabulado.Text = chi.ToString();
        }
        private void CalcularResultado()
        {
            if (double.Parse(txtAcum.Text)< double.Parse(txtTabulado.Text))
            {
                lblResult.Text = "Aprobado";
                lblResult.ForeColor = Color.Green;
            }
            else
            {
                lblResult.Text = "Reprobado";
                lblResult.ForeColor = Color.Red;
            }
        }
        private void BtnProbar_Click(object sender, EventArgs e)
        {
            if (txtInter.Text =="")
            {
                MessageBox.Show("Por Favor ingrese un numero de intervalos");
                txtInter.Focus();
                return;
            }
            else
            {
                var distribucion = lblDist.Text;
                switch (distribucion)
                {
                    case "Uniforme":
                        GenerarUni();
                        CalcularResultado();
                        break;
                    case "Normal":
                        GenerarNorm();
                        CalcularResultado();
                        break;
                    case "ExponencialNegativa":
                        GenerarEN();
                        CalcularResultado();
                        break;
                    case "Poisson":
                        GenerarPoi();
                        CalcularResultado();
                        break;
                    default:
                        break;
                }
            }

        }
    }
}
