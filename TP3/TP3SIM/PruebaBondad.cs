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
        
        public PruebaBondad(string dist, List<double> lista)
        {
            InitializeComponent();
            lblDist.Text = dist;
            Valores = lista;
        }
        public List<int> Seccionar()
        { 
            var intervalos = int.Parse(txtInter.Text);
            var array = new List<int>();
            var valorMinimo = Valores.Min();
            var valorMaximo = Valores.Max();
            var paso = (valorMaximo - valorMinimo) / intervalos;

            for (double i = valorMinimo; i <=valorMaximo; i += paso)
            {
                var valoresEnRango = Valores.Where(x => x >= i && x < (i + paso)).ToList();
                array.Add(valoresEnRango.Count());
            }
            return array;
        }
        private double CalcularSD(List<int> lista, double mean)
        {
            double sd = 0;
            for (int i = 0; i < lista.Count(); i++)
            {
                sd = Math.Pow(lista[i] + mean, 2);
            }
            sd = Math.Sqrt(sd / lista.Count());
            return sd;
        }
        private double CalcularMedia(List<int> lista)
        {
            double media = 0;
            for (int i = 0; i <= lista.Count(); i++)
            {
                media = media+ lista[i];
            }
            var mean = double.Parse((media / lista.Count()).ToString());
            return mean;
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
            var alpha = 0.95;
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
            //var mean = CalcularMedia(observados);
            //var desEst = CalcularSD(observados,mean);
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
            var alpha = 0.95;
            var chi = MathNet.Numerics.Distributions.ChiSquared.InvCDF(gl, alpha);
            txtTabulado.Text = chi.ToString();
        }
        private void GenerarEN()
        {
            var observados = Seccionar();
            var array = Valores.ToArray();
            double acumulador = 0;
            var frecAbs = new List<double>();
            var intervalos = int.Parse(txtInter.Text);
            var min = Valores.Min();
            var max = Valores.Max();
            var paso = (max - min) / intervalos;
            var lambda = 1/ArrayStatistics.Mean(array);
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
            var alpha = 0.95;
            var chi = MathNet.Numerics.Distributions.ChiSquared.InvCDF(gl, alpha);
            txtTabulado.Text = chi.ToString();
        }
        private void GenerarPoi()
        {
            var observados = Seccionar();
            var array = Valores.ToArray();
            double acumulador = 0;
            var frecAbs = new List<double>();
            var intervalos = int.Parse(txtInter.Text);
            var min = Valores.Min();
            var max = Valores.Max();
            var paso = (max - min) / intervalos;
            var lambda = ArrayStatistics.Mean(array);
            for (double i = min; i <= max; i += paso)
            {
                double esperado = Valores.Count()*(MathNet.Numerics.Distributions.Poisson.CDF(lambda, i + paso) - MathNet.Numerics.Distributions.Exponential.CDF(lambda, i));
                frecAbs.Add(esperado);
            }
            for (int i = 0; i < intervalos; i++)
            {
                acumulador = acumulador + Math.Pow((observados[i] - frecAbs[i]), 2) / frecAbs[i];
            }
            txtAcum.Text = acumulador.ToString();
            var gl = intervalos - 1 - 1;
            var alpha = 0.95;
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
